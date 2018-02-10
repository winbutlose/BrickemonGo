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
    public partial class MovePopUp : Form
    {
        public MovePopUp(Move m)
        {
            InitializeComponent();
            NameBox.Text = m.GetName();
        }
    }
}
