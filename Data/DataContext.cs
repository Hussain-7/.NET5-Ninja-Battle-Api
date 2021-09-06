using Dotnet_Rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Rpg.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        //Whenever we need to a table to our db we will create a property like this
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Skill>().HasData(
        new Skill{ Id=1, Name="Multi-Shadow-Clone Jutsu",Damage =9000 },
        new Skill{ Id=2, Name="Chidori",Damage = 10000 },
        new Skill{ Id=3, Name="Tsukuyomi",Damage = 8000 },
        new Skill{ Id=4, Name="Hirudora",Damage = 5000 },
        new Skill{ Id=5, Name="Flying Thunder God",Damage =8000 },
        new Skill{ Id=6, Name="Byakugou No Jutsu",Damage = 6000 },
        new Skill{ Id=7, Name="Rasengan",Damage = 4000 },
        new Skill{ Id=8, Name="Raikiri",Damage = 7000 },
        new Skill{ Id=9, Name="Chakra Enhanced Strength",Damage = 3000 },
        new Skill{ Id=10, Name="Shadow Imitation Jutsu",Damage = 2500 }
			);
		}
	}
}