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
            this.SuspendLayout();
            // 
            // dbPanel
            // 
            this.dbPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dbPanel.Location = new System.Drawing.Point(0, 0);
            this.dbPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dbPanel.Name = "dbPanel";
            this.dbPanel.Size = new System.Drawing.Size(327, 233);
            this.dbPanel.TabIndex = 0;
            this.dbPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Render);
            this.dbPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnTargetEntityPositionMouseClick);
            // 
            // WorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(816, 537);
            this.Controls.Add(this.dbPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorldForm";
            this.Text = "Amazing Mario Bros.";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnWorldFormKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnWorldFormKeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private DbPanel dbPanel;
    }
}

