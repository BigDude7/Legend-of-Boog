using Legend_of_Boog.Models.Characters;
using Legend_of_Boog.Models.Layout;
using Legend_of_Boog.Services;
using System.Net.Security;


var input = new InputService();
var player = new Player("");
var playerInput = string.Empty;
var enemy = new Enemy();
var isValid = true;
var playerClasses = GameService.GetPlayerClasses();

// press E to start game
do
{
    UIService.ClearAll();
    UIService.TitleScreen();
    playerInput = Console.ReadLine() ?? "";
} while (!input.ValidateInput(playerInput, inputMatcher: "e"));

// check for valid name
do
{
    StoryService.DisplayStoryStart();

    if (!isValid)
    {
        Console.WriteLine("Old Dude: Hmm... That name is..... kinda trash...\nMaybe try something that is NOT a number, or obnoxiously long... do better");
    }

    Console.Write("Enter Name:");
    playerInput = Console.ReadLine() ?? "";
    player.Name = playerInput.Trim();     

    isValid = input.ValidateInput(player.Name, maxLength: 25, intCheck: true);
} while (!isValid);

// transition dialog into class selection
StoryService.DisplayNameIntroduction(player.Name);

input.Continue();

var playerClassNum = "";

// check for valid class selection
do
{
    UIService.SelectClass();
    playerClassNum = Console.ReadLine() ?? "";
} while (playerClassNum != "1" && playerClassNum != "2" && playerClassNum != "3");

var playerClass = playerClasses.Find(playerClass =>
{
    return playerClass.Id == int.Parse(playerClassNum);
})!;

player.Class = playerClass.Name;

// Choose Weapon
StoryService.DisplayWeaponIntroduction(player);

string weaponChoice = "";

Console.WriteLine($"\n\n(1) an {playerClass.Weapons[0]}?, or would you prefer an (2) {playerClass.Weapons[1]}? \ndon't overthink it..... they both perform the same...");
Console.Write(":");
weaponChoice = Console.ReadLine();

while (weaponChoice != "1" && weaponChoice != "2")
{
    Console.Write($"\nOld Dude: *sigh* Please just choose 1 or 2. It is not that difficult, {player.Name}...\n:");
    weaponChoice = Console.ReadLine();
}

player.Weapon.Type = playerClass.Weapons[int.Parse(weaponChoice) - 1];

// Name your Weapon
UIService.Header();
Console.WriteLine("Old Dude: Marvelous choice! Now... What shall you name your mighty weapon?");
Console.Write("Enter Weapon Name:");
string weaponNameBad = Console.ReadLine() ?? "";
string weaponName = weaponNameBad.Trim();

while (input.ValidateInput(weaponName, maxLength: 15, intCheck: true) == false)
{
    UIService.Header();
    Console.WriteLine("\nOld Dude: That Name is horrible...Maybe try something that is NOT a number, or obnoxiously long... do better");
    Console.Write("Enter Weapon Name:");
    weaponNameBad = Console.ReadLine() ?? "";
    weaponName = weaponNameBad.Trim();
}

player.Weapon.Name = weaponName;

// Confirm Character
UIService.Header();
UIService.PlayerRecap(player);
input.Continue();

// Dialog transition into Forest Dungeon
UIService.Header();
StoryService.DisplayForestDungeon(player);
input.Continue();


// Forest Dungeon Enemies
Random random = new Random();


//Enemy MushSlime = new Enemy("Mush Slime", 75, 75, 10, 20, 1, 75, 10);
//Enemy SkellyShroom = new Enemy("Skelly Shroom", 100, 100, 10, 20, 1, 90, 30);
//Enemy SwampGoblin = new Enemy("Swamp Goblin", 120, 120, 10, 20, 1, 80, 20);
//Enemy MossyGolem = new Enemy("Mossy Golem", 140, 140, 10, 20, 1, 80, 10);
//Enemy LuminBat = new Enemy("Lumin Bat", 40, 40, 5, 10, 1, 75, 10);
//Enemy enemy = new Enemy("enemy", 1, 1, 1, 1, 1, 1, 1);


// FOREST DUNGEON 

// Values for UI
String CombatDialog1 = "";
String CombatDialog2 = "";
String CombatDialog3 = "";
String playerAction = "";

