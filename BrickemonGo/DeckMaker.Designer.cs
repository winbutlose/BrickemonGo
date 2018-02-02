namespace BrickemonGo
{
    partial class DeckMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckMaker));
            this.AllCardsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CardPictureBox = new System.Windows.Forms.PictureBox();
            this.CardNameLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.trunktab = new System.Windows.Forms.TabPage();
            this.decktab = new System.Windows.Forms.TabPage();
            this.DeckPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlayerMoneyLabel = new System.Windows.Forms.Label();
            this.PlayernameLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.storetab = new System.Windows.Forms.TabPage();
            this.storePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanelStore = new System.Windows.Forms.TableLayoutPanel();
            this.AllCardsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.trunktab.SuspendLayout();
            this.decktab.SuspendLayout();
            this.DeckPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.storetab.SuspendLayout();
            this.storePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllCardsPanel
            // 
            this.AllCardsPanel.AutoScroll = true;
            this.AllCardsPanel.Controls.Add(this.tableLayoutPanel1);
            this.AllCardsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCardsPanel.Location = new System.Drawing.Point(3, 3);
            this.AllCardsPanel.Name = "AllCardsPanel";
            this.AllCardsPanel.Size = new System.Drawing.Size(1073, 698);
            this.AllCardsPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 0);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CardPictureBox
            // 
            this.CardPictureBox.Location = new System.Drawing.Point(12, 12);
            this.CardPictureBox.Name = "CardPictureBox";
            this.CardPictureBox.Size = new System.Drawing.Size(245, 340);
            this.CardPictureBox.TabIndex = 1;
            this.CardPictureBox.TabStop = false;
            // 
            // CardNameLabel
            // 
            this.CardNameLabel.AutoSize = true;
            this.CardNameLabel.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardNameLabel.Location = new System.Drawing.Point(12, 355);
            this.CardNameLabel.Name = "CardNameLabel";
            this.CardNameLabel.Size = new System.Drawing.Size(70, 36);
            this.CardNameLabel.TabIndex = 2;
            this.CardNameLabel.Text = "+++++";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.trunktab);
            this.tabControl1.Controls.Add(this.decktab);
            this.tabControl1.Controls.Add(this.storetab);
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 25);
            this.tabControl1.Location = new System.Drawing.Point(263, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 737);
            this.tabControl1.TabIndex = 1;
            // 
            // trunktab
            // 
            this.trunktab.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trunktab.Controls.Add(this.AllCardsPanel);
            this.trunktab.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trunktab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.trunktab.Location = new System.Drawing.Point(4, 29);
            this.trunktab.Name = "trunktab";
            this.trunktab.Padding = new System.Windows.Forms.Padding(3);
            this.trunktab.Size = new System.Drawing.Size(1079, 704);
            this.trunktab.TabIndex = 0;
            this.trunktab.Text = "Trunk";
            // 
            // decktab
            // 
            this.decktab.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.decktab.Controls.Add(this.DeckPanel);
            this.decktab.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decktab.Location = new System.Drawing.Point(4, 29);
            this.decktab.Name = "decktab";
            this.decktab.Padding = new System.Windows.Forms.Padding(3);
            this.decktab.Size = new System.Drawing.Size(1079, 704);
            this.decktab.TabIndex = 1;
            this.decktab.Text = "Deck";
            // 
            // DeckPanel
            // 
            this.DeckPanel.AutoScroll = true;
            this.DeckPanel.Controls.Add(this.tableLayoutPanel2);
            this.DeckPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeckPanel.Location = new System.Drawing.Point(3, 3);
            this.DeckPanel.Name = "DeckPanel";
            this.DeckPanel.Size = new System.Drawing.Size(1073, 698);
            this.DeckPanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1073, 0);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.SaveButton);
            this.InfoPanel.Controls.Add(this.pictureBox1);
            this.InfoPanel.Controls.Add(this.PlayerMoneyLabel);
            this.InfoPanel.Controls.Add(this.PlayernameLabel);
            this.InfoPanel.Location = new System.Drawing.Point(12, 555);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(244, 194);
            this.InfoPanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // PlayerMoneyLabel
            // 
            this.PlayerMoneyLabel.AutoSize = true;
            this.PlayerMoneyLabel.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerMoneyLabel.Location = new System.Drawing.Point(40, 50);
            this.PlayerMoneyLabel.Name = "PlayerMoneyLabel";
            this.PlayerMoneyLabel.Size = new System.Drawing.Size(70, 36);
            this.PlayerMoneyLabel.TabIndex = 4;
            this.PlayerMoneyLabel.Text = "+++++";
            // 
            // PlayernameLabel
            // 
            this.PlayernameLabel.AutoSize = true;
            this.PlayernameLabel.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayernameLabel.Location = new System.Drawing.Point(0, 0);
            this.PlayernameLabel.Name = "PlayernameLabel";
            this.PlayernameLabel.Size = new System.Drawing.Size(82, 40);
            this.PlayernameLabel.TabIndex = 3;
            this.PlayernameLabel.Text = "+++++";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(0, 151);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(110, 36);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save and Exit";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // storetab
            // 
            this.storetab.Controls.Add(this.storePanel);
            this.storetab.Location = new System.Drawing.Point(4, 29);
            this.storetab.Name = "storetab";
            this.storetab.Size = new System.Drawing.Size(1079, 704);
            this.storetab.TabIndex = 2;
            this.storetab.Text = "Store";
            this.storetab.UseVisualStyleBackColor = true;
            // 
            // storePanel
            // 
            this.storePanel.AutoScroll = true;
            this.storePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.storePanel.Controls.Add(this.tableLayoutPanelStore);
            this.storePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storePanel.Location = new System.Drawing.Point(0, 0);
            this.storePanel.Name = "storePanel";
            this.storePanel.Size = new System.Drawing.Size(1079, 704);
            this.storePanel.TabIndex = 0;
            // 
            // tableLayoutPanelStore
            // 
            this.tableLayoutPanelStore.AutoSize = true;
            this.tableLayoutPanelStore.ColumnCount = 4;
            this.tableLayoutPanelStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelStore.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelStore.Name = "tableLayoutPanelStore";
            this.tableLayoutPanelStore.RowCount = 4;
            this.tableLayoutPanelStore.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStore.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStore.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStore.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStore.Size = new System.Drawing.Size(1079, 0);
            this.tableLayoutPanelStore.TabIndex = 0;
            // 
            // DeckMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1362, 761);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CardNameLabel);
            this.Controls.Add(this.CardPictureBox);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1300, 800);
            this.Name = "DeckMaker";
            this.Text = "DeckMaker";
            this.AllCardsPanel.ResumeLayout(false);
            this.AllCardsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.trunktab.ResumeLayout(false);
            this.decktab.ResumeLayout(false);
            this.DeckPanel.ResumeLayout(false);
            this.DeckPanel.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.storetab.ResumeLayout(false);
            this.storePanel.ResumeLayout(false);
            this.storePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AllCardsPanel;
        private System.Windows.Forms.PictureBox CardPictureBox;
        private System.Windows.Forms.Label CardNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage trunktab;
        private System.Windows.Forms.TabPage decktab;
        private System.Windows.Forms.Panel DeckPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label PlayerMoneyLabel;
        private System.Windows.Forms.Label PlayernameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TabPage storetab;
        private System.Windows.Forms.Panel storePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStore;
    }
}