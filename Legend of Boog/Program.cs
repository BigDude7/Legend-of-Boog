
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Transactions;
using Players;
using Weapons;
using Dungeons;
using Enemies;



// function for displaying class selection
void SelectClass()
{

    Console.WriteLine("                          ~ Select Your Calss ~\n ");

    Console.WriteLine("(1)");
    Console.WriteLine("###########################################################################");
    Console.WriteLine("| Cheese Wiz: a mystical clan of enchanted cheese beings imbued with the  |");
    Console.WriteLine("| ancient essence of magic itself. These ethereal entities possess the    |");
    Console.WriteLine("| extraordinary power to infuse ordinary cheese with mystical energies,   |");
    Console.WriteLine("| granting them the authority to manipulate and command cheese in their   |");
    Console.WriteLine("| battles against adversaries.                                            |");
    Console.WriteLine("###########################################################################");

    Console.WriteLine("(2)");
    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
    Console.WriteLine("| Beast Blade: These warriors combine the primal instincts of a druid     |");
    Console.WriteLine("| with the combat expertise of a warrior. This unique class taps into the |");
    Console.WriteLine("| untamed power of the wilderness, allowing players to partially          |");
    Console.WriteLine("| transform into a beastly form during combat, enhancing their strength   |");
    Console.WriteLine("| and unleashing furious attacks with their blades.                       |");
    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

    Console.WriteLine("(3)");
    Console.WriteLine("***************************************************************************");
    Console.WriteLine("| Prismancer Rogue: A cunning and agile specialist, wielding the          |");
    Console.WriteLine("| arcane arts of light manipulation and crystallization. These dexterous  |");
    Console.WriteLine("| adventurers blend the finesse of a rogue with the mystical abilities    |");
    Console.WriteLine("| of a Prismancer, enabling them to transform into reflective mirrors and |");
    Console.WriteLine("| conjure bows and daggers made from enchanted gem shards.                |");
    Console.WriteLine("***************************************************************************");


}

// function for pressing E to continue
void Continue()
{
    String input = "";
    Console.Write("Type (E) to Continue\n");
    Console.Write(":");
    input = Console.ReadLine();
    while (validateInput(input, inputMatcher: "e") == false)
    {
        Console.Clear();
        Header();
        Console.Write("Type (E) to Continue\n");
        Console.Write(":");
        input = Console.ReadLine();
   
    }
    Console.Clear();
}

// function for checking for valid input
bool validateInput(string input, int minLength = 1, int maxLength = 999, string inputMatcher = "", string inputMatcher2 = "", string inputMatcher3 = "", bool intCheck = false)
{
    bool valid = true;

    if (input.Length > maxLength)
    {
        valid = false;
    }

    if (input.Length < minLength)
    {
        valid = false;
    }

    if (inputMatcher != "" && input.ToLower() != inputMatcher.ToLower())
    {
        valid = false;
    }

    if (inputMatcher2 != "" && input.ToLower() != inputMatcher2.ToLower())
    {
        valid = false;
    }

    if (inputMatcher3 != "" && input.ToLower() != inputMatcher3.ToLower())
    {
        valid = false;
    }

    if ( intCheck && int.TryParse(input, out int trash)) // ask derek
    {
        return false;
    }


    return valid;
}

//function for displaying Sword Icon
void swordIcon()
{

    Console.WriteLine("       [");
    Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>");
    Console.WriteLine("       [");


}

// function for displaying sword Icon with Header line
void Header()
{

    swordIcon();
    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
}

// Title Screen and start of game

Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
Console.WriteLine("       [                                                                                        ]");
Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>   || The Legend of Boog ||     <:::::::::::::::::::::::::::}xxxxx@");
Console.WriteLine("       [                                                                                        ]\n");
Console.WriteLine("                                       || Type (E) to Start  ||\n");
Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
Console.WriteLine("                                                                              Created By: Chandler Combs");
Console.Write(":");
String PlayerStart = Console.ReadLine();

while (validateInput(PlayerStart, inputMatcher: "e") == false)
{
    Console.Clear();
    Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
    Console.WriteLine("       [                                                                                        ]");
    Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>   || The Legend of Boog ||     <:::::::::::::::::::::::::::}xxxxx@");
    Console.WriteLine("       [                                                                                        ]\n");
    Console.WriteLine("                                       || Type (E) to Start  ||\n");
    Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
    Console.WriteLine("                                                                              Created By: Chandler Combs");
    Console.WriteLine("Type (E) to start");
    Console.Write(":");
    PlayerStart = Console.ReadLine();
   
       

}

