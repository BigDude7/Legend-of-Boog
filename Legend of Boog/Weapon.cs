using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapons
{

   
    public class Weapon
    {
        public String name;
        public int BaseDamage;
        public int CritRate;
        public String Type;

        public Weapon(String Name, string type)
        {
            
            this.name = Name;
            this.BaseDamage = 5;
            this.CritRate = 2;
            Type = type;
        }

        //  bool RollForCrit() 
        //  {
        //       Random random = new Random();
        //      random.Next(1-100);
        //      if (random <= Weapon.CritRate)
        //          return true;


        //  }


    }
}
      
        
        




