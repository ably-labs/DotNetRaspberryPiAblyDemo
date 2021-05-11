using AblyGame.Surfaces;

namespace AblyGame
{
    class Sprite
    {
        private Surface _surface;

        protected void Draw(uint color)
        {
            _surface[X, Y] = color;
        }
        
        public int X { get; set; }
        public int Y { get; set; }
        
        public Sprite(Surface surface)
        {
            _surface = surface;
            X = 0;
            Y = 0;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }

        public virtual void Reset()
        {
        }
    }
}