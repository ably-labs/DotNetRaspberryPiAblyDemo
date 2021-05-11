using System.Drawing;

using Iot.Device.SenseHat;

namespace AblyGame.Displays
{
    class SenseHatDisplay: IDisplay
    {
        SenseHat _sh;

        public SenseHatDisplay() => _sh = new SenseHat();

        public void Draw(int x, int y, uint c) => _sh.SetPixel(x, y, UIntToColor(c));

        public void Clear() => _sh.LedMatrix.Fill(Color.Black);
        
        private static Color UIntToColor(uint color)
        {
            var argb = new Argb(color);
            return Color.FromArgb(argb.A, argb.R, argb.G, argb.B);
        }
    }
}