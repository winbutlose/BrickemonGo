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
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textboxwords = new System.Windows.Forms.TextBox();
            this.outputbox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oppstatuspicbox = new System.Windows.Forms.PictureBox();
            this.statuspicbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOppPoke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUserPoke)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oppstatuspicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statuspicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxOppPoke
            // 
            this.PictureBoxOppPoke.Location = new System.Drawing.Point(650, 12);
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
            this.MainPanel.Controls.Add(this.statuspicbox);
            this.MainPanel.Controls.Add(this.oppstatuspicbox);
            this.MainPanel.Controls.Add(this.button4);
            this.MainPanel.Controls.Add(this.button2);
            this.MainPanel.Controls.Add(this.button3);
            this.MainPanel.Controls.Add(this.button1);
            this.MainPanel.Controls.Add(this.textboxwords);
            this.MainPanel.Controls.Add(this.outputbox);
            this.MainPanel.Controls.Add(this.PictureBoxUserPoke);
            this.MainPanel.Controls.Add(this.PictureBoxOppPoke);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1191, 696);
            this.MainPanel.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(588, 664);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(186, 44);
            this.button4.TabIndex = 9;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 664);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 44);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 44);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textboxwords
            // 
            this.textboxwords.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textboxwords.Font = new System.Drawing.Font("Dubai", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxwords.Location = new System.Drawing.Point(12, 388);
            this.textboxwords.Name = "textboxwords";
            this.textboxwords.ReadOnly = true;
            this.textboxwords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxwords.Size = new System.Drawing.Size(931, 53);
            this.textboxwords.TabIndex = 3;
            // 
            // outputbox
            // 
            this.outputbox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.outputbox.Location = new System.Drawing.Point(963, 12);
            this.outputbox.Name = "outputbox";
            this.outputbox.ReadOnly = true;
            this.outputbox.Size = new System.Drawing.Size(221, 696);
            this.outputbox.TabIndex = 2;
            this.outputbox.Text = "";
            this.outputbox.TextChanged += new System.EventHandler(this.outputbox_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.breakinToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // breakinToolStripMenuItem
            // 
            this.breakinToolStripMenuItem.Name = "breakinToolStripMenuItem";
            this.breakinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.breakinToolStripMenuItem.Text = "Break-in";
            this.breakinToolStripMenuItem.Click += new System.EventHandler(this.BreakinToolStripMenuItem_Click);
            // 
            // oppstatuspicbox
            // 
            this.oppstatuspicbox.Location = new System.Drawing.Point(594, 212);
            this.oppstatuspicbox.Name = "oppstatuspicbox";
            this.oppstatuspicbox.Size = new System.Drawing.Size(50, 50);
            this.oppstatuspicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oppstatuspicbox.TabIndex = 10;
            this.oppstatuspicbox.TabStop = false;
            // 
            // statuspicbox
            // 
            this.statuspicbox.Location = new System.Drawing.Point(268, 212);
            this.statuspicbox.Name = "statuspicbox";
            this.statuspicbox.Size = new System.Drawing.Size(50, 50);
            this.statuspicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statuspicbox.TabIndex = 11;
            this.statuspicbox.TabStop = false;
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1191, 720);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Battle";
            this.Text = "Battle";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOppPoke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUserPoke)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oppstatuspicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statuspicbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxOppPoke;
        private System.Windows.Forms.PictureBox PictureBoxUserPoke;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.RichTextBox outputbox;
        private System.Windows.Forms.TextBox textboxwords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breakinToolStripMenuItem;
        private System.Windows.Forms.PictureBox statuspicbox;
        private System.Windows.Forms.PictureBox oppstatuspicbox;
    }
}