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
    public partial class Battle : Form
    {
        public Battle()
        {
            InitializeComponent();
            CreateBattle();
        }
        public void CreateBattle()
        {
            this.MainPanel.Paint += new PaintEventHandler(Main_paint);
            PictureBoxOppPoke.Update();
            Refresh();
        }
        private void Main_paint(object sender, PaintEventArgs e)
        {
            PictureBoxUserPoke.ImageLocation = (@"res/sprites/sugimori/6.png");
            PictureBoxUserPoke.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxOppPoke.ImageLocation = (@"res/sprites/sugimori/9.png");
            PictureBoxOppPoke.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