Console.Clear();

// intro cutscene and ask for name
Header();
Console.WriteLine("In the ethereal realm of Boog, where emerald skies danced with hues of violet, and the air\nwhispered secrets of ancient magic. A land brimming with mystical wonders stood on the\nprecipice of annihilation. This enchanted realm, teeming with magnificent creatures and\nbreathtaking landscapes, now faces an imminent demise at the hands of the nefarious Chunky Dungus.\n\nA shadow has descended upon Boog, cast by the malevolent ambitions of Chunky Dungus,\na man consumed by darkness and a thirst for dominion. His ominous presence looms over the\nland like a shroud, threatening to plunge the realm into eternal despair.\n\nYet, amidst this encroaching gloom, a glimmer of hope shimmers ever so faintly—a prophecy\nforetelling the creation of the legendary Artifact of Boog, the sole instrument capable of\nvanquishing the malevolence that threatened to swallow the land whole.\n\nFor this Artifact to manifest, a valiant adventurer is needed—a hero brave enough to embark on\na perilous quest to gather the three fabled Boog Stones scattered across the land.\nThese stones, imbued with raw elemental power, are fiercely guarded by formidable creatures lurking\nwithin the depths of the most treacherous dungeons, deterring all but the most resolute\nand daring of souls.\n\nAs the weight of destiny hangs heavy in the air, a question emerges from the whispers of fate:\nWho would dare to step forward and undertake this formidable journey?\nWhose name would be etched in Boog's history as the savior of this wondrous realm?\n\n");

Console.Write("Enter Name:");
string PlayerNameBad = Console.ReadLine();
string PlayerName = PlayerNameBad.Trim();

// check for valid name
while (validateInput(PlayerName, maxLength: 15, intCheck: true ) == false)
{
    Console.Clear();
    Header();
    Console.WriteLine("In the ethereal realm of Boog, where emerald skies danced with hues of violet, and the air\nwhispered secrets of ancient magic. A land brimming with mystical wonders stood on the\nprecipice of annihilation. This enchanted realm, teeming with magnificent creatures and\nbreathtaking landscapes, now faces an imminent demise at the hands of the nefarious Chunky Dungus.\n\nA shadow has descended upon Boog, cast by the malevolent ambitions of Chunky Dungus,\na man consumed by darkness and a thirst for dominion. His ominous presence looms over the\nland like a shroud, threatening to plunge the realm into eternal despair.\n\nYet, amidst this encroaching gloom, a glimmer of hope shimmers ever so faintly—a prophecy\nforetelling the creation of the legendary Artifact of Boog, the sole instrument capable of\nvanquishing the malevolence that threatened to swallow the land whole.\n\nFor this Artifact to manifest, a valiant adventurer is needed—a hero brave enough to embark on\na perilous quest to gather the three fabled Boog Stones scattered across the land.\nThese stones, imbued with raw elemental power, are fiercely guarded by formidable creatures lurking\nwithin the depths of the most treacherous dungeons, deterring all but the most resolute\nand daring of souls.\n\nAs the weight of destiny hangs heavy in the air, a question emerges from the whispers of fate:\nWho would dare to step forward and undertake this formidable journey?\nWhose name would be etched in Boog's history as the savior of this wondrous realm?\n\n");
    Console.WriteLine("Old Dude: Hmm... That name is..... kinda trash...\nMaybe try something that is NOT a number, or obnoxiously long... do better");
    Console.Write("Enter Name:");
    PlayerNameBad = Console.ReadLine();
    PlayerName = PlayerNameBad.Trim();

}

// transition dialog into class selection
Console.Clear(); 
Header();
Console.WriteLine($"Old Dude: Ahh, {PlayerName} is it? Well… please take my endless gratitude for daring to embark on this journey! \nBest of luck for you as you depart on this quest, please bring peace to the kingdom of Boog once again!\n");


Continue();


// Class Selection
    Header();
SelectClass();


Console.Write("\n\nType the number that is above the class you wish to select:");
String PlayerClassNum = Console.ReadLine();

// check for valid class selection
while (PlayerClassNum != "1" && PlayerClassNum != "2" && PlayerClassNum != "3")
{
    Console.Clear();
    Header();
    SelectClass();


    Console.Write("\n\nType the number that is above the class you wish to select:");
    PlayerClassNum = Console.ReadLine();


}


