using Newtonsoft.Json;
using SQLiteNetExtensions.Extensions.TextBlob;
using System;

namespace SKYNET.DB.Helpers
{
    public class TextBlobSerializer : ITextBlobSerializer
    {
        public object Deserialize(string text, Type type)
        {
            return JsonConvert.DeserializeObject(text, type);
        }

        public string Serialize(object element)
        {
            return JsonConvert.SerializeObject(element);
        }
    }
}
