using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickemonGo
{
    public partial class BreakInPanel : Form
    {
        private Pokemon poke1;
        public BreakInPanel(Pokemon x)
        {
            CreateForm(x);
        }

        public void CreateForm(Pokemon x)
        {
            InitializeComponent();
            this.poke1 = x;

            //Repaint Methods
            this.atkPanel.Paint += new PaintEventHandler(atkPanel_Paint);
            this.defPanel.Paint += new PaintEventHandler(defPanel_Paint);
            this.spatkPanel.Paint += new PaintEventHandler(spatkPanel_Paint);
            this.spdefPanel.Paint += new PaintEventHandler(spdefPanel_Paint);
            this.speedPanel.Paint += new PaintEventHandler(speedPanel_Paint);

            //name text box
            nameTextBox.Text = poke1.GetName();
            this.mainPicBox.ImageLocation = (@"res/sprites/sugimori/" + this.poke1.GetDexNum() + ".png");
            //pictures for types
            Type ty = poke1.GetType();
            mainPicBox.Controls.Add(type1PicBox);
            mainPicBox.Controls.Add(type2PicBox);
            type1PicBox.Location = new Point(0, mainPicBox.Height-type1PicBox.Height);
            type2PicBox.Location = new Point(type1PicBox.Height+10, mainPicBox.Height - type2PicBox.Height);
            type1PicBox.BackColor = Color.Transparent;
            type2PicBox.BackColor = Color.Transparent;
            type1PicBox.ImageLocation = @"res/type circles/" + ty.getPrimaryTypeAsString() + ".png";
            type2PicBox.ImageLocation = @"res/type circles/" + ty.getSecondaryTypeAsString() + ".png";
            Refresh();
        }

        private void atkPanel_Paint(object sender, PaintEventArgs e)
        {
            atkStageLabel.Text = "" + poke1.GetAtkStageMultiplier();
            atkFinalLabel.Text = "" + poke1.GetAtk();
            atkBaseLabel.Text = "" + poke1.GetBaseAtk();
        }
        private void defPanel_Paint(object sender, PaintEventArgs e)
        {
            defStageLabel.Text = "" + poke1.GetDefStageMultiplier();
            defBaseLabel.Text = "" + poke1.GetBaseDef();
            defFinalLabel.Text = "" + poke1.GetDef();
        }
        private void spatkPanel_Paint(object sender, PaintEventArgs e)
        {
            spatkStageLabel.Text = "" + poke1.GetSpAtkStageMultiplier();
            spatkBaseLabel.Text = "" + poke1.GetBaseSpAtk();
            spatkFinalLabel.Text = "" + poke1.GetSpAtk();
        }
        private void spdefPanel_Paint(object sender, PaintEventArgs e)
        {
            spdefStageLabel.Text = "" + poke1.GetSpDefStageMultiplier();
            spdefBaseLabel.Text = "" + poke1.GetBaseSpDef();
            spdefFinalLabel.Text = "" + poke1.GetSpDef();
        }
        private void speedPanel_Paint(object sender, PaintEventArgs e)
        {
            speedStageLabel.Text = "" + poke1.GetSpeedStageMultiplier();
            speedBaseLabel.Text = "" + poke1.GetBaseSpeed();
            speedFinalLabel.Text = "" + poke1.GetSpeed();
        }



        private void atkStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementAtkStageMultiplier();
        }

        private void atkStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementAtkStageMultiplier();
        }

        private void defStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementDefStageMultiplier();
        }

        private void defStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementDefStageMultiplier();
        }

        private void spatkStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementSpAtkStageMultiplier();
        }

        private void spatkStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementSpAtkStageMultiplier();
        }

        private void spdefStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementSpDefStageMultiplier();
        }

        private void spdefStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementSpDefStageMultiplier();
        }

        private void speedStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementSpeedStageMultiplier();
        }

        private void speedStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementSpeedStageMultiplier();
        }
    }
}
