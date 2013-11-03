using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_StreetFighter.Collision
{
    public class Collision_Manager
    {
        public static Players.Player P1;
        public static Players.Player P2;

        public static bool IsContato = false;

        public static bool Is_P1_Acerto = false;
        public static bool Is_P2_Acerto = false;

        public static void Update()
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Game)
                return;

            VerificaContato();
            VerificaGolpe();
        }

        private static void VerificaContato()
        {
            if (P1.BoxCollision.Corpo.Intersects(P2.BoxCollision.Braco) || P1.BoxCollision.Corpo.Intersects(P2.BoxCollision.Perna) 
                || P1.BoxCollision.Braco.Intersects(P2.BoxCollision.Braco) || P1.BoxCollision.Braco.Intersects(P2.BoxCollision.Perna)
                || P1.BoxCollision.Braco.Intersects(P2.BoxCollision.Corpo) || P1.BoxCollision.Perna.Intersects(P2.BoxCollision.Braco)
                || P1.BoxCollision.Perna.Intersects(P2.BoxCollision.Perna) || P1.BoxCollision.Perna.Intersects(P2.BoxCollision.Corpo)
                || P1.BoxCollision.Corpo.Intersects(P2.BoxCollision.Corpo))
            {
                IsContato = true;
            }
            else
            {
                IsContato = false;
            }
        }

        private static void VerificaGolpe()
        {
            if (P1.state == Players.Player_Manager.PlayerState.Chute_Fraco_A || P1.state == Players.Player_Manager.PlayerState.Chute_Forte_A
                || P1.state == Players.Player_Manager.PlayerState.Chute_Fraco_N || P1.state == Players.Player_Manager.PlayerState.Chute_Forte_N
                || P1.state == Players.Player_Manager.PlayerState.Chute_Fraco_B || P1.state == Players.Player_Manager.PlayerState.Chute_Forte_B)
            {

                if (P1.BoxCollision.Perna.Intersects(P2.BoxCollision.Braco) || P1.BoxCollision.Perna.Intersects(P2.BoxCollision.Perna)
                    || P1.BoxCollision.Perna.Intersects(P2.BoxCollision.Corpo))
                {
                    Is_P1_Acerto = true;
                }
                else
                {
                    Is_P1_Acerto = false;
                }

            }
            else if (P1.state == Players.Player_Manager.PlayerState.Soco_Fraco_A || P1.state == Players.Player_Manager.PlayerState.Soco_Forte_A
                || P1.state == Players.Player_Manager.PlayerState.Soco_Fraco_N || P1.state == Players.Player_Manager.PlayerState.Soco_Forte_N
                || P1.state == Players.Player_Manager.PlayerState.Soco_Fraco_B || P1.state == Players.Player_Manager.PlayerState.Soco_Forte_B)
            {
                if (P1.BoxCollision.Braco.Intersects(P2.BoxCollision.Braco) || P1.BoxCollision.Braco.Intersects(P2.BoxCollision.Perna)
                    || P1.BoxCollision.Braco.Intersects(P2.BoxCollision.Corpo))
                {
                    Is_P1_Acerto = true;
                }
                else
                {
                    Is_P1_Acerto = false;
                }
            }


            if (P2.state == Players.Player_Manager.PlayerState.Chute_Fraco_A || P2.state == Players.Player_Manager.PlayerState.Chute_Forte_A
                || P2.state == Players.Player_Manager.PlayerState.Chute_Fraco_N || P2.state == Players.Player_Manager.PlayerState.Chute_Forte_N
                || P2.state == Players.Player_Manager.PlayerState.Chute_Fraco_B || P2.state == Players.Player_Manager.PlayerState.Chute_Forte_B)
            {
                if (P2.BoxCollision.Perna.Intersects(P1.BoxCollision.Braco) || P2.BoxCollision.Perna.Intersects(P1.BoxCollision.Perna)
                    || P2.BoxCollision.Perna.Intersects(P1.BoxCollision.Corpo))
                {
                    Is_P2_Acerto = true;
                }
                else
                {
                    Is_P2_Acerto = false;
                }
            }
            else if (P2.state == Players.Player_Manager.PlayerState.Soco_Fraco_A || P2.state == Players.Player_Manager.PlayerState.Soco_Forte_A
                || P2.state == Players.Player_Manager.PlayerState.Soco_Fraco_N || P2.state == Players.Player_Manager.PlayerState.Soco_Forte_N
                || P2.state == Players.Player_Manager.PlayerState.Soco_Fraco_B || P2.state == Players.Player_Manager.PlayerState.Soco_Forte_B)
            {
                if (P2.BoxCollision.Braco.Intersects(P1.BoxCollision.Braco) || P2.BoxCollision.Braco.Intersects(P1.BoxCollision.Perna)
                    || P2.BoxCollision.Braco.Intersects(P1.BoxCollision.Corpo))
                {
                    Is_P2_Acerto = true;
                }
                else
                {
                    Is_P2_Acerto = false;
                }
            }


        }

    }
}
