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
    public partial class SwitchChoiceForm : Form
    {
        private Trainer T;
        public SwitchChoiceForm(Trainer tt)
        {
            T = tt;
            InitializeComponent();
            Pokemon[] party = T.GetPokemonParty();
            if (party.Length == 1)
            {
                button1.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[0].GetDexNum() + ".png");
                button1.BackgroundImageLayout = ImageLayout.Zoom;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                Refresh();
            }
            else if (party.Length == 2)
            {
                button1.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[0].GetDexNum() + ".png");
                button1.BackgroundImageLayout = ImageLayout.Zoom;
                button2.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[1].GetDexNum() + ".png");
                button2.BackgroundImageLayout = ImageLayout.Zoom;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                Refresh();
            }
            else if (party.Length == 3)
            {
                button1.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[0].GetDexNum() + ".png");
                button1.BackgroundImageLayout = ImageLayout.Zoom;
                button2.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[1].GetDexNum() + ".png");
                button2.BackgroundImageLayout = ImageLayout.Zoom;
                button3.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[2].GetDexNum() + ".png");
                button3.BackgroundImageLayout = ImageLayout.Zoom;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                Refresh();
            }
            else if (party.Length == 4)
            {
                button1.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[0].GetDexNum() + ".png");
                button1.BackgroundImageLayout = ImageLayout.Zoom;
                button2.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[1].GetDexNum() + ".png");
                button2.BackgroundImageLayout = ImageLayout.Zoom;
                button3.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[2].GetDexNum() + ".png");
                button3.BackgroundImageLayout = ImageLayout.Zoom;
                button4.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[3].GetDexNum() + ".png");
                button4.BackgroundImageLayout = ImageLayout.Zoom;
                button5.Visible = false;
                button6.Visible = false;
                Refresh();
            }
            else if (party.Length == 5)
            {
                button1.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[0].GetDexNum() + ".png");
                button1.BackgroundImageLayout = ImageLayout.Zoom;
                button2.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[1].GetDexNum() + ".png");
                button2.BackgroundImageLayout = ImageLayout.Zoom;
                button3.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[2].GetDexNum() + ".png");
                button3.BackgroundImageLayout = ImageLayout.Zoom;
                button4.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[3].GetDexNum() + ".png");
                button4.BackgroundImageLayout = ImageLayout.Zoom;
                button5.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[4].GetDexNum() + ".png");
                button5.BackgroundImageLayout = ImageLayout.Zoom;
                button6.Visible = false;
                Refresh();
            }
            else if (party.Length == 6)
            {
                button1.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[0].GetDexNum() + ".png");
                button1.BackgroundImageLayout = ImageLayout.Zoom;
                button2.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[1].GetDexNum() + ".png");
                button2.BackgroundImageLayout = ImageLayout.Zoom;
                button3.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[2].GetDexNum() + ".png");
                button3.BackgroundImageLayout = ImageLayout.Zoom;
                button4.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[3].GetDexNum() + ".png");
                button4.BackgroundImageLayout = ImageLayout.Zoom;
                button5.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[4].GetDexNum() + ".png");
                button5.BackgroundImageLayout = ImageLayout.Zoom;
                button6.BackgroundImage = Image.FromFile(@"res/sprites/sugimori/" + party[5].GetDexNum() + ".png");
                button6.BackgroundImageLayout = ImageLayout.Zoom;
                Refresh();
            }
            else
            {
                //L
            }
        }
        private int choice;

        private void button1_Click(object sender, EventArgs e)
        {
            choice = 0;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choice = 1;
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            choice = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choice = 3;
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            choice = 4;
            this.DialogResult = DialogResult.OK;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            choice = 5;
            this.DialogResult = DialogResult.OK;
        }

        public int GetChoice()
        {
            return choice;
        }
    }
}
