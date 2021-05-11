using System.Collections.Generic;

namespace AblyGame.Displays
{
    class CompositeDisplay : IDisplay
    {
        private readonly List<IDisplay> _displays;
        
        public CompositeDisplay()
        {
            _displays = new List<IDisplay>();
        }

        public void Add(IDisplay display)
        {
            _displays.Add(display);
        }
        
        public void Draw(int x, int y, uint color)
        {
            foreach (var display in _displays) {
                display.Draw(x, y, color);
            }
        }

        public void Clear()
        {
            foreach (var display in _displays) {
                display.Clear();
            }
        }
    }
}