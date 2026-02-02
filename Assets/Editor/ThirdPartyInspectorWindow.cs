using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Tiktok;
using JFramework;

public class ThirdPartyInspectorWindow : OdinEditorWindow
{
    [MenuItem("Tools/Third Party Inspector")]
    private static void OpenWindow()
    {
        var window = GetWindow<ThirdPartyInspectorWindow>();
        window.titleContent = new GUIContent("Third Party Inspector");

        window.Show();
    }

    // 目标对象（可拖入或代码赋值）
    [ShowInInspector, HideLabel, BoxGroup("Target")]
    public object Target { get; set; }

    // 显示所有字段（包括私有字段）
    [ShowInInspector, BoxGroup("Fields"), ListDrawerSettings(IsReadOnly = true, Expanded = true)]
    public List<FieldInfo> AllFields => GetAllFields();

    // 显示所有属性（包括私有属性）
    [ShowInInspector, BoxGroup("Properties"), ListDrawerSettings(IsReadOnly = true, Expanded = true)]
    public List<PropertyInfo> AllProperties => GetAllProperties();

    // 获取字段值（支持修改）
    [ShowInInspector, BoxGroup("Field Values")]
    public Dictionary<string, object> FieldValues
    {
        get => GetFieldValues();
        set => SetFieldValues(value);
    }

    // 获取所有字段（包括私有）
    private List<FieldInfo> GetAllFields()
    {
        if (Target == null) return new List<FieldInfo>();
        return Target.GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .ToList();
    }

    // 获取所有属性（包括私有）
    private List<PropertyInfo> GetAllProperties()
    {
        if (Target == null) return new List<PropertyInfo>();
        return Target.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .ToList();
    }

    // 获取字段值
    private Dictionary<string, object> GetFieldValues()
    {
        var dict = new Dictionary<string, object>();
        if (Target == null) return dict;

        foreach (var field in GetAllFields())
        {
            dict[field.Name] = field.GetValue(Target);
        }
        return dict;
    }

    // 修改字段值
    private void SetFieldValues(Dictionary<string, object> values)
    {
        if (Target == null) return;

        foreach (var field in GetAllFields())
        {
            if (values.TryGetValue(field.Name, out var newValue))
            {
                field.SetValue(Target, newValue);
            }
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        var container = GameObject.Find("Container").GetComponent<TiktokContainerMain>().Container;
        Target = container.Resolve<LevelsModel>();
    }
}