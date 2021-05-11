namespace AblyGame.Displays
{
    interface IDisplay
    {
        void Draw(int x, int y, uint color);

        void Clear();
    }
}