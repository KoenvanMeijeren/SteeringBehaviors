using System.Drawing;
using System.Windows.Forms;
using Src.behavior;
using Src.util;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class WorldForm : Form
    {
        private WorldVisualization _world;
        private const int WorldHeight = 640;
        private const int WorldWidth = 640;

        private bool _renderGrid;
        private bool _renderGraph;
        private bool _renderHitBox;
        private bool _renderSteeringBehavior;
        private bool _renderVelocity;

        private const float TimeDelta = 0.8f;
        private readonly Timer _timer = new Timer();

        public WorldForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Width = WorldWidth + 116;
            Height = WorldHeight + 140;

            dbPanel.Width = WorldWidth;
            dbPanel.Height = WorldHeight;
            dbPanel.Location = new Point(50, 50);

            _world = new WorldVisualization(width: WorldWidth, height: WorldHeight);

            _timer.Elapsed += Timer_Elapsed;
            _timer.Interval = 20;
            _timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs eventArgs)
        {
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        private void Render(object sender, PaintEventArgs eventArgs)
        {
            _world.Render(eventArgs.Graphics);

            if (_renderGrid)
            {
                _world.RenderGridOutline(eventArgs.Graphics);
            }

            if (_renderGraph)
            {
                _world.RenderGraph(eventArgs.Graphics);
            }

            if (_renderHitBox)
            {
                _world.RenderHitBox(eventArgs.Graphics);
            }

            if (_renderSteeringBehavior)
            {
                _world.RenderSteeringBehavior(eventArgs.Graphics);
            }

            if (_renderSteeringBehavior)
            {
                _world.RenderSteeringBehavior(eventArgs.Graphics);
            }

            if (_renderVelocity)
            {
                _world.RenderVelocity(eventArgs.Graphics);
            }
        }

        private void targetEntityPosition_MouseClick(object sender, MouseEventArgs eventArgs)
        {
            _world.Target.Position = new Vector(eventArgs.X, eventArgs.Y);
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        public void UpdateTimerInterval(int interval)
        {
            _timer.Interval = interval;
        }

        public bool IsTimerEnabled()
        {
            return _timer.Enabled;
        }

        public void EnableTimer()
        {
            _timer.Enabled = true;
        }

        public void DisableTimer()
        {
            _timer.Enabled = false;
        }

        public void UpdateWorld()
        {
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        public void UpdateEntityValues(int mass, int maxSpeed, SteeringBehaviorOptions steeringBehaviorOption)
        {
            _world.EditPopulation(steeringBehaviorOption, mass, maxSpeed);
        }

        public void DisableGridRender()
        {
            _renderGrid = false;
        }

        public void EnableGridRender()
        {
            _renderGrid = true;
        }

        public void DisableGraphRender()
        {
            _renderGraph = false;
        }

        public void EnableGraphRender()
        {
            _renderGraph = true;
        }

        public void DisableHitBoxRender()
        {
            _renderHitBox = false;
        }

        public void EnableHitBoxRender()
        {
            _renderHitBox = true;
        }

        public void DisableSteeringBehaviorRender()
        {
            _renderSteeringBehavior = false;
        }

        public void EnableSteeringBehaviorRender()
        {
            _renderSteeringBehavior = true;
        }

        public void DisableVelocityRender()
        {
            _renderVelocity = false;
        }

        public void EnableVelocityRender()
        {
            _renderVelocity = true;
        }

        private void WorldForm_KeyDown(object sender, KeyEventArgs eventArgs)
        {
            KeyHandler.RegisterPressedKeys(KeyEventArgsConverter.CreateFromEvent(eventArgs));

            if (eventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void WorldForm_KeyUp(object sender, KeyEventArgs eventArgs)
        {
            KeyHandler.RegisterUnpressedKeys(KeyEventArgsConverter.CreateFromEvent(eventArgs));
        }
    }
}
