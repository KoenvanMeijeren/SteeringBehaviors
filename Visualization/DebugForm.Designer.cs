using System;

namespace SteeringCS
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }

                base.Dispose(disposing);
            }
            catch(InvalidOperationException)
            {

            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.DebugSettingsLabel = new System.Windows.Forms.Label();
            this.Enemy3StateValue = new System.Windows.Forms.Label();
            this.Enemy3StateLabel = new System.Windows.Forms.Label();
            this.Enemy3MaxSpeedLabel = new System.Windows.Forms.Label();
            this.Enemy3MaxSpeedValue = new System.Windows.Forms.NumericUpDown();
            this.Enemy3MassLabel = new System.Windows.Forms.Label();
            this.Enemy3MassValue = new System.Windows.Forms.NumericUpDown();
            this.Enemy2StateValue = new System.Windows.Forms.Label();
            this.Enemy2StateLabel = new System.Windows.Forms.Label();
            this.Enemy2MaxSpeedLabel = new System.Windows.Forms.Label();
            this.Enemy2MaxSpeedValue = new System.Windows.Forms.NumericUpDown();
            this.Enemy2MassLabel = new System.Windows.Forms.Label();
            this.Enemy2MassValue = new System.Windows.Forms.NumericUpDown();
            this.Enemy1StateValue = new System.Windows.Forms.Label();
            this.Enemy1StateLabel = new System.Windows.Forms.Label();
            this.Enemy1MaxSpeedLabel = new System.Windows.Forms.Label();
            this.Enemy1MaxSpeedValue = new System.Windows.Forms.NumericUpDown();
            this.Enemy1MassLabel = new System.Windows.Forms.Label();
            this.Enemy1MassValue = new System.Windows.Forms.NumericUpDown();
            this.EnemiesSettingsLabel = new System.Windows.Forms.Label();
            this.RescueeStateValue = new System.Windows.Forms.Label();
            this.RescueeStateLabel = new System.Windows.Forms.Label();
            this.RescueeMaxSpeedLabel = new System.Windows.Forms.Label();
            this.RescueeMaxSpeedValue = new System.Windows.Forms.NumericUpDown();
            this.RescueeMassLabel = new System.Windows.Forms.Label();
            this.RescueeMassValue = new System.Windows.Forms.NumericUpDown();
            this.RescueeSettingsLabel = new System.Windows.Forms.Label();
            this.PlayerStateValue = new System.Windows.Forms.Label();
            this.PlayerStateLabel = new System.Windows.Forms.Label();
            this.ShowVelocityCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowBehaviorCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowHitboxCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowGraphCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowGridCheckbox = new System.Windows.Forms.CheckBox();
            this.PlayerMaxSpeedLabel = new System.Windows.Forms.Label();
            this.PlayerMaxSpeedValue = new System.Windows.Forms.NumericUpDown();
            this.PlayerMassLabel = new System.Windows.Forms.Label();
            this.PlayerMassValue = new System.Windows.Forms.NumericUpDown();
            this.PlayerSettingsLabel = new System.Windows.Forms.Label();
            this.TimerSettingsLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.UpdateIntervalLabel = new System.Windows.Forms.Label();
            this.UpdateIntervalSelector = new System.Windows.Forms.NumericUpDown();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3MaxSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3MassValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2MaxSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2MassValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1MaxSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1MassValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RescueeMaxSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RescueeMassValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMaxSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMassValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.DebugSettingsLabel);
            this.mainPanel.Controls.Add(this.Enemy3StateValue);
            this.mainPanel.Controls.Add(this.Enemy3StateLabel);
            this.mainPanel.Controls.Add(this.Enemy3MaxSpeedLabel);
            this.mainPanel.Controls.Add(this.Enemy3MaxSpeedValue);
            this.mainPanel.Controls.Add(this.Enemy3MassLabel);
            this.mainPanel.Controls.Add(this.Enemy3MassValue);
            this.mainPanel.Controls.Add(this.Enemy2StateValue);
            this.mainPanel.Controls.Add(this.Enemy2StateLabel);
            this.mainPanel.Controls.Add(this.Enemy2MaxSpeedLabel);
            this.mainPanel.Controls.Add(this.Enemy2MaxSpeedValue);
            this.mainPanel.Controls.Add(this.Enemy2MassLabel);
            this.mainPanel.Controls.Add(this.Enemy2MassValue);
            this.mainPanel.Controls.Add(this.Enemy1StateValue);
            this.mainPanel.Controls.Add(this.Enemy1StateLabel);
            this.mainPanel.Controls.Add(this.Enemy1MaxSpeedLabel);
            this.mainPanel.Controls.Add(this.Enemy1MaxSpeedValue);
            this.mainPanel.Controls.Add(this.Enemy1MassLabel);
            this.mainPanel.Controls.Add(this.Enemy1MassValue);
            this.mainPanel.Controls.Add(this.EnemiesSettingsLabel);
            this.mainPanel.Controls.Add(this.RescueeStateValue);
            this.mainPanel.Controls.Add(this.RescueeStateLabel);
            this.mainPanel.Controls.Add(this.RescueeMaxSpeedLabel);
            this.mainPanel.Controls.Add(this.RescueeMaxSpeedValue);
            this.mainPanel.Controls.Add(this.RescueeMassLabel);
            this.mainPanel.Controls.Add(this.RescueeMassValue);
            this.mainPanel.Controls.Add(this.RescueeSettingsLabel);
            this.mainPanel.Controls.Add(this.PlayerStateValue);
            this.mainPanel.Controls.Add(this.PlayerStateLabel);
            this.mainPanel.Controls.Add(this.ShowVelocityCheckbox);
            this.mainPanel.Controls.Add(this.ShowBehaviorCheckbox);
            this.mainPanel.Controls.Add(this.ShowHitboxCheckbox);
            this.mainPanel.Controls.Add(this.ShowGraphCheckbox);
            this.mainPanel.Controls.Add(this.ShowGridCheckbox);
            this.mainPanel.Controls.Add(this.PlayerMaxSpeedLabel);
            this.mainPanel.Controls.Add(this.PlayerMaxSpeedValue);
            this.mainPanel.Controls.Add(this.PlayerMassLabel);
            this.mainPanel.Controls.Add(this.PlayerMassValue);
            this.mainPanel.Controls.Add(this.PlayerSettingsLabel);
            this.mainPanel.Controls.Add(this.TimerSettingsLabel);
            this.mainPanel.Controls.Add(this.nextButton);
            this.mainPanel.Controls.Add(this.pauseButton);
            this.mainPanel.Controls.Add(this.UpdateIntervalLabel);
            this.mainPanel.Controls.Add(this.UpdateIntervalSelector);
            this.mainPanel.Location = new System.Drawing.Point(12, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(260, 501);
            this.mainPanel.TabIndex = 1;
            // 
            // DebugSettingsLabel
            // 
            this.DebugSettingsLabel.AutoSize = true;
            this.DebugSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugSettingsLabel.Location = new System.Drawing.Point(-4, 395);
            this.DebugSettingsLabel.Name = "DebugSettingsLabel";
            this.DebugSettingsLabel.Size = new System.Drawing.Size(111, 16);
            this.DebugSettingsLabel.TabIndex = 47;
            this.DebugSettingsLabel.Text = "Debug settings";
            // 
            // Enemy3StateValue
            // 
            this.Enemy3StateValue.AutoSize = true;
            this.Enemy3StateValue.Location = new System.Drawing.Point(55, 365);
            this.Enemy3StateValue.Name = "Enemy3StateValue";
            this.Enemy3StateValue.Size = new System.Drawing.Size(11, 16);
            this.Enemy3StateValue.TabIndex = 46;
            this.Enemy3StateValue.Text = "-";
            // 
            // Enemy3StateLabel
            // 
            this.Enemy3StateLabel.AutoSize = true;
            this.Enemy3StateLabel.Location = new System.Drawing.Point(-2, 365);
            this.Enemy3StateLabel.Name = "Enemy3StateLabel";
            this.Enemy3StateLabel.Size = new System.Drawing.Size(51, 16);
            this.Enemy3StateLabel.TabIndex = 45;
            this.Enemy3StateLabel.Text = "State 3:";
            // 
            // Enemy3MaxSpeedLabel
            // 
            this.Enemy3MaxSpeedLabel.AutoSize = true;
            this.Enemy3MaxSpeedLabel.Location = new System.Drawing.Point(115, 339);
            this.Enemy3MaxSpeedLabel.Name = "Enemy3MaxSpeedLabel";
            this.Enemy3MaxSpeedLabel.Size = new System.Drawing.Size(87, 16);
            this.Enemy3MaxSpeedLabel.TabIndex = 44;
            this.Enemy3MaxSpeedLabel.Text = "Max speed 3:";
            // 
            // Enemy3MaxSpeedValue
            // 
            this.Enemy3MaxSpeedValue.Location = new System.Drawing.Point(208, 337);
            this.Enemy3MaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy3MaxSpeedValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Enemy3MaxSpeedValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy3MaxSpeedValue.Name = "Enemy3MaxSpeedValue";
            this.Enemy3MaxSpeedValue.Size = new System.Drawing.Size(52, 22);
            this.Enemy3MaxSpeedValue.TabIndex = 43;
            this.Enemy3MaxSpeedValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy3MaxSpeedValue.ValueChanged += new System.EventHandler(this.Enemy3MaxSpeedValue_ValueChanged);
            // 
            // Enemy3MassLabel
            // 
            this.Enemy3MassLabel.AutoSize = true;
            this.Enemy3MassLabel.Location = new System.Drawing.Point(-1, 339);
            this.Enemy3MassLabel.Name = "Enemy3MassLabel";
            this.Enemy3MassLabel.Size = new System.Drawing.Size(53, 16);
            this.Enemy3MassLabel.TabIndex = 42;
            this.Enemy3MassLabel.Text = "Mass 3:";
            // 
            // Enemy3MassValue
            // 
            this.Enemy3MassValue.Location = new System.Drawing.Point(58, 334);
            this.Enemy3MassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy3MassValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Enemy3MassValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy3MassValue.Name = "Enemy3MassValue";
            this.Enemy3MassValue.Size = new System.Drawing.Size(55, 22);
            this.Enemy3MassValue.TabIndex = 41;
            this.Enemy3MassValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy3MassValue.ValueChanged += new System.EventHandler(this.Enemy3MassValue_ValueChanged);
            // 
            // Enemy2StateValue
            // 
            this.Enemy2StateValue.AutoSize = true;
            this.Enemy2StateValue.Location = new System.Drawing.Point(55, 315);
            this.Enemy2StateValue.Name = "Enemy2StateValue";
            this.Enemy2StateValue.Size = new System.Drawing.Size(11, 16);
            this.Enemy2StateValue.TabIndex = 40;
            this.Enemy2StateValue.Text = "-";
            // 
            // Enemy2StateLabel
            // 
            this.Enemy2StateLabel.AutoSize = true;
            this.Enemy2StateLabel.Location = new System.Drawing.Point(-2, 315);
            this.Enemy2StateLabel.Name = "Enemy2StateLabel";
            this.Enemy2StateLabel.Size = new System.Drawing.Size(51, 16);
            this.Enemy2StateLabel.TabIndex = 39;
            this.Enemy2StateLabel.Text = "State 2:";
            // 
            // Enemy2MaxSpeedLabel
            // 
            this.Enemy2MaxSpeedLabel.AutoSize = true;
            this.Enemy2MaxSpeedLabel.Location = new System.Drawing.Point(115, 289);
            this.Enemy2MaxSpeedLabel.Name = "Enemy2MaxSpeedLabel";
            this.Enemy2MaxSpeedLabel.Size = new System.Drawing.Size(87, 16);
            this.Enemy2MaxSpeedLabel.TabIndex = 38;
            this.Enemy2MaxSpeedLabel.Text = "Max speed 2:";
            // 
            // Enemy2MaxSpeedValue
            // 
            this.Enemy2MaxSpeedValue.Location = new System.Drawing.Point(208, 287);
            this.Enemy2MaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy2MaxSpeedValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Enemy2MaxSpeedValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy2MaxSpeedValue.Name = "Enemy2MaxSpeedValue";
            this.Enemy2MaxSpeedValue.Size = new System.Drawing.Size(49, 22);
            this.Enemy2MaxSpeedValue.TabIndex = 37;
            this.Enemy2MaxSpeedValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy2MaxSpeedValue.ValueChanged += new System.EventHandler(this.Enemy2MaxSpeedValue_ValueChanged);
            // 
            // Enemy2MassLabel
            // 
            this.Enemy2MassLabel.AutoSize = true;
            this.Enemy2MassLabel.Location = new System.Drawing.Point(-1, 289);
            this.Enemy2MassLabel.Name = "Enemy2MassLabel";
            this.Enemy2MassLabel.Size = new System.Drawing.Size(53, 16);
            this.Enemy2MassLabel.TabIndex = 36;
            this.Enemy2MassLabel.Text = "Mass 2:";
            // 
            // Enemy2MassValue
            // 
            this.Enemy2MassValue.Location = new System.Drawing.Point(58, 287);
            this.Enemy2MassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy2MassValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Enemy2MassValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy2MassValue.Name = "Enemy2MassValue";
            this.Enemy2MassValue.Size = new System.Drawing.Size(51, 22);
            this.Enemy2MassValue.TabIndex = 35;
            this.Enemy2MassValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy2MassValue.ValueChanged += new System.EventHandler(this.Enemy2MassValue_ValueChanged);
            // 
            // Enemy1StateValue
            // 
            this.Enemy1StateValue.AutoSize = true;
            this.Enemy1StateValue.Location = new System.Drawing.Point(55, 268);
            this.Enemy1StateValue.Name = "Enemy1StateValue";
            this.Enemy1StateValue.Size = new System.Drawing.Size(11, 16);
            this.Enemy1StateValue.TabIndex = 34;
            this.Enemy1StateValue.Text = "-";
            // 
            // Enemy1StateLabel
            // 
            this.Enemy1StateLabel.AutoSize = true;
            this.Enemy1StateLabel.Location = new System.Drawing.Point(-2, 268);
            this.Enemy1StateLabel.Name = "Enemy1StateLabel";
            this.Enemy1StateLabel.Size = new System.Drawing.Size(51, 16);
            this.Enemy1StateLabel.TabIndex = 33;
            this.Enemy1StateLabel.Text = "State 1:";
            // 
            // Enemy1MaxSpeedLabel
            // 
            this.Enemy1MaxSpeedLabel.AutoSize = true;
            this.Enemy1MaxSpeedLabel.Location = new System.Drawing.Point(115, 242);
            this.Enemy1MaxSpeedLabel.Name = "Enemy1MaxSpeedLabel";
            this.Enemy1MaxSpeedLabel.Size = new System.Drawing.Size(87, 16);
            this.Enemy1MaxSpeedLabel.TabIndex = 32;
            this.Enemy1MaxSpeedLabel.Text = "Max speed 1:";
            // 
            // Enemy1MaxSpeedValue
            // 
            this.Enemy1MaxSpeedValue.Location = new System.Drawing.Point(208, 240);
            this.Enemy1MaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy1MaxSpeedValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Enemy1MaxSpeedValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy1MaxSpeedValue.Name = "Enemy1MaxSpeedValue";
            this.Enemy1MaxSpeedValue.Size = new System.Drawing.Size(49, 22);
            this.Enemy1MaxSpeedValue.TabIndex = 31;
            this.Enemy1MaxSpeedValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Enemy1MaxSpeedValue.ValueChanged += new System.EventHandler(this.Enemy1MaxSpeedValue_ValueChanged);
            // 
            // Enemy1MassLabel
            // 
            this.Enemy1MassLabel.AutoSize = true;
            this.Enemy1MassLabel.Location = new System.Drawing.Point(-1, 242);
            this.Enemy1MassLabel.Name = "Enemy1MassLabel";
            this.Enemy1MassLabel.Size = new System.Drawing.Size(53, 16);
            this.Enemy1MassLabel.TabIndex = 30;
            this.Enemy1MassLabel.Text = "Mass 1:";
            // 
            // Enemy1MassValue
            // 
            this.Enemy1MassValue.Location = new System.Drawing.Point(58, 240);
            this.Enemy1MassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy1MassValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Enemy1MassValue.Name = "Enemy1MassValue";
            this.Enemy1MassValue.Size = new System.Drawing.Size(51, 22);
            this.Enemy1MassValue.TabIndex = 29;
            this.Enemy1MassValue.ValueChanged += new System.EventHandler(this.Enemy1MassValue_ValueChanged);
            // 
            // EnemiesSettingsLabel
            // 
            this.EnemiesSettingsLabel.AutoSize = true;
            this.EnemiesSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemiesSettingsLabel.Location = new System.Drawing.Point(-1, 220);
            this.EnemiesSettingsLabel.Name = "EnemiesSettingsLabel";
            this.EnemiesSettingsLabel.Size = new System.Drawing.Size(125, 16);
            this.EnemiesSettingsLabel.TabIndex = 28;
            this.EnemiesSettingsLabel.Text = "Enemies settings";
            // 
            // RescueeStateValue
            // 
            this.RescueeStateValue.AutoSize = true;
            this.RescueeStateValue.Location = new System.Drawing.Point(55, 188);
            this.RescueeStateValue.Name = "RescueeStateValue";
            this.RescueeStateValue.Size = new System.Drawing.Size(11, 16);
            this.RescueeStateValue.TabIndex = 27;
            this.RescueeStateValue.Text = "-";
            // 
            // RescueeStateLabel
            // 
            this.RescueeStateLabel.AutoSize = true;
            this.RescueeStateLabel.Location = new System.Drawing.Point(-2, 188);
            this.RescueeStateLabel.Name = "RescueeStateLabel";
            this.RescueeStateLabel.Size = new System.Drawing.Size(41, 16);
            this.RescueeStateLabel.TabIndex = 26;
            this.RescueeStateLabel.Text = "State:";
            // 
            // RescueeMaxSpeedLabel
            // 
            this.RescueeMaxSpeedLabel.AutoSize = true;
            this.RescueeMaxSpeedLabel.Location = new System.Drawing.Point(115, 162);
            this.RescueeMaxSpeedLabel.Name = "RescueeMaxSpeedLabel";
            this.RescueeMaxSpeedLabel.Size = new System.Drawing.Size(77, 16);
            this.RescueeMaxSpeedLabel.TabIndex = 25;
            this.RescueeMaxSpeedLabel.Text = "Max speed:";
            // 
            // RescueeMaxSpeedValue
            // 
            this.RescueeMaxSpeedValue.Location = new System.Drawing.Point(208, 160);
            this.RescueeMaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.RescueeMaxSpeedValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.RescueeMaxSpeedValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RescueeMaxSpeedValue.Name = "RescueeMaxSpeedValue";
            this.RescueeMaxSpeedValue.Size = new System.Drawing.Size(54, 22);
            this.RescueeMaxSpeedValue.TabIndex = 24;
            this.RescueeMaxSpeedValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RescueeMaxSpeedValue.ValueChanged += new System.EventHandler(this.RescueeMaxSpeedValue_ValueChanged);
            // 
            // RescueeMassLabel
            // 
            this.RescueeMassLabel.AutoSize = true;
            this.RescueeMassLabel.Location = new System.Drawing.Point(-1, 162);
            this.RescueeMassLabel.Name = "RescueeMassLabel";
            this.RescueeMassLabel.Size = new System.Drawing.Size(43, 16);
            this.RescueeMassLabel.TabIndex = 23;
            this.RescueeMassLabel.Text = "Mass:";
            // 
            // RescueeMassValue
            // 
            this.RescueeMassValue.Location = new System.Drawing.Point(58, 160);
            this.RescueeMassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.RescueeMassValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.RescueeMassValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RescueeMassValue.Name = "RescueeMassValue";
            this.RescueeMassValue.Size = new System.Drawing.Size(51, 22);
            this.RescueeMassValue.TabIndex = 22;
            this.RescueeMassValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RescueeMassValue.ValueChanged += new System.EventHandler(this.RescueeMassValue_ValueChanged);
            // 
            // RescueeSettingsLabel
            // 
            this.RescueeSettingsLabel.AutoSize = true;
            this.RescueeSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RescueeSettingsLabel.Location = new System.Drawing.Point(-1, 140);
            this.RescueeSettingsLabel.Name = "RescueeSettingsLabel";
            this.RescueeSettingsLabel.Size = new System.Drawing.Size(127, 16);
            this.RescueeSettingsLabel.TabIndex = 21;
            this.RescueeSettingsLabel.Text = "Rescuee settings";
            // 
            // PlayerStateValue
            // 
            this.PlayerStateValue.AutoSize = true;
            this.PlayerStateValue.Location = new System.Drawing.Point(55, 107);
            this.PlayerStateValue.Name = "PlayerStateValue";
            this.PlayerStateValue.Size = new System.Drawing.Size(11, 16);
            this.PlayerStateValue.TabIndex = 20;
            this.PlayerStateValue.Text = "-";
            // 
            // PlayerStateLabel
            // 
            this.PlayerStateLabel.AutoSize = true;
            this.PlayerStateLabel.Location = new System.Drawing.Point(-3, 110);
            this.PlayerStateLabel.Name = "PlayerStateLabel";
            this.PlayerStateLabel.Size = new System.Drawing.Size(41, 16);
            this.PlayerStateLabel.TabIndex = 19;
            this.PlayerStateLabel.Text = "State:";
            // 
            // ShowVelocityCheckbox
            // 
            this.ShowVelocityCheckbox.AutoSize = true;
            this.ShowVelocityCheckbox.Location = new System.Drawing.Point(0, 445);
            this.ShowVelocityCheckbox.Name = "ShowVelocityCheckbox";
            this.ShowVelocityCheckbox.Size = new System.Drawing.Size(111, 20);
            this.ShowVelocityCheckbox.TabIndex = 18;
            this.ShowVelocityCheckbox.Text = "Show velocity";
            this.ShowVelocityCheckbox.UseVisualStyleBackColor = true;
            this.ShowVelocityCheckbox.CheckedChanged += new System.EventHandler(this.ShowVelocityCheckbox_CheckedChanged);
            // 
            // ShowBehaviorCheckbox
            // 
            this.ShowBehaviorCheckbox.AutoSize = true;
            this.ShowBehaviorCheckbox.Location = new System.Drawing.Point(129, 415);
            this.ShowBehaviorCheckbox.Name = "ShowBehaviorCheckbox";
            this.ShowBehaviorCheckbox.Size = new System.Drawing.Size(118, 20);
            this.ShowBehaviorCheckbox.TabIndex = 17;
            this.ShowBehaviorCheckbox.Text = "Show behavior";
            this.ShowBehaviorCheckbox.UseVisualStyleBackColor = true;
            this.ShowBehaviorCheckbox.CheckedChanged += new System.EventHandler(this.ShowBehaviorCheckbox_CheckedChanged);
            // 
            // ShowHitboxCheckbox
            // 
            this.ShowHitboxCheckbox.AutoSize = true;
            this.ShowHitboxCheckbox.Location = new System.Drawing.Point(0, 415);
            this.ShowHitboxCheckbox.Name = "ShowHitboxCheckbox";
            this.ShowHitboxCheckbox.Size = new System.Drawing.Size(100, 20);
            this.ShowHitboxCheckbox.TabIndex = 16;
            this.ShowHitboxCheckbox.Text = "Show hitbox";
            this.ShowHitboxCheckbox.UseVisualStyleBackColor = true;
            this.ShowHitboxCheckbox.CheckedChanged += new System.EventHandler(this.ShowHitBoxCheckbox_CheckedChanged);
            // 
            // ShowGraphCheckbox
            // 
            this.ShowGraphCheckbox.AutoSize = true;
            this.ShowGraphCheckbox.Location = new System.Drawing.Point(1, 471);
            this.ShowGraphCheckbox.Name = "ShowGraphCheckbox";
            this.ShowGraphCheckbox.Size = new System.Drawing.Size(100, 20);
            this.ShowGraphCheckbox.TabIndex = 15;
            this.ShowGraphCheckbox.Text = "Show graph";
            this.ShowGraphCheckbox.UseVisualStyleBackColor = true;
            this.ShowGraphCheckbox.CheckedChanged += new System.EventHandler(this.ShowGraphCheckbox_CheckedChanged);
            // 
            // ShowGridCheckbox
            // 
            this.ShowGridCheckbox.AutoSize = true;
            this.ShowGridCheckbox.Location = new System.Drawing.Point(130, 445);
            this.ShowGridCheckbox.Name = "ShowGridCheckbox";
            this.ShowGridCheckbox.Size = new System.Drawing.Size(88, 20);
            this.ShowGridCheckbox.TabIndex = 14;
            this.ShowGridCheckbox.Text = "Show grid";
            this.ShowGridCheckbox.UseVisualStyleBackColor = true;
            this.ShowGridCheckbox.CheckedChanged += new System.EventHandler(this.ShowGridCheckbox_CheckedChanged);
            // 
            // PlayerMaxSpeedLabel
            // 
            this.PlayerMaxSpeedLabel.AutoSize = true;
            this.PlayerMaxSpeedLabel.Location = new System.Drawing.Point(114, 84);
            this.PlayerMaxSpeedLabel.Name = "PlayerMaxSpeedLabel";
            this.PlayerMaxSpeedLabel.Size = new System.Drawing.Size(77, 16);
            this.PlayerMaxSpeedLabel.TabIndex = 10;
            this.PlayerMaxSpeedLabel.Text = "Max speed:";
            // 
            // PlayerMaxSpeedValue
            // 
            this.PlayerMaxSpeedValue.Location = new System.Drawing.Point(208, 82);
            this.PlayerMaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.PlayerMaxSpeedValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PlayerMaxSpeedValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PlayerMaxSpeedValue.Name = "PlayerMaxSpeedValue";
            this.PlayerMaxSpeedValue.Size = new System.Drawing.Size(53, 22);
            this.PlayerMaxSpeedValue.TabIndex = 9;
            this.PlayerMaxSpeedValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PlayerMaxSpeedValue.ValueChanged += new System.EventHandler(this.PlayerMaxSpeedValueChanged);
            // 
            // PlayerMassLabel
            // 
            this.PlayerMassLabel.AutoSize = true;
            this.PlayerMassLabel.Location = new System.Drawing.Point(-2, 84);
            this.PlayerMassLabel.Name = "PlayerMassLabel";
            this.PlayerMassLabel.Size = new System.Drawing.Size(43, 16);
            this.PlayerMassLabel.TabIndex = 8;
            this.PlayerMassLabel.Text = "Mass:";
            // 
            // PlayerMassValue
            // 
            this.PlayerMassValue.Location = new System.Drawing.Point(58, 82);
            this.PlayerMassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.PlayerMassValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PlayerMassValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PlayerMassValue.Name = "PlayerMassValue";
            this.PlayerMassValue.Size = new System.Drawing.Size(50, 22);
            this.PlayerMassValue.TabIndex = 7;
            this.PlayerMassValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PlayerMassValue.ValueChanged += new System.EventHandler(this.PlayerMassValueChanged);
            // 
            // PlayerSettingsLabel
            // 
            this.PlayerSettingsLabel.AutoSize = true;
            this.PlayerSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerSettingsLabel.Location = new System.Drawing.Point(-2, 62);
            this.PlayerSettingsLabel.Name = "PlayerSettingsLabel";
            this.PlayerSettingsLabel.Size = new System.Drawing.Size(110, 16);
            this.PlayerSettingsLabel.TabIndex = 6;
            this.PlayerSettingsLabel.Text = "Player settings";
            // 
            // TimerSettingsLabel
            // 
            this.TimerSettingsLabel.AutoSize = true;
            this.TimerSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerSettingsLabel.Location = new System.Drawing.Point(-4, 9);
            this.TimerSettingsLabel.Name = "TimerSettingsLabel";
            this.TimerSettingsLabel.Size = new System.Drawing.Size(47, 16);
            this.TimerSettingsLabel.TabIndex = 5;
            this.TimerSettingsLabel.Text = "Timer";
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(159, 6);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(100, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(49, 6);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(100, 23);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // UpdateIntervalLabel
            // 
            this.UpdateIntervalLabel.AutoSize = true;
            this.UpdateIntervalLabel.Location = new System.Drawing.Point(-2, 33);
            this.UpdateIntervalLabel.Name = "UpdateIntervalLabel";
            this.UpdateIntervalLabel.Size = new System.Drawing.Size(130, 16);
            this.UpdateIntervalLabel.TabIndex = 2;
            this.UpdateIntervalLabel.Text = "Update Interval (ms):";
            // 
            // UpdateIntervalSelector
            // 
            this.UpdateIntervalSelector.Location = new System.Drawing.Point(208, 31);
            this.UpdateIntervalSelector.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.UpdateIntervalSelector.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.UpdateIntervalSelector.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UpdateIntervalSelector.Name = "UpdateIntervalSelector";
            this.UpdateIntervalSelector.Size = new System.Drawing.Size(51, 22);
            this.UpdateIntervalSelector.TabIndex = 1;
            this.UpdateIntervalSelector.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.UpdateIntervalSelector.ValueChanged += new System.EventHandler(this.UpdateIntervalSelectorValueChangedChanged);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 506);
            this.Controls.Add(this.mainPanel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DebugForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3MaxSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3MassValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2MaxSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2MassValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1MaxSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1MassValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RescueeMaxSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RescueeMassValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMaxSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMassValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label UpdateIntervalLabel;
        private System.Windows.Forms.NumericUpDown UpdateIntervalSelector;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label TimerSettingsLabel;
        private System.Windows.Forms.Label PlayerSettingsLabel;
        private System.Windows.Forms.Label PlayerMaxSpeedLabel;
        private System.Windows.Forms.NumericUpDown PlayerMaxSpeedValue;
        private System.Windows.Forms.Label PlayerMassLabel;
        private System.Windows.Forms.NumericUpDown PlayerMassValue;
        private System.Windows.Forms.CheckBox ShowGridCheckbox;
        private System.Windows.Forms.CheckBox ShowGraphCheckbox;
        private System.Windows.Forms.CheckBox ShowHitboxCheckbox;
        private System.Windows.Forms.CheckBox ShowBehaviorCheckbox;
        private System.Windows.Forms.CheckBox ShowVelocityCheckbox;
        private System.Windows.Forms.Label PlayerStateLabel;
        private System.Windows.Forms.Label PlayerStateValue;
        private System.Windows.Forms.Label DebugSettingsLabel;
        private System.Windows.Forms.Label Enemy3StateValue;
        private System.Windows.Forms.Label Enemy3StateLabel;
        private System.Windows.Forms.Label Enemy3MaxSpeedLabel;
        private System.Windows.Forms.NumericUpDown Enemy3MaxSpeedValue;
        private System.Windows.Forms.Label Enemy3MassLabel;
        private System.Windows.Forms.NumericUpDown Enemy3MassValue;
        private System.Windows.Forms.Label Enemy2StateValue;
        private System.Windows.Forms.Label Enemy2StateLabel;
        private System.Windows.Forms.Label Enemy2MaxSpeedLabel;
        private System.Windows.Forms.NumericUpDown Enemy2MaxSpeedValue;
        private System.Windows.Forms.Label Enemy2MassLabel;
        private System.Windows.Forms.NumericUpDown Enemy2MassValue;
        private System.Windows.Forms.Label Enemy1StateValue;
        private System.Windows.Forms.Label Enemy1StateLabel;
        private System.Windows.Forms.Label Enemy1MaxSpeedLabel;
        private System.Windows.Forms.NumericUpDown Enemy1MaxSpeedValue;
        private System.Windows.Forms.Label Enemy1MassLabel;
        private System.Windows.Forms.NumericUpDown Enemy1MassValue;
        private System.Windows.Forms.Label EnemiesSettingsLabel;
        private System.Windows.Forms.Label RescueeStateValue;
        private System.Windows.Forms.Label RescueeStateLabel;
        private System.Windows.Forms.Label RescueeMaxSpeedLabel;
        private System.Windows.Forms.NumericUpDown RescueeMaxSpeedValue;
        private System.Windows.Forms.Label RescueeMassLabel;
        private System.Windows.Forms.NumericUpDown RescueeMassValue;
        private System.Windows.Forms.Label RescueeSettingsLabel;
    }
}

