using Legend_of_Boog.Models.Characters;
using Legend_of_Boog.Models.Layout;
using Legend_of_Boog.Services;
using System.Net.Security;


var input = new InputService();
var player = new Player("");
var playerInput = string.Empty;
var enemy = new Enemy();
var playerClasses = GameService.GetPlayerClasses();
string combatDialog1 = "", combatDialog2 = "", combatDialog3 = "", playerAction = "";
ForestRoom currentRoom;
var playerClassNum = "";

// press E to start game
do
{
    UIService.ClearAll();
    UIService.TitleScreen();
    playerInput = Console.ReadLine() ?? "";
} while (!InputService.ValidateInput(playerInput, inputMatcher: "e"));

// Get Player Name
player.Name = GameService.GetPlayerName();

// transition dialog into class selection
StoryService.DisplayNameIntroduction(player.Name);

input.Continue();

// check for valid class selection
do
{
    UIService.SelectClass();
    playerClassNum = Console.ReadLine() ?? "";
} while (playerClassNum != "1" && playerClassNum != "2" && playerClassNum != "3");

player.Class = playerClasses.Find(playerClass => playerClass.Id == int.Parse(playerClassNum))!;

// Choose Weapon
StoryService.DisplayWeaponIntroduction(player);

player.Weapon = GameService.PickWeapon(player, player.Class);
player.Weapon.Name = GameService.NameWeapon();

// Confirm Character
UIService.Header();
UIService.PlayerRecap(player);
input.Continue();

// Dialog transition into Forest Dungeon
UIService.Header();
StoryService.DisplayForestDungeon(player);
input.Continue();

// Forest Dungeon Enemies
var random = new Random();

//Forest Dungeon ROOMS
var room1 = new ForestRoom()
{
    RoomId = 1,
    EntryDialog = " you entered Room 1",
    EnemyClearDialog = " you killed baddies",
    HasEvent = false,
    NumOfEnemies = 3,
    FullNumofEnemies = 3,
    HasKey = true
};

var room2 = new ForestRoom()
{
    RoomId = 2,
    EntryDialog = " you entered Room 2 ",
    EnemyClearDialog = " you killed baddies",
    HasEvent = false,
    NumOfEnemies = 4,
    FullNumofEnemies = 4,
    HasKey = false
};

// non combat action
var playerAction2 = "";

// combat dialog clear
void CombatDialogClear()
{
    combatDialog1 = "";
    combatDialog2 = "";
    combatDialog3 = "";
}

// INVENTORY SCREEN
var navInput = "";

enemy = GameService.PickForestEnemy();

/////////////////////////////  START OF GAME  ///////////////////////////////////////

currentRoom = room1;

