using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickemonGo
{
    class FormePanel : Panel
    {
        private PictureBox imageBox;
        private Label nameLabel;
        private Pokemon poke;
        private int megatype;
        public FormePanel(int m, Pokemon p, String image)//megatype is 0= X(primary) or 1= Y (second mega)
        {
            this.poke = p;
            this.megatype = m;
            this.Paint += new PaintEventHandler(formepaint);
            //this.AutoSize = true;
            this.Size = new Size(500, 200);
            nameLabel = new Label();
            this.Controls.Add(nameLabel);
            if (megatype == 0)
            {
                String str = poke.GetMegaName().Substring(poke.GetName().Length);
                str = FirstLetterToUpper(str);
                nameLabel.Text = str+" "+poke.GetName();
            }
            else if (megatype == 1)
            {
                String str = poke.GetMegaNameY().Substring(poke.GetName().Length);
                str = FirstLetterToUpper(str);
                nameLabel.Text = str + " " + poke.GetName();
            }
            nameLabel.Font = new Font("Dubai", 15);
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(30, 0);
            //nameLabel.Anchor = AnchorStyles.Top;
            Size size = new Size(150, 150);
            imageBox = new PictureBox()
            {
                ImageLocation = image,
                Size = size,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            this.Controls.Add(imageBox);
            imageBox.Location = new Point(20, 50);

            //type pic boxes
            if (megatype == 0)
            {
                PictureBox type1 = new PictureBox()
                {
                    ImageLocation = @"res/type circles/" + poke.GetMegaType().GetPrimaryTypeString().ToLower() + ".png",
                    Size = new Size(25, 25),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(200, 5)
                };
                this.Controls.Add(type1);
                //if not monotype then do 2nd type circle
                if (poke.GetMegaType().GetMonotype() == false)
                {
                    PictureBox type2 = new PictureBox()
                    {
                        ImageLocation = @"res/type circles/" + poke.GetMegaType().GetSecondaryTypeString().ToLower() + ".png",
                        Size = new Size(25, 25),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(230, 5)
                    };
                    this.Controls.Add(type2);
                }
            }
            if (megatype == 1)
            {
                PictureBox type1 = new PictureBox()
                {
                    ImageLocation = @"res/type circles/" + poke.GetMegaTypeY().GetPrimaryTypeString().ToLower() + ".png",
                    Size = new Size(25, 25),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(200, 5)
                };
                this.Controls.Add(type1);
                //if not monotype then do 2nd type circle
                if (poke.GetMegaTypeY().GetMonotype() == false)
                {
                    PictureBox type2 = new PictureBox()
                    {
                        ImageLocation = @"res/type circles/" + poke.GetMegaTypeY().GetSecondaryTypeString().ToLower() + ".png",
                        Size = new Size(25, 25),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(230, 5)
                    };
                    this.Controls.Add(type2);
                }
            }
            //labels for stats
            if (megatype == 0)
            {
                Label hplabel = new Label
                {
                    Text = "Hp: " + poke.GetMegaBaseHp(),
                    AutoSize = true
                };
                this.Controls.Add(hplabel);
                hplabel.Location = new Point(200, 50);

                Label atklabel = new Label
                {
                    Text = "Atk: " + poke.GetMegaBaseAtk(),
                    AutoSize = true
                };
                this.Controls.Add(atklabel);
                atklabel.Location = new Point(200, 70);

                Label deflabel = new Label
                {
                    Text = "Def: " + poke.GetMegaBaseDef(),
                    AutoSize = true
                };
                this.Controls.Add(deflabel);
                deflabel.Location = new Point(200, 90);

                Label spalabel = new Label
                {
                    Text = "Spa: " + poke.GetMegaBaseSpAtk(),
                    AutoSize = true
                };
                this.Controls.Add(spalabel);
                spalabel.Location = new Point(200, 110);

                Label spdlabel = new Label
                {
                    Text = "Spd: " + poke.GetMegaBaseSpDef(),
                    AutoSize = true
                };
                this.Controls.Add(spdlabel);
                spdlabel.Location = new Point(200, 130);

                Label spelabel = new Label
                {
                    Text = "Spe: " + poke.GetMegaBaseSpeed(),
                    AutoSize = true
                };
                this.Controls.Add(spelabel);
                spelabel.Location = new Point(200, 150);
            }

            //labels for stats Y forme
            if (megatype == 1)
            {
                Label hplabel = new Label
                {
                    Text = "Hp: " + poke.GetMegaBaseHpY(),
                    AutoSize = true
                };
                this.Controls.Add(hplabel);
                hplabel.Location = new Point(200, 50);

                Label atklabel = new Label
                {
                    Text = "Atk: " + poke.GetMegaBaseAtkY(),
                    AutoSize = true
                };
                this.Controls.Add(atklabel);
                atklabel.Location = new Point(200, 70);

                Label deflabel = new Label
                {
                    Text = "Def: " + poke.GetMegaBaseDefY(),
                    AutoSize = true
                };
                this.Controls.Add(deflabel);
                deflabel.Location = new Point(200, 90);

                Label spalabel = new Label
                {
                    Text = "Spa: " + poke.GetMegaBaseSpAtkY(),
                    AutoSize = true
                };
                this.Controls.Add(spalabel);
                spalabel.Location = new Point(200, 110);

                Label spdlabel = new Label
                {
                    Text = "Spd: " + poke.GetMegaBaseSpDefY(),
                    AutoSize = true
                };
                this.Controls.Add(spdlabel);
                spdlabel.Location = new Point(200, 130);

                Label spelabel = new Label
                {
                    Text = "Spe: " + poke.GetMegaBaseSpeedY(),
                    AutoSize = true
                };
                this.Controls.Add(spelabel);
                spelabel.Location = new Point(200, 150);
            }
            //images for mega sprites
            //??do we need this tho
        }

        private void formepaint(object sender, PaintEventArgs e)
        {
            if (megatype == 0)
            {
                //do calculations
                float hp = (float)(poke.GetMegaBaseHp());
                float atk = (float)(poke.GetMegaBaseAtk());
                float def = (float)(poke.GetMegaBaseDef());
                float spa = (float)(poke.GetMegaBaseSpAtk());
                float spd = (float)(poke.GetMegaBaseSpDef());
                float spe = (float)(poke.GetMegaBaseSpeed());

                //roll thru all 6 stat bars and draw with length and color based on each stat
                SolidBrush brush = new SolidBrush(Color.Black)
                {
                    //draw a hp bar
                    Color = DetermineColor(poke.GetMegaBaseHp(), 1)
                };
                e.Graphics.FillRectangle(brush, 265, 55, hp, 6);
                //draw atk bar
                brush.Color = DetermineColor(poke.GetMegaBaseAtk(), 0);
                e.Graphics.FillRectangle(brush, 265, 75, atk, 6);
                //def bar
                brush.Color = DetermineColor(poke.GetMegaBaseDef(), 0);
                e.Graphics.FillRectangle(brush, 265, 95, def, 6);
                //spa bar
                brush.Color = DetermineColor(poke.GetMegaBaseSpAtk(), 0);
                e.Graphics.FillRectangle(brush, 265, 115, spa, 6);
                //spd bar
                brush.Color = DetermineColor(poke.GetMegaBaseSpDef(), 0);
                e.Graphics.FillRectangle(brush, 265, 135, spd, 6);
                //speed bar
                brush.Color = DetermineColor(poke.GetMegaBaseSpeed(), 2);
                e.Graphics.FillRectangle(brush, 265, 155, spe, 6);
            }
            if (megatype == 1)
            {
                //do calculations
                float hp = (float)(poke.GetMegaBaseHpY());
                float atk = (float)(poke.GetMegaBaseAtkY());
                float def = (float)(poke.GetMegaBaseDefY());
                float spa = (float)(poke.GetMegaBaseSpAtkY());
                float spd = (float)(poke.GetMegaBaseSpDefY());
                float spe = (float)(poke.GetMegaBaseSpeedY());

                //roll thru all 6 stat bars and draw with length and color based on each stat
                SolidBrush brush = new SolidBrush(Color.Black)
                {
                    //draw a hp bar
                    Color = DetermineColor(poke.GetMegaBaseHpY(), 1)
                };
                e.Graphics.FillRectangle(brush, 265, 55, hp, 6);
                //draw atk bar
                brush.Color = DetermineColor(poke.GetMegaBaseAtkY(), 0);
                e.Graphics.FillRectangle(brush, 265, 75, atk, 6);
                //def bar
                brush.Color = DetermineColor(poke.GetMegaBaseDefY(), 0);
                e.Graphics.FillRectangle(brush, 265, 95, def, 6);
                //spa bar
                brush.Color = DetermineColor(poke.GetMegaBaseSpAtkY(), 0);
                e.Graphics.FillRectangle(brush, 265, 115, spa, 6);
                //spd bar
                brush.Color = DetermineColor(poke.GetMegaBaseSpDefY(), 0);
                e.Graphics.FillRectangle(brush, 265, 135, spd, 6);
                //speed bar
                brush.Color = DetermineColor(poke.GetMegaBaseSpeedY(), 2);
                e.Graphics.FillRectangle(brush, 265, 155, spe, 6);
            }
        }





        //det color method borrowed from "Form1.cs"
        public Color DetermineColor(float x, int id)//id is flag for whether its hp or not (hp bar calculated differently :))
        {
            if (id == 1)//its a hp bar
            {
                if (x > 149)
                    return Color.FromArgb(155, 128, 128, 128); //silver
                if (x > 89)
                    return Color.FromArgb(150, 0, 255, 33); //green     //format is: (alpha, red, green, blue)
                if (x > 49)
                    return Color.FromArgb(150, 255, 216, 0); //yellow
                return Color.FromArgb(150, 255, 0, 0); //red
            }
            if (id == 2)//its a speed bar
            {
                if (x > 119)
                    return Color.FromArgb(155, 128, 128, 128); //silver
                if (x > 85)
                    return Color.FromArgb(150, 0, 255, 33); //green 
                if (x > 39)
                    return Color.FromArgb(150, 255, 216, 0); //yellow
                return Color.FromArgb(150, 255, 0, 0); //red
            }
            //not a hp or speed bar
            if (x > 146)
                return Color.FromArgb(155, 128, 128, 128); //silver
            if (x > 99)
                return Color.FromArgb(150, 0, 255, 33); //green
            if (x > 59)
                return Color.FromArgb(150, 255, 216, 0); //yellow
            return Color.FromArgb(150, 255, 0, 0); //red
        }

        //thank you stack overflow :)
        //stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance?page=1&tab=votes#tab-top 
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}
