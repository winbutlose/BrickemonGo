using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickemonGo
{
    class PokeCardBox : PictureBox
    {
        private int index;
        private Card heldCard;
        public PokeCardBox(int x)
        {
            index = x;
            DoubleBuffered = true;
            //Size size = new Size(100, 100);
            //this.Size = size;
        }
        public int GetIndex()
        {
            return index;
        }
        public void SetIndex(int x)
        {
            index = x;
        }
        public Card GetHeldCard()
        {
            return heldCard;
        }
        public void SetHeldCard(Card x)
        {
            heldCard = x;
        }
    }
}
