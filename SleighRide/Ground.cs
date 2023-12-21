using Raylib_cs;
using System.Numerics;

namespace SleighRide
{
    public class Ground
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;

        public Ground(bool _isOffscreen, int index)
        {
            texture = Assets.GetTexture("background");

            position = new Vector2()
            {
                X = (56 * index),
                Y = Raylib.GetScreenHeight() - 32
            };

            if (_isOffscreen)
            {
                 position.X = Raylib.GetScreenWidth();
            }

            size = new Vector2()
            { 
                X = 56,
                Y = 32
            };
        }

        public void Update(float _deltaTime)
        {
            // scroll to the left
            position.X -= (60 * _deltaTime);
        }

        public void Draw()
        {
            Rectangle src = new Rectangle()
            {
                X = 0,
                Y = 40,
                Width = 56,
                Height = 32
            };

            Rectangle dest = new Rectangle()
            {
                X = position.X,
                Y = position.Y,
                Width = src.Width + 1,
                Height = src.Height
            };
            Assets.DrawSpriteFromTexture(texture, position, size, src, dest);
        }
    }
}
