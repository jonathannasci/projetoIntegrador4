using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto_StreetFighter.Characters
{
    public class Character
    {
        
        public enum CharacterStance { Normal_stance, Baixo_stance, Alto_stance }

        //public struct Textures
        //{
            public List<Texture2D> Normal_Instance = new List<Texture2D>();

            public List<Texture2D> Normal_Andando_Instance = new List<Texture2D>();

            public List<Texture2D> Normal_Chute_Forte_Instance = new List<Texture2D>();

            public List<Texture2D> Normal_Chute_Fraco_Instance = new List<Texture2D>();

            public List<Texture2D> Normal_Soco_Forte_Instance = new List<Texture2D>();

            public List<Texture2D> Normal_Soco_Fraco_Instance = new List<Texture2D>();
        //}


    }
}
