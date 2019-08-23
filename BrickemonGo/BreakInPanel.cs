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
        private Nature[] natureList;
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
            this.statuspanel.Paint += new PaintEventHandler(statuspanel_Paint);
            this.atkPanel.Paint += new PaintEventHandler(atkPanel_Paint);
            this.defPanel.Paint += new PaintEventHandler(defPanel_Paint);
            this.spatkPanel.Paint += new PaintEventHandler(spatkPanel_Paint);
            this.spdefPanel.Paint += new PaintEventHandler(spdefPanel_Paint);
            this.speedPanel.Paint += new PaintEventHandler(speedPanel_Paint);
            this.naturepanel.Paint += new PaintEventHandler(naturepanel_Paint);
            this.IVEVPanel.Paint += new PaintEventHandler(IVEVPanel_Paint);
            this.m1panel.Paint += new PaintEventHandler(m1panel_Paint);
            this.m2panel.Paint += new PaintEventHandler(m2panel_Paint);
            this.m3panel.Paint += new PaintEventHandler(m3panel_Paint);
            this.m4panel.Paint += new PaintEventHandler(m4panel_Paint);

            foreach (Pokemon y in T1.GetPokemonParty())
            {
                this.pokeComboBox.Items.Add(y.GetName());
            }
            foreach (Pokemon y in T2.GetPokemonParty())
            {
                this.pokeComboBox.Items.Add(y.GetName());
            }
            natureList = new Nature[25];
            for(int i=1; i<26; i++)
            {
                this.natureList[i-1] = new Nature(i);
                naturecombobox.Items.Add(natureList[i-1].GetName());
            }

            String[] statusList = {"None", "Burn", "Paralyze", "Poison", "Sleep", "Freeze","Badpoison" };
            foreach (String x in statusList)
            {
                statuscombobox.Items.Add(x);
            }

            updateIvevpanel();

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
            if (poke1.GetMove4() == null)
            {
                m4dmg.Text = "No Move 4";
                m4acc.Text = "";
                m4cat.Text = "";
                m4name.Text = "";
                m4pp.Text = "";
                m4effid.Text = "";
                m4pic.ImageLocation = "";
                m4id.Text = "";
                return;
            }
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
            npluslabel.Text = "+ "+poke1.GetNature().GetBoostedStatString();
            nminuslabel.Text = "- " + poke1.GetNature().GetReducedStatString();
        }
        private void IVEVPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void statuspanel_Paint(object sender, PaintEventArgs e)
        {
            statuslabel.Text = ""+poke1.GetStatusString();
            statuspicbox.ImageLocation = @"res/" + poke1.GetStatus() + ".png";
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

        private void Naturecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            poke1.SetNature(naturecombobox.SelectedIndex+1);
            Refresh();
        }

        private void Ivevupdatebtn_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(evhpbox.Text)+ Convert.ToInt32(evatkbox.Text)+ Convert.ToInt32(evdefbox.Text)+ Convert.ToInt32(evspabox.Text)+ Convert.ToInt32(evspdbox.Text)+ Convert.ToInt32(evspebox.Text) > 510)
            {
                MessageBox.Show("EVs cannot exceed 510 total, did not update pokemon");
            }

            poke1.SetHpIV(Convert.ToInt32(ivhpbox.Text));
            poke1.SetAtkIV(Convert.ToInt32(ivatkbox.Text));
            poke1.SetDefIV(Convert.ToInt32(ivdefbox.Text));
            poke1.SetSpAtkIV(Convert.ToInt32(ivspabox.Text));
            poke1.SetSpDefIV(Convert.ToInt32(ivspdbox.Text));
            poke1.SetSpeedIV(Convert.ToInt32(ivspebox.Text));

            poke1.SetHpEV(Convert.ToInt32(evhpbox.Text));
            poke1.SetAtkEV(Convert.ToInt32(evatkbox.Text));
            poke1.SetDefEV(Convert.ToInt32(evdefbox.Text));
            poke1.SetSpAtkEV(Convert.ToInt32(evspabox.Text));
            poke1.SetSpDefEV(Convert.ToInt32(evspdbox.Text));
            poke1.SetSpeedEV(Convert.ToInt32(evspebox.Text)); //we need to effectively cap total EVs at 510

            poke1.CalculateStats();
            updateIvevpanel();
            Refresh();
            Console.WriteLine(poke1.GetName()+"'s atk stat is now "+poke1.GetAtk());
        }

        private void pokeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = pokeComboBox.SelectedIndex;
            if(index < 6)
            {
                poke1 = T1.GetPartyAt(index);
            }
            else
            {
                poke1 = T2.GetPartyAt(index-6);
            }
            Refresh();
            updateIvevpanel();
        }

        private void Statuspicbox_Click(object sender, EventArgs e)
        {
            //intentionally left blank
        }

        private void Statuscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            poke1.SetStatus(statuscombobox.SelectedIndex);
            Refresh();
        }

        private void updateIvevpanel()
        {//update the text boxes used to manipulate IVs and EVs manually because repaint (refresh) is too fast

            ivhpbox.Text = "" + poke1.GetHpIV();
            ivatkbox.Text = "" + poke1.GetAtkIV();
            ivdefbox.Text = "" + poke1.GetDefIV();
            ivspabox.Text = "" + poke1.GetSpAtkIV();
            ivspdbox.Text = "" + poke1.GetSpDefIV();
            ivspebox.Text = "" + poke1.GetSpeedIV();

            evhpbox.Text = "" + poke1.GetHpEV();
            evatkbox.Text = "" + poke1.GetAtkEV();
            evdefbox.Text = "" + poke1.GetDefEV();
            evspabox.Text = "" + poke1.GetSpAtkEV();
            evspdbox.Text = "" + poke1.GetSpDefEV();
            evspebox.Text = "" + poke1.GetSpeedEV();
        }
    }
}
