using Raylib_cs;
using System.Numerics;

namespace SleighRide
{
    public class Snowflake
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        // sprite velocity
        public float yVelocity;

        private float rotation = 0f;
        private Rectangle srcRect;

        public Snowflake()
        {
            // this is a 6 col/ 3 row sheet of 9x9 sprites
            texture = Assets.GetTexture("snowflakes");

            size = new Vector2()
            {
                X = 9,
                Y = 9
            };

            srcRect = new Rectangle()
            {
                X = 9 * Raylib.GetRandomValue(0, 5),
                Y = 9 * Raylib.GetRandomValue(0,2),
                Width = 9,
                Height = 9
            };

            position = new Vector2()
            {
                X = Raylib.GetRandomValue(0, Raylib.GetScreenWidth() - 9),
                Y = -(size.Y * 3)
            };
        }

        public void Update(float _deltaTime)
        {
            if (position.Y < Raylib.GetScreenHeight())
            { 
                // weak gravity
                yVelocity -= (9.1f * _deltaTime * 0.2f);
            }
            else if (yVelocity != 0)
            {
                // stop descending
                Reset();
            }
            // snowflake falling
            position.Y -= yVelocity;
            rotation++;
        }

        public void Draw()
        {
            Rectangle dest = new Rectangle()
            {
                X = position.X,
                Y = position.Y,
                Width = srcRect.Width * 3,
                Height = srcRect.Height * 3
            };

            Assets.DrawSpriteFromTexture(texture, position, size, srcRect, dest, rotation);
        }

        public void Reset()
        {
            // back to top
            yVelocity = 0;
            position = new Vector2()
            {
                X = Raylib.GetRandomValue(0, Raylib.GetScreenWidth() - 9),
                Y = -(size.Y * 3)
            };
            srcRect = new Rectangle()
            {
                X = 9 * Raylib.GetRandomValue(0, 5),
                Y = 9 * Raylib.GetRandomValue(0, 2),
                Width = 9,
                Height = 9
            };
        }
    }
}
