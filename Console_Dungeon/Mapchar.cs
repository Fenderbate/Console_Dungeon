using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dungeon
{
    class Mapchar
    {
        public char ground;
        public char over;
        public ConsoleColor color = ConsoleColor.White;

        public Mapchar(char g, char o)
        {
            this.ground = g;
            this.over = o;
        }
    }
}
