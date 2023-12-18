using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Players;

namespace Dungeons
{
    public class Dungeon
    {
        public struct Room
        {
            public Room(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double Width { get; }
            public double Height { get; }

        }

        public Room room;
        public Player player;
        public void setPlayer(Player player1)
        {
            player = player1;
        }

        public Dungeon()
        {
            room = new Room(10, 20);
            Console.WriteLine("You created this room. cool.");
            Console.WriteLine(room.Width);



        }
            



        

    }
}
