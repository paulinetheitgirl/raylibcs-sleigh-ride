using Raylib_cs;
using SleighRide;
using System.Numerics;

namespace SleighRide
{
    public class Sleigh
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        public float groundHeight;

        private bool spriteToggle;
        private float rotation = 0f;

        public Sleigh()
        {
            texture = Assets.GetTexture("sleigh");

            position = new Vector2()
            {
                X = 30,
                Y = (Raylib.GetScreenHeight() / 2) - 20
            };

            size = new Vector2()
            {
                X = 48,
                Y = 20
            };
            groundHeight = Raylib.GetScreenHeight() - size.Y - 32;
        }

        public void Update(float _deltaTime, bool _spriteToggle)
        {
            spriteToggle = _spriteToggle;
            if ((bool)Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                int mouseY = Raylib.GetMouseY();
                float heightDelta = position.Y - mouseY;
                if (mouseY < groundHeight && Math.Abs(heightDelta) >= size.Y / 2)  // change in height is significant
                {
                    position.Y -= (int)heightDelta;
                    rotation = heightDelta > 0 ? -30 : 30 ;
                    Task.Delay(100).ContinueWith(task =>
                    {
                        rotation = 0;
                    });
                }
            }
        }

        public void Draw()
        {
            Rectangle src = spriteToggle ? new Rectangle()
            {
                X = 64,
                Y = 28,
                Width = 48,
                Height = 20
            } : new Rectangle()
            {
                X = 160,
                Y = 60,
                Width = 48,
                Height = 20
            };

            Rectangle dest = new Rectangle()
            {
                X = position.X,
                Y = position.Y,
                Width = src.Width * 2,
                Height = src.Height * 2
            };

            Assets.DrawSpriteFromTexture(texture, position, size, src, dest, rotation);
        }
    }
}
