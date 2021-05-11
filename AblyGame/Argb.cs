namespace AblyGame
{
    readonly struct Argb
    {
        private readonly uint _value;
        public Argb(uint value)
        {
            _value = value;
        }

        public byte A => (byte) (_value >> 24);

        public byte R => (byte) (_value >> 16);

        public byte G => (byte) (_value >> 8);

        public byte B => (byte) (_value >> 0);
        
        public static uint ToUint(byte a, byte r, byte g, byte b)
        {
            return (uint) ((a << 24) | (r << 16) | (g << 8) | (b << 0));
        }
    }
}