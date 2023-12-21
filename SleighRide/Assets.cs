using Raylib_cs;
using System.Numerics;

namespace SleighRide
{
    public static class Assets
    {
        private static readonly Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static Texture2D GetTexture(string _name) => textures[_name];

        public static void DrawTexture(Texture2D _texture, Vector2 _position, Vector2 _size, float _rotation = 0)
        {
            Rectangle src = new Rectangle()
            {
                X = 0,
                Y = 0,
                Width = _texture.Width,
                Height = _texture.Height
            };

            Rectangle dest = new Rectangle()
            {
                X = _position.X,
                Y = _position.Y,
                Width = _size.X,
                Height = _size.Y
            };

            Raylib.DrawTexturePro(_texture, src, dest, Vector2.Zero, _rotation, Color.WHITE);
        }

        public static void DrawSpriteFromTexture(Texture2D _texture, 
            Vector2 _position, 
            Vector2 _size, 
            Rectangle _source,
            Rectangle _dest, 
            float _rotation = 0)
        {
            Raylib.DrawTexturePro(_texture, _source, _dest, Vector2.Zero, _rotation, new Color(255, 255, 255, 255));
        }

        public static void Init(string _projName)
        {
            string directory = Directory.GetCurrentDirectory();
            string texturesDir = Path.Combine(directory, $"resources");
            Console.WriteLine(texturesDir);
            Load(texturesDir);
        }

        public static void Close()
        {
            foreach (var texture in textures)
            {
                Raylib.UnloadTexture(texture.Value);
            }
        }

        private static void Load(string _dir)
        {
            textures.Add("background", Raylib.LoadTexture($"{_dir}/8bit_yeti_sprite_sheet.png"));
            textures.Add("sleigh", Raylib.LoadTexture($"{_dir}/zombcool_sprite_sheet.png"));
            textures.Add("snowflakes", Raylib.LoadTexture($"{_dir}/alxl_sprite_sheet.png"));
        }
    }
}
