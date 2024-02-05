using Legend_of_Boog.Models.Characters;

namespace Legend_of_Boog.Services
{
    public static class StoryService
    {
        public static void DisplayStoryStart()
        {
            UIService.ClearAll();
            UIService.Header();
            Console.WriteLine("In the ethereal realm of Boog, where emerald skies danced with hues of violet, and the air\nwhispered secrets of ancient magic. A land brimming with mystical wonders stood on the\nprecipice of annihilation. This enchanted realm, teeming with magnificent creatures and\nbreathtaking landscapes, now faces an imminent demise at the hands of the nefarious Chunky Dungus.\n\nA shadow has descended upon Boog, cast by the malevolent ambitions of Chunky Dungus,\na man consumed by darkness and a thirst for dominion. His ominous presence looms over the\nland like a shroud, threatening to plunge the realm into eternal despair.\n\nYet, amidst this encroaching gloom, a glimmer of hope shimmers ever so faintly—a prophecy\nforetelling the creation of the legendary Artifact of Boog, the sole instrument capable of\nvanquishing the malevolence that threatened to swallow the land whole.\n\nFor this Artifact to manifest, a valiant adventurer is needed—a hero brave enough to embark on\na perilous quest to gather the three fabled Boog Stones scattered across the land.\nThese stones, imbued with raw elemental power, are fiercely guarded by formidable creatures lurking\nwithin the depths of the most treacherous dungeons, deterring all but the most resolute\nand daring of souls.\n\nAs the weight of destiny hangs heavy in the air, a question emerges from the whispers of fate:\nWho would dare to step forward and undertake this formidable journey?\nWhose name would be etched in Boog's history as the savior of this wondrous realm?\n\n");
        }

        public static void DisplayNameIntroduction(string name)
        {
            UIService.ClearAll();
            UIService.Header();
            Console.WriteLine($"Old Dude: Ahh, {name} is it? Well… please take my endless gratitude for daring to embark on this journey! \nBest of luck for you as you depart on this quest, please bring peace to the kingdom of Boog once again!\n");
        }

        public static void DisplayWeaponIntroduction(Player player)
        {
            UIService.Header();
            Console.WriteLine($"Old Dude: Incredible! I have never met a {player.Class.Name} in person before! \n\nNow..{player.Name}, A hero is nothing without a trusty companion! I shall forge you a weapon! \nAs a {player.Class.Name} like yourself, I entrust one of these two weapon types would suit you best?");
        }

        public static void DisplayForestDungeon(Player player)
        {
            Console.WriteLine("Old Dude: AND WE ARE OFF!!! Your quest begins in the Mushroom Woods, east of here, to find the Mush Elder. \nThere, amidst the towering trees, He can lead you to the forest dungeon, where the first Boog Stone rests. \nThe Boog Stone of the Forest! Hasten there, for darkness looms!");
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("\nWith resolve burning in your eyes, you waste no time. You surge forth, charging through the emerald tapestry \nof the Mushroom Woods.Entering the heart of the woods, you were met by the Mush Elder, a venerable figure \ndraped in robes woven from luminescent fungi. With an air of solemnity, the elder addressed speaks…");
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine($"\nMush Elder: Welcome, valiant {player.Name} the {player.Class.Name}, intoned the Mush Elder, his voice resonating \nwith both gratitude and concern. Our village suffers under the veil of night, beset by malevolent creatures \nfrom the dungeon \nthat plunder our precious Glow Shrooms, stealing our source of radiance.\n\nYour heart surged with a mixture of empathy and determination. \n{player.Name}:Fear not, revered elder. I shall confront these adversaries and reclaim your stolen Glow Shrooms! \n\nyou vowed, with your voice carrying the weight of your promise.\nWith a respectful bow from the Mush Elder, You dash towards the yawning maw of the forest dungeon, \nto retrieve the Glow Shrooms, and find the Boog Stone of the Forest!");
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("\nAs you step closer to the enigmatic forest dungeon, your gaze fixes upon its grandeur—crafted of \nancient stone, adorned with verdant moss, and illuminated by an ethereal glow emanating from an array of \nluminescent mushrooms. The air around the entrance crackles with an arcane energy, hinting at the mysteries \nveiled within.Standing before the colossal wooden door that guards the threshold to this mystical domain, \nyou nod solemnly, acknowledging the weight of the impending venture. \nWith resolute determination fueling your every step, you charge forth, \nyour heart pounding in rhythm with the call of adventure.");
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("\n\n\n                               *Now Entering the Forest Dungeon*\n\n");
        }
    }
}
