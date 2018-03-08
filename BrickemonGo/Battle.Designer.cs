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
            this.textboxwords = new System.Windows.Forms.TextBox();
            this.outputbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOppPoke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUserPoke)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxOppPoke
            // 
            this.PictureBoxOppPoke.Location = new System.Drawing.Point(1018, 12);
            this.PictureBoxOppPoke.Name = "PictureBoxOppPoke";
            this.PictureBoxOppPoke.Size = new System.Drawing.Size(250, 250);
            this.PictureBoxOppPoke.TabIndex = 0;
            this.PictureBoxOppPoke.TabStop = false;
            // 
            // PictureBoxUserPoke
            // 
            this.PictureBoxUserPoke.Location = new System.Drawing.Point(12, 12);
            this.PictureBoxUserPoke.Name = "PictureBoxUserPoke";
            this.PictureBoxUserPoke.Size = new System.Drawing.Size(250, 250);
            this.PictureBoxUserPoke.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxUserPoke.TabIndex = 1;
            this.PictureBoxUserPoke.TabStop = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.textboxwords);
            this.MainPanel.Controls.Add(this.outputbox);
            this.MainPanel.Controls.Add(this.PictureBoxUserPoke);
            this.MainPanel.Controls.Add(this.PictureBoxOppPoke);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1280, 720);
            this.MainPanel.TabIndex = 2;
            // 
            // textboxwords
            // 
            this.textboxwords.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textboxwords.Font = new System.Drawing.Font("Dubai", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxwords.Location = new System.Drawing.Point(92, 568);
            this.textboxwords.Name = "textboxwords";
            this.textboxwords.ReadOnly = true;
            this.textboxwords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxwords.Size = new System.Drawing.Size(1110, 53);
            this.textboxwords.TabIndex = 3;
            // 
            // outputbox
            // 
            this.outputbox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.outputbox.Location = new System.Drawing.Point(268, 3);
            this.outputbox.Multiline = true;
            this.outputbox.Name = "outputbox";
            this.outputbox.Size = new System.Drawing.Size(739, 139);
            this.outputbox.TabIndex = 2;
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOppPoke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUserPoke)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxOppPoke;
        private System.Windows.Forms.PictureBox PictureBoxUserPoke;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TextBox outputbox;
        private System.Windows.Forms.TextBox textboxwords;
    }
}