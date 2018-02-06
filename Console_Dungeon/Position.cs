using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dungeon
{
    class Position
    {
        private int _x;
        public int x
        {
            set
            {
                if (value < 0) throw new Exception("Az X koordináta nem lehet kissebb 8-nál a kirajzolás miatt!");
                _x = value;
            }
            get
            {
                return _x;
            }
        }
        private int _y;
        public int y
        {
            set
            {
                if (value < 0) throw new Exception("Az Y koordináta nem lehet kissebb 8-nál a kirajzolás miatt!");
                _y = value;
            }
            get
            {
                return _y;
            }
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position(Position pos)
        {
            this.x = pos.x;
            this.y = pos.y;
        }
    }
}
