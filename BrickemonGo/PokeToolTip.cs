using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//structure copied from https://cboard.cprogramming.com/csharp-programming/119414-custom-tooltip.html, thank you theoobe!

namespace BrickemonGo
{
    class PokeToolTip : ToolTip
    {
        Pokemon Poke1;
        public PokeToolTip(Pokemon p)
        {
            this.Poke1 = p;
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            e.ToolTipSize = new Size(200, 75);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brushw = new SolidBrush(Color.WhiteSmoke);
            g.FillRectangle(brushw, e.Bounds);
            g.FillRectangle(brush, 0, 40, 200, 35);
            e.Graphics.DrawString(Poke1.GetName(), new Font("Arial", 12), brush, 0, 0);
            e.Graphics.DrawString(Poke1.GetRemainingHp()+" / "+Poke1.GetHp(), new Font("Arial", 12), brush, 100, 0);
            e.Graphics.DrawString("Atk:"+Poke1.GetAtk(), new Font("Arial", 7), brush, 0, 22);
            e.Graphics.DrawString("Def:" + Poke1.GetDef(), new Font("Arial", 7), brush, 40, 22);
            e.Graphics.DrawString("Spa:" + Poke1.GetSpAtk(), new Font("Arial", 7), brush, 80, 22);
            e.Graphics.DrawString("Spd:" + Poke1.GetSpDef(), new Font("Arial", 7), brush, 120, 22);
            e.Graphics.DrawString("Spe:" + Poke1.GetSpeed(), new Font("Arial", 7), brush, 160, 22);
            e.Graphics.DrawString(Poke1.GetMove1().GetName(), new Font("Arial", 10), brushw, 0, 45);
            e.Graphics.DrawString(Poke1.GetMove2().GetName(), new Font("Arial", 10), brushw, 100, 45);
            e.Graphics.DrawString(Poke1.GetMove3().GetName(), new Font("Arial", 10), brushw, 0, 60);
            e.Graphics.DrawString(Poke1.GetMove4().GetName(), new Font("Arial", 10), brushw, 100, 60);
            brush.Dispose();
        }
    }
}