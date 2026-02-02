using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using JFramework;
using System;
using LitJson;
using System.Text;
using Newtonsoft.Json;

namespace JFramework.Extern
{
    public class LitJsonSerializer : IDataConverter
    {
        public string Serialize(object obj)
        {
            return JsonMapper.ToJson(obj);
        }


        public T ToObject<T>(string str)
        {
            return JsonMapper.ToObject<T>(str);
        }

        public object ToObject(string json, Type type)
        {
            return JsonMapper.ToObject(json, type);
        }

        public object ToObject(byte[] bytes, Type type)
        {
            var json = Encoding.UTF8.GetString(bytes);
            return JsonMapper.ToObject(json, type);
        }

        public T ToObject<T>(byte[] bytes)
        {
            return default(T);
        }
    }
}

