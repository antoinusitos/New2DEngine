using System;

namespace _2DEngine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new _Engine.Engine();
            game.Run();
        }
    }
}
