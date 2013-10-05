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
        private static List<Animator> Animator_List = new List<Animator>();

        public static Animator AddAnimator(List<Texture2D> texture_list,
            int x, int y, int width, int height, Game1.Variables.CurrentWindow window_related,
            int speed_millisecs)
        {
            Animator anim = new Animator();

            anim.textures_array = texture_list;
            anim.X = x;
            anim.Y = y;
            anim.Width = width;
            anim.Height = height;
            anim.window = window_related;
            anim.speedInMilliSecs = speed_millisecs;

            Animator_List.Add(anim);

            return anim;
        }

        public static void RemoveAnimator(Animator obj)
        {
            Animator_List.Remove(obj);
        }

        public static void UpdateAll(GameTime time)
        {
            lock (Animator_List)
                foreach (Animator anim in Animator_List)
                    anim.Update(time);
        }

        public static void DrawAll(SpriteBatch sprite)
        {
            lock (Animator_List)
                foreach (Animator anim in Animator_List)
                    anim.Draw(sprite);
        }
    }
}
