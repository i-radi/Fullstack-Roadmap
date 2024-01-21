using Newtonsoft.Json;

namespace Shopify_RavenDB.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T theObject)
        {
            string jsonData = JsonConvert.SerializeObject(theObject);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
