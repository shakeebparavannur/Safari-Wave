using System.Text.Json.Serialization;

namespace Safari_Wave.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeOfPackage
    {
        Cultural,
        Adventures,
        WildLife,
        Beach,
        Educational,
        Historical,
        Religious,
        HoneyMoon,
        Luxury,
        Natural,
        Greenery,
    }
}
