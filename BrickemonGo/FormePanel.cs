using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickemonGo
{
    class FormePanel : Panel
    {
        private PictureBox imageBox;
        private Label nameLabel;
        public FormePanel(String name, String image)
        {
            this.AutoSize = true;
            nameLabel = new Label();
            this.Controls.Add(nameLabel);
            nameLabel.Text = name;
            nameLabel.Font = new Font("Dubai", 15);
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(30,0);
            //nameLabel.Anchor = AnchorStyles.Top;
            Size size = new Size(150, 150);
            imageBox = new PictureBox()
            {
                ImageLocation = image,
                Size = size,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            //x.Controls.Add(p);
            this.Controls.Add(imageBox);
            imageBox.Location = new Point(20,50);
            //imageBox.Anchor = AnchorStyles.Left;
            //Console.WriteLine(image);
        }
    }
}
