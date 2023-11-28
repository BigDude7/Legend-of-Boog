
// Sword Icon
void swordIcon()
{

    Console.WriteLine("       [");
    Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>");
    Console.WriteLine("       [\n");


}

// cut scene header
void cutScene()
{

    swordIcon();
    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
}

// Title Screen////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X==X=X=X=X=X=X=X=X=\n");
Console.WriteLine("       [                                                                                        ]");
Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>   || The Legend of Boog ||     <:::::::::::::::::::::::::::}xxxxx@");
Console.WriteLine("       [                                                                                        ]\n");
Console.WriteLine("                                      || Type (E)nter to Start ||\n");
Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
Console.WriteLine("                                                                              Created By: Chandler Combs");
String PlayerStart = Console.ReadLine();
if (PlayerStart == "E" || PlayerStart == "e")
{
    Console.Clear();    
}

// intro cutscene and ask for name
cutScene();
Console.WriteLine("In the ethereal realm of Boog, where emerald skies danced with hues of violet, and the air\nwhispered secrets of ancient magic. A land brimming with mystical wonders stood on the\nprecipice of annihilation. This enchanted realm, teeming with magnificent creatures and\nbreathtaking landscapes, now faces an imminent demise at the hands of the nefarious Chunky Dungus.\n\nA shadow has descended upon Boog, cast by the malevolent ambitions of Chunky Dungus,\na man consumed by darkness and a thirst for dominion. His ominous presence looms over the\nland like a shroud, threatening to plunge the realm into eternal despair.\n\nYet, amidst this encroaching gloom, a glimmer of hope shimmers ever so faintly—a prophecy\nforetelling the creation of the legendary Artifact of Boog, the sole instrument capable of\nvanquishing the malevolence that threatened to swallow the land whole.\n\nFor this Artifact to manifest, a valiant adventurer is needed—a hero brave enough to embark on\na perilous quest to gather the three fabled Boog Stones scattered across the land.\nThese stones, imbued with raw elemental power, are fiercely guarded by formidable creatures lurking\nwithin the depths of the most treacherous dungeons, deterring all but the most resolute\nand daring of souls.\n\nAs the weight of destiny hangs heavy in the air, a question emerges from the whispers of fate:\nWho would dare to step forward and undertake this formidable journey?\nWhose name would be etched in Boog's history as the savior of this wondrous realm?\n\n");
Console.Write("Enter Name:");
string PlayerName = Console.ReadLine();

