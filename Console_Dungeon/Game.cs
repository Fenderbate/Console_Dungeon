using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dungeon
{
    class Game
    {
        public Level level;

        public Game()
        {
            
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(33, i);
                Console.Write('█');
            }
            for (int i = 0; i < 34; i++)
            {
                Console.SetCursorPosition(i, 21);
                Console.Write('▀');
            }

            level = new Level();
            Draw(level.player.Pos, level.map);
            Stats();
        }

        public void Update()
        {
            while (level.Update())
            {
                Draw(level.player.Pos, level.map);
                if (level.player.updateStats) Stats();
                //DO TH DEW
            }
        }

        public void Draw(Position pos, List<List<Mapchar>> map)
        {
            int yy = 0;
            string[] scrn = new string[33];
            for (int i = pos.y - 11; i < pos.y + 10; i++)
            {
                for (int j = pos.x - 17; j < pos.x + 16; j++)
                {
                    if (map[j][i].over == ' ') scrn[yy] += map[j][i].ground;
                    else scrn[yy] += map[j][i].over;
                }
                Console.SetCursorPosition(0, yy);
                Console.Write(scrn[yy]);
                yy++;
            }
        }

        public void Stats()
        {
            Console.SetCursorPosition(34, 2);
            Console.Write("Élet: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int playerHP = 0;
            for (int i = 0; i < level.player.Health; i++)
            {
                Console.Write("█");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(34, 3);
            Console.Write("Sebzés: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(level.player.Damage);
            Console.ForegroundColor = ConsoleColor.White;

        }



    }
}
