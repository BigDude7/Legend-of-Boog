using Legend_of_Boog.Models.Items;

namespace Legend_of_Boog.Models.Characters
{
    public class Player
    {
        public string Name = String.Empty;
        public int Health;
        public int FullHealth;
        public int HealthPotionValue;
        public int Mana;
        public int FullMana;
        public int ManaPotionValue;
        public int ManaRegenRate;
        public int HealthPotions;
        public int ManaPotions;
        public int Level;
        public string Class = String.Empty;
        public int Xp;
        public int XpNeeded;
        public int Gold;
        public Weapon Weapon = new();
      

        public Player(string name)
        {
            Name = name;
            Health = 100;
            HealthPotionValue = 35;
            FullHealth = 100;
            ManaRegenRate = 4;
            Mana = 100;
            FullMana = 100;
            ManaPotionValue = 10;
            HealthPotions = 3;
            ManaPotions = 3;
            Level = 1;
            Xp = 0;
            XpNeeded = 100;
            Gold = 0;
        }
    }
}