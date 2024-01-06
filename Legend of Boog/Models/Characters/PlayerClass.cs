﻿namespace Legend_of_Boog.Models.Characters
{
    public class PlayerClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string[] Weapons { get; set; }
        public List<Ability> Abilities { get; set; }
    }

    
}