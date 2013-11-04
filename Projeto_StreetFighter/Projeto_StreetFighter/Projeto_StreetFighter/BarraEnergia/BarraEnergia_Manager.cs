using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.BarraEnergia
{
    public class BarraEnergia_Manager
    {
        static Players.Player P1;
        static Players.Player P2;

        static BarraEnergia Barra_P1;
        static BarraEnergia Barra_P2;

        static int vidaPerdida_P1;
        static int vidaPerdida_P2;

        public static void LoadBarraEnergia(ContentManager Content)
        {
            Barra_P1 = new BarraEnergia(Content);
            Barra_P2 = new BarraEnergia(Content);
            P1 = Players.Player_Manager.Player_Array[0];
            P2 = Players.Player_Manager.Player_Array[1];
            AjustaPosicaoBarraEnergia();
        }


        private static void AjustaPosicaoBarraEnergia()
        {
            Barra_P1.Width = Barra_P2.Width = 400;
            Barra_P1.Height = Barra_P2.Height = 50;

            Barra_P1.X = 50;
            Barra_P1.Y = 50;

            Barra_P2.X = Game1.Variables.ResolucaoRectangle.Width - 50 - Barra_P2.Width;
            Barra_P2.Y = 50;

        }


        public static void Update()
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Game)
                return;

            if (Collision.Collision_Manager.Is_P1_Acerto && !P1.IsHealthAtualizado)
            {
                switch (Collision.Collision_Manager.GolpeP1)
                {
                    case Players.Player_Manager.PlayerState.Soco_Fraco_N:
                        P2.Health -= 7;
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Fraco_A:
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Fraco_B:
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Forte_N:
                        P2.Health -= 10;
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Forte_A:
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Forte_B:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Fraco_N:
                        P2.Health -= 8;
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Fraco_A:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Fraco_B:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Forte_N:
                        P2.Health -= 12;
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Forte_A:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Forte_B:
                        break;
                }

                Collision.Collision_Manager.Is_P1_Acerto = false;
                Collision.Collision_Manager.GolpeP1 = Players.Player_Manager.PlayerState.NULL;
                P1.IsHealthAtualizado = true;
            }
            if (Collision.Collision_Manager.Is_P2_Acerto && !P2.IsHealthAtualizado)
            {
                switch (Collision.Collision_Manager.GolpeP2)
                {
                    case Players.Player_Manager.PlayerState.Soco_Fraco_N:
                        P1.Health -= 7;
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Fraco_A:
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Fraco_B:
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Forte_N:
                        P1.Health -= 10;
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Forte_A:
                        break;
                    case Players.Player_Manager.PlayerState.Soco_Forte_B:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Fraco_N:
                        P1.Health -= 8;
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Fraco_A:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Fraco_B:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Forte_N:
                        P1.Health -= 12;
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Forte_A:
                        break;
                    case Players.Player_Manager.PlayerState.Chute_Forte_B:
                        break;
                }

                Collision.Collision_Manager.Is_P2_Acerto = false;
                Collision.Collision_Manager.GolpeP2 = Players.Player_Manager.PlayerState.NULL;
                P2.IsHealthAtualizado = true;
            }


            vidaPerdida_P1 = 100 - P1.Health;
            vidaPerdida_P2 = 100 - P2.Health;
        }

        public static void Draw(SpriteBatch sprite)
        {

            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Game)
                return;

            sprite.Draw(Barra_P1.texture_BarraEnergia, new Rectangle(Barra_P1.X, Barra_P1.Y, Barra_P1.Width, Barra_P1.Height), Color.White);
            sprite.Draw(Barra_P2.texture_BarraEnergia, new Rectangle(Barra_P2.X, Barra_P2.Y, Barra_P2.Width, Barra_P2.Height), null, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);

            sprite.Draw(Barra_P1.texture_Vida, new Rectangle(Barra_P1.X + 4 * vidaPerdida_P1, Barra_P1.Y, Barra_P1.Width -  4 * vidaPerdida_P1, Barra_P1.Height), Color.White);
            sprite.Draw(Barra_P2.texture_Vida, new Rectangle(Barra_P2.X, Barra_P2.Y, Barra_P2.Width - 4 * vidaPerdida_P2, Barra_P2.Height), null, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);

        }


    }
}
