namespace SteeringCS
{
    partial class WorldForm
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
            this.dbPanel = new SteeringCS.DbPanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.continueBtn = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbPanel
            // 
            this.dbPanel.BackColor = System.Drawing.Color.White;
            this.dbPanel.Location = new System.Drawing.Point(0, 0);
            this.dbPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dbPanel.Name = "dbPanel";
            this.dbPanel.Size = new System.Drawing.Size(815, 537);
            this.dbPanel.TabIndex = 0;
            this.dbPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.dbPanel1_Paint);
            this.dbPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbPanel1_MouseClick);
            // 
            // panel1
            // 
            this.mainPanel.Controls.Add(this.continueBtn);
            this.mainPanel.Controls.Add(this.pauseBtn);
            this.mainPanel.Location = new System.Drawing.Point(822, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(267, 537);
            this.mainPanel.TabIndex = 1;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(15, 10);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(100, 25);
            this.pauseBtn.TabIndex = 0;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // continueBtn
            // 
            this.continueBtn.Location = new System.Drawing.Point(135, 10);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(100, 25);
            this.continueBtn.TabIndex = 1;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = true;
            // 
            // WorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 537);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.dbPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorldForm";
            this.Text = "Steering";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DbPanel dbPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button continueBtn;
    }
}

