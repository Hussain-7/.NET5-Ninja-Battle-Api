using System.Text.Json.Serialization;

namespace Dotnet_Rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Hokage,
        Kazekage ,
        Mizukage,
        Raikage ,
        Tsuchikage ,
        SpecialJonin,
        LegendarySanin,
        Jonin ,
        Chunin,
        Genin,
        ANBU,
        MedicalNinja,
        RogueNinja,
        Otsuki,
    }
}