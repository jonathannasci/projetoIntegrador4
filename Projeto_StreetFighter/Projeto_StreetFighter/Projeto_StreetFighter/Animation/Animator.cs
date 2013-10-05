using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Animation
{
    class Animator
    {
        public List<Texture2D> textures_array = new List<Texture2D>();
        public int current_freme_index = 0;

        public int X, Y, Width, Height;

        public Game1.Variables.CurrentWindow window;

        public int time_counter;
        public int speedInMilliSecs;

        public void Update(GameTime time)
        {
            time_counter += time.ElapsedGameTime.Milliseconds;
            if (time_counter > speedInMilliSecs)
            {
                time_counter = 0;
                current_freme_index++;

                if (current_freme_index >= textures_array.Count)
                    current_freme_index = 0;
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            if (Game1.Variables.currentWindow != window)
                return;

            sprite.Draw(textures_array[current_freme_index], new Rectangle(X, Y, Width, Height), Color.White);

        }
    }
}
