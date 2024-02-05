using Legend_of_Boog.Models.Characters;
using Legend_of_Boog.Models.Items;

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
                    AbilityService.CreateBeastBladeClass(),
                    AbilityService.CreatePrismancerRougeClass(),
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

        public static Weapon PickWeapon(Player player, PlayerClass playerClass)
        {
            Console.WriteLine($"\n\n(1) an {playerClass.Weapons[0].Name}?, or would you prefer an (2) {playerClass.Weapons[1].Name}? \ndon't overthink it..... they both perform the same...");
            Console.Write(":");
            var weaponChoice = Console.ReadLine() ?? "";

            while (weaponChoice != "1" && weaponChoice != "2")
            {
                Console.Write($"\nOld Dude: *sigh* Please just choose 1 or 2. It is not that difficult, {player.Name}...\n:");
                weaponChoice = Console.ReadLine() ?? "";
            }
            
            return playerClass.Weapons[int.Parse(weaponChoice) - 1];
        }

        public static string NameWeapon()
        {
            string weaponName;
            var isValid = true;

            do {
                UIService.Header();

                Console.WriteLine(isValid
                    ? "Old Dude: Marvelous choice! Now... What shall you name your mighty weapon?"
                    : "\nOld Dude: That Name is horrible...Maybe try something that is NOT a number, or obnoxiously long... do better");

                Console.Write("Enter Weapon Name:");
                weaponName = Console.ReadLine()?.Trim() ?? "";

                isValid = InputService.ValidateInput(weaponName, maxLength: 15, intCheck: true);
            } while (!isValid);

            return weaponName;
        }

        public static string GetPlayerName()
        {
            var isValid = true;
            string name;
            
            do
            {
                StoryService.DisplayStoryStart();

                if (!isValid)
                {
                    Console.WriteLine("Old Dude: Hmm... That name is..... kinda trash...\nMaybe try something that is NOT a number, or obnoxiously long... do better");
                }

                Console.Write("Enter Name:");
                name = Console.ReadLine()?.Trim() ?? "";

                isValid = InputService.ValidateInput(name, maxLength: 25, intCheck: true);
            } while (!isValid);

            return name;
        }

        public static string Attack(Player player, Enemy enemy, int mana = 0)
        {
            var random = new Random();
            var roll = random.Next(1, 100);
            player.Mana -= mana;
            
            if (roll <= player.Weapon.CritRate)
            {
                enemy.Health -= player.Weapon.Damage * 2;
                return $"- You dealt {player.Weapon.Damage * 2} damage to {enemy.Name}!  *CRITICAL HIT*\n";
            }
            
            enemy.Health -= player.Weapon.Damage;
            return $"- You dealt {player.Weapon.Damage} damage to {enemy.Name}!\n";
        }

        public static string EnemyAttack(Player player, Enemy enemy)
        {
            var random = new Random();
            var enemyMissRoll = random.Next(1, 100);
            
            if (enemyMissRoll >= enemy.Accuracy)
            {
                return $"- The {enemy.Name} attacked, but missed!\n";
            }
            
            var enemyRoll = random.Next(1, 100);
            if (enemyRoll <= enemy.CritRate)
            {
                player.Health -= enemy.Damage * 2;
                return $"- {enemy.Name} strikes back and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
            }
            
            player.Health -= enemy.Damage;
            return $"- {enemy.Name} strikes back and hits you for {enemy.Damage} damage!\n";
        }
    }
}
