using Legend_of_Boog.Models.Characters;
using Legend_of_Boog.Models.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_Boog.Services
{
    static public class UIService
    {
        static public void ClearAll()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }

        static public void SelectClass()
        {
            ClearAll();
            Header();
            Console.WriteLine("                          ~ Select Your Class ~\n ");

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

            Console.Write("\n\nType the number that is above the class you wish to select:");
        }

        static public void SwordIcon()
        {
            Console.WriteLine("       [");
            Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>");
            Console.WriteLine("       [");
        }

        static public void Header()
        {
            ClearAll();
            SwordIcon();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        static public void TitleScreen()
        {
            Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
            Console.WriteLine("       [                                                                                        ]");
            Console.WriteLine(" @xxxxx{:::::::::::::::::::::::::::>   || The Legend of Boog ||     <:::::::::::::::::::::::::::}xxxxx@");
            Console.WriteLine("       [                                                                                        ]\n");
            Console.WriteLine("                                       || Type (E) to Start  ||\n");
            Console.WriteLine("=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=X=\n");
            Console.WriteLine("                                                                              Created By: Chandler Combs");
            Console.WriteLine("Type (E) to start");
            Console.Write(":");
        }

        public static void PlayerRecap(Player player)
        {
            Console.WriteLine($"Name: {player.Name}\nClass: {player.Class}\nLevel: {player.Level}\n\n\nWeapon: {player.Weapon.Name} the {player.Weapon.Type}\nWeapon Damage Range: {player.Weapon.BaseDamage} - {player.Weapon.MaxDamage} \nWeapon Crit Chance: {player.Weapon.CritRate}%");
        }

        public static void AbilitiesMenu(Player player)
        {
            Header();
            Console.WriteLine($"{player.Class}\nLevel: {player.Level}\n\n");

            Console.WriteLine("Ability 1: ????????");
            Console.WriteLine("Ability 2: ????????");
            Console.WriteLine("Ability 3: ????????");
            Console.WriteLine("Ultimate Ability: ????????");
            Console.WriteLine("============================================================================================================");
            Console.WriteLine("(B)ack");

            Console.WriteLine("Type Action:");
        }

        public static void InventoryMenu(Player player)
        {
            UIService.Header();
            Console.WriteLine($"                                      {player.Name}'s Inventory ");
            Console.WriteLine($"Weapon: {player.Weapon.Name} the {player.Weapon.Type} \n");
            Console.WriteLine($"Health Potions: {player.HealthPotions}\n");
            Console.WriteLine($"Mana Potions: {player.ManaPotions}\n\n");
            Console.WriteLine($"Gold: {player.Gold}\n\n\n");
            Console.WriteLine("============================================================================================================");

            Console.WriteLine("Type (B) to go back:");
        }

        public static void DungeonMap(string MapDialog)
        {
            UIService.Header();
            Console.WriteLine($"                                         Forest Dungeon                      {MapDialog}\n");

            Console.WriteLine("                                            ======= 8                                                      ");
            Console.WriteLine("                                            |  B  |                                                        ");
            Console.WriteLine("                                            |     |                                                        ");
            Console.WriteLine("                                            === ===                                                        ");
            Console.WriteLine("                               6 =======      | |      ======= 7                                           ");
            Console.WriteLine("                                 |     |____=== ===____|     |                                             ");
            Console.WriteLine("                                 |      ____       ____      |                                             ");
            Console.WriteLine("                                 =======    |     |    =======                                             ");
            Console.WriteLine("                                            === === 5                                                      ");
            Console.WriteLine("                          3 =======___________| |___________======= 4                                      ");
            Console.WriteLine("                            |      ___________   ___________      |                                        ");
            Console.WriteLine("                            |     |           | |           |     |                                        ");
            Console.WriteLine("                            =======         === === 2       =======                                        ");
            Console.WriteLine("                                            |     |                                                        ");
            Console.WriteLine("                                            |     |                                                        ");
            Console.WriteLine("                                            =======                                                        ");
            Console.WriteLine("                                              | |                                                          ");
            Console.WriteLine("                                            === === 1                                                      ");
            Console.WriteLine("                                            |     |                                                        ");
            Console.WriteLine("                                            |     |                                                        ");
            Console.WriteLine("                                            ==   ==                                                        ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("============================================================================================================");

            Console.WriteLine("Type (B) to go back:");
        }

        public static void CombatDialog(string dialog1, string dialog2, string dialog3)
        {
            if (dialog1 != "")
            {
                Thread.Sleep(500);
                Console.WriteLine(dialog1);
                Thread.Sleep(100);
            }

            if (dialog2 != "")
            {
                Thread.Sleep(500);
                Console.WriteLine(dialog2);
                Thread.Sleep(500);
            }

            if (dialog3 != "")
            {
                Thread.Sleep(500);
                Console.WriteLine(dialog3);
                Thread.Sleep(500);
            }
        }

    }


}
