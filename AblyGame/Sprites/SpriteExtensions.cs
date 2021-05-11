namespace AblyGame
{
    static class SpriteExtensions
    {
        public static void MoveLeft(this Sprite sprite)
        {
            if (sprite.X > 0)
            {
                sprite.X--;
            }
        }

        public static void MoveRight(this Sprite sprite)
        {
            if (sprite.X < Limits.XRes - 1)
            {
                sprite.X++;
            }
        }

        public static void MoveDown(this Sprite sprite)
        {
            if (sprite.Y > 0)
            {
                sprite.Y--;
            }
        }
    }
}