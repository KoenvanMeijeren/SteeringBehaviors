using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Src.util;
using SteeringCS.events;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class WorldForm : Form
    {
        public event EventHandler<UpdateWorldEvent> UpdateWorldEventHandler;
        public WorldVisualization World { get; private set; }
        private const int WorldHeight = 640,
            WorldWidth = 640;

        private bool _gameIsActive,
            _gameLost,
            _gameWon,
            _renderGrid,
            _renderGraph,
            _renderHitBox,
            _renderSteeringBehavior,
            _renderVelocity,
            _allowPlayerMoveOnMouseClick;

        private const float TimeDelta = 0.8f;
        private readonly Timer _timer = new Timer();

        public WorldForm()
        {
            InitializeComponent();

            Width = WorldWidth + 116;
            Height = WorldHeight + 140;

            dbPanel.Width = WorldWidth;
            dbPanel.Height = WorldHeight;
            dbPanel.Location = new Point(50, 50);

            _timer.Elapsed += WorldTimerElapsed;
            _timer.Interval = 20;
        }

        private void RenderStartScreen(Graphics graphics)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            fontCollection.AddFontFile("graphics/mario-font.ttf");

            // Create amazing mario logo
            Font logoFont = new Font(fontCollection.Families[0], 64f);

            SolidBrush logoBackgroundBrush = new SolidBrush(Color.FromArgb(199, 80, 20));
            SolidBrush logoBrush = new SolidBrush(Color.FromArgb(246, 197, 183));

            graphics.FillRectangle(logoBrush, 118, 30, 400, 200);
            graphics.FillRectangle(blackBrush, 122, 34, 400, 200);
            graphics.FillRectangle(logoBackgroundBrush, 120, 32, 400, 200);

            graphics.DrawString("amazing", logoFont, blackBrush, 135, 5);
            graphics.DrawString("amazing", logoFont, logoBrush, 130, 0);
            graphics.DrawString("MARIO BROS.", logoFont, blackBrush, 135, 115);
            graphics.DrawString("MARIO BROS.", logoFont, logoBrush, 130, 110);

            // Set game state related graphics
            string stateText = "TRY TO SAVE LUIGI!";
            if (_gameLost)
            {
                stateText = "FAILED SAVING LUIGI!";
                BackColor = Color.DarkRed;
                dbPanel.BackColor = Color.DarkRed;
            }

            if (_gameWon)
            {
                stateText = "YOU SAVED LUIGI!";
                BackColor = Color.Green;
                dbPanel.BackColor = Color.Green;
            }

            Font font = new Font(fontCollection.Families[0], 64f);

            SizeF textSize = graphics.MeasureString(stateText, font);
            float x = (graphics.VisibleClipBounds.Width - textSize.Width) / 2f;
            float y = (graphics.VisibleClipBounds.Height - textSize.Height) / 2f;

            graphics.DrawString(stateText, font, whiteBrush, x, y);

            // Create press space to enter text
            Font playFont = new Font(fontCollection.Families[0], 24f);
            graphics.DrawString("press space to play", playFont, whiteBrush, 200, 350);
        }

        private void StartGame()
        {
            if (_gameIsActive)
            {
                return;
            }

            World = new WorldVisualization(width: WorldWidth, height: WorldHeight);
            _timer.Enabled = true;
            _gameIsActive = true;
            _gameLost = false;
            _gameWon = false;

            BackColor = Color.FromArgb(51, 153, 255);
        }

        private void WorldTimerElapsed(object sender, System.Timers.ElapsedEventArgs eventArgs)
        {
            World.Update(TimeDelta);
            dbPanel.Invalidate();

            UpdateWorldEventHandler?.Invoke(this, new UpdateWorldEvent(World));
        }

        private void Render(object sender, PaintEventArgs eventArgs)
        {
            if (!_gameIsActive)
            {
                RenderStartScreen(eventArgs.Graphics);
                return;
            }

            if (World.Player.Health <= 0)
            {
                _gameLost = true;
                _gameIsActive = false;
                RenderStartScreen(eventArgs.Graphics);
                return;
            }

            if (World.Rescuee.IsSaved)
            {
                _gameWon = true;
                _gameIsActive = false;
                RenderStartScreen(eventArgs.Graphics);
                return;
            }

            World.Render(eventArgs.Graphics);

            if (_renderGrid)
            {
                World.RenderGridOutline(eventArgs.Graphics);
            }

            if (_renderGraph)
            {
                World.RenderGraph(eventArgs.Graphics);
            }

            if (_renderHitBox)
            {
                World.RenderHitBox(eventArgs.Graphics);
            }

            if (_renderSteeringBehavior)
            {
                World.RenderSteeringBehavior(eventArgs.Graphics);
            }

            if (_renderSteeringBehavior)
            {
                World.RenderSteeringBehavior(eventArgs.Graphics);
            }

            if (_renderVelocity)
            {
                World.RenderVelocity(eventArgs.Graphics);
            }
        }

        private void OnTargetEntityPositionMouseClick(object sender, MouseEventArgs eventArgs)
        {
            if (!_gameIsActive || !_allowPlayerMoveOnMouseClick)
            {
                return;
            }

            World.Player.Position = new Vector(eventArgs.X, eventArgs.Y);
            World.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        public void UpdateTimerInterval(int interval) => _timer.Interval = interval;

        public bool IsTimerEnabled() => _timer.Enabled;

        public void EnableTimer() => _timer.Enabled = true;

        public void DisableTimer() => _timer.Enabled = false;

        public void UpdateWorld()
        {
            World.Update(TimeDelta);
            dbPanel.Invalidate();

            UpdateWorldEventHandler?.Invoke(this, new UpdateWorldEvent(World));
        }

        public void DisableGridRender() => _renderGrid = false;

        public void EnableGridRender() => _renderGrid = true;

        public void DisableGraphRender() => _renderGraph = false;

        public void EnableGraphRender() => _renderGraph = true;

        public void DisableHitBoxRender() => _renderHitBox = false;

        public void EnableHitBoxRender() => _renderHitBox = true;

        public void DisableSteeringBehaviorRender() => _renderSteeringBehavior = false;

        public void EnableSteeringBehaviorRender() => _renderSteeringBehavior = true;

        public void DisableVelocityRender() => _renderVelocity = false;

        public void EnableVelocityRender() => _renderVelocity = true;

        public void DisablePlayerMoveOnMouseClick() => _allowPlayerMoveOnMouseClick = false;
        public void EnablePlayerMoveOnMouseClick() => _allowPlayerMoveOnMouseClick = true;

        private void OnWorldFormKeyDown(object sender, KeyEventArgs eventArgs)
        {
            KeyHandler.RegisterPressedKeys(KeyEventArgsConverter.CreateFromEvent(eventArgs));

            switch (eventArgs.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Space:
                    StartGame();
                    break;
            }
        }

        private void OnWorldFormKeyUp(object sender, KeyEventArgs eventArgs) => KeyHandler.RegisterUnpressedKeys(KeyEventArgsConverter.CreateFromEvent(eventArgs));
    }
}
