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
using System.Threading;

namespace Projeto_StreetFighter
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        public struct Variables
        {
            
            public static bool Exit = false;
            public static bool Paused = false;

            public static Rectangle ResolucaoRectangle = new Rectangle(0, 0, 1024, 768);

            public static Rectangle GameRectangle = new Rectangle(
                0, 0, ResolucaoRectangle.Width, ResolucaoRectangle.Height - 100);

            public enum CurrentWindow { Menu, SelectPlayer, Load, Game, SelectStage }
            public static CurrentWindow currentWindow = CurrentWindow.Menu;

            public struct Input
            {
                public static KeyboardState Prev_Key, New_Key;
                public static MouseState Prev_Mouse, New_Mouse;

                public static Keys keyPressed = Keys.None;
            }

            public struct CharacterSize
            {
                public static int Width = 426;
                public static int Height = 384;
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

            
            if (Variables.Paused == true)
                return;

            
            Menu.MainMenu.Update(Variables.Input.New_Key);
            Menu.SelectMenu.Update(Variables.Input.New_Key, gameTime);
            Menu.SelectStageMenu.Update(Variables.Input.New_Key, gameTime);
            Players.Player_Manager.Update(Variables.Input.Prev_Key, Variables.Input.New_Key, gameTime);
            Animation.Animator_Controller.UpdateAll(gameTime);
            Collision.Collision_Manager.Update();
            BarraEnergia.BarraEnergia_Manager.Update();
            Other.Functions.Update(Variables.Input.New_Key);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            Menu.SelectStageMenu.Draw(spriteBatch);
            Animation.Animator_Controller.DrawAll(spriteBatch);
            BarraEnergia.BarraEnergia_Manager.Draw(spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
