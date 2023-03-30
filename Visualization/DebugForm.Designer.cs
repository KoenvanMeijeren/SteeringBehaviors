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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ShowVelocityCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowBehaviorCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowHitboxCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowGraphCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowGridCheckbox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SteeringBehaviorSelector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxSpeedSelector = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.MassSelector = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Title1 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateIntervalSelector = new System.Windows.Forms.NumericUpDown();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpeedSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MassSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.ShowVelocityCheckbox);
            this.mainPanel.Controls.Add(this.ShowBehaviorCheckbox);
            this.mainPanel.Controls.Add(this.ShowHitboxCheckbox);
            this.mainPanel.Controls.Add(this.ShowGraphCheckbox);
            this.mainPanel.Controls.Add(this.ShowGridCheckbox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.SteeringBehaviorSelector);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.MaxSpeedSelector);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.MassSelector);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.Title1);
            this.mainPanel.Controls.Add(this.nextButton);
            this.mainPanel.Controls.Add(this.pauseButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.UpdateIntervalSelector);
            this.mainPanel.Location = new System.Drawing.Point(12, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(260, 355);
            this.mainPanel.TabIndex = 1;
            // 
            // ShowVelocityCheckbox
            // 
            this.ShowVelocityCheckbox.AutoSize = true;
            this.ShowVelocityCheckbox.Location = new System.Drawing.Point(0, 252);
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
            this.ShowBehaviorCheckbox.Location = new System.Drawing.Point(117, 222);
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
            this.ShowHitboxCheckbox.Location = new System.Drawing.Point(0, 222);
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
            this.ShowGraphCheckbox.Location = new System.Drawing.Point(117, 308);
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
            this.ShowGridCheckbox.Location = new System.Drawing.Point(0, 308);
            this.ShowGridCheckbox.Name = "ShowGridCheckbox";
            this.ShowGridCheckbox.Size = new System.Drawing.Size(88, 20);
            this.ShowGridCheckbox.TabIndex = 14;
            this.ShowGridCheckbox.Text = "Show grid";
            this.ShowGridCheckbox.UseVisualStyleBackColor = true;
            this.ShowGridCheckbox.CheckedChanged += new System.EventHandler(this.ShowGridCheckbox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-3, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Grid settings:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Steering Behavior:";
            // 
            // SteeringBehaviorSelector
            // 
            this.SteeringBehaviorSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SteeringBehaviorSelector.FormattingEnabled = true;
            this.SteeringBehaviorSelector.Location = new System.Drawing.Point(123, 186);
            this.SteeringBehaviorSelector.Name = "SteeringBehaviorSelector";
            this.SteeringBehaviorSelector.Size = new System.Drawing.Size(136, 24);
            this.SteeringBehaviorSelector.TabIndex = 11;
            this.SteeringBehaviorSelector.SelectedIndexChanged += new System.EventHandler(this.SteeringBehaviorSelector_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "MaxSpeed:";
            // 
            // MaxSpeedSelector
            // 
            this.MaxSpeedSelector.Location = new System.Drawing.Point(193, 152);
            this.MaxSpeedSelector.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.MaxSpeedSelector.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.MaxSpeedSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxSpeedSelector.Name = "MaxSpeedSelector";
            this.MaxSpeedSelector.Size = new System.Drawing.Size(68, 22);
            this.MaxSpeedSelector.TabIndex = 9;
            this.MaxSpeedSelector.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.MaxSpeedSelector.ValueChanged += new System.EventHandler(this.MaxSpeedSelector_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mass:";
            // 
            // MassSelector
            // 
            this.MassSelector.Location = new System.Drawing.Point(42, 152);
            this.MassSelector.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.MassSelector.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.MassSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MassSelector.Name = "MassSelector";
            this.MassSelector.Size = new System.Drawing.Size(66, 22);
            this.MassSelector.TabIndex = 7;
            this.MassSelector.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.MassSelector.ValueChanged += new System.EventHandler(this.MassSelector_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Entity settings:";
            // 
            // Title1
            // 
            this.Title1.AutoSize = true;
            this.Title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title1.Location = new System.Drawing.Point(-2, 9);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(109, 16);
            this.Title1.TabIndex = 5;
            this.Title1.Text = "Timer settings:";
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(139, 37);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(121, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(0, 37);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(121, 23);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "UpdateInterval (ms):";
            // 
            // UpdateIntervalSelector
            // 
            this.UpdateIntervalSelector.Location = new System.Drawing.Point(129, 71);
            this.UpdateIntervalSelector.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.UpdateIntervalSelector.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.UpdateIntervalSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateIntervalSelector.Name = "UpdateIntervalSelector";
            this.UpdateIntervalSelector.Size = new System.Drawing.Size(130, 22);
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
            this.ClientSize = new System.Drawing.Size(286, 367);
            this.Controls.Add(this.mainPanel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DebugForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpeedSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MassSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpdateIntervalSelector;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown MaxSpeedSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MassSelector;
        private System.Windows.Forms.ComboBox SteeringBehaviorSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ShowGridCheckbox;
        private System.Windows.Forms.CheckBox ShowGraphCheckbox;
        private System.Windows.Forms.CheckBox ShowHitboxCheckbox;
        private System.Windows.Forms.CheckBox ShowBehaviorCheckbox;
        private System.Windows.Forms.CheckBox ShowVelocityCheckbox;
    }
}

