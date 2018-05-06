using Newtonsoft.Json;

namespace JobsParser
{
    public static class ObjectExtensions
    {
        public static T ConvertJsonToClass<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
