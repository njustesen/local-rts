using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using ExiledRTS.Objects;
using ExiledRTS.Core;
using ExiledRTS.Components;
using ExiledRTS.GameScreen;
using ExiledRTS.Util;

namespace ExiledRTS.GameScreen
{
    /// <summary>
    /// A screen where you can see who made the game.
    /// </summary>
    class GameScreen : IGameScreen
    {
        public GameScreenManager ScreenManager { get; set; }
        Team teamA;
        Team teamB;
        bool gameOver = false;
        bool paused = false;
        Team winner;

        /// <summary>
        /// Initializes and gets all assets for this screen
        /// </summary>
        public void Initialize()
        {
            // TODO: use this.Content to load your game content here
            StartGame();
        }

        public void StartGame()
        {
            teamA = new Team();
            teamA.TeamNumber = 1;
            teamB = new Team();
            teamB.TeamNumber = 2;

            CreateUnit(teamA, new Vector2(200, 150), Textures.yellowTank, Color.Yellow,     0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, false);
            CreateUnit(teamA, new Vector2(200, 250), Textures.yellowTank, Color.Red,        0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, false);
            CreateUnit(teamA, new Vector2(200, 350), Textures.yellowTank, Color.Green,      0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, false);
            CreateUnit(teamA, new Vector2(200, 450), Textures.yellowTank, Color.Blue,       0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, false);
                                                                                                                                     
            CreateUnit(teamB, new Vector2(900, 150), Textures.yellowTank, Color.Yellow,     0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, true);
            CreateUnit(teamB, new Vector2(900, 250), Textures.yellowTank, Color.Red,        0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, true);
            CreateUnit(teamB, new Vector2(900, 350), Textures.yellowTank, Color.Green,      0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, true);
            CreateUnit(teamB, new Vector2(900, 450), Textures.yellowTank, Color.Blue,       0.5f, 50.0f, 0.5f, 600.0f, 100.0f, 16.0f, true);

            GameObject checkpointA = new GameObject(new Vector2(612, 150), Textures.checkpoint);
            checkpointA.Components.Add(new Checkpoint(checkpointA, 50.0f));
            GameObject checkpointB = new GameObject(new Vector2(350, 550), Textures.checkpoint);
            checkpointB.Components.Add(new Checkpoint(checkpointB, 50.0f));
            GameObject checkpointC = new GameObject(new Vector2(725, 550), Textures.checkpoint);
            checkpointC.Components.Add(new Checkpoint(checkpointC, 50.0f));

            // Obstacles
            GameObject box = new GameObject(new Vector2(50, 150), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

            box = new GameObject(new Vector2(450, 350), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

            box = new GameObject(new Vector2(650, 360), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

            box = new GameObject(new Vector2(900, 600), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

        }

        public void CreateUnit(Team team, Vector2 pos, Texture2D tex, Color color, float depth, float speed, float attackSpeed, float bulletSpeed, float health, float radius, bool flipped)
        {
            GameObject unit = new GameObject(pos, tex);
            unit.Renderer.Flipped = flipped;
            unit.Depth = depth;
            unit.Components.Add(new Unit(unit, teamA, color, speed, attackSpeed, bulletSpeed));
            unit.Components.Add(new Health(unit, health));
            unit.Components.Add(new CircleCollider(unit, radius));
            team.AddUnit(unit);
        }

        /// <summary>
        /// Logic for every update (frame)
        /// </summary>
        /// <param name="dtime"></param>
        public void Update(float dtime)
        {
            if (gameOver){
                return;
            }
            if (paused)
            {
                return;
            }

            if (InputManager.playerOneState == null || InputManager.playerTwoState == null)
            {
                InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
                InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);
                return;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SelectedUnitAttack(teamA, PlayerIndex.One);
            SelectedUnitAttack(teamB, PlayerIndex.Two);

            for (int i = 0; i < GameObject.GameObjects.Count; ++i)
            {
                GameObject.GameObjects[i].Update(dtime);
            }


            // Selection player A
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.Y != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Yellow));
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.B != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Red));
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.A != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Green));
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.X != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Blue));
            }

            // Selection player B
            if (GamePad.GetState(PlayerIndex.Two).Buttons.Y == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.Y != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Yellow));
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.B == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.B != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Red));
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.A != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Green));
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.X == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.X != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Blue));
            }

            // Move units
            if (teamA.SelectedUnit != null)
            {
                Move(teamA.SelectedUnit, InputManager.ThumbMovement(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left), dtime);
            }

            if (teamB.SelectedUnit != null)
            {
                Move(teamB.SelectedUnit, InputManager.ThumbMovement(GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left), dtime);
            }

            InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
            InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);

            checkForWinner();

        }

        private void checkForWinner()
        {
            
            if (teamA.Points >= 100f){
                gameOver = true;
                winner = teamA;
            }
            else if (teamB.Points >= 100f)
            {
                gameOver = true;
                winner = teamB;
            }

        }

        private static void SelectedUnitAttack(Team team, PlayerIndex index)
        {
            if (team.SelectedUnit != null)
            {
                var dir = InputManager.ThumbMovement(GamePad.GetState(index).ThumbSticks.Right);
                if (GamePad.GetState(index).Buttons.RightShoulder == ButtonState.Pressed)
                {
                    if (dir != Vector2.Zero)
                    {
                        dir.Normalize();
                        dir.Y *= -1.0f;
                        team.SelectedUnit.AttackDir = dir;
                        team.SelectedUnit.ShouldFire = true;
                    }
                    else
                    {
                        team.SelectedUnit.ShouldFire = false;
                    }
                }
            }
        }

        private void Move(Unit unit, Vector2 direction, float dtime)
        {
            float x = direction.X * dtime * unit.Speed;
            float y = -direction.Y * dtime * unit.Speed;
            unit.Velocity = new Vector2(x, y);

        }

        /// <summary>
        /// Drawing pictures for every frame.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="dtime"></param>
        public void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderLayer layer)
        {
            if (layer == RenderLayer.Early)
            {
                DrawSelection(spriteBatch);
            }
            else if (layer == RenderLayer.Normal)
            {
                foreach (Renderable render in Renderable.AllRenderable)
                {
                    render.Render(spriteBatch);
                }
            }
            else
            {
                DrawSelection(spriteBatch);
                DrawControlPointBars(spriteBatch);
                DrawScore(spriteBatch);
            }
        }

        private void DrawScore(SpriteBatch spriteBatch)
        {

            // Team A
            Vector2 position = new Vector2(16, 40);
            spriteBatch.Draw(Textures.scoreBar, position, Color.White);
            float progress = teamA.Points / 100f;
            spriteBatch.Draw(Textures.scoreProgress, new Rectangle((int)position.X, (int)(position.Y + 640) - (int)(Textures.scoreProgress.Height * progress), (int)(Textures.scoreProgress.Width), (int)(Textures.scoreProgress.Height * progress)), Color.White);

            // Team B
            position = new Vector2(1264 - Textures.scoreProgress.Width, 40);
            spriteBatch.Draw(Textures.scoreBar, position, Color.White);
            progress = teamB.Points / 100f;
            spriteBatch.Draw(Textures.scoreProgress, new Rectangle((int)position.X, (int)(position.Y + 640) - (int)(Textures.scoreProgress.Height * progress), (int)(Textures.scoreProgress.Width), (int)(Textures.scoreProgress.Height * progress)), Color.White);
        
        
        }

        private void DrawControlPointBars(SpriteBatch spriteBatch)
        {

            foreach (GameObject obj in GameObject.GameObjects)
            {
                Checkpoint checkpoint = obj.GetComponent<Checkpoint>();
                
                if (checkpoint != null && checkpoint.ControlTimer != null){
                    float progress = checkpoint.ControlTimer.Time / ControlTimer.maxTime;
                    Vector2 position = checkpoint.AttachedTo.Position;
                    position.Y += Textures.checkpoint.Height / 2;
                    position.X -= Textures.checkpoint.Width / 2;
                    spriteBatch.Draw(Textures.checkpointBar, position, Color.White);
                    spriteBatch.Draw(Textures.checkpointProgress, new Rectangle((int)position.X, (int)position.Y, (int)(Textures.checkpointProgress.Width * progress), (int)Textures.checkpointProgress.Height), Color.White);
                }

            }

        }

        private void DrawSelection(SpriteBatch spriteBatch)
        {

            if (teamA.SelectedUnit != null)
            {
                spriteBatch.Draw(Textures.selection, teamA.SelectedUnit.AttachedTo.Position, Textures.selection.Bounds, Color.White, 0.0f, Textures.GetOrigin(Textures.selection) + new Vector2(0, -13.0f), 1.0f, SpriteEffects.None, 0.5f);
            }

            if (teamB.SelectedUnit != null)
            {
                spriteBatch.Draw(Textures.selection, teamB.SelectedUnit.AttachedTo.Position, Textures.selection.Bounds, Color.White, 0.0f, Textures.GetOrigin(Textures.selection) + new Vector2(0, -13.0f), 1.0f, SpriteEffects.None, 0.5f);
            }

        }


        //Go back to the main menu
        public void Exit()
        {
            
        }
    }
}
