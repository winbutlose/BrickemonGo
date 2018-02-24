namespace BrickemonGo
{
    partial class Battle
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
            this.PictureBoxOppPoke = new System.Windows.Forms.PictureBox();
            this.PictureBoxUserPoke = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOppPoke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUserPoke)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxOppPoke
            // 
            this.PictureBoxOppPoke.Location = new System.Drawing.Point(844, 12);
            this.PictureBoxOppPoke.Name = "PictureBoxOppPoke";
            this.PictureBoxOppPoke.Size = new System.Drawing.Size(213, 192);
            this.PictureBoxOppPoke.TabIndex = 0;
            this.PictureBoxOppPoke.TabStop = false;
            // 
            // PictureBoxUserPoke
            // 
            this.PictureBoxUserPoke.Location = new System.Drawing.Point(35, 451);
            this.PictureBoxUserPoke.Name = "PictureBoxUserPoke";
            this.PictureBoxUserPoke.Size = new System.Drawing.Size(241, 214);
            this.PictureBoxUserPoke.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxUserPoke.TabIndex = 1;
            this.PictureBoxUserPoke.TabStop = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.PictureBoxUserPoke);
            this.MainPanel.Controls.Add(this.PictureBoxOppPoke);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1280, 720);
            this.MainPanel.TabIndex = 2;
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Battle";
            this.Text = "Battle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOppPoke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUserPoke)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxOppPoke;
        private System.Windows.Forms.PictureBox PictureBoxUserPoke;
        private System.Windows.Forms.Panel MainPanel;
    }
}