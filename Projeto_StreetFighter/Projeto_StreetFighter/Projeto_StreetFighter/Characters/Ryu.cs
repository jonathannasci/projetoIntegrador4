using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto_StreetFighter.Characters
{
    class Ryu : Collision.ICollision
    {
        public void LoadCollision(Players.Player player, int current_frame)
        {
            int X = player.X;
            int modX = 1;

            if (player.IsReversed)
            {
                X += Game1.Variables.CharacterSize.Width;
                modX = -1;
            }

            switch (player.state)
            {
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.NULL:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Normal:
                    
                    //teste colisão
                    player.BoxCollision.Corpo = new Rectangle(modX * 48 + X - (player.IsReversed ? 72 : 0), 45 + player.Y, 72, 147);
                    player.BoxCollision.Braco = new Rectangle(modX * 109 + X - (player.IsReversed ? 27 : 0), 66 + player.Y, 27, 54);
                    player.BoxCollision.Perna = new Rectangle(modX * 115 + X - (player.IsReversed ? 27 : 0), 144 + player.Y, 27, 46);
                    
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Andando:

                    if (current_frame == 0 || current_frame == 1 || current_frame == 3 ||
                        current_frame == 4 || current_frame == 5)
                    {
                        player.BoxCollision.Corpo = new Rectangle(modX * 73 + X - (player.IsReversed ? 43 : 0), 49 + player.Y, 43, 135);
                        player.BoxCollision.Braco = new Rectangle(modX * 108 + X - (player.IsReversed ? 27 : 0), 70 + player.Y, 27, 51);
                        player.BoxCollision.Perna = new Rectangle(modX * 102 + X - (player.IsReversed ? 31 : 0), 130 + player.Y, 31, 57);
                    }
                    else //current_frame 2 e 6
                    {
                        player.BoxCollision.Corpo = new Rectangle(modX * 46 + X - (player.IsReversed ? 61 : 0), 55 + player.Y, 61, 138);
                        player.BoxCollision.Braco = new Rectangle(modX * 99 + X - (player.IsReversed ? 31 : 0), 78 + player.Y, 31, 54);
                        player.BoxCollision.Perna = new Rectangle(modX * 102 + X - (player.IsReversed ? 26 : 0), 135 + player.Y, 26, 54);
                    }
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

                    player.BoxCollision.Corpo = new Rectangle(modX * 78 + X - (player.IsReversed ? 45 : 0), 49 + player.Y, 45, 142);
                    player.BoxCollision.Perna = new Rectangle(modX * 106 + X - (player.IsReversed ? 34 : 0), 144 + player.Y, 34, 46);
                    
                    switch (current_frame)
                    {
                        case 0:
                            player.BoxCollision.Braco = new Rectangle(modX * 114 + X - (player.IsReversed ? 25 : 0), 99 + player.Y, 25, 81);
                            break;

                        case 1:
                            player.BoxCollision.Braco = new Rectangle(modX * 118 + X - (player.IsReversed ? 40 : 0), 46 + player.Y, 40, 40);
                            break;

                        case 2:
                            player.BoxCollision.Braco = new Rectangle(modX * 115 + X - (player.IsReversed ? 93 : 0), 63 + player.Y, 93, 25);
                            break;
                    }

                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Fraco_B:
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Soco_Fraco_A:
                    break;
            }
        }

    }
}
