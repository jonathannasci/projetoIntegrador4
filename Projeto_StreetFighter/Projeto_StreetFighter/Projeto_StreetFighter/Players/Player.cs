using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_StreetFighter.Players
{
    public class Player
    {
        bool IsAI;
        public int Health = 100;

        int X_loc, Y_loc;

        Menu.SelectMenu.CharacterList character = Menu.SelectMenu.CharacterList.NULL;

        public bool NonInteruptableAnimation = false;

        public bool IsReversed = false;

        public Characters.Character Character_textures;


        public Collision.ICollision CollisionCalc;

        private Collision.BoxCollision boxCollision;

        public Collision.BoxCollision BoxCollision
        {
            get { return boxCollision; }
            set { boxCollision = value; }
        }


        public Menu.SelectMenu.CharacterList Character
        {
            get { return character; }
            set { character = value; }
        }

        public int X 
        { 
            get{ return X_loc;}
            set{ X_loc = value;}
        }

        public int Y
        {
            get { return Y_loc; }
            set { Y_loc = value; }
        }
        public Player_Manager.PlayerState state = Player_Manager.PlayerState.NULL;

        public Player(bool IsAI, int x_arg , int y_arg = -1 , bool isReversed = false)
        {
            X_loc = x_arg;
            if (y_arg == -1)
            {
                Y_loc = Game1.Variables.GameRectangle.Y + Game1.Variables.GameRectangle.Height -
                    Game1.Variables.CharacterSize.Height;
            }
            this.IsAI = IsAI;
            this.IsReversed = isReversed;

            Character_textures = new Characters.Character();
            boxCollision = new Collision.BoxCollision();
        }
    }
}
