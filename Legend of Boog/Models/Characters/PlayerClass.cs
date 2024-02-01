using Legend_of_Boog.Models.Items;

namespace Legend_of_Boog.Models.Characters
{
    public class PlayerClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Ability> Abilities { get; set; } = new List<Ability>();
    }

    
}