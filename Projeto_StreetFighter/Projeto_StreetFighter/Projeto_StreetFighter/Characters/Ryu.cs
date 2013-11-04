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
                    player.BoxCollision.Corpo = new Rectangle(modX * 96 + X - (player.IsReversed ? 144 : 0), 90 + player.Y, 144, 294);
                    player.BoxCollision.Braco = new Rectangle(modX * 218 + X - (player.IsReversed ? 54 : 0), 132 + player.Y, 54, 108);
                    player.BoxCollision.Perna = new Rectangle(modX * 230 + X - (player.IsReversed ? 54 : 0), 288 + player.Y, 54, 92);
                    
                    break;
                case Projeto_StreetFighter.Players.Player_Manager.PlayerState.Andando:

                    if (current_frame == 0 || current_frame == 1 || current_frame == 3 ||
                        current_frame == 4 || current_frame == 5)
                    {
                        player.BoxCollision.Corpo = new Rectangle(modX * 146 + X - (player.IsReversed ? 86 : 0), 98 + player.Y, 86, 270);
                        player.BoxCollision.Braco = new Rectangle(modX * 216 + X - (player.IsReversed ? 54 : 0), 140 + player.Y, 54, 102);
                        player.BoxCollision.Perna = new Rectangle(modX * 204 + X - (player.IsReversed ? 62 : 0), 260 + player.Y, 62, 114);
                    }
                    else //current_frame 2 e 6
                    {
                        player.BoxCollision.Corpo = new Rectangle(modX * 92 + X - (player.IsReversed ? 122 : 0), 110 + player.Y, 122, 176);
                        player.BoxCollision.Braco = new Rectangle(modX * 198 + X - (player.IsReversed ? 62 : 0), 156 + player.Y, 62, 108);
                        player.BoxCollision.Perna = new Rectangle(modX * 204 + X - (player.IsReversed ? 52 : 0), 270 + player.Y, 52, 108);
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

                    player.BoxCollision.Corpo = new Rectangle(modX * 156 + X - (player.IsReversed ? 90 : 0), 98 + player.Y, 90, 284);
                    player.BoxCollision.Perna = new Rectangle(modX * 212 + X - (player.IsReversed ? 68 : 0), 288 + player.Y, 68, 92);
                    
                    switch (current_frame)
                    {
                        case 0:
                            player.BoxCollision.Braco = new Rectangle(modX * 228 + X - (player.IsReversed ? 50 : 0), 198 + player.Y, 50, 162);
                            break;

                        case 1:
                            player.BoxCollision.Braco = new Rectangle(modX * 236 + X - (player.IsReversed ? 80 : 0), 92 + player.Y, 80, 80);
                            break;

                        case 2:
                            player.BoxCollision.Braco = new Rectangle(modX * 230 + X - (player.IsReversed ? 186 : 0), 126 + player.Y, 186, 50);
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
