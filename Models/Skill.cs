using System.Collections.Generic;

namespace Dotnet_Rpg.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Damage { get; set; } 
        public List<Character> Characters { get; set; }
    }
}