// assigning Player class to PlayerClassNum
Console.Clear();
Header();

String PlayerClass = null;

if (PlayerClassNum == "1")
{
    PlayerClass = "Cheeze Wiz";

}

if (PlayerClassNum == "2")
{
    PlayerClass = "Beast Blade";

}

if (PlayerClassNum == "3")
{
    PlayerClass = "Prismancer Rouge";

}

// creatiing Player object
Player Player = new Player(PlayerName, PlayerClass);

// Choose Weapon

Console.WriteLine($"Old Dude: Incredible! I have never met a {PlayerClass} in person before! \n\nNow..{PlayerName}, A hero is nothing without a trusty companion! I shall forge you a weapon! \nAs a {PlayerClass} like yourself, I entrust one of these two weapon types would suit you best?");

String WeaponChoice = " ";

if (PlayerClassNum == "1")
{
    Console.WriteLine("\n\n(1) an Enchanted Cheddar Staff?, or would you prefer an (2) Etheral Cheese Wand? \ndon't overthink it..... they both perform the same...");
    Console.Write(":");
    WeaponChoice = Console.ReadLine();

}
if (PlayerClassNum == "2")
{
    Console.WriteLine("\n\n(1) a Mountainforge GreatSword?, or would you prefer (2) Dual Shredder Blades? \ndon't overthink it..... they both perform the same...");
    Console.Write(":");
    WeaponChoice = Console.ReadLine();

}
if (PlayerClassNum == "3")
{
    Console.WriteLine("\n\n(1) DeathGem Daggers?, or would you prefer an (2)Crystalized Shadow-Bow? \ndon't overthink it..... they both perform the same...");
    Console.Write(":");
    WeaponChoice = Console.ReadLine();

}

// check for valid weapon choice

while (WeaponChoice != "1" && WeaponChoice != "2")
{ 
    Console.Write($"\nOld Dude: *sigh* Please just choose 1 or 2. It is not that difficult, {Player.Name}...\n:");
    WeaponChoice = Console.ReadLine();

}

// ESTABLISHING the weapon type chosen

String WeaponType = "";

if (PlayerClassNum == "1" && WeaponChoice == "1")
{
    WeaponType = "Enchanted Cheddar Staff";
}

if (PlayerClassNum == "1" && WeaponChoice == "2")
{
    WeaponType = "Etheral Cheese Wand";
}

if (PlayerClassNum == "2" && WeaponChoice == "1")
{
    WeaponType = "Mountainforge GreatSword";
}

if (PlayerClassNum == "2" && WeaponChoice == "2")
{
    WeaponType = "Dual Shredder Blades";
}

if (PlayerClassNum == "3" && WeaponChoice == "1")
{
    WeaponType = "DeathGem Daggers";
}

if (PlayerClassNum == "3" && WeaponChoice == "2")
{
    WeaponType = "Crystalized Shadow-Bow";
}


// Name your Weapon
Console.Clear();
Header();

Console.WriteLine("Old Dude: Marvelous choice! Now... What shall you name your mighty weapon?\nEnter Weapon Name: ");
String WeaponNameBad = Console.ReadLine();
String WeaponName = WeaponNameBad.Trim();


while (validateInput(WeaponName, maxLength: 15, intCheck: true) == false)
{
    Console.Clear();
    Header();
    Console.WriteLine("\nOld Dude: That Name is horrible...Maybe try something that is NOT a number, or obnoxiously long... do better");
    Console.Write("Enter Weapon Name:");
    WeaponNameBad = Console.ReadLine();
    WeaponName = WeaponNameBad.Trim();
    

}

//creating weapon object
Weapon PlayersWeapon = new Weapon(WeaponName, WeaponType);

// Confirm Character
Console.Clear();
Header();

Console.WriteLine($"Name: {Player.Name}\nClass: {Player.Class}\nLevel: {Player.Level}\n\n\nWeapon: {PlayersWeapon.name} the {PlayersWeapon.Type}\nWeapon Base Damage: {PlayersWeapon.BaseDamage} \nWeapon Crit Chance: {PlayersWeapon.CritRate}%");

Continue();

// Dialog transition into Forest Dungeon

Console.Clear();
Header();