//Forest Dungeon ROOMS
ForestRoom currentRoom = new ForestRoom()
{
    RoomId = 0,
    HasEvent = false,
    NumOfEnemies = 0,
    HasKey = false
};

ForestRoom room1 = new ForestRoom()
{
    RoomId = 1,
    EntryDialog = " you entered ROOM 1",
    EnemyClearDialog = " you killed baddies",
    HasEvent = false,
    NumOfEnemies = 3,
    FullNumofEnemies = 3,
    HasKey = true
};

ForestRoom room2 = new ForestRoom()
{
    RoomId = 2,
    EntryDialog = " you entered room 2 ",
    EnemyClearDialog = " you killed baddies",
    HasEvent = false,
    NumOfEnemies = 4,
    FullNumofEnemies = 4,
    HasKey = false
};


// ability text
String ability1 = "?????";
String ability2 = "?????";
String ability3 = "?????";
String Uability = "?????";

// forest dungeon UI function

void ForestDungeonUI()
{
    Console.WriteLine("=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~  Forest Dungeon  ~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=");
    Console.WriteLine($"                                                    Room {currentRoom.RoomId}                                        ");
    Console.WriteLine("       [                                                                                           ]");
    Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>                                   <:::::::::::::::::::::::::::}xxxxx@");
    Console.WriteLine("       [                                                                                           ]\n");
    Console.WriteLine($"[{player.Name}] Level: {player.Level} {player.Class}                                                EXP: {player.Xp}/{player.XpNeeded}          Gold:{player.Gold}");
    Console.WriteLine($"Health: {player.Health}/{player.FullHealth}\nMana: {player.Mana}/{player.FullMana}   \n");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  Enemies  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine($"Enemies remaining: {currentRoom.NumOfEnemies} / {currentRoom.FullNumofEnemies} \n\n");
    Console.WriteLine($"  [{enemy.Name}] Health:{enemy.Health}\n\n"); ;


    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  Dialog  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

    UIService.CombatDialog(CombatDialog1, CombatDialog2, CombatDialog3);

    Console.WriteLine($"                                                                          Dungeon Keys: 0       Boss Key: 0  ");
    Console.WriteLine("===============================================  Action Bar  ===============================================");
    Console.WriteLine($"|  (B)asic Attack  [0 MP]                                           (1){ability1}                                    |");
    Console.WriteLine($"|  (S)trong Attack [10 MP]                                          (2){ability2}                                    |");
    Console.WriteLine($"|  (H)ealth Potion [{player.HealthPotions}]                                (3){ability3}                                    |");
    Console.WriteLine($"|  (M)ana Potion   [{player.ManaPotions}]                                  (4){Uability}                                    |");
    Console.WriteLine("============================================================================================================");
    Console.WriteLine("(I)nventory           (D)ungeon Map               (V)endor             (C)haracter               (A)bilities ");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
    Console.WriteLine("Type Action:");
    playerAction = Console.ReadLine();
    playerAction = playerAction.ToLower();

}

// non combat action
String PlayerAction2 = "";
void ForestDungonUiNonCombat()
{


    Console.WriteLine("=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~  Forest Dungeon  ~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=");
    Console.WriteLine($"                                                    Room {currentRoom.RoomId}                                        ");
    Console.WriteLine("       [                                                                                           ]");
    Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>                                   <:::::::::::::::::::::::::::}xxxxx@");
    Console.WriteLine("       [                                                                                           ]\n");
    Console.WriteLine($"[{player.Name}] Level:{player.Level} {player.Class}                                                EXP: {player.Xp}/{player.XpNeeded}");
    Console.WriteLine($"Health: {player.Health}\nMana: {player.Mana}                                                              Gold: {player.Gold}\n");


    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  Dialog  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

    Console.WriteLine("Type 2 to enter room 2");


    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
    Console.WriteLine("Type Action:");
    PlayerAction2 = Console.ReadLine();
    PlayerAction2 = PlayerAction2.ToLower();

}

// Dialog Delay


// combat dialog clear
void combatDialogClear()
{
    CombatDialog1 = "";
    CombatDialog2 = "";
    CombatDialog3 = "";
}

// Pick forest enemy method



// INVENTORY SCREEN
string navInput = "";

enemy = GameService.PickForestEnemy();

/////////////////////////////  START OF GAME  ///////////////////////////////////////

currentRoom = room1;

