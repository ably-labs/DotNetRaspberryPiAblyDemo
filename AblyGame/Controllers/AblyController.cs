using System.Collections.Concurrent;

using IO.Ably;
using IO.Ably.Realtime;

namespace AblyGame.Controllers
{
    class AblyController : ControllerBase, IController
    {
        private readonly AblyRealtime _ably;
        private readonly IRealtimeChannel _channel;
        private readonly ConcurrentQueue<string> _messages;
        
        private readonly string Topic = "demo-controller";
        
        public AblyController(string key)
        {
            _ably = new AblyRealtime(key);
            _channel = _ably.Channels.Get(Topic);
            _channel.Subscribe(SubscribeHandler);

            _messages = new ConcurrentQueue<string>();
        }
        
        public void ProcessInput()
        {
            string message;
            if (!_messages.TryDequeue(out message))
            {
                return;
            }

            switch(message)
            {
                case "Up":
                    Up();
                    break;
                case "Down":
                    Down();
                    break;
                case "Left":
                    Left();
                    break; 
                case "Right":
                    Right();
                    break;
                case "Quit":
                    Reset();
                    break;
            };
        }
        
        private void SubscribeHandler(Message m)
        {
            string message = m.Data as string;
            _messages.Enqueue(message);
        }
    }
}