using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Collision
{
    public class BoxCollision
    {
        
        public Rectangle Corpo { get; set; }
        public Rectangle Perna { get; set; }
        public Rectangle Braco { get; set; }

        public BoxCollision()
        {
            Corpo = new Rectangle();
            Braco = new Rectangle();
            Perna = new Rectangle();
        }
    }

    public interface ICollision
    {
        void LoadCollision(Players.Player player ,int current_frame);
    }
}
