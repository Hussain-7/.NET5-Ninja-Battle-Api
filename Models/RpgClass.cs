using System.Text.Json.Serialization;

namespace Dotnet_Rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Ninja,
        Knight,
        Mage,
        Cleric
    }
}