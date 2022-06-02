using System;
using OpenTK;


namespace Endless_Sky
{
    static class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(1000, 560);
            Game game = new Game(window);
        }
    }
}
