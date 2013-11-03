using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projeto_StreetFighter
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        public struct Variables
        {
            public static bool Exit = false;

            public static Rectangle ResolucaoRectangle = new Rectangle(0, 0, 1024, 768);

            public static Rectangle GameRectangle = new Rectangle(
                0, 0, ResolucaoRectangle.Width, ResolucaoRectangle.Height - 100);

            public enum CurrentWindow { Menu, SelectPlayer, Load ,Game }
            public static CurrentWindow currentWindow = CurrentWindow.Menu;

            public struct Input
            {
                public static KeyboardState Prev_Key, New_Key;
                public static MouseState Prev_Mouse, New_Mouse;
            }

            public struct CharacterSize
            {
                public static int Width = 213;
                public static int Height = 192;
            }

            public struct FotoSize
            {
                public static int Width = 155;
                public static int Height = 156;
            }
        }

        

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth =  Variables.ResolucaoRectangle.Width;
            graphics.PreferredBackBufferHeight = Variables.ResolucaoRectangle.Height;
            graphics.ApplyChanges();
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Other.Functions.LoadTextureFrame(
            //    ref Characters.Character.Textures.Normal_Instance,
            //    Content.Load<Texture2D>("Characters/Ken/Ken_Normal"));


            //for (int i = 0; i < 5; i++)
            //{
            //    Other.Functions.LoadTextureFrame(
            //        ref Characters.Character.Textures.Normal_Instance,
            //        Content.Load<Texture2D>("Characters/Ryu/Normal/0" + i.ToString()));
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    Other.Functions.LoadTextureFrame(
            //        ref Characters.Character.Textures.Normal_Andando_Instance,
            //        Content.Load<Texture2D>("Characters/Ryu/Andando/0" + i.ToString()));
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    Other.Functions.LoadTextureFrame(
            //        ref Characters.Character.Textures.Normal_Chute_Forte_Instance,
            //        Content.Load<Texture2D>("Characters/Ryu/Chute_Forte/N0" + i.ToString()));
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    Other.Functions.LoadTextureFrame(
            //        ref Characters.Character.Textures.Normal_Chute_Fraco_Instance,
            //        Content.Load<Texture2D>("Characters/Ryu/Chute_Fraco/N0" + i.ToString()));
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    Other.Functions.LoadTextureFrame(
            //        ref Characters.Character.Textures.Normal_Soco_Forte_Instance,
            //        Content.Load<Texture2D>("Characters/Ryu/Soco_Forte/N0" + i.ToString()));
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    Other.Functions.LoadTextureFrame(
            //        ref Characters.Character.Textures.Normal_Soco_Fraco_Instance,
            //        Content.Load<Texture2D>("Characters/Ryu/Soco_Fraco/N0" + i.ToString()));
            //}

            for (int i = 0; i < 4; i++)
            {
                Other.Functions.LoadTextureFrame(
                ref Menu.MainMenu.Textures_Animation_Start,
                Content.Load<Texture2D>("Menu/Start/0" + i.ToString()));
            }

            for (int i = 0; i < 4; i++)
            {
                Other.Functions.LoadTextureFrame(
                ref Menu.MainMenu.Textures_Animation_Quit,
                Content.Load<Texture2D>("Menu/Quit/0" + i.ToString()));
            }

            

            Menu.SelectMenu.Content = Content;

            Players.Player_Manager.AddPlayer();
            Players.Player_Manager.AddPlayer();

            LoadOthersAnimation();
            //LoadCharactersAnimation();

            Menu.MainMenu.ShowSplashScreen();

        }

        public static void LoadOthersAnimation()
        {
            Animation.Animator_Controller.LoadAnimator(
                Menu.MainMenu.Textures_Animation_Start, 0, 0,
                Variables.ResolucaoRectangle.Width, Variables.ResolucaoRectangle.Height,
                Variables.CurrentWindow.Menu,
                100,
                Animation.Animator_Controller.AnimationType.Normal_Reversed, null,
                Players.Player_Manager.PlayerState.NULL,
                Animation.Animator_Controller.OtherAnimation_enum.SplashScreen_Start);

            Animation.Animator_Controller.LoadAnimator(
                Menu.MainMenu.Textures_Animation_Quit, 0, 0,
                Variables.ResolucaoRectangle.Width, Variables.ResolucaoRectangle.Height,
                Variables.CurrentWindow.Menu,
                100,
                Animation.Animator_Controller.AnimationType.Normal_Reversed, null,
                Players.Player_Manager.PlayerState.NULL,
                Animation.Animator_Controller.OtherAnimation_enum.SplashScreen_Quit);

            
        }

        //public static void LoadCharactersAnimation()
        //{
        //    Animation.Animator_Controller.LoadAnimator(
        //            Characters.Character.Textures.Normal_Soco_Forte_Instance, 200, 400,
        //            Variables.CharacterSize.Width, Variables.CharacterSize.Height,
        //            Game1.Variables.CurrentWindow.Game, 90,
        //            Animation.Animator_Controller.AnimationType.Normal_Reversed,
        //            Players.Player_Manager.Player_Array[0],
        //            Players.Player_Manager.PlayerState.Soco_Forte_N, IsGolpe: true);

        //    Animation.Animator_Controller.LoadAnimator(
        //            Characters.Character.Textures.Normal_Soco_Fraco_Instance, 200, 400,
        //            Variables.CharacterSize.Width, Variables.CharacterSize.Height,
        //            Game1.Variables.CurrentWindow.Game, 70,
        //            Animation.Animator_Controller.AnimationType.Normal_Reversed,
        //            Players.Player_Manager.Player_Array[0],
        //            Players.Player_Manager.PlayerState.Soco_Fraco_N, IsGolpe: true);

        //    Animation.Animator_Controller.LoadAnimator(
        //            Characters.Character.Textures.Normal_Chute_Forte_Instance, 200, 400,
        //            Variables.CharacterSize.Width, Variables.CharacterSize.Height,
        //            Game1.Variables.CurrentWindow.Game, 90,
        //            Animation.Animator_Controller.AnimationType.Normal_Reversed,
        //            Players.Player_Manager.Player_Array[0],
        //            Players.Player_Manager.PlayerState.Chute_Forte_N, IsGolpe: true);

        //    Animation.Animator_Controller.LoadAnimator(
        //            Characters.Character.Textures.Normal_Chute_Fraco_Instance, 200, 400,
        //            Variables.CharacterSize.Width, Variables.CharacterSize.Height,
        //            Game1.Variables.CurrentWindow.Game, 70,
        //            Animation.Animator_Controller.AnimationType.Normal_Reversed,
        //            Players.Player_Manager.Player_Array[0],
        //            Players.Player_Manager.PlayerState.Chute_Fraco_N, IsGolpe: true);

        //    Animation.Animator_Controller.LoadAnimator(
        //            Characters.Character.Textures.Normal_Andando_Instance, 200, 400,
        //            Variables.CharacterSize.Width, Variables.CharacterSize.Height,
        //            Game1.Variables.CurrentWindow.Game, 110,
        //            Animation.Animator_Controller.AnimationType.Normal,
        //            Players.Player_Manager.Player_Array[0],
        //            Players.Player_Manager.PlayerState.Andando);

        //    Animation.Animator_Controller.LoadAnimator(
        //        Characters.Character.Textures.Normal_Instance, 200, 400,
        //        Variables.CharacterSize.Width, Variables.CharacterSize.Height,
        //        Game1.Variables.CurrentWindow.Game, 120,
        //        Animation.Animator_Controller.AnimationType.Normal_Reversed,
        //        Players.Player_Manager.Player_Array[0],
        //        Players.Player_Manager.PlayerState.Normal);
        //}

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Variables.Exit)
                this.Exit();

            //get the input
            Variables.Input.Prev_Key = Variables.Input.New_Key;
            Variables.Input.New_Key = Keyboard.GetState();

            Variables.Input.Prev_Mouse = Variables.Input.New_Mouse;
            Variables.Input.New_Mouse = Mouse.GetState();

            Animation.Animator_Controller.UpdateAll(gameTime);

            Menu.MainMenu.Update(Variables.Input.New_Key);
            Menu.SelectMenu.Update(Variables.Input.New_Key, gameTime);
            Players.Player_Manager.Update(Variables.Input.Prev_Key, Variables.Input.New_Key, gameTime);
            Collision.Collision_Manager.Update();
            BarraEnergia.BarraEnergia_Manager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            Animation.Animator_Controller.DrawAll(spriteBatch);
            BarraEnergia.BarraEnergia_Manager.Draw(spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
