using System;
using System.Text;
using Newtonsoft.Json;

namespace JFramework.Extern
{
    public class JsonNetSerializer : IDeserializer
    {
        public T ToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public T ToObject<T>(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public object ToObject(string str, Type type)
        {
            return JsonConvert.DeserializeObject(str, type);
        }

        public object ToObject(byte[] bytes, Type type)
        {
            var json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject(json, type);
        }
    }
}

