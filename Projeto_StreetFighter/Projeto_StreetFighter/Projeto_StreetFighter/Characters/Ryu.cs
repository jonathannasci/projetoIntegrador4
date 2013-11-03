using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto_StreetFighter.Characters
{
    class Ryu : ICollision
    {
        public void LoadCollision( ref BoxCollision boxCollision ,int current_frame, Players.Player_Manager.PlayerState playerState)
        {

            switch (playerState)
            {
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.NULL:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Normal:
                    
                    //teste colisão
                    boxCollision.Corpo = new Rectangle(37, 38, 41, 112);
                    boxCollision.Braco = new Rectangle(83, 56, 17, 38);
                    boxCollision.Perna = new Rectangle(83,122,17,28);
                    
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Andando:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Alto:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Baixo:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Morto:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Chute_Forte_N:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Chute_Forte_B:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Chute_Forte_A:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Chute_Fraco_N:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Chute_Fraco_B:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Chute_Fraco_A:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Forte_N:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Forte_B:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Forte_A:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Fraco_N:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Fraco_B:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Fraco_A:
                    break;
            }
        }

    }
}
