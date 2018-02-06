using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dungeon
{
    class Program
    {
        private const int WIDTH = 70;
        private const int HEIGHT = 28;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = WIDTH;
            Console.WindowHeight = HEIGHT;
            Console.SetBufferSize(WIDTH, HEIGHT);


            Console.SetCursorPosition(0, Console.BufferHeight - 1);
            Console.Write(Console.BufferHeight+" "+Console.BufferWidth);

            Game game = new Game();

            game.Update();

            
        }
    }
}
