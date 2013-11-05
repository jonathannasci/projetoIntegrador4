using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Menu
{
    public class SelectStageMenu
    {

        public enum Stages { NULL = -1, St00 = 0, St01 = 1, St02 = 2, St03 = 3, St04 = 4, St05 = 5 }

        public struct PosicaoInicial
        {
            public const int X = 206;
            public const int Y = 377;

            public struct St01
            {
                public static int X = PosicaoInicial.X + Game1.Variables.FotoSize.Width - 1;
                public static int Y = PosicaoInicial.Y;
            }

            public struct St02
            {
                public static int X = PosicaoInicial.X + 2 * Game1.Variables.FotoSize.Width - 3;
                public static int Y = PosicaoInicial.Y;
            }

            public struct St03
            {
                public static int X = PosicaoInicial.X;
                public static int Y = PosicaoInicial.Y + Game1.Variables.FotoSize.Height;
            }

            public struct St04
            {
                public static int X = PosicaoInicial.X + Game1.Variables.FotoSize.Width - 1;
                public static int Y = PosicaoInicial.Y + Game1.Variables.FotoSize.Height;
            }

            public struct St05
            {
                public static int X = PosicaoInicial.X + 2 * Game1.Variables.FotoSize.Width - 3;
                public static int Y = PosicaoInicial.Y + Game1.Variables.FotoSize.Height;
            }
        }

        static Texture2D texture_TelaStages;
        static List<Texture2D> texture_Stages = new List<Texture2D>();

        public static Stages SelectedStage = Stages.NULL;
        public static List<Texture2D> Textures_Animation_Selector = new List<Texture2D>();

        static Players.Player P1;

        //static int delay;

        static ContentManager Content;


        public static void LoadSelectStageMenu(ContentManager content)
        {
            Content = content;

            SelectedStage = Stages.St00;

            P1 = Players.Player_Manager.Player_Array[0];

            LoadAnimations();
            

        }

        private static void LoadAnimations()
        {
            texture_TelaStages = Content.Load<Texture2D>("SelectPlayer/00");

            for (int i = 0; i < 6; i++)
            {
                Other.Functions.LoadTextureFrame(ref texture_Stages, Content.Load<Texture2D>("Stages/0" + i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(ref Textures_Animation_Selector, Content.Load<Texture2D>("SelectPlayer/Player01/0" + i.ToString()));
            }

            Animation.Animator_Controller.LoadAnimator(
                Textures_Animation_Selector, 0, 0,
                Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                Game1.Variables.CurrentWindow.SelectStage,
                100,
                Animation.Animator_Controller.AnimationType.Normal,
                Players.Player_Manager.Player_Array[0],
                Players.Player_Manager.PlayerState.NULL,
                Animation.Animator_Controller.OtherAnimation_enum.SelectStage);

            Animation.Animator_Controller.PlayAnimation(Animation.Animator_Controller.OtherAnimation_enum.SelectStage);
        }


        public static void Update(KeyboardState  new_key, GameTime gameTime)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.SelectStage)
                return;

            UpdatePosition(P1);

            if (!Other.Functions.PermiteKeyPressed(new_key))
                return;

            //delay += gameTime.ElapsedGameTime.Milliseconds;

            //if (delay < 90)
            //    return;

            //delay = 0;

            if (new_key.IsKeyDown(Keys.S))
            {

                Game1.Variables.Input.keyPressed = Keys.S;
                if (SelectedStage <= Stages.St02)
                {
                    SelectedStage += 3;
                }
            }
            else if (new_key.IsKeyDown(Keys.W))
            {

                Game1.Variables.Input.keyPressed = Keys.W;
                if (SelectedStage >= Stages.St03)
                {
                    SelectedStage -= 3;
                }
            }
            else if (new_key.IsKeyDown(Keys.A))
            {

                Game1.Variables.Input.keyPressed = Keys.A;
                if (SelectedStage != Stages.St00
                    && SelectedStage != Stages.St03)
                {
                    SelectedStage -= 1;
                }
            }
            else if (new_key.IsKeyDown(Keys.D))
            {

                Game1.Variables.Input.keyPressed = Keys.D;
                if (SelectedStage != Stages.St02
                    && SelectedStage != Stages.St05)
                {
                    SelectedStage += 1;
                }
            }
            else if (new_key.IsKeyDown(Keys.Enter))
            {
                Game1.Variables.Input.keyPressed = Keys.Enter;
                Players.Player_Manager.LoadGame();
                Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Game;
            }

        }

        private static void UpdatePosition(Players.Player player)
        {

            switch (SelectedStage)
            {
                case Stages.St00:
                    player.X = PosicaoInicial.X;
                    player.Y = PosicaoInicial.Y;
                    break;
                case Stages.St01:
                    player.X = PosicaoInicial.St01.X;
                    player.Y = PosicaoInicial.St01.Y;
                    break;
                case Stages.St02:
                    player.X = PosicaoInicial.St02.X;
                    player.Y = PosicaoInicial.St02.Y;
                    break;
                case Stages.St03:
                    player.X = PosicaoInicial.St03.X;
                    player.Y = PosicaoInicial.St03.Y;
                    break;
                case Stages.St04:
                    player.X = PosicaoInicial.St04.X;
                    player.Y = PosicaoInicial.St04.Y;
                    break;
                case Stages.St05:
                    player.X = PosicaoInicial.St05.X;
                    player.Y = PosicaoInicial.St05.Y;
                    break;
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if(Game1.Variables.currentWindow == Game1.Variables.CurrentWindow.Game)
                spriteBatch.Draw(texture_Stages[(int)SelectedStage], new Rectangle(-170, 0, 1365, Game1.Variables.ResolucaoRectangle.Height), Color.White);

            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.SelectStage)
                return;


            spriteBatch.Draw(texture_TelaStages, new Rectangle(0, 0, Game1.Variables.ResolucaoRectangle.Width , Game1.Variables.ResolucaoRectangle.Height),Color.White);

            spriteBatch.Draw(texture_Stages[0], new Rectangle(PosicaoInicial.X, PosicaoInicial.Y, Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height), Color.White);
            spriteBatch.Draw(texture_Stages[1], new Rectangle(PosicaoInicial.St01.X, PosicaoInicial.St01.Y, Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height), Color.White);
            spriteBatch.Draw(texture_Stages[2], new Rectangle(PosicaoInicial.St02.X, PosicaoInicial.St02.Y, Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height), Color.White);
            spriteBatch.Draw(texture_Stages[3], new Rectangle(PosicaoInicial.St03.X, PosicaoInicial.St03.Y, Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height), Color.White);
            spriteBatch.Draw(texture_Stages[4], new Rectangle(PosicaoInicial.St04.X, PosicaoInicial.St04.Y, Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height), Color.White);
            spriteBatch.Draw(texture_Stages[5], new Rectangle(PosicaoInicial.St05.X, PosicaoInicial.St05.Y, Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height), Color.White);

        }



    }
}
