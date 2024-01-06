using Legend_of_Boog.Models.Characters;

namespace Legend_of_Boog.Services
{
    public static class GameService
    {
        public static List<PlayerClass> GetPlayerClasses()
        {
            var list = new List<PlayerClass>()
                {
                    new PlayerClass
                    {
                        Id = 1,
                        Name = "Cheese Whiz",
                        Description = "",
                        Weapons = new []
                        {
                            "Enchanted Cheddar Staff",
                            "Etheral Cheese Wand"
                        },
                        Abilities = new List<Ability>()
                    },
                    new PlayerClass
                    {
                        Id = 2,
                        Name = "Beast Blade",
                        Description = "",
                        Weapons = new []
                        {
                            "Mountainforge GreatSword",
                            "Dual Shredder Blades"
                        },
                        Abilities = new List<Ability>()
                    },
                    new PlayerClass
                    {
                        Id = 3,
                        Name = "Prismancer Rouge",
                        Description = "",
                        Weapons = new []
                        {
                            "DeathGem Daggers",
                            "Crystalized Shadow-Bow"
                        },
                        Abilities = new List<Ability>()
                    }
                };

            return list;
        }
    }
}
