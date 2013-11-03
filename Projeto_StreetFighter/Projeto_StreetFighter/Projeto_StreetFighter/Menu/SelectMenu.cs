using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Menu
{
    public class SelectMenu
    {
        public enum CharacterList { NULL = 0, Char01 = 1, Char02 = 2, Char03 = 3, Char04 = 4, Char05 = 5, Char06 = 6 }

        public struct PosicaoInicial
        {
            public const int X = 206;
            public const int Y = 377;

            public struct Char02
            {
                public static int X = PosicaoInicial.X + Game1.Variables.FotoSize.Width - 1;
                public static int Y = PosicaoInicial.Y;
            }

            public struct Char03
            {
                public static int X = PosicaoInicial.X + 2 * Game1.Variables.FotoSize.Width - 3;
                public static int Y = PosicaoInicial.Y;
            }

            public struct Char04
            {
                public static int X = PosicaoInicial.X;
                public static int Y = PosicaoInicial.Y + Game1.Variables.FotoSize.Height;
            }

            public struct Char05
            {
                public static int X = PosicaoInicial.X + Game1.Variables.FotoSize.Width - 1;
                public static int Y = PosicaoInicial.Y + Game1.Variables.FotoSize.Height;
            }

            public struct Char06
            {
                public static int X = PosicaoInicial.X + 2 * Game1.Variables.FotoSize.Width - 3;
                public static int Y = PosicaoInicial.Y + Game1.Variables.FotoSize.Height;
            }
        }

        public static ContentManager Content;

        public static List<Texture2D> Textures_Animation_SelectPlayer = new List<Texture2D>();

        public static List<Texture2D> Textures_Animation_Char01 = new List<Texture2D>();
        public static List<Texture2D> Textures_Animation_Char02 = new List<Texture2D>();
        public static List<Texture2D> Textures_Animation_Char03 = new List<Texture2D>();
        //public static List<Texture2D> Textures_Animation_Char04 = new List<Texture2D>();
        //public static List<Texture2D> Textures_Animation_Char05 = new List<Texture2D>();
        //public static List<Texture2D> Textures_Animation_Char06 = new List<Texture2D>();

        public static List<Texture2D> Textures_Animation_Player01 = new List<Texture2D>();
        public static List<Texture2D> Textures_Animation_Player02 = new List<Texture2D>();

        private static int delay = 0;

        public static void ShowSelectMenu()
        {

            if (Game1.Variables.currentWindow == Game1.Variables.CurrentWindow.SelectPlayer)
            {
                LoadSelectMenuAnimation();
                Animation.Animator_Controller.PlayAnimation(
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);
                Players.Player_Manager.Player_Array[0].Character = CharacterList.Char01;
                Players.Player_Manager.Player_Array[1].Character = CharacterList.Char03;
            }
        }
        public static void Update(KeyboardState new_state, GameTime gameTime)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.SelectPlayer)
                return;

            Players.Player P1 = Players.Player_Manager.Player_Array[0];
            Players.Player P2 = Players.Player_Manager.Player_Array[1];

            if (P1.Character == CharacterList.NULL)
            {
                ShowSelectMenu();
                return;
            }

            UpdatePosition(P1);
            UpdatePosition(P2);

            //Keys[] array_keys = new_state.GetPressedKeys();

            //if (array_keys.Length == 0)
            //    return;

            delay += gameTime.ElapsedGameTime.Milliseconds;

            if (delay < 90)
                return;

            delay = 0;

            if (new_state.IsKeyDown(Keys.S))
            {
                if (P1.Character <= CharacterList.Char03)
                {
                    P1.Character += 3;
                }
            }
            else if (new_state.IsKeyDown(Keys.W))
            {
                if (P1.Character >= CharacterList.Char04)
                {
                    P1.Character -= 3;
                }
            }
            else if (new_state.IsKeyDown(Keys.A))
            {
                if (P1.Character != CharacterList.Char01
                    && P1.Character != CharacterList.Char04)
                {
                    P1.Character -= 1;
                }
            }
            else if (new_state.IsKeyDown(Keys.D))
            {
                if (P1.Character != CharacterList.Char03
                    && P1.Character != CharacterList.Char06)
                {
                    P1.Character += 1;
                }
            }
            else if (new_state.IsKeyDown(Keys.Down))
            {
                if (P2.Character <= CharacterList.Char03)
                {
                    P2.Character += 3;
                }
            }
            else if (new_state.IsKeyDown(Keys.Up))
            {
                if (P2.Character >= CharacterList.Char04)
                {
                    P2.Character -= 3;
                }
            }
            else if (new_state.IsKeyDown(Keys.Left))
            {
                if (P2.Character != CharacterList.Char01
                    && P2.Character != CharacterList.Char04)
                {
                    P2.Character -= 1;
                }
            }
            else if (new_state.IsKeyDown(Keys.Right))
            {
                if (P2.Character != CharacterList.Char03
                    && P2.Character != CharacterList.Char06)
                {
                    P2.Character += 1;
                }
            }
            else if (new_state.IsKeyDown(Keys.Enter))
            {

                LoadPlayerCharacter(ref P1);

                LoadPlayerCharacter(ref P2);

                Collision.Collision_Manager.P1 = P1;
                Collision.Collision_Manager.P2 = P2;

                BarraEnergia.BarraEnergia_Manager.LoadBarraEnergia(Content);

                Game1.Variables.currentWindow = Game1.Variables.CurrentWindow.Game;
            }
        }

        private static void UpdatePosition(Players.Player player)
        {
            
            if (player.Character == CharacterList.Char01)
            {
                player.X = PosicaoInicial.X;
                player.Y = PosicaoInicial.Y;
            }
            else if (player.Character == CharacterList.Char02)
            {
                player.X = PosicaoInicial.Char02.X;
                player.Y = PosicaoInicial.Char02.Y;
            }
            else if (player.Character == CharacterList.Char03)
            {
                player.X = PosicaoInicial.Char03.X;
                player.Y = PosicaoInicial.Char03.Y;
            }
            else if (player.Character == CharacterList.Char04)
            {
                player.X = PosicaoInicial.Char04.X;
                player.Y = PosicaoInicial.Char04.Y;
            }
            else if (player.Character == CharacterList.Char05)
            {
                player.X = PosicaoInicial.Char05.X;
                player.Y = PosicaoInicial.Char05.Y;
            }
            else if (player.Character == CharacterList.Char06)
            {
                player.X = PosicaoInicial.Char06.X;
                player.Y = PosicaoInicial.Char06.Y;
            }
        }

        private static void LoadPlayerCharacter(ref Players.Player player)
        {
            string Pasta = "";

            switch (player.Character)
            {
                case CharacterList.Char01:
                    player.CollisionCalc = new Characters.Ryu();
                    Pasta = "Ryu";
                    break;
                case CharacterList.Char02:
                    player.CollisionCalc = new Characters.Ryu();
                    Pasta = "Ryu";
                    break;
                case CharacterList.Char03:
                    player.CollisionCalc = new Characters.Ryu();
                    Pasta = "Ryu";
                    break;
                case CharacterList.Char04:
                    player.CollisionCalc = new Characters.Ryu();
                    Pasta = "Ryu";
                    break;
                case CharacterList.Char05:
                    player.CollisionCalc = new Characters.Ryu();
                    Pasta = "Ryu";
                    break;
                case CharacterList.Char06:
                    player.CollisionCalc = new Characters.Ryu();
                    Pasta = "Ryu";
                    break;
            }

            for (int i = 0; i < 5; i++)
            {
                Other.Functions.LoadTextureFrame(
                    ref player.Character_textures.Normal_Instance,
                    Content.Load<Texture2D>("Characters/"+ Pasta +"/Normal/0" + i.ToString()));
            }

            for (int i = 0; i < 7; i++)
            {
                Other.Functions.LoadTextureFrame(
                    ref player.Character_textures.Normal_Andando_Instance,
                    Content.Load<Texture2D>("Characters/" + Pasta + "/Andando/0" + i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(
                    ref player.Character_textures.Normal_Chute_Forte_Instance,
                    Content.Load<Texture2D>("Characters/" + Pasta + "/Chute_Forte/N0" + i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(
                    ref player.Character_textures.Normal_Chute_Fraco_Instance,
                    Content.Load<Texture2D>("Characters/" + Pasta + "/Chute_Fraco/N0" + i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(
                    ref player.Character_textures.Normal_Soco_Forte_Instance,
                    Content.Load<Texture2D>("Characters/" + Pasta + "/Soco_Forte/N0" + i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(
                    ref player.Character_textures.Normal_Soco_Fraco_Instance,
                    Content.Load<Texture2D>("Characters/" + Pasta + "/Soco_Fraco/N0" + i.ToString()));
            }

            Animation.Animator_Controller.LoadAnimator(
                    player.Character_textures.Normal_Soco_Forte_Instance, player.X, player.Y,
                    Game1.Variables.CharacterSize.Width, Game1.Variables.CharacterSize.Height,
                    Game1.Variables.CurrentWindow.Game, 90,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    player,
                    Players.Player_Manager.PlayerState.Soco_Forte_N, IsGolpe: true);

            Animation.Animator_Controller.LoadAnimator(
                    player.Character_textures.Normal_Soco_Fraco_Instance, player.X, player.Y,
                    Game1.Variables.CharacterSize.Width, Game1.Variables.CharacterSize.Height,
                    Game1.Variables.CurrentWindow.Game, 70,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    player,
                    Players.Player_Manager.PlayerState.Soco_Fraco_N, IsGolpe: true);

            Animation.Animator_Controller.LoadAnimator(
                    player.Character_textures.Normal_Chute_Forte_Instance, player.X, player.Y,
                    Game1.Variables.CharacterSize.Width, Game1.Variables.CharacterSize.Height,
                    Game1.Variables.CurrentWindow.Game, 90,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    player,
                    Players.Player_Manager.PlayerState.Chute_Forte_N, IsGolpe: true);

            Animation.Animator_Controller.LoadAnimator(
                    player.Character_textures.Normal_Chute_Fraco_Instance, player.X, player.Y,
                    Game1.Variables.CharacterSize.Width, Game1.Variables.CharacterSize.Height,
                    Game1.Variables.CurrentWindow.Game, 70,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    player,
                    Players.Player_Manager.PlayerState.Chute_Fraco_N, IsGolpe: true);

            Animation.Animator_Controller.LoadAnimator(
                    player.Character_textures.Normal_Andando_Instance, player.X, player.Y,
                    Game1.Variables.CharacterSize.Width, Game1.Variables.CharacterSize.Height,
                    Game1.Variables.CurrentWindow.Game, 110,
                    Animation.Animator_Controller.AnimationType.Normal,
                    player,
                    Players.Player_Manager.PlayerState.Andando);

            Animation.Animator_Controller.LoadAnimator(
                    player.Character_textures.Normal_Instance, player.X, player.Y,
                    Game1.Variables.CharacterSize.Width, Game1.Variables.CharacterSize.Height,
                    Game1.Variables.CurrentWindow.Game, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    player,
                    Players.Player_Manager.PlayerState.Normal);
        }

        private static void LoadSelectMenuAnimation()
        {
            Other.Functions.LoadTextureFrame(
                ref Textures_Animation_SelectPlayer,
                Content.Load<Texture2D>("SelectPlayer/00"));

            Other.Functions.LoadTextureFrame(
                ref Textures_Animation_Char01,
                Content.Load<Texture2D>("Characters/Ryu/00"));

            Other.Functions.LoadTextureFrame(
                ref Textures_Animation_Char02,
                Content.Load<Texture2D>("Characters/Ken/00"));

            Other.Functions.LoadTextureFrame(
                ref Textures_Animation_Char03,
                Content.Load<Texture2D>("Characters/Sagat/00"));


            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(
                ref Menu.SelectMenu.Textures_Animation_Player01,
                Content.Load<Texture2D>("SelectPlayer/Player01/0" + i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                Other.Functions.LoadTextureFrame(
                ref Menu.SelectMenu.Textures_Animation_Player02,
                Content.Load<Texture2D>("SelectPlayer/Player02/0" + i.ToString()));
            }

            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_SelectPlayer, 0, 0,
                    Game1.Variables.ResolucaoRectangle.Width, Game1.Variables.ResolucaoRectangle.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            
            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_Char01, PosicaoInicial.X, PosicaoInicial.Y,
                    Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_Char02, PosicaoInicial.Char02.X, PosicaoInicial.Char02.Y,
                    Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_Char03, PosicaoInicial.Char03.X, PosicaoInicial.Char03.Y,
                    Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_Char01, PosicaoInicial.Char04.X, PosicaoInicial.Char04.Y,
                    Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_Char02, PosicaoInicial.Char05.X, PosicaoInicial.Char05.Y,
                    Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            Animation.Animator_Controller.LoadAnimator(
                    Textures_Animation_Char03, PosicaoInicial.Char06.X, PosicaoInicial.Char06.Y,
                    Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                    Game1.Variables.CurrentWindow.SelectPlayer, 120,
                    Animation.Animator_Controller.AnimationType.Normal_Reversed,
                    null,
                    Players.Player_Manager.PlayerState.NULL,
                    Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);
            
            
            Animation.Animator_Controller.LoadAnimator(
                Menu.SelectMenu.Textures_Animation_Player01, 0, 0,
                Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                Game1.Variables.CurrentWindow.SelectPlayer,
                100,
                Animation.Animator_Controller.AnimationType.Normal,
                Players.Player_Manager.Player_Array[0],
                Players.Player_Manager.PlayerState.NULL,
                Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);

            Animation.Animator_Controller.LoadAnimator(
                Menu.SelectMenu.Textures_Animation_Player02, 0, 0,
                Game1.Variables.FotoSize.Width, Game1.Variables.FotoSize.Height,
                Game1.Variables.CurrentWindow.SelectPlayer,
                100,
                Animation.Animator_Controller.AnimationType.Normal,
                Players.Player_Manager.Player_Array[1],
                Players.Player_Manager.PlayerState.NULL,
                Animation.Animator_Controller.OtherAnimation_enum.SelectMenu);
        }

    }
}
