using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto_StreetFighter.BarraEnergia
{
    public class BarraEnergia
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Texture2D texture_BarraEnergia;
        public Texture2D texture_Vida;

        public BarraEnergia(ContentManager Content)
        {
            this.texture_BarraEnergia = Content.Load<Texture2D>("BarraEnergia/BarraEnergia");
            this.texture_Vida = Content.Load<Texture2D>("BarraEnergia/Vida");
        }
    }
}
