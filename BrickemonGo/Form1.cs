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
    public partial class Form1 : Form
    {
        //private Pokemon poke;
        private Dictionary<int, Move> MoveDictionary;
        public Form1(int x)
        {
            CreateForm(x);
        }
        public void CreateForm(int x)
        {
            //init
            InitializeComponent();
            int pokenum = x;
            //set up paint methods below
            this.StatPanel.Paint += new PaintEventHandler(Form1_Paint);
            this.InfoPanel.Paint += new PaintEventHandler(Info_Paint);
            this.formeTablePanel.Paint += new PaintEventHandler(Formes_Paint);
            this.spritestabPanel.Paint += new PaintEventHandler(Sprites_Paint);
            this.MoveTablePanel.Paint += new PaintEventHandler(Moves_Paint);
            Refresh();
            pictureBox1.Update();
            NameLabel.Update();
            GetAllInformation();
            GetFormes();
            DrawMoves();
            //fix horizontal scrollbar in movetablepanel
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            MoveTablePanel.Padding = new Padding(0, 0, vertScrollWidth, 0);


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = (@"res/sprites/sugimori/" + this.pokenum.GetNum(poke) + ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //name text box
            NameLabel.Text = "#" + poke.GetDexNum() + "  " + poke.GetName();
            //do calculations
            float hp = (float)(poke.GetBaseHp() * 2);
            float atk = (float)(poke.GetBaseAtk() * 2);
            float def = (float)(poke.GetBaseDef() * 2);
            float spa = (float)(poke.GetBaseSpAtk() * 2);
            float spd = (float)(poke.GetBaseSpDef() * 2);
            float spe = (float)(poke.GetBaseSpeed() * 2);

            //roll thru all 6 stat bars and draw with length and color based on each stat
            SolidBrush brush = new SolidBrush(Color.Black)
            {
                //draw a hp bar
                Color = DetermineColor(poke.GetBaseHp(), 1)
            };
            e.Graphics.FillRectangle(brush, 0, 5, hp, 30);
            //draw atk bar
            brush.Color = DetermineColor(poke.GetBaseAtk(), 0);
            e.Graphics.FillRectangle(brush, 0, 55, atk, 30);
            //def bar
            brush.Color = DetermineColor(poke.GetBaseDef(), 0);
            e.Graphics.FillRectangle(brush, 0, 105, def, 30);
            //spa bar
            brush.Color = DetermineColor(poke.GetBaseSpAtk(), 0);
            e.Graphics.FillRectangle(brush, 0, 155, spa, 30);
            //spd bar
            brush.Color = DetermineColor(poke.GetBaseSpDef(), 0);
            e.Graphics.FillRectangle(brush, 0, 205, spd, 30);
            //speed bar
            brush.Color = DetermineColor(poke.GetBaseSpeed(), 2);
            e.Graphics.FillRectangle(brush, 0, 255, spe, 30);

            //write numbers for stats in ? boxes
            HPValueLabel.Text = "" + poke.GetBaseHp();
            ATKValueLabel.Text = "" + poke.GetBaseAtk();
            DEFValueLabel.Text = "" + poke.GetBaseDef();
            SPAValueLabel.Text = "" + poke.GetBaseSpAtk();
            SPDValueLabel.Text = "" + poke.GetBaseSpDef();
            SPEEDValueLabel.Text = "" + poke.GetBaseSpeed();
            int totalStat = poke.GetBaseHp() + poke.GetBaseAtk() + poke.GetBaseDef() + poke.GetBaseSpAtk() + poke.GetBaseSpDef() + poke.GetBaseSpeed();
            TotalStatLabel.Text = "" + totalStat;
        }
        private void Info_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //name text box
            NameLabel.Text = "#" + poke.GetDexNum() + "  " + poke.GetName();
            //pictures for types
            Type type = poke.GetType();
            type1picturebox.ImageLocation = @"res/type circles/" + type.getPrimaryTypeAsString() + ".png";
            type2picturebox.ImageLocation = @"res/type circles/" + type.getSecondaryTypeAsString() + ".png";
            //GetAllInformation();
        }
        private void Formes_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //name text box
            NameLabel.Text = "#" + poke.GetDexNum() + "  " + poke.GetName();
            //GetFormes();
        }
        private void Sprites_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //name text box
            NameLabel.Text = "#" + poke.GetDexNum() + "  " + poke.GetName();
            //sprite pictures
            SpriteboxFront.ImageLocation = @"res/sprites/blackwhite/" + poke.GetDexNum() + ".png";
            SpriteboxBack.ImageLocation = @"res/sprites/blackwhite/back/" + poke.GetDexNum() + ".png";
            SpriteboxFrontShiny.ImageLocation = @"res/sprites/blackwhite/shiny/" + poke.GetDexNum() + ".png";
            SpriteboxBackShiny.ImageLocation = @"res/sprites/blackwhite/back/shiny/" + poke.GetDexNum() + ".png";
        }

        private void Moves_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //name text box
            NameLabel.Text = "#" + poke.GetDexNum() + "  " + poke.GetName();
        }

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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Rebuild(int.Parse(SearchBox.Text));
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Rebuild(int.Parse(SearchBox.Text));
            }
        }

        private void GetAllInformation()
        {

        }

        //private void GetAllInformation()
        //{//EXAMPLE: charizard:{num:6,species:"Charizard",types:["Fire","Flying"],genderRatio:{M:0.875,F:0.125},baseStats:{hp:78,atk:84,def:78,spa:109,spd:85,spe:100},abilities:{0:"Blaze",H:"Solar Power"},heightm:1.7,weightkg:90.5,color:"Red",prevo:"charmeleon",evoLevel:36,eggGroups:["Monster","Dragon"],otherFormes:["charizardmegax","charizardmegay"]},
        //    string[] allInfo = System.IO.File.ReadAllLines(@"res/pokedex.txt");
        //    String line = allInfo[poke.GetDexNum()];
        //    Console.WriteLine(line);
        //    //abilities
        //    String formattedInfo = "";
        //    String str = line.Substring(line.IndexOf("abilities:") + 11);
        //    str = str.Substring(0, str.IndexOf("}"));
        //    str = str.Replace("0", "Normal");
        //    str = str.Replace("H", "Hidden");
        //    str = str.Replace("\"", " ");
        //    str = str.Replace(",", " ");
        //    formattedInfo += "Abilities [ " + str + "]";
        //    //height and weight
        //    str = line.Substring(line.IndexOf("heightm:") + 8);
        //    str = str.Substring(0, str.IndexOf(","));
        //    formattedInfo += "\r\n" + "Height [ " + str + " Meters ]";
        //    str = line.Substring(line.IndexOf("weightkg:") + 9);
        //    str = str.Substring(0, str.IndexOf(","));
        //    formattedInfo += "    Weight [ " + str + " Kg ]";
        //    //color
        //    str = line.Substring(line.IndexOf("color:") + 6);
        //    str = str.Substring(0, str.IndexOf(","));
        //    str = str.Replace("\"", " ");
        //    formattedInfo += "\r\n" + "Color [" + str + "]";
        //    //evos prevos
        //    if (line.Contains("prevo"))
        //    {
        //        str = line.Substring(line.IndexOf("prevo:") + 6);
        //        str = str.Substring(0, str.IndexOf(","));
        //        str = str.Replace("\"", " ");
        //        formattedInfo += "\r\n" + "Prevo [" + str + "]";
        //    }
        //    else
        //    {
        //        formattedInfo += "\r\n" + "Prevo [ none ]";
        //    }
        //    if (line.Contains("evos:"))
        //    {
        //        str = line.Substring(line.IndexOf("evos:") + 5);
        //        str = str.Substring(0, str.IndexOf(","));
        //        str = str.Replace("\"", " ");
        //        str = str.Replace("[", "");
        //        str = str.Replace("]", "");
        //        formattedInfo += "\r\n" + "Evolutions [" + str + "]";
        //    }
        //    else
        //    {
        //        formattedInfo += "\r\n" + "Evolutions [ none ]";
        //    }
        //    //original game (later to support giving credit for fakemons too)
        //    if (line.Contains("OriginalGame"))
        //    {
        //        str = line.Substring(line.IndexOf("OriginalGame") + 13);
        //        str = str.Substring(0, str.IndexOf(","));
        //        str = str.Replace("[", "");
        //        str = str.Replace("]", "");
        //        switch (str)
        //        {
        //            case "Gen1":
        //                formattedInfo += "\r\n" + "Original Games: [ Red/Blue/Yellow ]";
        //                break;
        //            case "Gen2":
        //                formattedInfo += "\r\n" + "Original Games: [ Gold/Silver/Crystal ]";
        //                break;
        //            case "Gen3":
        //                formattedInfo += "\r\n" + "Original Games: [ Ruby/Sapphire/Emerald ]";
        //                break;
        //            case "Gen4":
        //                formattedInfo += "\r\n" + "Original Games: [ Diamond/Pearl/Platinum ]";
        //                break;
        //            case "Gen5":
        //                formattedInfo += "\r\n" + "Original Games: [ BLack/White ]";
        //                break;
        //            case "Gen6":
        //                formattedInfo += "\r\n" + "Original Games: [ X/Y ]";
        //                break;
        //            default:
        //                throw new Exception("Pokemon has unknown original game");
        //        }
        //    }






        //    fullinfobox.Text = formattedInfo;
        //}
        private void GetFormes()//populate formes tab with other formes of pokemon if necesscary 
        {
            Label FormesLabel = new Label();
            PictureBox formePicBox = new PictureBox();
            String[] formelist = new String[2];
            if (poke.HasMega() == 0)
            {
                formeTablePanel.Controls.Clear();
                return;
            }
            else if (poke.HasMega() == 1)//single mega forme
            {
                formelist[0] = poke.GetMegaName().Substring(poke.GetName().Length);
            }
            else if (poke.HasMega() == 2)//multiple mega formes
            {
                formelist[0] = poke.GetMegaName().Substring(poke.GetName().Length);
                formelist[1] = poke.GetMegaNameY().Substring(poke.GetName().Length);
            }
            DrawFormes(formelist);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            Rebuild(poke.GetDexNum() + 1);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            Rebuild(poke.GetDexNum() - 1);
        }
        public void Rebuild(int dexnum)
        {
            if (dexnum > 721 || dexnum < 1)
            {
                System.Windows.Forms.MessageBox.Show("Invalid Dex Number");
                return;
            }
            Pokemon x = new Pokemon(dexnum, 100);
            SearchBox.Text = "";
            this.poke = x;
            GetAllInformation();
            GetFormes();
            DrawMoves();
            Refresh();
        }
        private void DrawFormes(String[] formeList)
        {
            //first clear panel
            formeTablePanel.Controls.Clear();
            //roll thru list and make new formepanel (with pic) for each forme this poke has
            if (formeList == null)
            {
                return;
            }
            FormePanel x = new FormePanel(0, this.poke, "res/sprites/sugimori/" + poke.GetDexNum() + "-" + formeList[0] + ".png");
            formeTablePanel.Controls.Add(x);
            Console.WriteLine(formeList[0]);
            if (formeList[1] == null)
                return;
            FormePanel y = new FormePanel(1, this.poke, "res/sprites/sugimori/" + poke.GetDexNum() + "-" + formeList[1] + ".png");
            formeTablePanel.Controls.Add(y);
            Console.WriteLine(formeList[1]);

        }
        private void DrawMoves()
        {
            //make move table
            MoveDictionary = poke.GetMoveset();
            //GRAB DATA FROM HERE^ AND POPULATE MOVE TAB TABLE :)
            MoveTablePanel.Controls.Clear();
            MoveTablePanel.AutoScroll = false;
            MoveTablePanel.AutoScroll = true;
            int iterator = 0;
            Size s = new Size(25, 25);
            foreach (KeyValuePair<int, Move> entry in MoveDictionary)
            {
                MoveTablePanel.Controls.Add(new TextBox() { Text = entry.Value.GetName(), ReadOnly = true, BackColor = SystemColors.ControlDarkDark, Width = 150, BorderStyle = BorderStyle.None, }, 2, iterator);
                MoveTablePanel.Controls.Add(new TextBox() { Text = "" + entry.Key, ReadOnly = true, BackColor = SystemColors.ControlDarkDark, Width = 25, BorderStyle = BorderStyle.None }, 0, iterator);
                MoveTablePanel.Controls.Add(new PictureBox() { ImageLocation = @"res/type circles/" + entry.Value.GetType().getPrimaryTypeAsString().ToLower() + ".png", SizeMode = PictureBoxSizeMode.Zoom, Size = s }, 1, iterator);
                MoveTablePanel.Controls.Add(new TextBox() { Text = "" + entry.Value.GetDamage(), ReadOnly = true, BackColor = SystemColors.ControlDarkDark, Width = 25, BorderStyle = BorderStyle.None }, 3, iterator);
                MoveTablePanel.Controls.Add(new TextBox() { Text = "" + entry.Value.GetAccuracy() + "%", ReadOnly = true, BackColor = SystemColors.ControlDarkDark, Width = 40, BorderStyle = BorderStyle.None }, 4, iterator);
                MoveTablePanel.Controls.Add(new TextBox() { Text = "" + entry.Value.GetMoveCategoryString(), ReadOnly = true, BackColor = SystemColors.ControlDarkDark, Width = 75, BorderStyle = BorderStyle.None }, 5, iterator);
                PictureBox checkmark = new PictureBox();
                checkmark.SizeMode = PictureBoxSizeMode.Zoom;
                checkmark.ImageLocation = @"res/symbols/yes.png";
                checkmark.Size = s;
                checkmark.MouseHover += Checkmark_hover;
                MoveTablePanel.Controls.Add(checkmark,6,iterator);
                iterator++;
            }
        }

        private void Checkmark_hover(object sender, EventArgs e)
        {
            //int rowIndex = MoveTablePanel.HitTest(e.X, e.Y).RowIndex;
            //Console.WriteLine(rowIndex):
        }

        //thank you stack overflow :)
        public Point? GetIndex(TableLayoutPanel tlp, Point point)
        {
            // Method adapted from: stackoverflow.com/a/15449969
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = 0, h = 0;
            int[] widths = tlp.GetColumnWidths(), heights = tlp.GetRowHeights();

            int i;
            for (i = 0; i < widths.Length && point.X > w; i++)
            {
                w += widths[i];
            }
            int col = i - 1;

            for (i = 0; i < heights.Length && point.Y + tlp.VerticalScroll.Value > h; i++)
            {
                h += heights[i];
            }
            int row = i - 1;

            return new Point(col, row);
        }
    }
}
