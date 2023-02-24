﻿using System;
using System.Drawing;
using System.Windows.Forms;
using SteeringCS.behavior;
using SteeringCS.entity;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class WorldForm : Form
    {
        private World _world;
        private const int _worldHeight = 640;
        private const int _worldWidth = 640;

        private bool _renderGrid;
        private bool _renderGraph;

        private const float TimeDelta = 0.8f;
        private readonly Timer _timer = new Timer();

        public WorldForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Width = _worldWidth + 116;
            Height = _worldHeight + 140;

            dbPanel.Width = _worldWidth;
            dbPanel.Height = _worldHeight;
            dbPanel.Location = new Point(50, 50);

            _world = new World(width: _worldWidth, height: _worldHeight);

            _timer.Elapsed += Timer_Elapsed;
            _timer.Interval = 20;
            _timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs eventArgs)
        {
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        private void dbPanel1_Paint(object sender, PaintEventArgs eventArgs)
        {
            _world.RenderGrid(eventArgs.Graphics);

            if (_renderGrid)
            {
                _world.RenderGridOutline(eventArgs.Graphics);
            }

            if (_renderGraph)
            {
                _world.RenderGraph(eventArgs.Graphics);
            }

            _world.Render(eventArgs.Graphics);
        }

        private void dbPanel1_MouseClick(object sender, MouseEventArgs eventArgs)
        {
            _world.Target.Position = new Vector2D(eventArgs.X, eventArgs.Y);
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
    }
}
