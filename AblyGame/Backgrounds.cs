using AblyGame.Surfaces;

namespace AblyGame {
    static class Backgrounds {
        private const uint Mask = 0x00000000;
        
        public static void CreateDefaultBackground(Surface background)
        {
            // private const uint DarkBlue = 0xFF00008B;
            uint  DarkBlue = 0xFF00006B;
            // private const uint DarkViolet = 0xFF9400D3;
            uint DarkViolet = 0xFF7400B3;
        
            int y = 0;
            ColorTools.Interpolate(
                DarkBlue, 
                DarkViolet, 
                Limits.YRes, 
                color => {
                    for (int x = 0; x < Limits.XRes; ++x)
                    {
                        background[x, y] = color;
                    }
                    ++y;
                });
        }

        public static void CreateSmileBackground(Surface background)
        {
            uint midGreen = 0xFF008800;

            Surface smile = new Surface();

            void Plot(int x, int y) => smile[x, y] = midGreen;

            // Mouth.
            for (int x = 2; x < 6; ++x) {
                Plot(x, 6);
            }

            Plot(1, 5);
            Plot(6, 5);
            Plot(1, 4);
            Plot(6, 4);

            // Left eye.
            Plot(1, 2);
            Plot(2, 2);
            Plot(1, 1);
            Plot(2, 1);

            // Right eye.
            Plot(6, 1);
            Plot(5, 2);
            Plot(6, 2);
            Plot(5, 1);
            
            Backgrounds.CreateDefaultBackground(background);
            SurfaceTools.Compose(background, background, smile, Mask);
        }
        
        public static void CreateFrownBackground(Surface background)
        {
            uint midRed = 0xFF880000;

            Surface frown = new Surface();

            void Plot(int x, int y) => frown[x, y] = midRed;

            // Mouth.
            Plot(1, 6);
            Plot(6, 6);
            Plot(1, 5);
            Plot(6, 5);

            for (int x = 2; x < 6; ++x) {
                Plot(x, 4);
            }

            // Left eye.
            Plot(1, 2);
            Plot(2, 2);
            Plot(1, 1);
            Plot(2, 1);

            // Right eye.
            Plot(6, 1);
            Plot(5, 2);
            Plot(6, 2);
            Plot(5, 1);

            Backgrounds.CreateDefaultBackground(background);
            SurfaceTools.Compose(background, background, frown, Mask);  
        }
    }
}