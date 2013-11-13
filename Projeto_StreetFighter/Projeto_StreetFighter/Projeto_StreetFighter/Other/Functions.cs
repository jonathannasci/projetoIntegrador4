using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto_StreetFighter.Other
{
    public class Functions
    {
        public static FrmQuit TelaQuit = new Other.FrmQuit();
        
        public static void LoadTextureFrame(ref List<Texture2D> list, Texture2D frame)
        {
            list.Add(frame);
        }

        public static bool PermiteKeyPressed(KeyboardState new_state)
        {
            bool retorno = true;

            if (new_state.IsKeyUp(Game1.Variables.Input.keyPressed))
            {
                Game1.Variables.Input.keyPressed = Keys.None;
            }

            if (new_state.IsKeyDown(Game1.Variables.Input.keyPressed))
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool PermiteKeyPressed(KeyboardState new_state,ref Keys keyPressed)
        {
            bool retorno = true;

            if (new_state.IsKeyUp(keyPressed))
            {
                keyPressed = Keys.None;
            }

            if (new_state.IsKeyDown(keyPressed))
            {
                retorno = false;
            }

            return retorno;
        }

        public static void Update(KeyboardState new_state)
        {
            if (Game1.Variables.currentWindow == Game1.Variables.CurrentWindow.Menu)
                return;

            if (new_state.IsKeyDown(Keys.Escape))
            {
                Game1.Variables.Paused = true;
                if (TelaQuit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Menu;
                    Players.Player_Manager.Player_Array = new List<Players.Player>();
                    Players.Player_Manager.AddPlayer();
                    Players.Player_Manager.AddPlayer();
                    
                    Menu.MainMenu.ShowSplashScreen();
                    Game1.Variables.Input.keyPressed = Keys.None;
                }
                Game1.Variables.Paused = false;

            }
        }

    }
}
