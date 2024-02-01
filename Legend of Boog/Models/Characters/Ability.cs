namespace Legend_of_Boog.Models.Characters
{
    public class Ability
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ManaCost { get; set; }
        public int LevelUnlock { get; set; }
        public bool IsUnlocked { get; set; } = false;
        public int Damage { get; set; }
        public bool IsStun { get; set; } = false;
        public bool IsDamageOverTime { get; set; } = false;

        public Ability(string name, string description, int mana, int level, int damage)
        {
            Name = name;
            Description = description;
            ManaCost = mana;
            LevelUnlock = level;
            Damage = damage;
        }

    }
}
