namespace AblyGame.Surfaces
{
    public class Surface
    {
        private uint[,] _data;

        public Surface()
        {
            _data = new uint[Limits.XRes, Limits.YRes];
        }

        public uint this[int x, int y]
        {
            get { return _data[x, y]; }
            set { _data[x, y] = value; }
        }
    }
}