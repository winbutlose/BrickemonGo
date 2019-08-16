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
        private Trainer T1, T2;
        public BreakInPanel(Trainer Tr1, Trainer Tr2)
        {
            CreateForm(Tr1,Tr2);
        }

        public void CreateForm(Trainer Tr1, Trainer Tr2)
        {
            InitializeComponent();
            T1 = Tr1;
            T2 = Tr2;
            this.poke1 = T1.GetPartyAt(0);

            //Repaint Methods
            this.T1panel.Paint += new PaintEventHandler(T1panel_Paint);
            this.atkPanel.Paint += new PaintEventHandler(atkPanel_Paint);
            this.defPanel.Paint += new PaintEventHandler(defPanel_Paint);
            this.spatkPanel.Paint += new PaintEventHandler(spatkPanel_Paint);
            this.spdefPanel.Paint += new PaintEventHandler(spdefPanel_Paint);
            this.speedPanel.Paint += new PaintEventHandler(speedPanel_Paint);
            this.naturepanel.Paint += new PaintEventHandler(naturepanel_Paint);
            this.m1panel.Paint += new PaintEventHandler(m1panel_Paint);
            this.m2panel.Paint += new PaintEventHandler(m2panel_Paint);
            this.m3panel.Paint += new PaintEventHandler(m3panel_Paint);
            this.m4panel.Paint += new PaintEventHandler(m4panel_Paint);

            foreach (Pokemon y in T1.GetPokemonParty())
            {
                this.pokeComboBox.Items.Add(y.GetName());
            }

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
        private void m1panel_Paint(object sender, PaintEventArgs e)
        {
            Move m = poke1.GetMove1();
            m1dmglabel.Text = "" + m.GetDamage() + " dmg";
            m1acclabel.Text = "" + m.GetAccuracy() + "% acc";
            m1category.Text = "" + m.GetMoveCategoryString();
            move1NameLabel.Text = "" + m.GetName();
            m1pp.Text = ""+m.GetPP() + " pp";
            m1effid.Text = "effid:" + m.GetEffectId();
            m1type.ImageLocation = @"res/type circles/" + m.GetType().getPrimaryTypeAsString() + ".png";
            m1id.Text = "id:"+m.GetMoveId();
        }
        private void m2panel_Paint(object sender, PaintEventArgs e)
        {
            Move m = poke1.GetMove2();
            m2dmg.Text = "" + m.GetDamage() + " dmg";
            m2acc.Text = "" + m.GetAccuracy() + "% acc";
            m2cat.Text = "" + m.GetMoveCategoryString();
            m2name.Text = "" + m.GetName();
            m2pp.Text = "" + m.GetPP()+" pp";
            m2effid.Text = "effid:" + m.GetEffectId();
            m2pic.ImageLocation = @"res/type circles/" + m.GetType().getPrimaryTypeAsString() + ".png";
            m2id.Text = "id:" + m.GetMoveId();
        }
        private void m3panel_Paint(object sender, PaintEventArgs e)
        {
            Move m = poke1.GetMove3();
            m3dmg.Text = "" + m.GetDamage()+" dmg";
            m3acc.Text = "" + m.GetAccuracy() + "% acc";
            m3cat.Text = "" + m.GetMoveCategoryString();
            m3name.Text = "" + m.GetName();
            m3pp.Text = "" + m.GetPP() + " pp";
            m3effid.Text = "effid:" + m.GetEffectId();
            m3pic.ImageLocation = @"res/type circles/" + m.GetType().getPrimaryTypeAsString() + ".png";
            m3id.Text = "id:" + m.GetMoveId();
        }
        private void m4panel_Paint(object sender, PaintEventArgs e)
        {
            Move m = poke1.GetMove4();
            m4dmg.Text = "" + m.GetDamage() + " dmg";
            m4acc.Text = "" + m.GetAccuracy() + "% acc";
            m4cat.Text = "" + m.GetMoveCategoryString();
            m4name.Text = "" + m.GetName();
            m4pp.Text = "" + m.GetPP() + " pp";
            m4effid.Text = "effid:" + m.GetEffectId();
            m4pic.ImageLocation = @"res/type circles/" + m.GetType().getPrimaryTypeAsString() + ".png";
            m4id.Text = "id:" + m.GetMoveId();
        }
        private void T1panel_Paint(object sender, PaintEventArgs e)
        { 
            nameTextBox.Text = poke1.GetName();
            Bitmap bmMain = new Bitmap(@"res/sprites/sugimori/" + this.poke1.GetDexNum() + ".png");
            this.mainPicBox.Image = bmMain;
            Type ty = poke1.GetType();
            Bitmap bm1 = new Bitmap(@"res/type circles/" + ty.getPrimaryTypeAsString() + ".png");
            this.type1PicBox.Image = bm1;
            if (poke1.GetType().GetMonotype())
            {
                this.type2PicBox.Image = null;
            }
            else
            {
                Bitmap bm2 = new Bitmap(@"res/type circles/" + ty.getSecondaryTypeAsString() + ".png");
                this.type2PicBox.Image = bm2;
            }
            type1PicBox.BackColor = Color.Transparent;
            type2PicBox.BackColor = Color.Transparent;
        }

        private void naturepanel_Paint(object sender, PaintEventArgs e)
        {
            naturelabel.Text = poke1.GetNature().GetName();
            npluslabel.Text = "+ "+poke1.GetNature().GetBoostedStat();
            nminuslabel.Text = "- " + poke1.GetNature().GetReducedStat();
        }


            private void atkStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementAtkStageMultiplier();
            Refresh();
        }

        private void atkStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementAtkStageMultiplier();
            Refresh();
        }

        private void defStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementDefStageMultiplier();
            Refresh();
        }

        private void defStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementDefStageMultiplier();
            Refresh();
        }

        private void spatkStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementSpAtkStageMultiplier();
            Refresh();
        }

        private void spatkStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementSpAtkStageMultiplier();
            Refresh();
        }

        private void spdefStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementSpDefStageMultiplier();
            Refresh();
        }

        private void spdefStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementSpDefStageMultiplier();
            Refresh();
        }

        private void speedStageIncButton_Click(object sender, EventArgs e)
        {
            poke1.IncrementSpeedStageMultiplier();
            Refresh();
        }

        private void speedStageDecButton_Click(object sender, EventArgs e)
        {
            poke1.DecrementSpeedStageMultiplier();
            Refresh();
        }

        private void T1panel_Scroll(object sender, ScrollEventArgs e)
        {
            //intentionally empty
        }

        private void T1panel_Click(object sender, EventArgs e)
        {
            //Refresh();
        }

        private void pokeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            poke1 = T1.GetPartyAt(pokeComboBox.SelectedIndex);
            Refresh();
        }
    }
}
