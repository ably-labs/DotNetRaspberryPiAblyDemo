using System;

namespace AblyGame
{
    static class ColorTools
    {
        public static void Interpolate(uint startColor, uint endColor, byte steps, Action<uint> onStep)
        {
            var start = new Argb(startColor);
            var end = new Argb(endColor);

            int stepR = (start.R - end.R) / steps;
            int stepG = (start.G - end.G) / steps;
            int stepB = (start.B - end.B) / steps;

            int r = end.R;
            int g = end.G;
            int b = end.B;

            for (int i = 0; i < steps; ++i)
            {
                onStep(Argb.ToUint(0, (byte)r, (byte)g, (byte)b));
                
                r += stepR;
                g += stepG;
                b += stepB;
            }    
        }
    }
}