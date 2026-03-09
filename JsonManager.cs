using System.Text.Json;

namespace Overwatch_Map_Statistics_v3
{
    internal static class JsonManager
    {
        private static readonly JsonSerializerOptions options = new() 
        { 
            IncludeFields = true,
            //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
         
        public static string SerializeObject(object? value)
        {
            //return JsonConvert.SerializeObject(value);
            return JsonSerializer.Serialize(value, options);
        }

        public static T? DeserializeObject<T>(string value)
        {
            //return JsonConvert.DeserializeObject<T>(value);
            if (string.IsNullOrEmpty(value)) return default;
            return JsonSerializer.Deserialize<T>(value, options);
        }
    }
}
