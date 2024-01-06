namespace Legend_of_Boog.Models.Items
{
    public class Weapon
    {
        public string Name;
        public int BaseDamage;
        public int MaxDamage;
        public int Damage;
        public int CritRate;
        public string Type;
        public int AttackCount;

        public Weapon()
        {
            Name = "";
            BaseDamage = 10;
            Damage = 1;
            MaxDamage = 20;
            CritRate = 10;
            Type = "";
            AttackCount = 1;
        }

        public Weapon(string name, string type)
        {
            Name = name;
            BaseDamage = 10;
            Damage = 1;
            MaxDamage = 20;
            CritRate = 10;
            Type = type;
            AttackCount = 1;
        }

        public Weapon LightWeapon(string name, string type)
        {
            return new Weapon(name, type)
            {
                Name = name,
                BaseDamage = 5,
                Damage = 1,
                MaxDamage = 10,
                CritRate = 10,
                Type = type,
                AttackCount = 5
            };
        }

        public Weapon HeavyWeapon(string name, string type)
        {
            return new Weapon(name, type)
            {
                Name = name,
                BaseDamage = 15,
                Damage = 1,
                MaxDamage = 25,
                CritRate = 10,
                Type = type,
                AttackCount = 1
            };
        }
    }
}