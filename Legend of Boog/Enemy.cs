using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemies
{
    public class Enemy
    {
        public String name;
        public int health;
        public int damage;


        public Enemy(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }
}
