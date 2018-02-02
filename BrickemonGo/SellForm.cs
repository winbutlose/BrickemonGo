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
    public partial class SellForm : Form
    {
        public SellForm(int cost, Card c, int index)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = c.GetImageLoc();
            label2.Text = ""+cost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }
    }
}
