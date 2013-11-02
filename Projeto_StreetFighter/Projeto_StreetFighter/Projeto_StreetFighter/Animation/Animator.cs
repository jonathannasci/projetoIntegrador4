using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Animation
{
    class Animator
    {
        public Players.Player PlayerRelatedTo;
        
        public List<Texture2D> textures_array = new List<Texture2D>();
        public int current_freme_index = 0;

        public int X, Y, Width, Height;

        public bool Is_Animating;

        public bool Is_Golpe = false;

        public Game1.Variables.CurrentWindow window;

        public Animation.Animator_Controller.AnimationType anim_Type;

        public int time_counter;
        public int speedInMilliSecs;

        private bool is_animating_backward = false;


        public void Update(GameTime time)
        {
            if (!Is_Animating)
                return;

            if (PlayerRelatedTo != null)
            {
                X = PlayerRelatedTo.X;
                Y = PlayerRelatedTo.Y;
            }

            time_counter += time.ElapsedGameTime.Milliseconds;
            if (time_counter > speedInMilliSecs)
            {
                time_counter = 0;

                VerificarFimAnimacao();
                switch (anim_Type)
                {
                    case Animator_Controller.AnimationType.Normal:
                        current_freme_index++;
                        if (current_freme_index >= textures_array.Count)
                            current_freme_index = 0;

                        break;
                    case Animator_Controller.AnimationType.Normal_Reversed:

                        if (is_animating_backward)
                        {
                            current_freme_index--;
                            if (current_freme_index < 0)
                            {
                                if (textures_array.Count > 1)
                                    current_freme_index = 1;
                                else
                                    current_freme_index = 0;

                                is_animating_backward = false;
                            }
                        }
                        else
                        {
                            current_freme_index++;
                            if (current_freme_index >= textures_array.Count)
                            {
                                if (textures_array.Count > 1)
                                    current_freme_index = textures_array.Count - 2;
                                else
                                    current_freme_index = textures_array.Count - 1;

                                is_animating_backward = true;
                            }
                        }

                        break;
                    case Animator_Controller.AnimationType.Reversed:
                        current_freme_index--;
                        if (current_freme_index < 0)
                            current_freme_index = textures_array.Count - 1;

                        break;
                }
            }


        }

        public void VerificarFimAnimacao()
        {
            if(Is_Golpe){
                switch (anim_Type)
                {
                    case Animator_Controller.AnimationType.Normal:
                        if(current_freme_index == textures_array.Count - 1){
                            PlayerRelatedTo.NonInteruptableAnimation = false;
                        }
                        break;
                    case Animator_Controller.AnimationType.Normal_Reversed:
                        if (is_animating_backward && current_freme_index == 0)
                        {
                            PlayerRelatedTo.NonInteruptableAnimation = false;
                        }
                        break;
                    case Animator_Controller.AnimationType.Reversed:
                        if (current_freme_index == 0)
                        {
                            PlayerRelatedTo.NonInteruptableAnimation = false;
                        }
                        break;
                }
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            if (!Is_Animating)
                return;

            if (Game1.Variables.currentWindow != window)
                return;

            if (PlayerRelatedTo != null && PlayerRelatedTo.IsReversed == true)
                sprite.Draw(textures_array[current_freme_index], new Rectangle(X, Y, Width, Height), null, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            else
                sprite.Draw(textures_array[current_freme_index], new Rectangle(X, Y, Width, Height), Color.White);

        }
    }
}
