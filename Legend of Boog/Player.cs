using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class Player
    {
        public string Name;
        public int Health;
        public int Mana;
        public int Armor;
        public int Level;
        public string Class;
        public int XP;
        public int Gold;
        public int speed;
        public string ability1;
        public string ability2;
        public string ability3;
        public string ability4;


        public Player(string Name,string Class) 
        
        {
              
          this.Name = Name;
            this.Health = 100;
            this.Mana = 100;
            this.Armor = 1;
            this.Level = 1;
            this.Class = Class;
            this.XP = 0;
            this.Gold = 0;
            this.speed = 5;


        }

        
    }

    


}