void LegendOfBoog()
{
    while (player.Health > 0)
    {
        UIService.ClearAll();
        UIService.ForestDungeonUI(currentRoom, player, enemy, combatDialog1, combatDialog2, combatDialog3);
        playerAction = Console.ReadLine()?.ToLower() ?? "";

        player.Weapon.Damage = random.Next(player.Weapon.BaseDamage, player.Weapon.MaxDamage);
        enemy.Damage = random.Next(10, 20);

        // Basic Attack
        if (playerAction == "b")
        {
            combatDialog1 = GameService.Attack(player, enemy);
            combatDialog2 = GameService.EnemyAttack(player, enemy);
            
            player.Mana += player.ManaRegenRate;
            combatDialog3 = $"- You Regained {player.ManaRegenRate} Mana.";
            playerAction = string.Empty;
        }

        // Strong Attack
        if (playerAction == "s" & player.Mana >= 10)
        {
            combatDialog1 = GameService.Attack(player, enemy, 10);
            combatDialog2 = GameService.EnemyAttack(player, enemy);
            
            combatDialog3 = "- You used 10 Mana.";
            playerAction = string.Empty;
        }
        else if (playerAction == "s" & player.Mana < 10)
        {
            CombatDialogClear();
            combatDialog1 = "- You do not have enough Mana";
        }

        // Health Potion
        if (playerAction == "h" & player.HealthPotions > 0)
        {
            if (player.Health == player.FullHealth)
            {
                combatDialog1 = "- You already have full health.";
                combatDialog2 = "";
                combatDialog3 = "";
            }
            else
            {
                player.Health += player.HealthPotionValue;
                combatDialog1 = $"- You drank a Health Potion, you Gained {player.HealthPotionValue} Health!\n";

                var hitRoll = random.Next(1, 100);
                if (hitRoll <= 60)
                {
                    combatDialog2 = "";
                    combatDialog3 = "";
                    player.HealthPotions -= 1;
                    playerAction = "z";
                }
                else
                {
                    var enemyRoll = random.Next(1, 100);
                    if (enemyRoll <= enemy.CritRate)
                    {
                        combatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
                        player.Health -= enemy.Damage * 2;
                    }
                    else
                    {
                        combatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage} damage!\n";
                        player.Health -= enemy.Damage;
                    }

                    combatDialog3 = "";
                    player.HealthPotions -= 1;
                    playerAction = "z";
                }
            }
        }

        // health cap
        if (player.Health > player.FullHealth)
        {
            player.Health = player.FullHealth;
        }

        // health potion cap
        if (player.HealthPotions <= 0)
        {
            player.HealthPotions = 0;
        }
        // out of Health Potions
        if (playerAction == "h" & player.HealthPotions <= 0)
        {
            combatDialog1 = "- You are out of Health Potions";
            combatDialog2 = "";
            combatDialog3 = "";
        }

        // Mana Potion
        if (playerAction == "m" & player.ManaPotions > 0)
        {
            if (player.Mana == player.FullMana)
            {
                combatDialog1 = "- You already have full Mana.";
                combatDialog2 = "";
                combatDialog3 = "";
            }
            else
            {
                player.Mana += player.ManaPotionValue;
                combatDialog1 = $"- You drank a Mana Potion, you Gained {player.ManaPotionValue} Mana!\n";

                var hitRoll = random.Next(1, 100);
                if (hitRoll <= 60)
                {
                    combatDialog2 = "";
                    combatDialog3 = "";
                    player.ManaPotions -= 1;
                    playerAction = "z";
                }
                else
                {
                    var enemyRoll = random.Next(1, 100);
                    if (enemyRoll <= enemy.CritRate)
                    {
                        combatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
                        player.Mana -= enemy.Damage * 2;
                    }
                    else
                    {
                        combatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage} damage!\n";
                        player.Mana -= enemy.Damage;
                    }

                    combatDialog3 = "";
                    player.ManaPotions -= 1;
                    playerAction = "z";
                }
            }
        }

        // Mana Cap
        if (player.Mana > player.FullMana)
        {
            player.Mana = player.FullMana;
        }

        // out of Mana Potions
        if (playerAction == "m" & player.ManaPotions == 0)
        {
            combatDialog1 = "- You are out of Mana Potions";
            combatDialog2 = "";
            combatDialog3 = "";
        }

        // Mana potion cap
        if (player.ManaPotions <= 0)
        {
            player.ManaPotions = 0;
        }
        
        //mana out
        if (player.Mana <= 0)
        {
            player.Mana = 0;
        }

        // Enemy Death
        if (enemy.Health <= 0)
        {
            var xpGain = random.Next(40, 70);
            var goldGain = random.Next(10, 30);
            player.Xp += xpGain;
            player.Gold += goldGain;

            UIService.ClearAll();
            UIService.Header();
            UIService.CombatDialog(combatDialog1, combatDialog2, combatDialog3);
            Console.WriteLine($"\n\nThe {enemy.Name} was defeated!! \n\nYou got {xpGain} XP! \n\nYou also found {goldGain} Gold! \n");
            
            enemy.Health = enemy.FullHealth;
            currentRoom.NumOfEnemies--;
            enemy = GameService.PickForestEnemy();

            input.Continue();
            CombatDialogClear();
        }

        // stay alive if you both die
        if (enemy.Health <= 0 & player.Health <= 0)
        {
            player.Health = 1;
            UIService.Header();
            Console.WriteLine("\n~ That was a close call... You are ever so sligthly clinging to life");
        }

        var mapDialog = "";

        // NON COMBAT LOOP ////////////////
        while (currentRoom.NumOfEnemies == 0)
        {
            UIService.Header();
            UIService.ForestDungeonUiNonCombat(player, currentRoom);
            playerAction2 = Console.ReadLine()?.ToLower() ?? "";

            if (playerAction2 == "2")
            {
                currentRoom = room2;
                mapDialog = "You are in Room 2";
            }
            else if (playerAction2 == "1")
            {
                currentRoom = room1;
                mapDialog = "You are in Room 1";
            }
        }

        //Forest Dungeon  Map
        if (playerAction == "d")
        {
            UIService.DungeonMap(mapDialog);
            navInput = Console.ReadLine();
            navInput = navInput.ToLower();

            if (navInput == "b")
            {
                playerAction = "";
            }

        }

        // INVENTORY UI
        if (playerAction == "i")
        {
            UIService.InventoryMenu(player);

            navInput = Console.ReadLine().ToLower();

            if (navInput == "b")
            {
                playerAction = "";
            }
        }

        // LEVEL UP
        if (player.Xp >= player.XpNeeded)
        {
            player.Level += 1;

            UIService.Header();
            Console.WriteLine($"                                              LEVEL UP! You are now Level {player.Level}!\n\n\n");

            if (player.Level == 2 & playerClassNum == "1")
            {
                UIService.ClearAll();
                UIService.Header();
                Console.WriteLine("You unloacked a new ability! \n\nQueso Blast:");
                Console.WriteLine("\nYou cast boiling hot liquid cheese on your enemy! \nThis ability deals +20 to your normal damage and inflicts burn for 3 turns!");
                input.Continue();
            }
            if (player.Level == 5 & playerClassNum == "1")
            {
                UIService.ClearAll();
                UIService.Header();
                Console.WriteLine("You unloacked a new ability! \n\nNacho Melt:");
                Console.WriteLine("\nYou conjure a large slice of cheese that melts like a blanket over your enemy! \nThis ability makes your enemy unable to move for 2 turns!");
                input.Continue();
            }
            if (player.Level == 8 & playerClassNum == "1")
            {
                UIService.ClearAll();
                UIService.Header();
                Console.WriteLine("You unloacked a new ability! \n\nCheddar Bites:");
                Console.WriteLine("\nYou summon a swarm of tiny cheddar bite minions that swarm your enemy and bite them! \nThis ability hits for half your normal damage and can hit 5-10 times!");
                input.Continue();
            }
            if (player.Level == 11 & playerClassNum == "1")
            {
                UIService.ClearAll();
                UIService.Header();
                Console.WriteLine("You unloacked your ultimate ability! \n\nCheese Storm:");
                Console.WriteLine("\nYou summon a meteor storm of massive cheese wheels! \nThis ability hits for 4 times your normal damage!");
                input.Continue();
            }

            Console.WriteLine($"Do you want to upgrade Health or Mana? \nType (H) for health and (M) for Mana. (+10 points) ");
            Console.WriteLine("Type Here:");
            var upgradeInput = Console.ReadLine();
            upgradeInput = upgradeInput.ToLower();

            if (upgradeInput == "h")
            {
                UIService.ClearAll();
                UIService.Header();
                player.FullHealth += 10;

                Console.WriteLine(" - You gained 10 Health Points!");
                input.Continue();
            }
            if (upgradeInput == "m")
            {
                UIService.ClearAll();
                UIService.Header();
                player.FullMana += 10;

                Console.WriteLine(" - You gained 10 Mana Points!");
                input.Continue();
            }

            UIService.Header();

            Console.WriteLine($"Do you want to upgrade Weapon Damage? or Critical Rate? \nType (D) for Weapon Damage (+5 points to min and max Damage) and (C) for Critical Rate (+2 points) ");
            Console.WriteLine("Type Here:");
            var upgradeInput2 = Console.ReadLine().ToLower();

            if (upgradeInput2 == "d")
            {
                UIService.ClearAll();
                UIService.Header();
                player.Weapon.BaseDamage += 5;
                player.Weapon.MaxDamage += 5; ; ; ;
                Console.WriteLine($" - Your Weapon Damage Range is now {player.Weapon.BaseDamage} - {player.Weapon.MaxDamage}! ");
                input.Continue();
            }
            if (upgradeInput2 == "c")
            {
                UIService.ClearAll();
                UIService.Header();
                player.Weapon.CritRate += 2;
                Console.WriteLine($" - Your Crit Rate is now {player.Weapon.CritRate}%!");
                input.Continue();
            }

            player.Health = player.FullHealth;
            player.Mana = player.FullMana;
            player.Xp -= player.XpNeeded;
            player.XpNeeded += 50;

        }

        //Ability Text display
        var cwAbility1 = "Queso Blast [15 Mana]";

        if (playerClassNum == "1" & player.Level == 2)
        {
            //TODO: Rework later
            //ability1 = CwAbility1;
        }

        // character menue
        if (playerAction == "c")
        {
            UIService.Header();

            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Class: {player.Class}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Health: {player.FullHealth}");
            Console.WriteLine($"Mana: {player.FullMana}");
            Console.WriteLine($"Weapon Damage Range: {player.Weapon.BaseDamage} - {player.Weapon.MaxDamage}");
            Console.WriteLine($"Crit Rate: {player.Weapon.CritRate}%");
            Console.WriteLine($"Health Potion Value: {player.HealthPotionValue}");
            Console.WriteLine($"Mana Potion Value: {player.ManaPotionValue}");
            Console.WriteLine("============================================================================================================");
            Console.WriteLine("(B)ack");

            Console.WriteLine("Type Action:");
            navInput = Console.ReadLine().ToLower();

            if (navInput == "b")
            {
                playerAction = "z";
            }
        }

        var hPotionStock = 5;
        var mPotionStock = 5;
        var pocGobStock = 1;
        var manaOrbStock = 1;
        var storeLoop = 1;
        var storeDialog = "";

        if (playerAction == "v")
        {
            while (storeLoop == 1)
            {
                UIService.Header();
                Console.WriteLine($"                                                     Store                                     Gold:{player.Gold} \n\n\n");

                Console.WriteLine($"(1) Health Potion: 10 Gold");
                Console.WriteLine($"(2) Mana Potion: 10 Gold");
                Console.WriteLine($"(3) Health Potion Enhancer: 50 Gold [Gain 10 more points per potion] ({hPotionStock} in stock)");
                Console.WriteLine($"(4) Mana Potion Enhancer: 50 Gold [Gain 10 more points per potion] ({mPotionStock} in stock)");
                Console.WriteLine($"(5) Mana Restoration Orb: 100 Gold [Restores 10 Mana on actions that do not cost Mana] ({manaOrbStock} in stock)");
                Console.WriteLine($"(6) Pocket Goblin: 100 Gold \n[A tiny Goblin that will search your enemies after you defeat them to help you find even more gold from them] ({pocGobStock} in stock)\n");

                Console.WriteLine(storeDialog);

                Console.WriteLine("\nType the number of the item you want to purchase. Or type (B) to go back.\nType Here:");
                navInput = Console.ReadLine().ToLower();

                if (navInput == "b")
                {
                    playerAction = "z";
                    storeLoop = 0;
                }
                else if (navInput == "1" & player.Gold < 10)
                {
                    storeDialog = "Not Enough Gold...";
                }
                else if (navInput == "1" & player.Gold >= 10)
                {
                    player.Gold -= 10;
                    player.HealthPotions += 1;
                    storeDialog = "You Purchased a Health Potion for 10 Gold!";
                }

                if (navInput == "2" & player.Gold < 10)
                {
                    storeDialog = "Not Enough Gold...";
                }
                if (navInput == "2" & player.Gold >= 10)
                {
                    player.Gold -= 10;
                    player.ManaPotions += 1;
                    storeDialog = "You Purchased a Mana Potion for 10 Gold!";
                }

                //GOOD way to use nested if statements
                if (navInput == "3")
                {
                    if (hPotionStock > 0)
                    {
                        if (player.Gold < 50)
                        {
                            storeDialog = "Not Enough Gold...";
                        }
                        else
                        {
                            player.Gold -= 50;
                            hPotionStock -= 1;
                            storeDialog = "Your Health Potion Heals for +10 more!";
                            player.HealthPotionValue += 10;
                        }
                    }
                    else
                    {
                        storeDialog = "Out of Stock...";
                    }
                }

                if (navInput == "4" & player.Gold < 50 & mPotionStock > 0)
                {
                    storeDialog = "Not Enough Gold...";
                }
                if (navInput == "4" & mPotionStock <= 0)
                {
                    storeDialog = "Out of Stock...";
                }
                if (navInput == "4" & player.Gold >= 50 & mPotionStock > 0)
                {
                    player.Gold -= 50;
                    mPotionStock -= 1;
                    storeDialog = "Your Mana Potion Restores for +10 more Mana!";
                    player.HealthPotionValue += 10;
                }
            }
        }

        //ability menu
        if (playerAction == "a")
        {
            UIService.AbilitiesMenu(player);

            navInput = Console.ReadLine() ?? "";
            navInput = navInput.ToLower();
            if (navInput == "b")
            {
                playerAction = "z";
            }
        }
    }
}

LegendOfBoog();

UIService.Header();
Console.WriteLine("YOU DIED. GET REKT.");