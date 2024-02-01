using Legend_of_Boog.Models.Characters;

namespace Legend_of_Boog.Services
{
    public static class GameService
    {

        private static List<Enemy> enemies = new List<Enemy>
        {
            new Enemy("Mush Slime", 75, 75, 10, 20, 1, 75, 10),
            new Enemy("Skelly Shroom", 100, 100, 10, 20, 1, 90, 30),
            new Enemy("Swamp Goblin", 120, 120, 10, 20, 1, 80, 20),
            new Enemy("Mossy Golem", 140, 140, 10, 20, 1, 80, 10),
            new Enemy("Lumin Bat", 40, 40, 5, 10, 1, 75, 10)
        };

        public static List<PlayerClass> GetPlayerClasses()
        {
            var list = new List<PlayerClass>()
                {
                    AbilityService.CreateCheezeWizClass(),
                    //TODO: Create Other Classes in Ability Service and then call the method in here

                    //new PlayerClass
                    //{
                    //    Id = 2,
                    //    Name = "Beast Blade",
                    //    Description = "",
                    //    Weapons = new []
                    //    {
                    //        "Mountainforge GreatSword",
                    //        "Dual Shredder Blades"
                    //    },
                    //    Abilities = new List<Ability>()
                    //},
                    //new PlayerClass
                    //{
                    //    Id = 3,
                    //    Name = "Prismancer Rouge",
                    //    Description = "",
                    //    Weapons = new []
                    //    {
                    //        "DeathGem Daggers",
                    //        "Crystalized Shadow-Bow"
                    //    },
                    //    Abilities = new List<Ability>()
                    //}
                };

            return list;
        }
        
        public static Enemy PickForestEnemy()
        {
            var random = new Random();
            var enemy = new Enemy();

            int enemyPicker = random.Next(enemies.Count - 1);
            enemy = enemies[enemyPicker];

            return enemy;
        }


    }
}
