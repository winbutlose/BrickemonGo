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
    public partial class MoveChoiceForm : Form
    {
        private Pokemon poke;
        public MoveChoiceForm(Pokemon x)
        {
            poke = x;
            InitializeComponent();
            button1.Text = ""+poke.GetMove1();
            button2.Text = "" + poke.GetMove2();
            button3.Text = "" + poke.GetMove3();
            button4.Text = "" + poke.GetMove4();
        }
        private int choice;

        private void button1_Click(object sender, EventArgs e)
        {
            choice = 1;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choice = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            choice = 3;
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choice = 4;
            this.DialogResult = DialogResult.OK;
        }

        public int GetChoice()
        {
            return choice;
        }
    }
}
