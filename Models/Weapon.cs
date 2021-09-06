namespace Dotnet_Rpg.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }//this is entity Framework core convention it knows by default that controller name followed by id is foreign key of other table 
    }
}