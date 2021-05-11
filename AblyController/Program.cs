using System;

using AblyDemoUtils;

namespace AblyController
{
    class Program
    {
        static int Main(string[] args)
        {
            return Application.Run(args, key => {
                Console.WriteLine("Ably Demo: Controller");
                Console.WriteLine("Press 'Q' to quit Game...");

                var ably = new AblyPublisher(key);

                CommandDispatcher.Run(ConsoleKey.Q,
                    () => ably.Publish(AblyPublisher.Command.Up),
                    () => ably.Publish(AblyPublisher.Command.Down),
                    () => ably.Publish(AblyPublisher.Command.Left),
                    () => ably.Publish(AblyPublisher.Command.Right));

                ably.Publish(AblyPublisher.Command.Quit);
                
                return (int) Application.ExitCode.Success;
            });
        }
    }
}