void LegendOfBoog()
{
    while (player.Health > 0)
    {
        UIService.ClearAll();

        ForestDungeonUI();

        player.Weapon.Damage = random.Next(player.Weapon.BaseDamage, player.Weapon.MaxDamage);
        enemy.Damage = random.Next(10, 20);

        // Basic Attack
        if (playerAction == "b")
        {
            int roll = random.Next(1, 100);
            if (roll <= player.Weapon.CritRate)
            {
                enemy.Health = enemy.Health - player.Weapon.Damage * 2;
                CombatDialog1 = $"- You dealt {player.Weapon.Damage * 2} damage to {enemy.Name}!  *CRITICAL HIT*\n";
            }
            else
            {
                enemy.Health = enemy.Health - player.Weapon.Damage;
                CombatDialog1 = $"- You dealt {player.Weapon.Damage} damage to {enemy.Name}!\n";
            }

            int enemyMissRoll = random.Next(1, 100);
            if (enemyMissRoll >= enemy.Accuracy)
            {
                CombatDialog2 = $"- The {enemy.Name} attacked, but missed!\n";
                player.Mana = player.Mana + player.ManaRegenRate;
                CombatDialog3 = $"- You Regained Mana {player.ManaRegenRate} Mana.";
                playerAction = "z";
            }
            else
            {
                int EnemyRoll = random.Next(1, 100);
                if (EnemyRoll <= enemy.CritRate)
                {
                    CombatDialog2 = $"- {enemy.Name} Strikes back and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
                    player.Health = player.Health - enemy.Damage * 2;
                }
                else
                {
                    CombatDialog2 = $"- {enemy.Name} Strikes back and hits you for {enemy.Damage} damage!\n";
                    player.Health = player.Health - enemy.Damage;
                }

                player.Mana = player.Mana + player.ManaRegenRate;
                CombatDialog3 = $"- You Regained Mana {player.ManaRegenRate} Mana.";
                playerAction = "z";
            }
        }

        // Strong Attack
        if (playerAction == "s" & player.Mana >= 10)
        {
            int roll = random.Next(1, 100);
            if (roll <= player.Weapon.CritRate)
            {
                enemy.Health = enemy.Health - player.Weapon.Damage * 4;
                CombatDialog1 = $"- You dealt a staggering {player.Weapon.Damage * 4} damage to {enemy.Name}!  *CRITICAL HIT*\n";
            }
            else
            {
                enemy.Health = enemy.Health - player.Weapon.Damage * 2;
                CombatDialog1 = $"- You dealt {player.Weapon.Damage * 2} damage to {enemy.Name}!\n";
            }
            int enemyMissRoll = random.Next(1, 100);
            if (enemyMissRoll >= enemy.Accuracy)
            {
                CombatDialog2 = $"- The {enemy.Name} attacked, but missed!\n";
                player.Mana = player.Mana - 10;
                CombatDialog3 = $"- You used 10 Mana.";
                playerAction = "z";
            }
            else
            {
                int EnemyRoll = random.Next(1, 100);
                if (EnemyRoll <= enemy.CritRate)
                {
                    CombatDialog2 = $"- {enemy.Name} Strikes back and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
                    player.Health = player.Health - enemy.Damage * 2;
                }
                else
                {
                    CombatDialog2 = $"- {enemy.Name} Strikes back and hits you for {enemy.Damage} damage!\n";
                    player.Health = player.Health - enemy.Damage;
                }

                player.Mana = player.Mana - 10;
                CombatDialog3 = $"- You used 10 Mana.";
                playerAction = "z";
            }
        }

        // out of mana for Strong Attack
        if (playerAction == "s" & player.Mana < 10)
        {
            CombatDialog1 = "- You do not have enough Mana";
            CombatDialog2 = "";
            CombatDialog3 = "";
        }

        // Health Potion
        if (playerAction == "h" & player.HealthPotions > 0)
        {
            if (player.Health == player.FullHealth)
            {
                CombatDialog1 = "- You already have full health.";
                CombatDialog2 = "";
                CombatDialog3 = "";
            }
            else
            {
                player.Health = player.Health + player.HealthPotionValue;
                CombatDialog1 = $"- You drank a Health Potion, you Gained {player.HealthPotionValue} Health!\n";

                int HitRoll = random.Next(1, 100);
                if (HitRoll <= 60)
                {
                    CombatDialog2 = "";
                    CombatDialog3 = "";
                    player.HealthPotions = player.HealthPotions - 1;
                    playerAction = "z";
                }
                else
                {
                    int EnemyRoll = random.Next(1, 100);
                    if (EnemyRoll <= enemy.CritRate)
                    {
                        CombatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
                        player.Health = player.Health - enemy.Damage * 2;
                    }
                    else
                    {
                        CombatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage} damage!\n";
                        player.Health = player.Health - enemy.Damage;
                    }

                    CombatDialog3 = "";
                    player.HealthPotions = player.HealthPotions - 1;
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
            CombatDialog1 = "- You are out of Health Potions";
            CombatDialog2 = "";
            CombatDialog3 = "";
        }

        // Mana Potion
        if (playerAction == "m" & player.ManaPotions > 0)
        {
            if (player.Mana == player.FullMana)
            {
                CombatDialog1 = "- You already have full Mana.";
                CombatDialog2 = "";
                CombatDialog3 = "";
            }
            else
            {
                player.Mana = player.Mana + player.ManaPotionValue;
                CombatDialog1 = $"- You drank a Mana Potion, you Gained {player.ManaPotionValue} Mana!\n";

                int HitRoll = random.Next(1, 100);
                if (HitRoll <= 60)
                {
                    CombatDialog2 = "";
                    CombatDialog3 = "";
                    player.ManaPotions = player.ManaPotions - 1;
                    playerAction = "z";
                }
                else
                {
                    int EnemyRoll = random.Next(1, 100);
                    if (EnemyRoll <= enemy.CritRate)
                    {
                        CombatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage * 2} damage! *CRITICAL HIT*\n";
                        player.Mana = player.Mana - enemy.Damage * 2;
                    }
                    else
                    {
                        CombatDialog2 = $"- The {enemy.Name} attacks you as you drink your potion and hits you for {enemy.Damage} damage!\n";
                        player.Mana = player.Mana - enemy.Damage;
                    }

                    CombatDialog3 = "";
                    player.ManaPotions = player.ManaPotions - 1;
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
            CombatDialog1 = "- You are out of Mana Potions";
            CombatDialog2 = "";
            CombatDialog3 = "";
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
            int XpGain = random.Next(40, 70);
            int GoldGain = random.Next(10, 30);
            player.Xp += XpGain;
            player.Gold += GoldGain;

            UIService.ClearAll();
            UIService.Header();
            UIService.CombatDialog(CombatDialog1, CombatDialog2, CombatDialog3);
            Console.WriteLine($"\n\nThe {enemy.Name} was defeated!! \n\nYou got {XpGain} XP! \n\nYou also found {GoldGain} Gold! \n");
            
            enemy.Health = enemy.FullHealth;
            currentRoom.NumOfEnemies--;
            enemy = GameService.PickForestEnemy();

            input.Continue();
            combatDialogClear();
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
            ForestDungonUiNonCombat();

            if (PlayerAction2 == "2")
            {
                currentRoom = room2;
                mapDialog = "You are in Room 2";
            }
            else if (PlayerAction2 == "1")
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
            player.Level = player.Level + 1;

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
            String UpgradeInput = Console.ReadLine();
            UpgradeInput = UpgradeInput.ToLower();

            if (UpgradeInput == "h")
            {
                UIService.ClearAll();
                UIService.Header();
                player.FullHealth = player.FullHealth + 10;

                Console.WriteLine(" - You gained 10 Health Points!");
                input.Continue();
            }
            if (UpgradeInput == "m")
            {
                UIService.ClearAll();
                UIService.Header();
                player.FullMana = player.FullMana + 10;

                Console.WriteLine(" - You gained 10 Mana Points!");
                input.Continue();
            }

            UIService.Header();

            Console.WriteLine($"Do you want to upgrade Weapon Damage? or Critical Rate? \nType (D) for Weapon Damage (+5 points to min and max Damage) and (C) for Critical Rate (+2 points) ");
            Console.WriteLine("Type Here:");
            string upgradeInput2 = Console.ReadLine().ToLower();

            if (upgradeInput2 == "d")
            {
                UIService.ClearAll();
                UIService.Header();
                player.Weapon.BaseDamage = player.Weapon.BaseDamage + 5;
                player.Weapon.MaxDamage = player.Weapon.MaxDamage + 5; ; ; ;
                Console.WriteLine($" - Your Weapon Damage Range is now {player.Weapon.BaseDamage} - {player.Weapon.MaxDamage}! ");
                input.Continue();
            }
            if (upgradeInput2 == "c")
            {
                UIService.ClearAll();
                UIService.Header();
                player.Weapon.CritRate = player.Weapon.CritRate + 2;
                Console.WriteLine($" - Your Crit Rate is now {player.Weapon.CritRate}%!");
                input.Continue();
            }

            player.Health = player.FullHealth;
            player.Mana = player.FullMana;
            player.Xp = player.Xp - player.XpNeeded;
            player.XpNeeded = player.XpNeeded + 50;

        }

        //Ability Text display
        String CwAbility1 = "Queso Blast [15 Mana]";

        if (playerClassNum == "1" & player.Level == 2)
        {
            ability1 = CwAbility1;
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

        int HPotionStock = 5;
        int MPotionStock = 5;
        int PocGobStock = 1;
        int ManaOrbStock = 1;
        int StoreLoop = 1;
        String StoreDialog = "";

        if (playerAction == "v")
        {
            while (StoreLoop == 1)
            {
                UIService.Header();
                Console.WriteLine($"                                                     Store                                     Gold:{player.Gold} \n\n\n");

                Console.WriteLine($"(1) Health Potion: 10 Gold");
                Console.WriteLine($"(2) Mana Potion: 10 Gold");
                Console.WriteLine($"(3) Health Potion Enhancer: 50 Gold [Gain 10 more points per potion] ({HPotionStock} in stock)");
                Console.WriteLine($"(4) Mana Potion Enhancer: 50 Gold [Gain 10 more points per potion] ({MPotionStock} in stock)");
                Console.WriteLine($"(5) Mana Restoration Orb: 100 Gold [Restores 10 Mana on actions that do not cost Mana] ({ManaOrbStock} in stock)");
                Console.WriteLine($"(6) Pocket Goblin: 100 Gold \n[A tiny Goblin that will search your enemies after you defeat them to help you find even more gold from them] ({PocGobStock} in stock)\n");

                Console.WriteLine(StoreDialog);

                Console.WriteLine("\nType the number of the item you want to purchase. Or type (B) to go back.\nType Here:");
                navInput = Console.ReadLine().ToLower();

                if (navInput == "b")
                {
                    playerAction = "z";
                    StoreLoop = 0;
                }

                if (navInput == "1" & player.Gold < 10)
                {
                    StoreDialog = "Not Enough Gold...";
                }
                if (navInput == "1" & player.Gold >= 10)
                {
                    player.Gold = player.Gold - 10;
                    player.HealthPotions = player.HealthPotions + 1;
                    StoreDialog = "You Purchased a Health Potion for 10 Gold!";
                }

                if (navInput == "2" & player.Gold < 10)
                {
                    StoreDialog = "Not Enough Gold...";
                }
                if (navInput == "2" & player.Gold >= 10)
                {
                    player.Gold = player.Gold - 10;
                    player.ManaPotions = player.ManaPotions + 1;
                    StoreDialog = "You Purchased a Mana Potion for 10 Gold!";
                }

                //GOOD way to use nested if statements
                if (navInput == "3")
                {
                    if (HPotionStock > 0)
                    {
                        if (player.Gold < 50)
                        {
                            StoreDialog = "Not Enough Gold...";
                        }
                        else
                        {
                            player.Gold = player.Gold - 50;
                            HPotionStock = HPotionStock - 1;
                            StoreDialog = "Your Health Potion Heals for +10 more!";
                            player.HealthPotionValue = player.HealthPotionValue + 10;
                        }
                    }
                    else
                    {
                        StoreDialog = "Out of Stock...";
                    }
                }

                if (navInput == "4" & player.Gold < 50 & MPotionStock > 0)
                {
                    StoreDialog = "Not Enough Gold...";
                }
                if (navInput == "4" & MPotionStock <= 0)
                {
                    StoreDialog = "Out of Stock...";
                }
                if (navInput == "4" & player.Gold >= 50 & MPotionStock > 0)
                {
                    player.Gold = player.Gold - 50;
                    MPotionStock = MPotionStock - 1;
                    StoreDialog = "Your Mana Potion Restores for +10 more Mana!";
                    player.HealthPotionValue = player.HealthPotionValue + 10;
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