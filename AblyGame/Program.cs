using System.Threading;

using AblyGame.Controllers;
using AblyGame.Displays;

using AblyDemoUtils;

namespace AblyGame
{
    class Limits
    {
        public const int XRes = 8;
        public const int YRes = 8;
    }

    class Program {
        static int Main(string[] args)
        {
            return Application.Run(args, key => {
                IDisplay display = new SenseHatDisplay();
                IController controller = new AblyController(key);
                
                var game = new Game(display, controller);
                while (game.IsRunning)
                {
                    controller.ProcessInput();
                
                    game.Update();
                    game.Draw();

                    Thread.Sleep(200);
                }
                display.Clear();

                return (int) Application.ExitCode.Success;
            });
        }
    }
}
