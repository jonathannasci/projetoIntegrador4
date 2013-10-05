using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto_StreetFighter.Menu
{
    class SplashScreen
    {
        public static List<Texture2D> Textures_array = new List<Texture2D>();

        public static void Update(KeyboardState new_state)
        {
            Keys[] array_keys = new_state.GetPressedKeys();

            if (array_keys.Length == 0)
                return;
            
            Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Menu;
        }
    }
}
