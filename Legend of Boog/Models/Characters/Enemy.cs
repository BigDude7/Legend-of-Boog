namespace Legend_of_Boog.Models.Characters
{
    public class Enemy
    {
        public string Name;
        public int Health;
        public int FullHealth;
        public int BaseDamage;
        public int MaxDamage;
        public int Damage;
        public int Accuracy;
        public int CritRate;

        public Enemy(string name, int health, int fullHealth, int baseDamage, int maxDamage, int damage, int accuracy, int critRate)
        {
            Name = name;
            Health = health;
            FullHealth = fullHealth;
            BaseDamage = baseDamage;
            MaxDamage = maxDamage;
            Accuracy = accuracy;
            Damage = damage;
            CritRate = critRate;
        }
    }
}
