using Legend_of_Boog.Models.Characters;
using Legend_of_Boog.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_Boog.Services
{
    public static class AbilityService
    {
        public static PlayerClass CreateCheezeWizClass()
        {
            return new PlayerClass()
            {
                Id = 1,
                Name = "Cheeze Wiz",
                Description = "Does Cheeze Wiz Stuff",
                Weapons =
                {
                    Weapon.LightWeapon("Ethereal Cheeze Wand", "Wand"),
                    Weapon.HeavyWeapon("", "")
                },
                Abilities =
                {
                    new Ability("Queso Blast", "Does Queso Blast things", 5, 2, 10),
                    new Ability("Queso Blast 2", "Does Queso Blast things", 5, 2, 10)
                }
            };
        }
    }
}
