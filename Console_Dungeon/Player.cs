using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dungeon
{
    class Player
    {
        public bool updateStats = false;
        private Chars charset = new Chars();

        private Level Level; // PARENT INSTANCE

        public readonly char Glyph = '@';

        public ConsoleColor Color;

        private Position prevpos;
        public Position Pos;

        private const int MAX_HEALTH = 25;
        private int health;
        public int Health
        {
            set
            {
                health = value;
                if(health <= 0) Die();
                if (health > MAX_HEALTH) health = MAX_HEALTH;
            }
            get
            {
                return health;
            }
        }

        private int damage;
        public int Damage
        {
            set
            {
                if(value < 0)throw new Exception("A sebzés nem lehet kisseb 0-nál!");
                damage = value;
            }
            get
            {
                return damage;
            }
        }

        public Player(Level level, Position pos, ConsoleColor color, int health, int damage)
        {
            Level = level;
            Pos = pos;
            prevpos = new Position(this.Pos.x,this.Pos.y);
            Color = color;
            Health = health;
            Damage = damage;
            level.map[pos.x][pos.y].over = Glyph;
        }

        public void Move(List<List<Mapchar>> map, ConsoleKeyInfo key)
        {


            if (key.Key == ConsoleKey.NumPad8 || key.Key == ConsoleKey.W) prevpos.y--;
            else if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.S) prevpos.y++;
            else if (key.Key == ConsoleKey.NumPad4 || key.Key == ConsoleKey.A) prevpos.x--;
            else if (key.Key == ConsoleKey.NumPad6 || key.Key == ConsoleKey.D) prevpos.x++;
            else if (key.Key == ConsoleKey.NumPad7) { prevpos.x--; prevpos.y--; }
            else if (key.Key == ConsoleKey.NumPad9) { prevpos.x++; prevpos.y--; }
            else if (key.Key == ConsoleKey.NumPad1) { prevpos.x--; prevpos.y++; }
            else if (key.Key == ConsoleKey.NumPad3) { prevpos.x++; prevpos.y++; }

            if (prevpos.x < 17) prevpos.x = 17;
            if (prevpos.y < 11) prevpos.y = 11;

            Mapchar moveTo = map[prevpos.x][prevpos.y];
            Console.SetCursorPosition(16, 0);
            Console.Write("~"+moveTo.ground + " " + moveTo.over);

            if(moveTo == new Mapchar(' ',' '))
            {
                Display(map);
            }
            else
            {
                
                if(new Chars().enemies.Contains(moveTo.ground))
                {
                    throw new Exception("Enemy interaction not implemkented!");
                }
                else if (new Chars().items.Contains(moveTo.ground))
                {
                    throw new Exception("Item pickup not implemkented!");
                }
                else if (new Chars().objects.Contains(moveTo.ground))
                {
                    prevpos = Pos;
                }
                Display(map);
            }

        }

        private void Display(List<List<Mapchar>> map)
        {
            map[Pos.x][Pos.y].over = ' ';
            Pos = new Position(prevpos);
            map[Pos.x][Pos.y].over = Glyph;
        }

        public void Hurt(int dmg)
        {
            //Do the damages
            updateStats = false;
        }



        private void Die()
        {

        }




    }
}
