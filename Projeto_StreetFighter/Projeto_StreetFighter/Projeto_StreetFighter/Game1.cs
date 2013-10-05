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
        public enum CurrentWindow { SplashScreen, Menu, Game }
        public static CurrentWindow currentWindow = CurrentWindow.SplashScreen;

        public static Rectangle ResolucaoRectangle = new Rectangle(0, 0, 1024, 760);

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = ResolucaoRectangle.Width;
            graphics.PreferredBackBufferHeight = ResolucaoRectangle.Height;
            graphics.ApplyChanges();
        }


        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Other.Functions.LoadTextureFrame(
                ref Characters.Character.Textures.Normal_Instace.Textures_array,
                Content.Load<Texture2D>("Characters/Ken/Ken_Normal"));

            for (int i = 0; i < 4; i++)
            {
                Other.Functions.LoadTextureFrame(
                ref Menu.SplashScreen.Textures_array,
                Content.Load<Texture2D>("Menu/Main_Menu_0" + i.ToString()));
            }

            Animation.Animator_Controller.AddAnimator(
                Menu.SplashScreen.Textures_array, 0, 0, 
                ResolucaoRectangle.Width, ResolucaoRectangle.Height, 
                CurrentWindow.SplashScreen,100);
            
        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Animation.Animator_Controller.UpdateAll(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            Animation.Animator_Controller.DrawAll(spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
