// Assets/Editor/CollectGenericMethods.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class CollectGenericMethods
{
    [MenuItem("HybridCLR/收集泛型方法")]
    public static void Collect()
    {
        // 扫描热更程序集
        string hotfixDllPath = "Assets/HotfixDlls/MyHotfix.dll"; // 你的热更dll路径

        if (!File.Exists(hotfixDllPath))
        {
            Debug.LogError($"热更dll不存在: {hotfixDllPath}");
            return;
        }

        // 加载热更程序集
        byte[] dllBytes = File.ReadAllBytes(hotfixDllPath);
        Assembly hotfixAssembly = Assembly.Load(dllBytes);

        List<string> genericMethodSignatures = new List<string>();

        // 扫描所有类型中的泛型方法
        foreach (Type type in hotfixAssembly.GetTypes())
        {
            // 扫描方法
            foreach (MethodInfo method in type.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.DeclaredOnly))
            {
                if (method.ContainsGenericParameters)
                {
                    // 记录泛型方法签名
                    genericMethodSignatures.Add(method.ToString());
                }
            }

            // 扫描字段类型中的泛型
            foreach (FieldInfo field in type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static))
            {
                if (field.FieldType.IsGenericType)
                {
                    string genericType = field.FieldType.FullName;
                    if (!genericMethodSignatures.Contains(genericType))
                    {
                        genericMethodSignatures.Add(genericType);
                    }
                }
            }
        }

        // 生成 AOT 泛型引用文件
        GenerateAOTGenericReference(genericMethodSignatures);

        Debug.Log($"收集到 {genericMethodSignatures.Count} 个泛型方法/类型");
    }

    private static void GenerateAOTGenericReference(List<string> signatures)
    {
        string template = @"
// Auto-generated AOT generic references
// This file is generated automatically, do not modify manually

using System;
using System.Collections.Generic;
using UnityEngine;

public class AOTGenericReferences
{
    // Reference method to force AOT compilation
    private static void __ReferenceMethods()
    {
        // Generated generic references:";

        foreach (string sig in signatures)
        {
            template += $"\n        // {sig}";
        }

        template += @"
        
        // You can manually add additional generic references here if needed
        // Example: List<int> list = new List<int>();
    }
}";

        string outputPath = "Assets/Scripts/AOTGenerics/AOTGenericReferences.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        File.WriteAllText(outputPath, template);
        AssetDatabase.Refresh();

        Debug.Log($"AOT泛型引用文件已生成: {outputPath}");
    }
}