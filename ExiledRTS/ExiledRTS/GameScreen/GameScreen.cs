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
using Microsoft.Xna.Framework.Audio;

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

        private bool isStarted = false;

        /// <summary>
        /// Initializes and gets all assets for this screen
        /// </summary>
        public void Initialize()
        {
            // TODO: use this.Content to load your game content here
            //StartGame();
        }

        public void StartGame()
        {
            teamA = new Team();
            teamA.TeamNumber = 1;
            teamA.Sound = Sounds.conquerA;
            teamB = new Team();
            teamB.TeamNumber = 2;
            teamB.Sound = Sounds.conquerB;

            float attackSpeed = 0.15f;
            float bulletSpeed = 400f;
            float speed = 100.0f;
            float size = 32.0f;

            CreateUnit(teamA, new Vector2(175, 75), Textures.yellowTank, Sounds.shootA, Color.Yellow, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, false);
            CreateUnit(teamA, new Vector2(175, 175), Textures.redTank, Sounds.shootB, Color.Red, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, false);
            CreateUnit(teamA, new Vector2(175, 275), Textures.greenTank, Sounds.shootC, Color.Green, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, false);
            CreateUnit(teamA, new Vector2(175, 375), Textures.blueTank, Sounds.shootD, Color.Blue, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, false);

            CreateUnit(teamB, new Vector2(1105, 345), Textures.yellowTank, Sounds.shootA, Color.Yellow, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, true);
            CreateUnit(teamB, new Vector2(1105, 445), Textures.redTank, Sounds.shootB, Color.Red, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, true);
            CreateUnit(teamB, new Vector2(1105, 545), Textures.greenTank, Sounds.shootC, Color.Green, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, true);
            CreateUnit(teamB, new Vector2(1105, 645), Textures.blueTank, Sounds.shootD, Color.Blue, 0.5f, speed, attackSpeed, bulletSpeed, 100.0f, size, true);

            GameObject checkpointA = new GameObject(new Vector2(860, 250), Textures.checkpoint);
            checkpointA.Components.Add(new Checkpoint(checkpointA, 100.0f));
            GameObject checkpointB = new GameObject(new Vector2(640, 360), Textures.checkpoint);
            checkpointB.Components.Add(new Checkpoint(checkpointB, 100.0f));
            GameObject checkpointC = new GameObject(new Vector2(420, 470), Textures.checkpoint);
            checkpointC.Components.Add(new Checkpoint(checkpointC, 100.0f));

            // Walls
            GameObject wall = new GameObject(new Vector2(0, 640), null);
            wall.Components.Add(new SquareCollider(wall, 230, 1280));

            wall = new GameObject(new Vector2(1280, 640), null);
            wall.Components.Add(new SquareCollider(wall, 230, 1280));

            wall = new GameObject(new Vector2(0, 0), null);
            wall.Components.Add(new SquareCollider(wall, 640, 40));

            wall = new GameObject(new Vector2(655, 0), null);
            wall.Components.Add(new SquareCollider(wall, 200, 40));

            wall = new GameObject(new Vector2(1280, 0), null);
            wall.Components.Add(new SquareCollider(wall, 640, 40));

            wall = new GameObject(new Vector2(655, 720), null);
            wall.Components.Add(new SquareCollider(wall, 200, 40));

            wall = new GameObject(new Vector2(0, 720), null);
            wall.Components.Add(new SquareCollider(wall, 640, 40));

            wall = new GameObject(new Vector2(1280, 720), null);
            wall.Components.Add(new SquareCollider(wall, 640, 40));

            wall = new GameObject(new Vector2(1280, 720), null);
            wall.Components.Add(new SquareCollider(wall, 230, 1280));

            // Obstacles
            GameObject box = new GameObject(new Vector2(375, 540), Textures.horizontalBlock);
            box.Components.Add(new SquareCollider(box, 142, 50));

            box = new GameObject(new Vector2(905, 180), Textures.horizontalBlock);
            box.Components.Add(new SquareCollider(box, 142, 50));

            box = new GameObject(new Vector2(320, 200), Textures.verticalBlock);
            box.Components.Add(new SquareCollider(box, 50, 142));

            box = new GameObject(new Vector2(960, 520), Textures.verticalBlock);
            box.Components.Add(new SquareCollider(box, 50, 142));

            box = new GameObject(new Vector2(510, 360), Textures.squareBlock);
            box.Components.Add(new SquareCollider(box, 100, 100));

            box = new GameObject(new Vector2(770, 360), Textures.squareBlock);
            box.Components.Add(new SquareCollider(box, 100, 100));
            /*
            box = new GameObject(new Vector2(450, 350), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

            box = new GameObject(new Vector2(650, 360), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

            box = new GameObject(new Vector2(900, 600), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));
            */
        }

        public void CreateUnit(Team team, Vector2 pos, Texture2D tex, SoundEffect sound, Color color, float depth, float speed, float attackSpeed, float bulletSpeed, float health, float radius, bool flipped)
        {
            GameObject unit = new GameObject(pos, tex);
            unit.Renderer.Flipped = flipped;
            unit.Depth = depth;
            unit.Components.Add(new Unit(unit, team, sound, color, speed, attackSpeed, bulletSpeed));
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
            if (gameOver || !isStarted){
                return;
            }
            
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Released && InputManager.playerOneState.Buttons.Start == ButtonState.Pressed) ||
                (GamePad.GetState(PlayerIndex.Two).Buttons.Start == ButtonState.Released && InputManager.playerTwoState.Buttons.Start == ButtonState.Pressed))
            {
                paused = !paused;
                //return;
            }
            
            if (paused)
            {
                InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
                InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);
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

            // Extra deselection
            if (GamePad.GetState(PlayerIndex.One).Triggers.Left >= 0.6f || GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.6f){
                if (teamA.SelectedUnit != null){
                    teamA.SelectUnit(teamA.SelectedUnit);
                }
            }

            if (GamePad.GetState(PlayerIndex.Two).Triggers.Left >= 0.6f || GamePad.GetState(PlayerIndex.Two).Triggers.Right >= 0.6f)
            {
                if (teamB.SelectedUnit != null)
                {
                    teamB.SelectUnit(teamB.SelectedUnit);
                }
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
                if (teamA.SelectedUnit.AttachedTo.GetComponent<Health>().IsDead)
                {
                    teamA.SelectedUnit = null;
                }
                else 
                    Move(teamA.SelectedUnit, InputManager.ThumbMovement(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left), dtime);
            }

            if (teamB.SelectedUnit != null)
            {
                if (teamB.SelectedUnit.AttachedTo.GetComponent<Health>().IsDead)
                {
                    teamB.SelectedUnit = null;
                }
                else 
                    Move(teamB.SelectedUnit, InputManager.ThumbMovement(GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left), dtime);
            }

            InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
            InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);

            outOfBounds();

            checkForWinner();

        }

        private void outOfBounds()
        {
            Rectangle gameArea = new Rectangle(0, 0, 1280, 720);
            foreach(GameObject obj in GameObject.GameObjects){
                Unit unit = obj.GetComponent<Unit>();
                if (unit != null){
                    int height = obj.Renderer.Texture.Height;
                    int halfHeight = (int)Math.Ceiling(height / 2.0f);


                    Rectangle unitArea = new Rectangle(-halfHeight, -halfHeight, halfHeight, halfHeight);
                    unitArea.X = unitArea.X + (int) obj.Position.X;
                    unitArea.Y = unitArea.Y + (int) obj.Position.Y;

                    if (!gameArea.Intersects(unitArea)){
                        if (obj.Position.Y < -halfHeight - 16.0f)
                        {
                            obj.Position.Y = 720+halfHeight;
                        }
                        else if (obj.Position.Y > 720 + halfHeight)
                        {
                            obj.Position.Y = -halfHeight - 15.0f;
                        }
                    }
                }
            }

            foreach (GameObject obj in GameObject.GameObjects)
            {
                Projectile projectile = obj.GetComponent<Projectile>();
                if (projectile != null)
                {
                    int height = obj.Renderer.Texture.Height;
                    int halfHeight = (int)Math.Ceiling(height / 2.0f);

                    Rectangle unitArea = new Rectangle(-halfHeight, -halfHeight, halfHeight, halfHeight);
                    unitArea.X = unitArea.X + (int)obj.Position.X;
                    unitArea.Y = unitArea.Y + (int)obj.Position.Y;

                    if (!gameArea.Intersects(unitArea))
                    {
                        if (obj.Position.Y < -halfHeight)
                        {
                            obj.Position.Y = 720 + halfHeight;
                        }
                        else if (obj.Position.Y > 720 + halfHeight)
                        {
                            obj.Position.Y = -halfHeight;
                        }
                    }
                }
            }
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
                /*if (GamePad.GetState(index).Buttons.RightShoulder == ButtonState.Pressed)
                {*/
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
                //}
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
            if (isStarted)
            {
                if (layer == RenderLayer.Early)
                {

                    DrawSelection(spriteBatch);
                    DrawBackground(spriteBatch);
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
                    DrawHealthBars(spriteBatch);
                    DrawControlPointBars(spriteBatch);
                    DrawScore(spriteBatch);
                    DrawUnitRespawn(spriteBatch);
                }
            }
            else
                StartScreen(spriteBatch);
        }

        private bool hasPressedStart;
        private void StartScreen(SpriteBatch spriteBatch)
        {
            if (!hasPressedStart)
                hasPressedStart = GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || GamePad.GetState(PlayerIndex.Two).Buttons.Start == ButtonState.Pressed;


            if (!hasPressedStart)
            {
                spriteBatch.DrawHelper(Textures.startScreenWithText, Vector2.Zero, 1.0f);
            }
            else
            {
                spriteBatch.DrawHelper(Textures.startScreen, Vector2.Zero, 1.0f);
                spriteBatch.DrawHelper(Textures.splash, Vector2.Zero, 0.8f);
                spriteBatch.DrawHelper(Textures.buttonAToStart, new Vector2(205, 140), 0.7f);
                bool p1Ready = GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed;
                if (p1Ready)
                    spriteBatch.DrawHelper(Textures.player1Ready, new Vector2(206.0f, 320.0f), 0.5f);

                bool p2Ready = GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed;

                p2Ready = p1Ready;

                if (p2Ready)
                    spriteBatch.DrawHelper(Textures.player2Ready, new Vector2(641, 320.0f), 0.5f);
                if (p1Ready && p2Ready)
                {
                    isStarted = true;
                    StartGame();
                }
            }

        }   

        private void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.levelBackground,Vector2.Zero, Textures.levelBackground.Bounds, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
        }

        private void DrawHealthBars(SpriteBatch spriteBatch)
        {

            foreach (GameObject obj in GameObject.GameObjects)
            {
                Unit unit = obj.GetComponent<Unit>();

                if (unit != null)
                {
                    Vector2 position = new Vector2(unit.AttachedTo.Position.X - Textures.yellowTank.Width / 2, unit.AttachedTo.Position.Y - Textures.yellowTank.Height / 2);
                    spriteBatch.Draw(Textures.healthBar, position, Textures.healthBar.Bounds, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
                    float progress = obj.GetComponent<Health>().CurrentHealth / 100f;
                    spriteBatch.Draw(Textures.checkpointProgress,
                        new Rectangle((int)position.X, (int)position.Y, (int)(Textures.healthProgress.Width * progress), (int)Textures.healthProgress.Height)
                        , Textures.checkpointProgress.Bounds, new Color((int)(255f / (1 - progress)), (int)(255 * progress), (int)0f), 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.9f);
                }

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
                spriteBatch.Draw(Textures.selection, teamA.SelectedUnit.AttachedTo.Position, Textures.selection.Bounds, Color.White, 0.0f, Textures.GetOrigin(Textures.selection) + new Vector2(0, -13.0f), 1.0f, SpriteEffects.None, 0.0f);
            }

            if (teamB.SelectedUnit != null)
            {
                spriteBatch.Draw(Textures.selection, teamB.SelectedUnit.AttachedTo.Position, Textures.selection.Bounds, Color.White, 0.0f, Textures.GetOrigin(Textures.selection) + new Vector2(0, -13.0f), 1.0f, SpriteEffects.None, 0.0f);
            }

        }


        private void DrawUnitRespawn(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }

        //Go back to the main menu
        public void Exit()
        {
            
        }


    }
}
