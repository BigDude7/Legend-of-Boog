using Legend_of_Boog.Models.Characters;
using Legend_of_Boog.Models.Items;

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
        
        public static PlayerClass CreateBeastBladeClass()
        {
            return new PlayerClass()
            {
                Id = 2,
                Name = "Beast Blade",
                Description = "",
                Weapons =
                {
                    Weapon.LightWeapon("Mountainforge Greatsword", "Greatsword"),
                    Weapon.HeavyWeapon("Dual Shredder Blades", "Blades")
                },
                Abilities =
                {
                    new Ability("", "", 5, 2, 10),
                    new Ability("", "", 5, 2, 10)
                }
            };
        }
        
        public static PlayerClass CreatePrismancerRougeClass()
        {
            return new PlayerClass()
            {
                Id = 3,
                Name = "Prismancer Rouge",
                Description = "",
                Weapons =
                {
                    Weapon.LightWeapon("Deathgem Daggers", "Daggers"),
                    Weapon.HeavyWeapon("Crystalized Shadow Bow", "Bow")
                },
                Abilities =
                {
                    new Ability("", "", 5, 2, 10),
                    new Ability("", "", 5, 2, 10)
                }
            };
        }
    }
}
