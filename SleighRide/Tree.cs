using Raylib_cs;
using System.Numerics;

namespace SleighRide
{
    public class Tree
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;

        public Tree()
        {
            texture = Assets.GetTexture("sleigh");

            position = new Vector2()
            {
                X = Raylib.GetScreenWidth() + 20,
                Y = Raylib.GetScreenHeight() - 30
            };
            size = new Vector2()
            {
                X = 18,
                Y = 20
            };
        }

        public void Update(float _deltaTime)
        {
            // scroll to the left
            position.X -= (200 * _deltaTime);
        }

        public void Draw()
        {
            Rectangle src = new Rectangle()
            {
                X = 160,
                Y = 96,
                Width = 20,
                Height = 20
            };

            Rectangle dest = new Rectangle()
            {
                X = position.X,
                Y = position.Y,
                Width = src.Width * 2,
                Height = src.Height * 2
            };
            Assets.DrawSpriteFromTexture(texture, position, size, src, dest);
        }
    }
}
