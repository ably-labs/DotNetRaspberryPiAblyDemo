using System.Diagnostics;

using IO.Ably;
using IO.Ably.Realtime;

namespace AblyController
{
    class AblyPublisher
    {
        private readonly AblyRealtime _ably;
        private readonly IRealtimeChannel _channel;
        
        private static readonly string Topic = "demo-controller";
        
        private static void PublishErrorHandler(bool b, ErrorInfo errorInfo)
        {
            Debug.Assert(b);
            Debug.Assert(errorInfo == null);
        }
        
        public enum Command
        {
            Up,
            Down,
            Left,
            Right,
            Quit
        } 
        
        public AblyPublisher(string key)
        {
            _ably = new AblyRealtime(key);
            _channel = _ably.Channels.Get(Topic);
        }

        public void Publish(Command command)
        {
            _channel.Publish(Topic, command.ToString(), PublishErrorHandler);
        }
    }
}