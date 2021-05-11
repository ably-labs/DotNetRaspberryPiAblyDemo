using System;

namespace AblyGame.Controllers
{
    class KeyBoardController: ControllerBase, IController
    {
        public void ProcessInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }
            
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Q:
                    Reset();
                    break;
                case ConsoleKey.UpArrow:
                    Up();
                    break;
                case ConsoleKey.DownArrow:
                    Down();
                    break;
                case ConsoleKey.LeftArrow:
                    Left();
                    break;
                case ConsoleKey.RightArrow:
                    Right();
                    break;
            }
        }
    }
}