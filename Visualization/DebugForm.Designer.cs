﻿using System;

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
            this.checkBoxShouldMovePlayerOnClick = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.consequenceResultValue = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.ConsequenceRightShoulderMaxValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceRightShoulderPeakValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceRightShoulderMinValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceTriangleMaxValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceTrianglePeakValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceTriangleMinValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceLeftShoulderMaxValue = new System.Windows.Forms.NumericUpDown();
            this.ConsequenceLeftShoulderPeakValue = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.ConsequenceLeftShoulderMinValue = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.antecedentDTNGRightShoulderMaxValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGRightShoulderPeakValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGRightShoulderMinValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGTriangleMaxValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGTrianglePeakValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGTriangleMinValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGLeftShoulderMaxValue = new System.Windows.Forms.NumericUpDown();
            this.antecedentDTNGLeftShoulderPeakValue = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.antecedentDTNGLeftShoulderMinValue = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.enemiesLabel = new System.Windows.Forms.Label();
            this.enemiesValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
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
            this.nextButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.UpdateIntervalLabel = new System.Windows.Forms.Label();
            this.UpdateIntervalSelector = new System.Windows.Forms.NumericUpDown();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceRightShoulderMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceRightShoulderPeakValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceRightShoulderMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceTriangleMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceTrianglePeakValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceTriangleMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceLeftShoulderMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceLeftShoulderPeakValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceLeftShoulderMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGRightShoulderMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGRightShoulderPeakValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGRightShoulderMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGTriangleMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGTrianglePeakValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGTriangleMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGLeftShoulderMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGLeftShoulderPeakValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGLeftShoulderMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemiesValue)).BeginInit();
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
            this.mainPanel.Controls.Add(this.checkBoxShouldMovePlayerOnClick);
            this.mainPanel.Controls.Add(this.label26);
            this.mainPanel.Controls.Add(this.consequenceResultValue);
            this.mainPanel.Controls.Add(this.label27);
            this.mainPanel.Controls.Add(this.ConsequenceRightShoulderMaxValue);
            this.mainPanel.Controls.Add(this.ConsequenceRightShoulderPeakValue);
            this.mainPanel.Controls.Add(this.ConsequenceRightShoulderMinValue);
            this.mainPanel.Controls.Add(this.ConsequenceTriangleMaxValue);
            this.mainPanel.Controls.Add(this.ConsequenceTrianglePeakValue);
            this.mainPanel.Controls.Add(this.ConsequenceTriangleMinValue);
            this.mainPanel.Controls.Add(this.ConsequenceLeftShoulderMaxValue);
            this.mainPanel.Controls.Add(this.ConsequenceLeftShoulderPeakValue);
            this.mainPanel.Controls.Add(this.label20);
            this.mainPanel.Controls.Add(this.label21);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.label23);
            this.mainPanel.Controls.Add(this.label24);
            this.mainPanel.Controls.Add(this.label25);
            this.mainPanel.Controls.Add(this.ConsequenceLeftShoulderMinValue);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.antecedentDTNGRightShoulderMaxValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGRightShoulderPeakValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGRightShoulderMinValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGTriangleMaxValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGTrianglePeakValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGTriangleMinValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGLeftShoulderMaxValue);
            this.mainPanel.Controls.Add(this.antecedentDTNGLeftShoulderPeakValue);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.label16);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.label18);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.antecedentDTNGLeftShoulderMinValue);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.enemiesLabel);
            this.mainPanel.Controls.Add(this.enemiesValue);
            this.mainPanel.Controls.Add(this.label1);
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
            this.mainPanel.Controls.Add(this.nextButton);
            this.mainPanel.Controls.Add(this.pauseButton);
            this.mainPanel.Controls.Add(this.UpdateIntervalLabel);
            this.mainPanel.Controls.Add(this.UpdateIntervalSelector);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(418, 695);
            this.mainPanel.TabIndex = 1;
            // 
            // checkBoxShouldMovePlayerOnClick
            // 
            this.checkBoxShouldMovePlayerOnClick.AutoSize = true;
            this.checkBoxShouldMovePlayerOnClick.Location = new System.Drawing.Point(263, 347);
            this.checkBoxShouldMovePlayerOnClick.Name = "checkBoxShouldMovePlayerOnClick";
            this.checkBoxShouldMovePlayerOnClick.Size = new System.Drawing.Size(158, 21);
            this.checkBoxShouldMovePlayerOnClick.TabIndex = 106;
            this.checkBoxShouldMovePlayerOnClick.Text = "Move player on click";
            this.checkBoxShouldMovePlayerOnClick.UseVisualStyleBackColor = true;
            this.checkBoxShouldMovePlayerOnClick.CheckedChanged += new System.EventHandler(this.checkBoxShouldMovePlayerOnClick_CheckedChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 853);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 17);
            this.label26.TabIndex = 105;
            // 
            // consequenceResultValue
            // 
            this.consequenceResultValue.AutoSize = true;
            this.consequenceResultValue.Location = new System.Drawing.Point(200, 661);
            this.consequenceResultValue.Name = "consequenceResultValue";
            this.consequenceResultValue.Size = new System.Drawing.Size(13, 17);
            this.consequenceResultValue.TabIndex = 104;
            this.consequenceResultValue.Text = "-";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 661);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(171, 17);
            this.label27.TabIndex = 103;
            this.label27.Text = "Desirability to follow Mario";
            // 
            // ConsequenceRightShoulderMaxValue
            // 
            this.ConsequenceRightShoulderMaxValue.Location = new System.Drawing.Point(253, 636);
            this.ConsequenceRightShoulderMaxValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceRightShoulderMaxValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceRightShoulderMaxValue.Name = "ConsequenceRightShoulderMaxValue";
            this.ConsequenceRightShoulderMaxValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceRightShoulderMaxValue.TabIndex = 102;
            // 
            // ConsequenceRightShoulderPeakValue
            // 
            this.ConsequenceRightShoulderPeakValue.Location = new System.Drawing.Point(252, 608);
            this.ConsequenceRightShoulderPeakValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceRightShoulderPeakValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceRightShoulderPeakValue.Name = "ConsequenceRightShoulderPeakValue";
            this.ConsequenceRightShoulderPeakValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceRightShoulderPeakValue.TabIndex = 101;
            // 
            // ConsequenceRightShoulderMinValue
            // 
            this.ConsequenceRightShoulderMinValue.Location = new System.Drawing.Point(253, 586);
            this.ConsequenceRightShoulderMinValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceRightShoulderMinValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceRightShoulderMinValue.Name = "ConsequenceRightShoulderMinValue";
            this.ConsequenceRightShoulderMinValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceRightShoulderMinValue.TabIndex = 100;
            // 
            // ConsequenceTriangleMaxValue
            // 
            this.ConsequenceTriangleMaxValue.Location = new System.Drawing.Point(156, 636);
            this.ConsequenceTriangleMaxValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceTriangleMaxValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceTriangleMaxValue.Name = "ConsequenceTriangleMaxValue";
            this.ConsequenceTriangleMaxValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceTriangleMaxValue.TabIndex = 99;
            // 
            // ConsequenceTrianglePeakValue
            // 
            this.ConsequenceTrianglePeakValue.Location = new System.Drawing.Point(155, 608);
            this.ConsequenceTrianglePeakValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceTrianglePeakValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceTrianglePeakValue.Name = "ConsequenceTrianglePeakValue";
            this.ConsequenceTrianglePeakValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceTrianglePeakValue.TabIndex = 98;
            // 
            // ConsequenceTriangleMinValue
            // 
            this.ConsequenceTriangleMinValue.Location = new System.Drawing.Point(156, 586);
            this.ConsequenceTriangleMinValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceTriangleMinValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceTriangleMinValue.Name = "ConsequenceTriangleMinValue";
            this.ConsequenceTriangleMinValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceTriangleMinValue.TabIndex = 97;
            // 
            // ConsequenceLeftShoulderMaxValue
            // 
            this.ConsequenceLeftShoulderMaxValue.Location = new System.Drawing.Point(61, 636);
            this.ConsequenceLeftShoulderMaxValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceLeftShoulderMaxValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceLeftShoulderMaxValue.Name = "ConsequenceLeftShoulderMaxValue";
            this.ConsequenceLeftShoulderMaxValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceLeftShoulderMaxValue.TabIndex = 96;
            // 
            // ConsequenceLeftShoulderPeakValue
            // 
            this.ConsequenceLeftShoulderPeakValue.Location = new System.Drawing.Point(60, 608);
            this.ConsequenceLeftShoulderPeakValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceLeftShoulderPeakValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceLeftShoulderPeakValue.Name = "ConsequenceLeftShoulderPeakValue";
            this.ConsequenceLeftShoulderPeakValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceLeftShoulderPeakValue.TabIndex = 95;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 638);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 17);
            this.label20.TabIndex = 94;
            this.label20.Text = "Max";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 613);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 17);
            this.label21.TabIndex = 93;
            this.label21.Text = "Peak";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 591);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 17);
            this.label22.TabIndex = 92;
            this.label22.Text = "Min";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(252, 566);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 17);
            this.label23.TabIndex = 91;
            this.label23.Text = "Very desirable";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(155, 566);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 17);
            this.label24.TabIndex = 90;
            this.label24.Text = "Desirable";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(58, 566);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 17);
            this.label25.TabIndex = 89;
            this.label25.Text = "Undesirable";
            // 
            // ConsequenceLeftShoulderMinValue
            // 
            this.ConsequenceLeftShoulderMinValue.Location = new System.Drawing.Point(61, 586);
            this.ConsequenceLeftShoulderMinValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.ConsequenceLeftShoulderMinValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.ConsequenceLeftShoulderMinValue.Name = "ConsequenceLeftShoulderMinValue";
            this.ConsequenceLeftShoulderMinValue.Size = new System.Drawing.Size(51, 22);
            this.ConsequenceLeftShoulderMinValue.TabIndex = 88;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(201, 519);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 17);
            this.label12.TabIndex = 87;
            this.label12.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 519);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 17);
            this.label13.TabIndex = 86;
            this.label13.Text = "Distance to nearest goomba";
            // 
            // antecedentDTNGRightShoulderMaxValue
            // 
            this.antecedentDTNGRightShoulderMaxValue.Location = new System.Drawing.Point(252, 494);
            this.antecedentDTNGRightShoulderMaxValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGRightShoulderMaxValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.antecedentDTNGRightShoulderMaxValue.Name = "antecedentDTNGRightShoulderMaxValue";
            this.antecedentDTNGRightShoulderMaxValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGRightShoulderMaxValue.TabIndex = 85;
            // 
            // antecedentDTNGRightShoulderPeakValue
            // 
            this.antecedentDTNGRightShoulderPeakValue.Location = new System.Drawing.Point(251, 466);
            this.antecedentDTNGRightShoulderPeakValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGRightShoulderPeakValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.antecedentDTNGRightShoulderPeakValue.Name = "antecedentDTNGRightShoulderPeakValue";
            this.antecedentDTNGRightShoulderPeakValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGRightShoulderPeakValue.TabIndex = 84;
            // 
            // antecedentDTNGRightShoulderMinValue
            // 
            this.antecedentDTNGRightShoulderMinValue.Location = new System.Drawing.Point(252, 444);
            this.antecedentDTNGRightShoulderMinValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGRightShoulderMinValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.antecedentDTNGRightShoulderMinValue.Name = "antecedentDTNGRightShoulderMinValue";
            this.antecedentDTNGRightShoulderMinValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGRightShoulderMinValue.TabIndex = 83;
            // 
            // antecedentDTNGTriangleMaxValue
            // 
            this.antecedentDTNGTriangleMaxValue.Location = new System.Drawing.Point(155, 494);
            this.antecedentDTNGTriangleMaxValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGTriangleMaxValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.antecedentDTNGTriangleMaxValue.Name = "antecedentDTNGTriangleMaxValue";
            this.antecedentDTNGTriangleMaxValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGTriangleMaxValue.TabIndex = 82;
            // 
            // antecedentDTNGTrianglePeakValue
            // 
            this.antecedentDTNGTrianglePeakValue.Location = new System.Drawing.Point(154, 466);
            this.antecedentDTNGTrianglePeakValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGTrianglePeakValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.antecedentDTNGTrianglePeakValue.Name = "antecedentDTNGTrianglePeakValue";
            this.antecedentDTNGTrianglePeakValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGTrianglePeakValue.TabIndex = 81;
            // 
            // antecedentDTNGTriangleMinValue
            // 
            this.antecedentDTNGTriangleMinValue.Location = new System.Drawing.Point(155, 444);
            this.antecedentDTNGTriangleMinValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGTriangleMinValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.antecedentDTNGTriangleMinValue.Name = "antecedentDTNGTriangleMinValue";
            this.antecedentDTNGTriangleMinValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGTriangleMinValue.TabIndex = 80;
            // 
            // antecedentDTNGLeftShoulderMaxValue
            // 
            this.antecedentDTNGLeftShoulderMaxValue.DecimalPlaces = 2;
            this.antecedentDTNGLeftShoulderMaxValue.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.antecedentDTNGLeftShoulderMaxValue.Location = new System.Drawing.Point(60, 494);
            this.antecedentDTNGLeftShoulderMaxValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGLeftShoulderMaxValue.Name = "antecedentDTNGLeftShoulderMaxValue";
            this.antecedentDTNGLeftShoulderMaxValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGLeftShoulderMaxValue.TabIndex = 79;
            // 
            // antecedentDTNGLeftShoulderPeakValue
            // 
            this.antecedentDTNGLeftShoulderPeakValue.DecimalPlaces = 2;
            this.antecedentDTNGLeftShoulderPeakValue.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.antecedentDTNGLeftShoulderPeakValue.Location = new System.Drawing.Point(59, 466);
            this.antecedentDTNGLeftShoulderPeakValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGLeftShoulderPeakValue.Name = "antecedentDTNGLeftShoulderPeakValue";
            this.antecedentDTNGLeftShoulderPeakValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGLeftShoulderPeakValue.TabIndex = 78;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 496);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 17);
            this.label14.TabIndex = 77;
            this.label14.Text = "Max";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 471);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 76;
            this.label15.Text = "Peak";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 449);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 17);
            this.label16.TabIndex = 75;
            this.label16.Text = "Min";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(251, 424);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 17);
            this.label17.TabIndex = 74;
            this.label17.Text = "Far";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(154, 424);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 17);
            this.label18.TabIndex = 73;
            this.label18.Text = "Medium";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(57, 424);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 17);
            this.label19.TabIndex = 72;
            this.label19.Text = "Close";
            // 
            // antecedentDTNGLeftShoulderMinValue
            // 
            this.antecedentDTNGLeftShoulderMinValue.DecimalPlaces = 2;
            this.antecedentDTNGLeftShoulderMinValue.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.antecedentDTNGLeftShoulderMinValue.Location = new System.Drawing.Point(60, 444);
            this.antecedentDTNGLeftShoulderMinValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.antecedentDTNGLeftShoulderMinValue.Name = "antecedentDTNGLeftShoulderMinValue";
            this.antecedentDTNGLeftShoulderMinValue.Size = new System.Drawing.Size(51, 22);
            this.antecedentDTNGLeftShoulderMinValue.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-1, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Variable Desirability to follow Mario (in %)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-1, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 17);
            this.label5.TabIndex = 54;
            this.label5.Text = "Variable distance to nearest goomba (in %)";
            // 
            // enemiesLabel
            // 
            this.enemiesLabel.AutoSize = true;
            this.enemiesLabel.Location = new System.Drawing.Point(2, 176);
            this.enemiesLabel.Name = "enemiesLabel";
            this.enemiesLabel.Size = new System.Drawing.Size(135, 17);
            this.enemiesLabel.TabIndex = 52;
            this.enemiesLabel.Text = "Number of enemies:";
            // 
            // enemiesValue
            // 
            this.enemiesValue.Location = new System.Drawing.Point(209, 174);
            this.enemiesValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.enemiesValue.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.enemiesValue.Name = "enemiesValue";
            this.enemiesValue.Size = new System.Drawing.Size(51, 22);
            this.enemiesValue.TabIndex = 51;
            this.enemiesValue.ValueChanged += new System.EventHandler(this.enemiesValue_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Fuzzy logic settings";
            // 
            // DebugSettingsLabel
            // 
            this.DebugSettingsLabel.AutoSize = true;
            this.DebugSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugSettingsLabel.Location = new System.Drawing.Point(-4, 297);
            this.DebugSettingsLabel.Name = "DebugSettingsLabel";
            this.DebugSettingsLabel.Size = new System.Drawing.Size(117, 17);
            this.DebugSettingsLabel.TabIndex = 47;
            this.DebugSettingsLabel.Text = "Debug settings";
            // 
            // Enemy3StateValue
            // 
            this.Enemy3StateValue.AutoSize = true;
            this.Enemy3StateValue.Location = new System.Drawing.Point(336, 263);
            this.Enemy3StateValue.Name = "Enemy3StateValue";
            this.Enemy3StateValue.Size = new System.Drawing.Size(13, 17);
            this.Enemy3StateValue.TabIndex = 46;
            this.Enemy3StateValue.Text = "-";
            // 
            // Enemy3StateLabel
            // 
            this.Enemy3StateLabel.AutoSize = true;
            this.Enemy3StateLabel.Location = new System.Drawing.Point(278, 266);
            this.Enemy3StateLabel.Name = "Enemy3StateLabel";
            this.Enemy3StateLabel.Size = new System.Drawing.Size(57, 17);
            this.Enemy3StateLabel.TabIndex = 45;
            this.Enemy3StateLabel.Text = "State 3:";
            // 
            // Enemy3MaxSpeedLabel
            // 
            this.Enemy3MaxSpeedLabel.AutoSize = true;
            this.Enemy3MaxSpeedLabel.Location = new System.Drawing.Point(117, 263);
            this.Enemy3MaxSpeedLabel.Name = "Enemy3MaxSpeedLabel";
            this.Enemy3MaxSpeedLabel.Size = new System.Drawing.Size(92, 17);
            this.Enemy3MaxSpeedLabel.TabIndex = 44;
            this.Enemy3MaxSpeedLabel.Text = "Max speed 3:";
            // 
            // Enemy3MaxSpeedValue
            // 
            this.Enemy3MaxSpeedValue.Location = new System.Drawing.Point(210, 261);
            this.Enemy3MaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy3MaxSpeedValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.Enemy3MaxSpeedValue.Name = "Enemy3MaxSpeedValue";
            this.Enemy3MaxSpeedValue.Size = new System.Drawing.Size(52, 22);
            this.Enemy3MaxSpeedValue.TabIndex = 43;
            this.Enemy3MaxSpeedValue.ValueChanged += new System.EventHandler(this.Enemy3MaxSpeedValue_ValueChanged);
            // 
            // Enemy3MassLabel
            // 
            this.Enemy3MassLabel.AutoSize = true;
            this.Enemy3MassLabel.Location = new System.Drawing.Point(1, 263);
            this.Enemy3MassLabel.Name = "Enemy3MassLabel";
            this.Enemy3MassLabel.Size = new System.Drawing.Size(57, 17);
            this.Enemy3MassLabel.TabIndex = 42;
            this.Enemy3MassLabel.Text = "Mass 3:";
            // 
            // Enemy3MassValue
            // 
            this.Enemy3MassValue.Location = new System.Drawing.Point(60, 258);
            this.Enemy3MassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy3MassValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.Enemy3MassValue.Name = "Enemy3MassValue";
            this.Enemy3MassValue.Size = new System.Drawing.Size(55, 22);
            this.Enemy3MassValue.TabIndex = 41;
            this.Enemy3MassValue.ValueChanged += new System.EventHandler(this.Enemy3MassValue_ValueChanged);
            // 
            // Enemy2StateValue
            // 
            this.Enemy2StateValue.AutoSize = true;
            this.Enemy2StateValue.Location = new System.Drawing.Point(336, 236);
            this.Enemy2StateValue.Name = "Enemy2StateValue";
            this.Enemy2StateValue.Size = new System.Drawing.Size(13, 17);
            this.Enemy2StateValue.TabIndex = 40;
            this.Enemy2StateValue.Text = "-";
            // 
            // Enemy2StateLabel
            // 
            this.Enemy2StateLabel.AutoSize = true;
            this.Enemy2StateLabel.Location = new System.Drawing.Point(278, 236);
            this.Enemy2StateLabel.Name = "Enemy2StateLabel";
            this.Enemy2StateLabel.Size = new System.Drawing.Size(57, 17);
            this.Enemy2StateLabel.TabIndex = 39;
            this.Enemy2StateLabel.Text = "State 2:";
            // 
            // Enemy2MaxSpeedLabel
            // 
            this.Enemy2MaxSpeedLabel.AutoSize = true;
            this.Enemy2MaxSpeedLabel.Location = new System.Drawing.Point(117, 233);
            this.Enemy2MaxSpeedLabel.Name = "Enemy2MaxSpeedLabel";
            this.Enemy2MaxSpeedLabel.Size = new System.Drawing.Size(92, 17);
            this.Enemy2MaxSpeedLabel.TabIndex = 38;
            this.Enemy2MaxSpeedLabel.Text = "Max speed 2:";
            // 
            // Enemy2MaxSpeedValue
            // 
            this.Enemy2MaxSpeedValue.Location = new System.Drawing.Point(210, 231);
            this.Enemy2MaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy2MaxSpeedValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.Enemy2MaxSpeedValue.Name = "Enemy2MaxSpeedValue";
            this.Enemy2MaxSpeedValue.Size = new System.Drawing.Size(49, 22);
            this.Enemy2MaxSpeedValue.TabIndex = 37;
            this.Enemy2MaxSpeedValue.ValueChanged += new System.EventHandler(this.Enemy2MaxSpeedValue_ValueChanged);
            // 
            // Enemy2MassLabel
            // 
            this.Enemy2MassLabel.AutoSize = true;
            this.Enemy2MassLabel.Location = new System.Drawing.Point(1, 233);
            this.Enemy2MassLabel.Name = "Enemy2MassLabel";
            this.Enemy2MassLabel.Size = new System.Drawing.Size(57, 17);
            this.Enemy2MassLabel.TabIndex = 36;
            this.Enemy2MassLabel.Text = "Mass 2:";
            // 
            // Enemy2MassValue
            // 
            this.Enemy2MassValue.Location = new System.Drawing.Point(60, 231);
            this.Enemy2MassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy2MassValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.Enemy2MassValue.Name = "Enemy2MassValue";
            this.Enemy2MassValue.Size = new System.Drawing.Size(51, 22);
            this.Enemy2MassValue.TabIndex = 35;
            this.Enemy2MassValue.ValueChanged += new System.EventHandler(this.Enemy2MassValue_ValueChanged);
            // 
            // Enemy1StateValue
            // 
            this.Enemy1StateValue.AutoSize = true;
            this.Enemy1StateValue.Location = new System.Drawing.Point(337, 207);
            this.Enemy1StateValue.Name = "Enemy1StateValue";
            this.Enemy1StateValue.Size = new System.Drawing.Size(13, 17);
            this.Enemy1StateValue.TabIndex = 34;
            this.Enemy1StateValue.Text = "-";
            // 
            // Enemy1StateLabel
            // 
            this.Enemy1StateLabel.AutoSize = true;
            this.Enemy1StateLabel.Location = new System.Drawing.Point(279, 204);
            this.Enemy1StateLabel.Name = "Enemy1StateLabel";
            this.Enemy1StateLabel.Size = new System.Drawing.Size(57, 17);
            this.Enemy1StateLabel.TabIndex = 33;
            this.Enemy1StateLabel.Text = "State 1:";
            // 
            // Enemy1MaxSpeedLabel
            // 
            this.Enemy1MaxSpeedLabel.AutoSize = true;
            this.Enemy1MaxSpeedLabel.Location = new System.Drawing.Point(118, 204);
            this.Enemy1MaxSpeedLabel.Name = "Enemy1MaxSpeedLabel";
            this.Enemy1MaxSpeedLabel.Size = new System.Drawing.Size(92, 17);
            this.Enemy1MaxSpeedLabel.TabIndex = 32;
            this.Enemy1MaxSpeedLabel.Text = "Max speed 1:";
            // 
            // Enemy1MaxSpeedValue
            // 
            this.Enemy1MaxSpeedValue.Location = new System.Drawing.Point(211, 202);
            this.Enemy1MaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy1MaxSpeedValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.Enemy1MaxSpeedValue.Name = "Enemy1MaxSpeedValue";
            this.Enemy1MaxSpeedValue.Size = new System.Drawing.Size(49, 22);
            this.Enemy1MaxSpeedValue.TabIndex = 31;
            this.Enemy1MaxSpeedValue.ValueChanged += new System.EventHandler(this.Enemy1MaxSpeedValue_ValueChanged);
            // 
            // Enemy1MassLabel
            // 
            this.Enemy1MassLabel.AutoSize = true;
            this.Enemy1MassLabel.Location = new System.Drawing.Point(2, 204);
            this.Enemy1MassLabel.Name = "Enemy1MassLabel";
            this.Enemy1MassLabel.Size = new System.Drawing.Size(57, 17);
            this.Enemy1MassLabel.TabIndex = 30;
            this.Enemy1MassLabel.Text = "Mass 1:";
            // 
            // Enemy1MassValue
            // 
            this.Enemy1MassValue.Location = new System.Drawing.Point(61, 202);
            this.Enemy1MassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.Enemy1MassValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.Enemy1MassValue.Name = "Enemy1MassValue";
            this.Enemy1MassValue.Size = new System.Drawing.Size(51, 22);
            this.Enemy1MassValue.TabIndex = 29;
            this.Enemy1MassValue.ValueChanged += new System.EventHandler(this.Enemy1MassValue_ValueChanged);
            // 
            // EnemiesSettingsLabel
            // 
            this.EnemiesSettingsLabel.AutoSize = true;
            this.EnemiesSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemiesSettingsLabel.Location = new System.Drawing.Point(-4, 152);
            this.EnemiesSettingsLabel.Name = "EnemiesSettingsLabel";
            this.EnemiesSettingsLabel.Size = new System.Drawing.Size(304, 17);
            this.EnemiesSettingsLabel.TabIndex = 28;
            this.EnemiesSettingsLabel.Text = "Enemies settings (only first 3 are shown)";
            // 
            // RescueeStateValue
            // 
            this.RescueeStateValue.AutoSize = true;
            this.RescueeStateValue.Location = new System.Drawing.Point(335, 118);
            this.RescueeStateValue.Name = "RescueeStateValue";
            this.RescueeStateValue.Size = new System.Drawing.Size(13, 17);
            this.RescueeStateValue.TabIndex = 27;
            this.RescueeStateValue.Text = "-";
            // 
            // RescueeStateLabel
            // 
            this.RescueeStateLabel.AutoSize = true;
            this.RescueeStateLabel.Location = new System.Drawing.Point(277, 118);
            this.RescueeStateLabel.Name = "RescueeStateLabel";
            this.RescueeStateLabel.Size = new System.Drawing.Size(45, 17);
            this.RescueeStateLabel.TabIndex = 26;
            this.RescueeStateLabel.Text = "State:";
            // 
            // RescueeMaxSpeedLabel
            // 
            this.RescueeMaxSpeedLabel.AutoSize = true;
            this.RescueeMaxSpeedLabel.Location = new System.Drawing.Point(114, 115);
            this.RescueeMaxSpeedLabel.Name = "RescueeMaxSpeedLabel";
            this.RescueeMaxSpeedLabel.Size = new System.Drawing.Size(80, 17);
            this.RescueeMaxSpeedLabel.TabIndex = 25;
            this.RescueeMaxSpeedLabel.Text = "Max speed:";
            // 
            // RescueeMaxSpeedValue
            // 
            this.RescueeMaxSpeedValue.Location = new System.Drawing.Point(207, 113);
            this.RescueeMaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.RescueeMaxSpeedValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.RescueeMaxSpeedValue.Name = "RescueeMaxSpeedValue";
            this.RescueeMaxSpeedValue.Size = new System.Drawing.Size(54, 22);
            this.RescueeMaxSpeedValue.TabIndex = 24;
            this.RescueeMaxSpeedValue.ValueChanged += new System.EventHandler(this.RescueeMaxSpeedValue_ValueChanged);
            // 
            // RescueeMassLabel
            // 
            this.RescueeMassLabel.AutoSize = true;
            this.RescueeMassLabel.Location = new System.Drawing.Point(-2, 115);
            this.RescueeMassLabel.Name = "RescueeMassLabel";
            this.RescueeMassLabel.Size = new System.Drawing.Size(45, 17);
            this.RescueeMassLabel.TabIndex = 23;
            this.RescueeMassLabel.Text = "Mass:";
            // 
            // RescueeMassValue
            // 
            this.RescueeMassValue.Location = new System.Drawing.Point(57, 113);
            this.RescueeMassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.RescueeMassValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.RescueeMassValue.Name = "RescueeMassValue";
            this.RescueeMassValue.Size = new System.Drawing.Size(51, 22);
            this.RescueeMassValue.TabIndex = 22;
            this.RescueeMassValue.ValueChanged += new System.EventHandler(this.RescueeMassValue_ValueChanged);
            // 
            // RescueeSettingsLabel
            // 
            this.RescueeSettingsLabel.AutoSize = true;
            this.RescueeSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RescueeSettingsLabel.Location = new System.Drawing.Point(-4, 93);
            this.RescueeSettingsLabel.Name = "RescueeSettingsLabel";
            this.RescueeSettingsLabel.Size = new System.Drawing.Size(133, 17);
            this.RescueeSettingsLabel.TabIndex = 21;
            this.RescueeSettingsLabel.Text = "Rescuee settings";
            // 
            // PlayerStateValue
            // 
            this.PlayerStateValue.AutoSize = true;
            this.PlayerStateValue.Location = new System.Drawing.Point(334, 63);
            this.PlayerStateValue.Name = "PlayerStateValue";
            this.PlayerStateValue.Size = new System.Drawing.Size(13, 17);
            this.PlayerStateValue.TabIndex = 20;
            this.PlayerStateValue.Text = "-";
            // 
            // PlayerStateLabel
            // 
            this.PlayerStateLabel.AutoSize = true;
            this.PlayerStateLabel.Location = new System.Drawing.Point(276, 63);
            this.PlayerStateLabel.Name = "PlayerStateLabel";
            this.PlayerStateLabel.Size = new System.Drawing.Size(45, 17);
            this.PlayerStateLabel.TabIndex = 19;
            this.PlayerStateLabel.Text = "State:";
            // 
            // ShowVelocityCheckbox
            // 
            this.ShowVelocityCheckbox.AutoSize = true;
            this.ShowVelocityCheckbox.Location = new System.Drawing.Point(4, 347);
            this.ShowVelocityCheckbox.Name = "ShowVelocityCheckbox";
            this.ShowVelocityCheckbox.Size = new System.Drawing.Size(115, 21);
            this.ShowVelocityCheckbox.TabIndex = 18;
            this.ShowVelocityCheckbox.Text = "Show velocity";
            this.ShowVelocityCheckbox.UseVisualStyleBackColor = true;
            this.ShowVelocityCheckbox.CheckedChanged += new System.EventHandler(this.ShowVelocityCheckbox_CheckedChanged);
            // 
            // ShowBehaviorCheckbox
            // 
            this.ShowBehaviorCheckbox.AutoSize = true;
            this.ShowBehaviorCheckbox.Location = new System.Drawing.Point(134, 317);
            this.ShowBehaviorCheckbox.Name = "ShowBehaviorCheckbox";
            this.ShowBehaviorCheckbox.Size = new System.Drawing.Size(123, 21);
            this.ShowBehaviorCheckbox.TabIndex = 17;
            this.ShowBehaviorCheckbox.Text = "Show behavior";
            this.ShowBehaviorCheckbox.UseVisualStyleBackColor = true;
            this.ShowBehaviorCheckbox.CheckedChanged += new System.EventHandler(this.ShowBehaviorCheckbox_CheckedChanged);
            // 
            // ShowHitboxCheckbox
            // 
            this.ShowHitboxCheckbox.AutoSize = true;
            this.ShowHitboxCheckbox.Location = new System.Drawing.Point(4, 317);
            this.ShowHitboxCheckbox.Name = "ShowHitboxCheckbox";
            this.ShowHitboxCheckbox.Size = new System.Drawing.Size(105, 21);
            this.ShowHitboxCheckbox.TabIndex = 16;
            this.ShowHitboxCheckbox.Text = "Show hitbox";
            this.ShowHitboxCheckbox.UseVisualStyleBackColor = true;
            this.ShowHitboxCheckbox.CheckedChanged += new System.EventHandler(this.ShowHitBoxCheckbox_CheckedChanged);
            // 
            // ShowGraphCheckbox
            // 
            this.ShowGraphCheckbox.AutoSize = true;
            this.ShowGraphCheckbox.Location = new System.Drawing.Point(263, 317);
            this.ShowGraphCheckbox.Name = "ShowGraphCheckbox";
            this.ShowGraphCheckbox.Size = new System.Drawing.Size(105, 21);
            this.ShowGraphCheckbox.TabIndex = 15;
            this.ShowGraphCheckbox.Text = "Show graph";
            this.ShowGraphCheckbox.UseVisualStyleBackColor = true;
            this.ShowGraphCheckbox.CheckedChanged += new System.EventHandler(this.ShowGraphCheckbox_CheckedChanged);
            // 
            // ShowGridCheckbox
            // 
            this.ShowGridCheckbox.AutoSize = true;
            this.ShowGridCheckbox.Location = new System.Drawing.Point(134, 347);
            this.ShowGridCheckbox.Name = "ShowGridCheckbox";
            this.ShowGridCheckbox.Size = new System.Drawing.Size(92, 21);
            this.ShowGridCheckbox.TabIndex = 14;
            this.ShowGridCheckbox.Text = "Show grid";
            this.ShowGridCheckbox.UseVisualStyleBackColor = true;
            this.ShowGridCheckbox.CheckedChanged += new System.EventHandler(this.ShowGridCheckbox_CheckedChanged);
            // 
            // PlayerMaxSpeedLabel
            // 
            this.PlayerMaxSpeedLabel.AutoSize = true;
            this.PlayerMaxSpeedLabel.Location = new System.Drawing.Point(112, 60);
            this.PlayerMaxSpeedLabel.Name = "PlayerMaxSpeedLabel";
            this.PlayerMaxSpeedLabel.Size = new System.Drawing.Size(80, 17);
            this.PlayerMaxSpeedLabel.TabIndex = 10;
            this.PlayerMaxSpeedLabel.Text = "Max speed:";
            // 
            // PlayerMaxSpeedValue
            // 
            this.PlayerMaxSpeedValue.Location = new System.Drawing.Point(206, 58);
            this.PlayerMaxSpeedValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.PlayerMaxSpeedValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.PlayerMaxSpeedValue.Name = "PlayerMaxSpeedValue";
            this.PlayerMaxSpeedValue.Size = new System.Drawing.Size(53, 22);
            this.PlayerMaxSpeedValue.TabIndex = 9;
            this.PlayerMaxSpeedValue.ValueChanged += new System.EventHandler(this.PlayerMaxSpeedValueChanged);
            // 
            // PlayerMassLabel
            // 
            this.PlayerMassLabel.AutoSize = true;
            this.PlayerMassLabel.Location = new System.Drawing.Point(-4, 60);
            this.PlayerMassLabel.Name = "PlayerMassLabel";
            this.PlayerMassLabel.Size = new System.Drawing.Size(45, 17);
            this.PlayerMassLabel.TabIndex = 8;
            this.PlayerMassLabel.Text = "Mass:";
            // 
            // PlayerMassValue
            // 
            this.PlayerMassValue.Location = new System.Drawing.Point(56, 58);
            this.PlayerMassValue.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.PlayerMassValue.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.PlayerMassValue.Name = "PlayerMassValue";
            this.PlayerMassValue.Size = new System.Drawing.Size(50, 22);
            this.PlayerMassValue.TabIndex = 7;
            this.PlayerMassValue.ValueChanged += new System.EventHandler(this.PlayerMassValueChanged);
            // 
            // PlayerSettingsLabel
            // 
            this.PlayerSettingsLabel.AutoSize = true;
            this.PlayerSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerSettingsLabel.Location = new System.Drawing.Point(-4, 38);
            this.PlayerSettingsLabel.Name = "PlayerSettingsLabel";
            this.PlayerSettingsLabel.Size = new System.Drawing.Size(116, 17);
            this.PlayerSettingsLabel.TabIndex = 6;
            this.PlayerSettingsLabel.Text = "Player settings";
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(315, 6);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(100, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(209, 6);
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
            this.UpdateIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateIntervalLabel.Location = new System.Drawing.Point(-4, 12);
            this.UpdateIntervalLabel.Name = "UpdateIntervalLabel";
            this.UpdateIntervalLabel.Size = new System.Drawing.Size(150, 17);
            this.UpdateIntervalLabel.TabIndex = 2;
            this.UpdateIntervalLabel.Text = "Timer Interval (ms):";
            // 
            // UpdateIntervalSelector
            // 
            this.UpdateIntervalSelector.Location = new System.Drawing.Point(146, 10);
            this.UpdateIntervalSelector.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.UpdateIntervalSelector.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.UpdateIntervalSelector.Name = "UpdateIntervalSelector";
            this.UpdateIntervalSelector.Size = new System.Drawing.Size(51, 22);
            this.UpdateIntervalSelector.TabIndex = 1;
            this.UpdateIntervalSelector.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.UpdateIntervalSelector.ValueChanged += new System.EventHandler(this.UpdateIntervalSelectorValueChangedChanged);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 722);
            this.Controls.Add(this.mainPanel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DebugForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceRightShoulderMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceRightShoulderPeakValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceRightShoulderMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceTriangleMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceTrianglePeakValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceTriangleMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceLeftShoulderMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceLeftShoulderPeakValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsequenceLeftShoulderMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGRightShoulderMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGRightShoulderPeakValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGRightShoulderMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGTriangleMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGTrianglePeakValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGTriangleMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGLeftShoulderMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGLeftShoulderPeakValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antecedentDTNGLeftShoulderMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemiesValue)).EndInit();
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

        private System.Windows.Forms.CheckBox checkBoxShouldMovePlayerOnClick;

        private System.Windows.Forms.Label label26;

        private System.Windows.Forms.Label consequenceResultValue;
        private System.Windows.Forms.Label label27;

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown antecedentDTNGRightShoulderMaxValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGRightShoulderPeakValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGRightShoulderMinValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGTriangleMaxValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGTrianglePeakValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGTriangleMinValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGLeftShoulderMaxValue;
        private System.Windows.Forms.NumericUpDown antecedentDTNGLeftShoulderPeakValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown antecedentDTNGLeftShoulderMinValue;
        private System.Windows.Forms.NumericUpDown ConsequenceRightShoulderMaxValue;
        private System.Windows.Forms.NumericUpDown ConsequenceRightShoulderPeakValue;
        private System.Windows.Forms.NumericUpDown ConsequenceRightShoulderMinValue;
        private System.Windows.Forms.NumericUpDown ConsequenceTriangleMaxValue;
        private System.Windows.Forms.NumericUpDown ConsequenceTrianglePeakValue;
        private System.Windows.Forms.NumericUpDown ConsequenceTriangleMinValue;
        private System.Windows.Forms.NumericUpDown ConsequenceLeftShoulderMaxValue;
        private System.Windows.Forms.NumericUpDown ConsequenceLeftShoulderPeakValue;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown ConsequenceLeftShoulderMinValue;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label enemiesLabel;
        private System.Windows.Forms.NumericUpDown enemiesValue;

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label UpdateIntervalLabel;
        private System.Windows.Forms.NumericUpDown UpdateIntervalSelector;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button pauseButton;
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

