using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dungeon
{
    
    
    class Level
    {
        public List<List<Mapchar>> map;
        public int MAX_HEIGHT = 500;
        public int MAX_WIDTH = 500;

        public Player player;

        public Level()
        {
            map = new List<List<Mapchar>>();
            for (int i = 0; i < MAX_HEIGHT + 20; i++)
            {
                map.Add(new List<Mapchar>());
                for (int j = 0; j < MAX_WIDTH + 20; j++)
                {
                    map[i].Add(new Mapchar(' ', ' '));
                }
            }

            
            map[33][22] = new Mapchar('#', '#');

            Random r = new Random();

            for (int i = 17; i < MAX_HEIGHT; i++)
            {
                for (int j = 11; j < MAX_WIDTH; j++)
                {
                    map[i][j] = r.Next(0, 100) > 95 ? new Mapchar('#', '#') : new Mapchar(' ', ' ');
                    if (i == MAX_HEIGHT - 1 || j == MAX_WIDTH - 1 || i == 17 || j == 11 || (i == MAX_HEIGHT - 1 && j == MAX_WIDTH - 1) || (i == 17 && j == 11)) map[i][j] = new Mapchar('#', '#');
                }
            }

            map[16][10] = new Mapchar('█', '█');
            player = new Player(this, new Position(480, 480), ConsoleColor.White, 25, 1);
            
        }

        public bool Update()
        {
            var input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.Escape) return false;

            player.Move(map, input);


            

            return true;
        }

        


    }
}
