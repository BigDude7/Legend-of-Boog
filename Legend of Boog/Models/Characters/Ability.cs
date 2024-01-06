namespace Legend_of_Boog.Models.Characters
{
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManaCost { get; set; }
        public int LevelUnlock { get; set; }
        public bool isUnlocked { get; set; }
    }
}
