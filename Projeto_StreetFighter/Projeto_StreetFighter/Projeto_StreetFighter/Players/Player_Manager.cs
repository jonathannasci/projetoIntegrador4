﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Projeto_StreetFighter.Players
{
    class Player_Manager
    {
        public enum PlayerState
        {
            NULL,
            Normal,
            Andando,
            Alto,
            Baixo,
            Morto,
            Chute_Forte_N, Chute_Forte_B, Chute_Forte_A,
            Chute_Fraco_N, Chute_Fraco_B, Chute_Fraco_A,
            Soco_Forte_N, Soco_Forte_B, Soco_Forte_A,
            Soco_Fraco_N, Soco_Fraco_B, Soco_Fraco_A,
        }

        public static List<Player> Player_Array = new List<Player>();

        public static void AddPlayer()
        {
            if (Player_Array.Count == 0)
                Player_Array.Add(new Player(false, 150));
            else
                Player_Array.Add(new Player(false, Game1.Variables.GameRectangle.Width - 150, isReversed: true));
        }

        public static void GenerateAnimation()
        {

        }

        public static void Update(KeyboardState prev_state, KeyboardState actual_state, GameTime time)
        {
            //UpdateSelectMenu(prev_state, actual_state, time);
            UpdateMovimentosP1(prev_state, actual_state, time);
            UpdateMovimentosP2(prev_state, actual_state, time);
        }

        public static void UpdateSelectMenu(KeyboardState prev_state, KeyboardState actual_state, GameTime time)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.SelectPlayer)
                return;
        }

        public static void UpdateMovimentosP1(KeyboardState prev_state, KeyboardState actual_state, GameTime time)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Game)
                return;

            if (!Player_Array[0].NonInteruptableAnimation)
            {
                CheckForCombos(prev_state, actual_state, time);

                if (actual_state.IsKeyDown(Keys.I))
                {
                    Player_Array[0].NonInteruptableAnimation = true;
                    Player_Array[0].state = PlayerState.Soco_Forte_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Soco_Forte_N);
                }
                else if (actual_state.IsKeyDown(Keys.U))
                {
                    Player_Array[0].NonInteruptableAnimation = true;
                    Player_Array[0].state = PlayerState.Soco_Fraco_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Soco_Fraco_N);
                }
                else if (actual_state.IsKeyDown(Keys.K))
                {
                    Player_Array[0].NonInteruptableAnimation = true;
                    Player_Array[0].state = PlayerState.Chute_Forte_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Chute_Forte_N);
                }
                else if (actual_state.IsKeyDown(Keys.J))
                {
                    Player_Array[0].NonInteruptableAnimation = true;
                    Player_Array[0].state = PlayerState.Chute_Fraco_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Chute_Fraco_N);
                }
                else if (actual_state.IsKeyDown(Keys.A))
                {
                    Player_Array[0].state = PlayerState.Andando;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Andando);
                    Player_Array[0].X -= 3;
                }
                else if (actual_state.IsKeyDown(Keys.D))
                {
                    Player_Array[0].state = PlayerState.Andando;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Andando);
                    Player_Array[0].X += 3;
                }
                else
                {
                    Player_Array[0].state = PlayerState.Normal;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Normal);
                }
            }
        }


        public static void UpdateMovimentosP2(KeyboardState prev_state, KeyboardState actual_state, GameTime time)
        {
            if (Game1.Variables.currentWindow != Game1.Variables.CurrentWindow.Game)
                return;

            if (!Player_Array[1].NonInteruptableAnimation)
            {
                CheckForCombos(prev_state, actual_state, time);

                if (actual_state.IsKeyDown(Keys.NumPad6))
                {
                    Player_Array[1].NonInteruptableAnimation = true;
                    Player_Array[1].state = PlayerState.Soco_Forte_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Soco_Forte_N);
                }
                else if (actual_state.IsKeyDown(Keys.NumPad5))
                {
                    Player_Array[1].NonInteruptableAnimation = true;
                    Player_Array[1].state = PlayerState.Soco_Fraco_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Soco_Fraco_N);
                }
                else if (actual_state.IsKeyDown(Keys.NumPad3))
                {
                    Player_Array[1].NonInteruptableAnimation = true;
                    Player_Array[1].state = PlayerState.Chute_Forte_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Chute_Forte_N);
                }
                else if (actual_state.IsKeyDown(Keys.NumPad2))
                {
                    Player_Array[1].NonInteruptableAnimation = true;
                    Player_Array[1].state = PlayerState.Chute_Fraco_N;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Chute_Fraco_N);
                }
                else if (actual_state.IsKeyDown(Keys.Left))
                {
                    Player_Array[1].state = PlayerState.Andando;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Andando);
                    Player_Array[1].X -= 3;
                }
                else if (actual_state.IsKeyDown(Keys.Right))
                {
                    Player_Array[1].state = PlayerState.Andando;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Andando);
                    Player_Array[1].X += 3;
                }
                else
                {
                    Player_Array[1].state = PlayerState.Normal;
                    Animation.Animator_Controller.PlayAnimation(PlayerState.Normal);
                }
            }
        }


        public static void CheckForCombos(KeyboardState prev_state, KeyboardState actual_state, GameTime time)
        {
            //if (Player_Array[0].state != PlayerState.Soco_Fraco_N)
            //    return;


            //if (actual_state.IsKeyDown(Keys.U))
            //{
            //    ComboStruc.IsInitialKeyUp = true;
            //    return;
            //}

            //if (ComboStruc.IsInitialKeyUp)
            //{
            //    time_counter += time.ElapsedGameTime.Milliseconds;
            //    if(time_counter >= 350)
            //    {

            //    }
            //}

        }
    }
}