Console.WriteLine("Old Dude: AND WE ARE OFF!!! Your quest begins in the Mushroom Woods, east of here, to find the Mush Elder. \nThere, amidst the towering trees, He can lead you to the forest dungeon, where the first Moog Stone rests. \nThe Moog Stone of the Forest! Hasten there, for darkness looms!");
Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
Console.WriteLine("\nWith resolve burning in your eyes, you waste no time. You surge forth, charging through the emerald tapestry \nof the Mushroom Woods.Entering the heart of the woods, you were met by the Mush Elder, a venerable figure \ndraped in robes woven from luminescent fungi. With an air of solemnity, the elder addressed speaks…");
Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
Console.WriteLine($"\nMush Elder: Welcome, valiant {Player.Name} the {Player.Class}, intoned the Mush Elder, his voice resonating \nwith both gratitude and concern. Our village suffers under the veil of night, beset by malevolent creatures \nfrom the dungeon \nthat plunder our precious Glow Shrooms, stealing our source of radiance.\n\nYour heart surged with a mixture of empathy and determination. \n{Player.Name}:Fear not, revered elder. I shall confront these adversaries and reclaim your stolen Glow Shrooms! \n\nyou vowed, with your voice carrying the weight of your promise.\nWith a respectful bow from the Mush Elder, You dash towards the yawning maw of the forest dungeon, \nto retrieve the Glow Shrooms, and find the Moog Stone of the Forest!");
Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
Console.WriteLine("\nAs you step closer to the enigmatic forest dungeon, your gaze fixes upon its grandeur—crafted of \nancient stone, adorned with verdant moss, and illuminated by an ethereal glow emanating from an array of \nluminescent mushrooms. The air around the entrance crackles with an arcane energy, hinting at the mysteries \nveiled within.Standing before the colossal wooden door that guards the threshold to this mystical domain, \nyou nod solemnly, acknowledging the weight of the impending venture. \nWith resolute determination fueling your every step, you charge forth, \nyour heart pounding in rhythm with the call of adventure.");
Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
Console.WriteLine("\n\n\n                               *Now Entering the Forest Dungeon*\n\n");
Continue();

// connor stuff

// Dungeon ForestDungeon = new Dungeon();
// ForestDungeon.setPlayer(Player);



// Enemies
Random random1 = new Random();
Enemy ChunkySlime = new Enemy("Chunky Slime", 75, 5);
Enemy Skeleton = new Enemy("Skelly", 120, 5);
Enemy[] randomEnemy = {ChunkySlime, Skeleton};



// FOREST DUNGEON 

// Values for UI
String CombatDialog1 = "";
String CombatDialog2 = "";
String CombatDialog3 = "";
String PlayerAction = "";
int HealthPotions = 3;
int ManaPotions = 3;
Random random = new Random();   
    Enemy enemy = new Enemy("TRASH",1 , 1);


// forest dungeon UI function

void ForestDungeonUI()
{
    Console.WriteLine("=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~  Forest Dungeon  ~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=");
    Console.WriteLine("                                                    Room 1                                                  ");
    Console.WriteLine("       [                                                                                           ]");
    Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>                                   <:::::::::::::::::::::::::::}xxxxx@");
    Console.WriteLine("       [                                                                                           ]\n");
    Console.WriteLine($"[{Player.Name}] Level:{Player.Level} {Player.Class}                                                EXP: {Player.XP}/100");
    Console.WriteLine($"Health: {Player.Health}\nMana: {Player.Mana}\n");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  Enemies  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

    Console.WriteLine($"   [{enemy.name}] Health:{enemy.health}\n\n");


    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  Dialog  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
    Console.WriteLine(CombatDialog1);
    Console.WriteLine(CombatDialog2);
    Console.WriteLine(CombatDialog3);
    

    Console.WriteLine("===============================================  Action Bar  ===============================================");
    Console.WriteLine("|  (B)asic Attack  [5 MP]                                                                                  |");
    Console.WriteLine("|  (S)trong Attack [10 MP]                                                                                 |");
   Console.WriteLine($"|  (H)ealth Potion [{HealthPotions}]                                                                                     |");
   Console.WriteLine($"|  (M)ana Potion   [{ManaPotions}]                                                                                     |");
    Console.WriteLine("============================================================================================================\n\n");

    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  Inventory  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
    Console.WriteLine($" Weapon:{PlayersWeapon.name} the {PlayersWeapon.Type}                                       Gold:{Player.Gold}\n\n");
    Console.WriteLine(" Mana Orb Lvl 1: {Restores 2 Mana Per Turn}");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
    Console.WriteLine("Type Action:");
    PlayerAction = Console.ReadLine();
    PlayerAction = PlayerAction.ToLower();

}


