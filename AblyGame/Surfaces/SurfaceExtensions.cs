using System;
using System.Text;

namespace AblyGame.Surfaces
{
    static class SurfaceExtensions
    {
        public static void Diff(this Surface first, Surface second, Action<int, int, uint> onDiff)
        {
            for (int y = 0; y < Limits.YRes; ++y)
            {
                for (int x = 0; x < Limits.XRes; ++x)
                {
                    var secondColor = second[x, y];
                    if (first[x, y] != secondColor)
                    {
                        onDiff(x, y, secondColor);
                    }
                }
            }
        }

        public static void Fill(this Surface surface, uint color)
        {
            for (int y = 0; y < Limits.YRes; ++y)
            {
                for (int x = 0; x < Limits.XRes; ++x)
                {
                    surface[x, y] = color;
                }
            }
        }
        
        public static string Dump(this Surface surface)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Limits.YRes; ++y)
            {
                sb.Append(surface[0, y].ToString("X8"));
                for (int x = 1; x < Limits.XRes; ++x)
                {
                    sb.Append(", ");
                    sb.Append(surface[x, y].ToString("X8"));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}