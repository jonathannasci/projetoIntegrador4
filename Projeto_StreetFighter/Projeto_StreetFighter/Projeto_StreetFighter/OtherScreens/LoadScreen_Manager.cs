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

        static Texture2D texture_P1;
        static Texture2D texture_P2;

        static ContentManager Content;

        public struct PositionStage
        {
            public static int X;
            public static int Y;
            public static int Width;
            public static int Height;
        }

        static int load_time = 0;

        public static void ShowLoadScreen(ContentManager content)
        {
            Content = content;

            PositionStage.Width = Convert.ToInt32(Game1.Variables.FotoSize.Width * 1.5);
            PositionStage.Height = Game1.Variables.FotoSize.Height;
            PositionStage.X = (Game1.Variables.ResolucaoRectangle.Width / 2) - (PositionStage.Width / 2);
            PositionStage.Y = Game1.Variables.ResolucaoRectangle.Height - 50 - Game1.Variables.FotoSize.Height;

            LoadCharImages();
            texture_screen = Content.Load<Texture2D>("OtherScreens/Load/Load");

            Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Load;
        }

        private static void LoadCharImages()
        {
            switch (Players.Player_Manager.Player_Array[0].Character)
            {
                case Menu.SelectMenu.CharacterList.Char01:
                    texture_P1 = Menu.SelectMenu.Textures_Animation_Char01[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char02:
                    texture_P1 = Menu.SelectMenu.Textures_Animation_Char02[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char03:
                    texture_P1 = Menu.SelectMenu.Textures_Animation_Char03[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char04:
                    texture_P1 = Menu.SelectMenu.Textures_Animation_Char04[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char05:
                    texture_P1 = Menu.SelectMenu.Textures_Animation_Char05[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char06:
                    texture_P1 = Menu.SelectMenu.Textures_Animation_Char06[0];
                    break;
            }

            switch (Players.Player_Manager.Player_Array[1].Character)
            {
                case Menu.SelectMenu.CharacterList.Char01:
                    texture_P2 = Menu.SelectMenu.Textures_Animation_Char01[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char02:
                    texture_P2 = Menu.SelectMenu.Textures_Animation_Char02[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char03:
                    texture_P2 = Menu.SelectMenu.Textures_Animation_Char03[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char04:
                    texture_P2 = Menu.SelectMenu.Textures_Animation_Char04[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char05:
                    texture_P2 = Menu.SelectMenu.Textures_Animation_Char05[0];
                    break;
                case Menu.SelectMenu.CharacterList.Char06:
                    texture_P2 = Menu.SelectMenu.Textures_Animation_Char06[0];
                    break;
            }

        }

        public static void Update(GameTime time)
        {

            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Load)
                return;

            load_time += time.ElapsedGameTime.Milliseconds;

            if (load_time > 5000)
            {
                load_time = 0;
                Players.Player_Manager.LoadGame();
                Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Game;
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Load)
                return;

            spriteBatch.Draw(texture_screen, 
                            new Rectangle(Game1.Variables.ResolucaoRectangle.X, 
                                            Game1.Variables.ResolucaoRectangle.Y, 
                                            Game1.Variables.ResolucaoRectangle.Width, 
                                            Game1.Variables.ResolucaoRectangle.Height),   
                            Color.White);

            spriteBatch.Draw(Menu.SelectStageMenu.texture_Stages[ Convert.ToInt32(Menu.SelectStageMenu.SelectedStage)], 
                            new Rectangle(PositionStage.X, PositionStage.Y, 
                                            PositionStage.Width, 
                                            PositionStage.Height), 
                            Color.White);

            spriteBatch.Draw(texture_P1,
                            new Rectangle((Game1.Variables.ResolucaoRectangle.Width / 2) - (Game1.Variables.FotoSize.Width * 3),
                                            (Game1.Variables.ResolucaoRectangle.Height / 2) - Game1.Variables.FotoSize.Height, 
                                            Game1.Variables.FotoSize.Width * 2, 
                                            Game1.Variables.FotoSize.Height * 2), 
                            Color.White);

            spriteBatch.Draw(texture_P2,
                            new Rectangle((Game1.Variables.ResolucaoRectangle.Width / 2) + Game1.Variables.FotoSize.Width,
                                            (Game1.Variables.ResolucaoRectangle.Height / 2) - Game1.Variables.FotoSize.Height,
                                            Game1.Variables.FotoSize.Width * 2,
                                            Game1.Variables.FotoSize.Height * 2), 
                            null, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            
        }
    }
}