void Combat()
{
    while (Player.Health > 0)
    {

        int enemyPicker = random.Next(0, 1);
        if (enemyPicker == 0)
        {

            enemy = randomEnemy[0];
        }

        if (enemyPicker == 1)
        {

            enemy = randomEnemy[1];
        }

        Console.Clear();
        ForestDungeonUI();


        PlayersWeapon.BaseDamage = random.Next(5, 15);
        enemy.damage = random.Next(5, 15);


        // Basic Attack
        if (PlayerAction == "b" & Player.Mana >= 5)
        {
            enemy.health = enemy.health - PlayersWeapon.BaseDamage;
            CombatDialog1 = $"- You dealt {PlayersWeapon.BaseDamage} damage to {enemy.name}!\n";
            Player.Health = Player.Health - enemy.damage;
            CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
            Player.Mana = Player.Mana - 5;
            CombatDialog3 = "- You Used 5 Mana";
            Player.Mana = Player.Mana + 2;
            PlayerAction = "z";
        }

        // out of mana for Basic Attack
        if (PlayerAction == "b" & Player.Mana < 5)
        {
            CombatDialog1 = "- You do not have enough Mana";
            CombatDialog2 = "";
            CombatDialog3 = "";


        }
        // Strong Attack
        if (PlayerAction == "s" & Player.Mana >= 10)
        {
            enemy.health = enemy.health - PlayersWeapon.BaseDamage * 2;
            CombatDialog1 = $"- You dealt {PlayersWeapon.BaseDamage * 2} damage to {enemy.name}!\n";
            Player.Health = Player.Health - enemy.damage;
            CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
            Player.Mana = Player.Mana - 10;
            CombatDialog3 = "- You Used 10 Mana";
            Player.Mana = Player.Mana + 2;
            PlayerAction = "z";
        }

        // out of mana for Strong Attack
        if (PlayerAction == "b" & Player.Mana < 10)
        {
            CombatDialog1 = "- You do not have enough Mana";
            CombatDialog2 = "";
            CombatDialog3 = "";


        }

        // Health Potion
        if (PlayerAction == "h" & HealthPotions > 0)
        {
            Player.Health = Player.Health + 20;
            CombatDialog1 = "- You drank a Health Potion, you Gained 20 Health!";
            Player.Health = Player.Health - enemy.damage;
            CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
            CombatDialog3 = "";
            HealthPotions = HealthPotions - 1;
            Player.Mana = Player.Mana + 2;
            PlayerAction = "z";
        }


        // health cap
        if (Player.Health > 100)
        {

            Player.Health = 100;
        }

        // health potion cap
        if (HealthPotions <= 0)
        {
            HealthPotions = 0;

        }
        // out of Health Potions
        if (PlayerAction == "h" & HealthPotions <= 0)
        {
            CombatDialog1 = "- You are out of Health Potions";
            CombatDialog2 = "";
            CombatDialog3 = "";

        }


        // Mana Potion
        if (PlayerAction == "m" & ManaPotions > 0)
        {
            Player.Mana = Player.Mana + 20;
            CombatDialog1 = "- You drank a Mana Potion, you Gained 20 Mana!";
            Player.Health = Player.Health - enemy.damage;
            CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
            CombatDialog3 = "";
            ManaPotions = ManaPotions - 1;
            PlayerAction = "z";
        }

        // Mana Cap
        if (Player.Mana > 100)
        {

            Player.Mana = 100;
        }

        // out of Mana Potions
        if (PlayerAction == "m" & ManaPotions == 0)
        {
            CombatDialog1 = "- You are out of Mana Potions";
            CombatDialog2 = "";
            CombatDialog3 = "";


        }

        // Mana potion cap
        if (ManaPotions <= 0)
        {
            ManaPotions = 0;

        }
        //mana out

        if (Player.Mana <= 0)
        {

            Player.Mana = 0;
        }


        // Enemy Death
        if (enemy.health <= 0)
        {
            enemy.health = 0;
            int XpGain = random.Next(10, 19);
            int GoldGain = random.Next(10, 30);
            Player.XP = Player.XP + XpGain;
            Player.Gold = Player.Gold + GoldGain;
            CombatDialog1 = $"BLEH! The {enemy.name} was defeated! You got {XpGain} XP! \nYou also found {GoldGain} Gold!";
            CombatDialog2 = "";
            CombatDialog3 = "";
            
        }


    }

}


Combat();
Combat();
































