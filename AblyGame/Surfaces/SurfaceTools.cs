namespace AblyGame.Surfaces
{
    static class SurfaceTools
    {
        public static void Compose(Surface destination, Surface first, Surface second, uint mask)
        {
            for (int y = 0; y < Limits.YRes; ++y)
            {
                for (int x = 0; x < Limits.XRes; ++x)
                {
                    uint secondPixel = second[x, y];
                    destination[x, y] = mask == secondPixel ? first[x, y] : secondPixel;
                }
            }
        }
    }
}