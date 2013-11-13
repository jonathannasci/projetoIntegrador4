using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.OtherScreens
{
    public class LoadScreen_Manager
    {
        static Texture2D texture_screen;

        static ContentManager Content;

        static int load_time = 0;

        public static void ShowLoadScreen(ContentManager content)
        {
            Content = content;
        }

        public static void Update(GameTime time)
        {

            if (load_time > 5000)
            {
                Players.Player_Manager.LoadGame();
                Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Game;
            }

        }

        public static void Draw()
        {

        }
    }
}
