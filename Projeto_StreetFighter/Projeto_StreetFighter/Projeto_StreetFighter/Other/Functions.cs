using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto_StreetFighter.Other
{
    class Functions
    {
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
    }
}
