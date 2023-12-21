using Raylib_cs;
using System.Numerics;

namespace SleighRide
{
    public class Game
    {
        private bool isPlaying;
        private float timer = 0;
        private static float ANIMATION_INTERVAL = 1;
        // characters
        private Sleigh sleigh;
        private List<Ground> grounds = new List<Ground>();
        private List<Tree> trees = new List<Tree>();
        private bool sleighToggle = true;
        private Snowflake snowflake;
        #region Setup
        public const string NAME = "Sleigh Ride";
        public const int WIDTH = 560;
        public const int HEIGHT = 320;

        public void Run()
        {
            Raylib.SetTargetFPS(60);
            Raylib.InitWindow(WIDTH, HEIGHT, NAME);

            Assets.Init(NAME);
            Load();

            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();
                Update(dt);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(new Color(173, 193, 214, 255));

                Draw();

                Raylib.EndDrawing();
            }

            Unload();
            Raylib.CloseWindow();
        }
        #endregion

        public void Load()
        {
            sleigh = new Sleigh();
            int visibleBackgrounds = (int)Math.Ceiling((double)WIDTH / 56);
            for (int i = 0; i < visibleBackgrounds; i++)
            {
                grounds.Add(new Ground(false, i));
            }
            grounds.Add(new Ground(true, visibleBackgrounds));
            snowflake = new Snowflake();
        }

        public void Update(float _deltaTime)
        {
            if (isPlaying)
            {
                if (timer < ANIMATION_INTERVAL)
                {
                    timer += _deltaTime;
                }
                else
                {
                    timer = 0;
                    sleighToggle = !sleighToggle;
                    trees.Add(new Tree());
                }
                sleigh.Update(_deltaTime, sleighToggle);
                snowflake.Update(_deltaTime);
                for (int i = 0; i < grounds.Count; i++)
                {
                    Ground g = grounds[i];
                    Vector2 size = g.size;
                    g.Update(_deltaTime);

                    if (g.position.X < -size.X)
                    {
                        grounds.Remove(g);
                        grounds.Add(new Ground(true, i));
                        i--;
                    }
                }
                for (int i = 0; i < trees.Count; i++)
                {
                    Tree t = trees[i];
                    Vector2 size = t.size;
                    t.Update(_deltaTime);

                    if (t.position.X < -size.X)
                    {
                        trees.Remove(t);
                        i--;
                    }
                }
            }
            else
            {
                if ((bool)Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    isPlaying = true;
                }
            }
        }

        public void Draw()
        {
            snowflake.Draw();
            foreach (Ground g in grounds)
            {
                g.Draw();
            }
            foreach (Tree t in trees)
            {
                t.Draw();
            }
            sleigh.Draw();
            
            if (!isPlaying)
            {
                int fontSize = 24;
                string instructions = "Click to Start";
                int textWidth = Raylib.MeasureText(instructions, fontSize);
                Raylib.DrawText(instructions, (int)Raylib.GetScreenWidth() / 2 - (textWidth / 2), (int)Raylib.GetScreenHeight() / 2, fontSize, Color.BLACK);
            }
        }

        public void Unload()
        {
            Assets.Close();
        }
    }
}
