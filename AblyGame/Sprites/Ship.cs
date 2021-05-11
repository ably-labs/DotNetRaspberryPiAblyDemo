using AblyGame.Surfaces;

namespace AblyGame
{
    class Ship : Sprite
    {
        private const uint Yellow = 0xFFFFFF00;

        public Ship(Surface surface) : base(surface)
        {
            Reset();
        }

        public override void Draw()
        {
            Draw(Yellow);
        }

        public override void Reset()
        {
            X = 4;
            Y = 6;
        }
    }
}