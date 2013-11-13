using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Animation
{
    class Animator_Controller
    {
        //public delegate void AnimationEnded_delegate();
        //public static event AnimationEnded_delegate Animation_ended;

        public enum OtherAnimation_enum { NULL, SplashScreen_Start, SplashScreen_Quit, 
                                            SelectMenu, SelectStage, LoadScreen }
        public struct Animation_List_struct
        {
            public Animator animator;
            public Players.Player_Manager.PlayerState Player_state_animation;
            public OtherAnimation_enum OtherAnimationType;
        }

        private static List<Animation_List_struct> Animation_List = new List<Animation_List_struct>();

        public enum AnimationType { Normal, Normal_Reversed, Reversed }


        public static void LoadAnimator(List<Texture2D> texture_list,
            int x, int y, int width, int height,
            Game1.Variables.CurrentWindow window_related, 
            int speed_millisecs, 
            AnimationType anim_type, 
            Players.Player Player_related_to,
            Players.Player_Manager.PlayerState anim_name = Players.Player_Manager.PlayerState.NULL,
            OtherAnimation_enum OtherAnimationType = OtherAnimation_enum.NULL, bool IsGolpe = false)
        {
            
            Animator anim = new Animator();

            anim.textures_array = texture_list;
            anim.Width = width;
            anim.Height = height;
            anim.window = window_related;
            anim.speedInMilliSecs = speed_millisecs;
            anim.anim_Type = anim_type;
            anim.Is_Animating = false;
            anim.PlayerRelatedTo = Player_related_to;
            anim.Is_Golpe = IsGolpe;

            if (Player_related_to != null)
            {
                anim.X = Player_related_to.X;
                anim.Y = Player_related_to.Y;
            }
            else
            {
                anim.X = x;
                anim.Y = y;
            }


            Animation_List_struct stru = new Animation_List_struct();
            stru.animator = anim;
            stru.Player_state_animation = anim_name;
            stru.OtherAnimationType = OtherAnimationType;

            Animation_List.Add(stru);

        }

        public static void PlayAnimation(Players.Player_Manager.PlayerState name, Players.Player player)
        {
            foreach (Animation_List_struct stru in Animation_List)
            {
                if (player == stru.animator.PlayerRelatedTo)
                {
                    if (stru.Player_state_animation == name)
                        stru.animator.Is_Animating = true;
                    else
                        stru.animator.Is_Animating = false;
                }
            }

        }

        public static void PlayAnimation(OtherAnimation_enum name)
        {
            foreach (Animation_List_struct stru in Animation_List)
            {
                if (stru.OtherAnimationType == name)
                    stru.animator.Is_Animating = true;
                else
                    stru.animator.Is_Animating = false;
            }

        }

        public static void RemoveAnimation(Game1.Variables.CurrentWindow currentWindow)
        {
            Animation_List.RemoveAll(anim_list => anim_list.animator.window != currentWindow );
        }
        
        public static void UpdateAll(GameTime time)
        {
            lock (Animation_List)
                foreach (Animation_List_struct s in Animation_List)
                    s.animator.Update(time);
        }
        
        public static void DrawAll(SpriteBatch sprite)
        {
            lock (Animation_List)
                foreach (Animation_List_struct s in Animation_List)
                    s.animator.Draw(sprite);
        }
    }
}
