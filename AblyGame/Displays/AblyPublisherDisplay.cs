using System.Diagnostics;

using IO.Ably;
using IO.Ably.Realtime;

namespace AblyGame.Displays
{
    class AblyPublisherDisplay : IDisplay
    {
        private readonly AblyRealtime _ably;
        private readonly IRealtimeChannel _channel;
        
        private readonly string Topic = "demo-display";
        
        public AblyPublisherDisplay(string key)
        {
            _ably = new AblyRealtime(key);
            _channel = _ably.Channels.Get(Topic);         
        }
        
        public void Draw(int x, int y, uint color)
        {
            Publish($"{x},{y},{color}");
        }

        public void Clear()
        {
            Publish("Clear");
        }

        private void Publish(string message)
        {
            _channel.Publish(Topic, message, PublishErrorHandler);
        }
        
        private static void PublishErrorHandler(bool b, ErrorInfo errorInfo)
        {
            Debug.Assert(b);
            Debug.Assert(errorInfo == null);
        }
    }
}