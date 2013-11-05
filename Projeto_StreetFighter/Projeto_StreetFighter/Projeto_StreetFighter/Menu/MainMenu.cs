using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto_StreetFighter.Menu
{
    class MainMenu
    {
        public enum Menu_Opcao {Menu_Start, Menu_Quit}

        public static Menu_Opcao menu_Opcao;


        public static List<Texture2D> Textures_Animation_Start = new List<Texture2D>();
        public static List<Texture2D> Textures_Animation_Quit = new List<Texture2D>();


        public static void ShowSplashScreen()
        {
            if (Game1.Variables.currentWindow == Game1.Variables.CurrentWindow.Menu)
            {
                Animation.Animator_Controller.PlayAnimation(
                    Animation.Animator_Controller.OtherAnimation_enum.SplashScreen_Start);
                menu_Opcao = Menu_Opcao.Menu_Start;
            }
        }
        public static void Update(KeyboardState new_state)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Menu)
                return;

            Keys[] array_keys = new_state.GetPressedKeys();

            if (array_keys.Length == 0)
                return;

            if (!Other.Functions.PermiteKeyPressed(new_state))
                return;

            if (new_state.IsKeyDown(Keys.S))
            {

                Game1.Variables.Input.keyPressed = Keys.S;
                menu_Opcao = Menu_Opcao.Menu_Quit;
                Animation.Animator_Controller.PlayAnimation(
                    Animation.Animator_Controller.OtherAnimation_enum.SplashScreen_Quit);
            }
            else if (new_state.IsKeyDown(Keys.W))
            {
                Game1.Variables.Input.keyPressed = Keys.W;
                menu_Opcao = Menu_Opcao.Menu_Start;
                Animation.Animator_Controller.PlayAnimation(
                    Animation.Animator_Controller.OtherAnimation_enum.SplashScreen_Start);
            }
            else if (new_state.IsKeyDown(Keys.Enter))
            {
                Game1.Variables.Input.keyPressed = Keys.Enter;
                if (menu_Opcao == Menu_Opcao.Menu_Start)
                {
                    Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.SelectPlayer;
                }
                else
                    Game1.Variables.Exit = true;
            }
        }
    }
}
