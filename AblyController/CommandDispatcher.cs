using System;
using System.Threading;

namespace AblyController
{
    class CommandDispatcher
    {
        public static void Run(ConsoleKey quit, Action up, Action down, Action left, Action right)
        {
            bool isControllerRunning = true;
            while (isControllerRunning)
            {
                Thread.Sleep(200);

                if (!Console.KeyAvailable)
                {
                    continue;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;
                if (key == quit)
                {
                    isControllerRunning = false;
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    up();
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    down();
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    left();
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    right();
                }
            }       
        }
  
    }
}