using System.Text.Json.Serialization;

namespace Safari_Wave.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Facilities
    {
        AC,
        Swimming_Pool,
        Trucking,
        Camp_Fire,
        Fitness_Center,
        SPA,
        WIFI,
        Entertainment,
        Childrens_Activity
    }
}
    