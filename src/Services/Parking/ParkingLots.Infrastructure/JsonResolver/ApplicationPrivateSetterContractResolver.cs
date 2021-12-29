using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ParkingLots.Infrastructure.JsonResolver
{
    public class ApplicationPrivateSetterContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            if (jsonProperty.Writable)
            {
                return jsonProperty;
            }

            if (member is PropertyInfo propertyInfo)
            {
                jsonProperty.Writable = propertyInfo.GetSetMethod(true) != null;
            }

            return jsonProperty;
        }
    }
}

