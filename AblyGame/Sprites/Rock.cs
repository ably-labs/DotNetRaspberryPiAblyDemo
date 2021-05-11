using System;

using AblyGame.Surfaces;

namespace AblyGame
{
    class Rock: Sprite
    {
        private const uint Gray = 0xFF808080;

        private readonly Random _rng;

        private int RandomXPos()
        {
            return _rng.Next(0, Limits.XRes);
        }

        public Rock(Surface surface): base(surface)
        {
            _rng = new Random(DateTime.Now.Millisecond);
            X = RandomXPos();
        }

        public override void Update()
        {
            ++Y;
            if (Y == Limits.YRes)
            {
                X = RandomXPos();
                Y = 0;
            }
        }

        public override void Draw()
        {
            Draw(Gray);
        }
    }
}