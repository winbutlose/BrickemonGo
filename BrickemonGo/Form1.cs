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
        private Pokemon poke;
        public Form1(Pokemon x)
        {
            CreateForm(x);
        }
        public void CreateForm(Pokemon x)
        {
            InitializeComponent();
            poke = x;
            //set up paint methods below
            this.StatPanel.Paint += new PaintEventHandler(Form1_Paint);
            this.InfoPanel.Paint += new PaintEventHandler(Info_Paint);
            this.formeTablePanel.Paint += new PaintEventHandler(Formes_Paint);
            Refresh();
            pictureBox1.Update();
            NameLabel.Update();
            GetAllInformation();
            GetFormes();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
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
            NameLabel.Text = poke.GetName();
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
            NameLabel.Text = poke.GetName();
            //pictures for types
            Type type = poke.GetType();
            type1picturebox.ImageLocation = @"res/type circles/" + type.GetPrimaryTypeString() + ".png";
            type2picturebox.ImageLocation = @"res/type circles/" + type.GetSecondaryTypeString() + ".png";
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
            NameLabel.Text = poke.GetName();
            //GetFormes();
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
        {//EXAMPLE: charizard:{num:6,species:"Charizard",types:["Fire","Flying"],genderRatio:{M:0.875,F:0.125},baseStats:{hp:78,atk:84,def:78,spa:109,spd:85,spe:100},abilities:{0:"Blaze",H:"Solar Power"},heightm:1.7,weightkg:90.5,color:"Red",prevo:"charmeleon",evoLevel:36,eggGroups:["Monster","Dragon"],otherFormes:["charizardmegax","charizardmegay"]},
            string[] allInfo = System.IO.File.ReadAllLines(@"res/pokedex.txt");
            String line = allInfo[poke.GetDexNum()];
            Console.WriteLine(line);
            //abilities
            String formattedInfo = "";
            String str = line.Substring(line.IndexOf("abilities:") + 11);
            str = str.Substring(0, str.IndexOf("}"));
            str = str.Replace("0", "Normal");
            str = str.Replace("H", "Hidden");
            str = str.Replace("\"", " ");
            str = str.Replace(",", " ");
            formattedInfo += "Abilities [ " + str + "]";
            //height and weight
            str = line.Substring(line.IndexOf("heightm:") + 8);
            str = str.Substring(0, str.IndexOf(","));
            formattedInfo += "\r\n" + "Height [ " + str + " Meters ]";
            str = line.Substring(line.IndexOf("weightkg:") + 9);
            str = str.Substring(0, str.IndexOf(","));
            formattedInfo += "    Weight [ " + str + " Kg ]";
            //color
            str = line.Substring(line.IndexOf("color:") + 6);
            str = str.Substring(0, str.IndexOf(","));
            str = str.Replace("\"", " ");
            formattedInfo += "\r\n" + "Color [" + str + "]";
            //evos prevos
            if (line.Contains("prevo"))
            {
                str = line.Substring(line.IndexOf("prevo:") + 6);
                str = str.Substring(0, str.IndexOf(","));
                str = str.Replace("\"", " ");
                formattedInfo += "\r\n" + "Prevo [" + str + "]";
            }
            else
            {
                formattedInfo += "\r\n" + "Prevo [ none ]";
            }
            if (line.Contains("evos:"))
            {
                str = line.Substring(line.IndexOf("evos:") + 5);
                str = str.Substring(0, str.IndexOf(","));
                str = str.Replace("\"", " ");
                str = str.Replace("[", "");
                str = str.Replace("]", "");
                formattedInfo += "\r\n" + "Evolutions [" + str + "]";
            }
            else
            {
                formattedInfo += "\r\n" + "Evolutions [ none ]";
            }








            fullinfobox.Text = formattedInfo;
        }
        private void GetFormes()//populate formes tab with other formes of pokemon if necesscary 
        {
            string[] allInfo = System.IO.File.ReadAllLines(@"res/pokedex.txt");
            String line = allInfo[poke.GetDexNum()];
            String formattedInfo = "";
            String str = "none";
            Label FormesLabel = new Label();
            PictureBox formePicBox = new PictureBox();


            if (line.Contains("otherFormes"))
            {
                str = line.Substring(line.IndexOf("otherFormes:") + 14);
                str = str.Substring(0, str.IndexOf("]") - 1);
                Console.WriteLine("FORMESTRING=" + str);
            }
            else
            {
                //no extra formes
                formattedInfo += "Formes: None";
                FormesLabel.Text = formattedInfo;
                formePicBox.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + "dne.png");
                //clear the formes another pokemon might have drawn in the panel
                formeTablePanel.Controls.Clear();
                return;
            }

            if (str.Contains(","))//multiple formes
            {
                //formattedInfo = str.Substring(0, str.IndexOf(",")-1);
                String[] formes = str.Split(',');
                Console.WriteLine("formeimagelocMULTIPLE_FORMES=" + formes[0]);
                for (int i = 0; i < formes.Length; i++)
                {
                    formes[i] = formes[i].Replace("\"", "");
                    formes[i] = formes[i].Substring(poke.GetName().Length);
                    Console.WriteLine("res/sprites/sugimori/" + this.poke.GetDexNum() + "-" + formes[0] + ".png");
                }
                //FormesLabel.Text = formes[0];
                //formePicBox.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + "-" + formes[0] + ".png");
                //DRAW IT NOW
                DrawFormes(formes);
                return;
            }

            //single extra forme

            formattedInfo = str.Substring(poke.GetName().Length);
            Console.WriteLine("formeimageloc=" + formattedInfo);
            String formattedInfoUp = (formattedInfo.Substring(0, 1)).ToUpper() + formattedInfo.Substring(1);
            if (formattedInfo.Equals("mega"))
            {
                FormesLabel.Text = "Mega " + poke.GetName();
            }
            else
            {
                FormesLabel.Text = poke.GetName() + " " + formattedInfoUp + " Forme";
            }
            formePicBox.ImageLocation = (@"res/sprites/sugimori/" + this.poke.GetDexNum() + "-" + formattedInfo + ".png");
            Console.WriteLine("res/sprites/sugimori/" + this.poke.GetDexNum() + "-" + formattedInfo + ".png");

            //DRAW IT NOW
            String[] formelist = new String[1];
            formelist[0] = formattedInfo;
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
            Refresh();
        }
        private void DrawFormes(String[] formeList)
        {
            //first clear panel
            formeTablePanel.Controls.Clear();
            //roll thru list and make new formepanel (with pic) for each forme this poke has
            for (int i = 0; i < formeList.Count(); i++)
            {
                FormePanel x = new FormePanel(formeList[i] +" forme", "res/sprites/sugimori/" + poke.GetDexNum() +"-"+formeList[i]+ ".png");
                formeTablePanel.Controls.Add(x);
                Console.WriteLine(formeList[i]);
            }
        }
    }
}