while (Player.Health > 0)
{

    int enemyPicker = random.Next(0, 1);
    if (enemyPicker == 0)
    {

        enemy = randomEnemy[0];
    }

    if (enemyPicker == 1)
    {

        enemy = randomEnemy[1];
    }

    Console.Clear();
    ForestDungeonUI();


    PlayersWeapon.BaseDamage = random.Next(5, 15);
    enemy.damage = random.Next(5, 15);


    // Basic Attack
    if (PlayerAction == "b" & Player.Mana >=5)
    {
        enemy.health = enemy.health - PlayersWeapon.BaseDamage;
        CombatDialog1 = $"- You dealt {PlayersWeapon.BaseDamage} damage to {enemy.name}!\n";
        Player.Health = Player.Health - enemy.damage;
        CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
        Player.Mana = Player.Mana - 5;
        CombatDialog3 = "- You Used 5 Mana";
        Player.Mana = Player.Mana + 2;
        PlayerAction = "z";
    }

    // out of mana for Basic Attack
    if (PlayerAction == "b" & Player.Mana < 5)
    {
        CombatDialog1 = "- You do not have enough Mana";
        CombatDialog2 = "";
        CombatDialog3 = "";
        

    }
    // Strong Attack
    if (PlayerAction == "s" & Player.Mana >= 10)
    {
        enemy.health = enemy.health - PlayersWeapon.BaseDamage * 2;
        CombatDialog1 = $"- You dealt {PlayersWeapon.BaseDamage * 2} damage to {enemy.name}!\n";
        Player.Health = Player.Health - enemy.damage;
        CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
        Player.Mana = Player.Mana - 10;
        CombatDialog3 = "- You Used 10 Mana";
        Player.Mana = Player.Mana + 2;
        PlayerAction = "z";
    }

    // out of mana for Strong Attack
    if (PlayerAction == "b" & Player.Mana < 10)
    {
        CombatDialog1 = "- You do not have enough Mana";
        CombatDialog2 = "";
        CombatDialog3 = "";


    }

    // Health Potion
    if (PlayerAction == "h" & HealthPotions > 0)
    {
        Player.Health = Player.Health + 20;
        CombatDialog1 = "- You drank a Health Potion, you Gained 20 Health!";
        Player.Health = Player.Health - enemy.damage;
        CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
        CombatDialog3 = "";
        HealthPotions = HealthPotions - 1;
        Player.Mana = Player.Mana + 2;
        PlayerAction = "z";
    }
  

    // health cap
    if (Player.Health > 100)
    {

        Player.Health = 100;
    }

    // health potion cap
    if (HealthPotions <= 0)
    {
        HealthPotions = 0;

    }
    // out of Health Potions
    if (PlayerAction == "h" & HealthPotions <= 0)
    {
        CombatDialog1 = "- You are out of Health Potions";
        CombatDialog2 = "";
        CombatDialog3 = "";
        
    }
   

    // Mana Potion
    if (PlayerAction == "m" & ManaPotions > 0)
    {
        Player.Mana = Player.Mana + 20;
        CombatDialog1 = "- You drank a Mana Potion, you Gained 20 Mana!";
        Player.Health = Player.Health - enemy.damage;
        CombatDialog2 = $"- {enemy.name} Slaps back and hits you for {enemy.damage}!\n";
        CombatDialog3 = "";
        ManaPotions = ManaPotions - 1;
        PlayerAction = "z";
    }
   
    // Mana Cap
    if (Player.Mana > 100)
    {

        Player.Mana = 100;
    }

    // out of Mana Potions
    if (PlayerAction == "m" & ManaPotions == 0)
    {
        CombatDialog1 = "- You are out of Mana Potions";
        CombatDialog2 = "";
        CombatDialog3 = "";
        

    }

    // Mana potion cap
    if (ManaPotions <= 0)
    {
        ManaPotions = 0;

    }
    //mana out

    if (Player.Mana <= 0)
    {

        Player.Mana = 0;
    }


    // Enemy Death
    if (enemy.health <= 0)
    {
        enemy.health = 0;
        int XpGain = random.Next(10, 19);
        int GoldGain = random.Next(10, 30);
        Player.XP = Player.XP + XpGain;
        Player.Gold = Player.Gold + GoldGain;
        CombatDialog1 = $"BLEH! The {enemy.name} was defeated! You got {XpGain} XP! \nYou also found {GoldGain} Gold!";
        CombatDialog2 = "";
        CombatDialog3 = "";
        
    }


}

    Console.WriteLine("You Died.");