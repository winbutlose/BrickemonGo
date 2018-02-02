using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickemonGo
{
    public partial class DeckMaker : Form
    {
        private List<Card> trunkCards;
        private List<Card> deckCards;
        private List<Pack> packs;
        private Card currentCard;
        private List<PokeCardBox> trunkCardList;
        private List<PokeCardBox> deckCardList;
        private List<PictureBox> PackPictureList;
        private int playerMoney;
        private Point cellPos;
        private ContextMenuStrip cm;
        private ContextMenuStrip deckcm;
        public DeckMaker()
        {
            InitializeComponent();
            DoubleBuffered = true;
            //link paint methods
            this.AllCardsPanel.Paint += new PaintEventHandler(AllCardsPanel_Paint);
            this.DeckPanel.Paint += new PaintEventHandler(DeckPanel_Paint);
            this.InfoPanel.Paint += new PaintEventHandler(InfoPanel_Paint);
            //read in player's money (2000 for now)
            System.IO.StreamReader file = new System.IO.StreamReader(@"res/playermoney.txt");
            String money = "";
            if ((money = file.ReadLine()) != null)//shouldnt be null but just in case
            {
                System.Console.WriteLine("Player has $"+money);
                playerMoney = int.Parse(money);
            }
            file.Close();

            //read in cards from list in /res
            String[] trunkList = ReadDir(@"res/trunkcards.txt");
            trunkCards = new List<Card>();

            //put cards in trunk backend (arraylist)
            for (int i = 0; i < trunkList.Length; i++)
            {
                String s = trunkList[i];
                //s = s.Substring(0, s.Length - 8);
                s = Regex.Replace(s, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                Card x = new Card(s, "res/cards/" + trunkList[i] + " card.png");
                trunkCards.Add(x);
            }

            //read in cards from list in /res
            String[] deckList = ReadDir(@"res/deckcards.txt");
            deckCards = new List<Card>();

            //put cards in deck
            for (int i = 0; i < deckList.Length; i++)
            {
                String s = deckList[i];
                //s = s.Substring(0, s.Length - 8);
                s = Regex.Replace(s, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                Card x = new Card(s, "res/cards/" + deckList[i] + " card.png");
                deckCards.Add(x);
            }

            //right click menu for trunk cards
            cm = new ContextMenuStrip();
            ToolStripMenuItem sell = new ToolStripMenuItem("Sell");
            sell.Click += new EventHandler(Sell_click);
            cm.Items.Insert(0, sell);
            ToolStripMenuItem move = new ToolStripMenuItem("Move to Deck");
            move.Click += new EventHandler(Move_Click);
            cm.Items.Insert(0, move);

            //right click menu for deck cards
            deckcm = new ContextMenuStrip();
            ToolStripMenuItem moveToTrunk = new ToolStripMenuItem("Move to Trunk");
            moveToTrunk.Click += new EventHandler(MoveToTrunk_Click);
            deckcm.Items.Insert(0, moveToTrunk);

            //make cards in trunk

            trunkCardList = new List<PokeCardBox>();
            deckCardList = new List<PokeCardBox>();

            for (int i = 0; i < trunkCards.Count; i++)
            {
                trunkCardList.Add(new PokeCardBox(i));
                trunkCardList[i].SetHeldCard(trunkCards[i]);
                trunkCardList[i].ImageLocation = trunkCardList[i].GetHeldCard().GetImageLoc();
            }

            for (int i = 0; i < deckCards.Count; i++)
            {
                deckCardList.Add(new PokeCardBox(i));
                deckCardList[i].SetHeldCard(deckCards[i]);
                deckCardList[i].ImageLocation = deckCardList[i].GetHeldCard().GetImageLoc();
            }

            DrawDeck();
            DrawTrunk();
            ShowBackendArrays();

            //do store stuff
            //theres only 1 pack for now lol so its hardcoded :)
            packs = new List<Pack>();
            PackPictureList = new List<PictureBox>();
            packs.Add(new Pack("NAME", @"res/packs/card pack 1.png"));
            packs.Add(new Pack("NAME", @"res/packs/card pack 2.png"));
            for (int i = 0; i < packs.Count; i++)
            {
                PackPictureList.Add(new PictureBox());
                PackPictureList[i].ImageLocation = packs[i].GetImageLoc();
            }

            DrawPacks();

            Refresh();
        }

        private void PictureboxDefault_MouseEnter(object sender, EventArgs e)
        {
            PokeCardBox trigger = (PokeCardBox)sender;
            currentCard = trigger.GetHeldCard();
            //Console.WriteLine("HOVER:"+sender);
            Refresh();
        }

        private void PictureboxDefault_MouseDownTrunk(object sender, EventArgs e)
        {
            cellPos = (Point)GetIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
            Console.WriteLine(cellPos);
        }
        private void PictureboxDefault_MouseDownDeck(object sender, EventArgs e)
        {
            cellPos = (Point)GetIndex(tableLayoutPanel2, tableLayoutPanel2.PointToClient(Cursor.Position));
            Console.WriteLine(cellPos);
        }
        private void Sell_click(object sender, EventArgs e)//remove from trunk and get money
        {
            int position = cellPos.Y * 8 + cellPos.X; //row*5+col
            Card trigger = trunkCards[position];
            //make the sell dialogue
            SellForm sf = new SellForm(500, trigger, position);
            var result = sf.ShowDialog();
            if (result == DialogResult.OK)
            {
                RemoveCardFromTrunk(position, cellPos.Y, cellPos.X);
                playerMoney += 500;
                Refresh();
            }
            ShowBackendArrays();
        }
        private void Move_Click(object sender, EventArgs e)//to move from trunk to deck
        {
            //only 5 cards allowed in deck
            if (deckCardList.Count == 5)
            {
                System.Windows.Forms.MessageBox.Show("Deck is full!");
                return;
            }
            int position = cellPos.Y * 8 + cellPos.X; //row*8+col
            //add the selected card to the deck
            Card trigger = trunkCards[position];
            deckCards.Add(trigger);
            deckCardList.Add(new PokeCardBox(deckCardList.Count));
            deckCardList[deckCardList.Count - 1].SetHeldCard(deckCards[deckCardList.Count - 1]);
            deckCardList[deckCardList.Count - 1].ImageLocation = deckCardList[deckCardList.Count - 1].GetHeldCard().GetImageLoc();
            //remove the card from the trunk
            RemoveCardFromTrunk(position, cellPos.Y, cellPos.X);
            //redraw
            DrawDeck();
            DrawTrunk();

            ShowBackendArrays();

        }
        private void MoveToTrunk_Click(object sender, EventArgs e)
        {
            int position = cellPos.X; //for deck theres only 5 cards so col# is position in array :) since theres only 1 row
            //add the selected card to the deck
            Card trigger = deckCards[position];
            trunkCards.Add(trigger);
            trunkCardList.Add(new PokeCardBox(trunkCardList.Count));
            trunkCardList[trunkCardList.Count - 1].SetHeldCard(trunkCards[trunkCardList.Count - 1]);
            trunkCardList[trunkCardList.Count - 1].ImageLocation = trunkCardList[trunkCardList.Count - 1].GetHeldCard().GetImageLoc();
            //remove the card from the trunk
            RemoveCardFromDeck(position, cellPos.Y, cellPos.X);
            //redraw
            DrawDeck();
            DrawTrunk();

            ShowBackendArrays();
        }


        private void AllCardsPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                CardPictureBox.ImageLocation = currentCard.GetImageLoc();
                CardNameLabel.Text = currentCard.GetName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //Console.WriteLine("PAINTED");
        }
        private void DeckPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                CardPictureBox.ImageLocation = currentCard.GetImageLoc();
                CardNameLabel.Text = currentCard.GetName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //Console.WriteLine("PAINTED");
        }

        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {
            PlayernameLabel.Text = "Player";
            PlayerMoneyLabel.Text = "" + playerMoney;
            //Console.WriteLine("PAINTED");
        }


        private string[] ReadDir(String path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
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
        public void RemoveCardFromTrunk(int x, int r, int c)
        {
            Console.WriteLine("Removing Card From Trunk at: (" + c + "," + r + ")");
            trunkCards.RemoveAt(x);
            trunkCardList.RemoveAt(x);
            tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(c, r));
            Refresh();
        }
        public void RemoveCardFromDeck(int x, int r, int c)
        {
            Console.WriteLine("Removing Card From Deck at: (" + c + "," + r + ")");
            deckCards.RemoveAt(x);
            deckCardList.RemoveAt(x);
            tableLayoutPanel2.Controls.Remove(tableLayoutPanel2.GetControlFromPosition(c, r));
            Refresh();
        }
        private void DrawTrunk()
        {
            for (int i = 0; i < trunkCards.Count; i++)
            {
                tableLayoutPanel1.Controls.Add(trunkCardList[i]);
                Size size = new Size(119, 167);
                trunkCardList[i].Size = size;
                trunkCardList[i].SizeMode = PictureBoxSizeMode.Zoom;
                trunkCardList[i].MouseEnter += PictureboxDefault_MouseEnter;
                trunkCardList[i].MouseDown += PictureboxDefault_MouseDownTrunk;
                trunkCardList[i].ContextMenuStrip = cm;
            }
        }
        private void DrawDeck()
        {
            for (int i = 0; i < deckCards.Count; i++)
            {
                tableLayoutPanel2.Controls.Add(deckCardList[i]);
                Size size = new Size(238, 333);
                deckCardList[i].Size = size;
                deckCardList[i].SizeMode = PictureBoxSizeMode.Zoom;
                deckCardList[i].MouseEnter += PictureboxDefault_MouseEnter;
                deckCardList[i].MouseDown += PictureboxDefault_MouseDownDeck;
                deckCardList[i].ContextMenuStrip = deckcm;
            }
        }
        private void DrawPacks()
        {
            for (int i = 0; i < packs.Count; i++)
            {
                tableLayoutPanelStore.Controls.Add(PackPictureList[i]);
                Size size = new Size(250, 400);
                PackPictureList[i].Size = size;
                PackPictureList[i].SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void ShowBackendArrays()//for debugging, shows decklist and trunklist in debug text
        {
            //deck
            Console.WriteLine("CARDS IN DECK" + "(" + deckCardList.Count + ")");
            Boolean first = true;
            foreach (Card obj in deckCards)
            {
                if (first)
                {
                    Console.Write("[" + obj.GetName());
                    first = false;
                    continue;
                }
                Console.Write("," + obj.GetName());
            }
            Console.WriteLine("]");
            //trunk
            Console.WriteLine("CARDS IN TRUNK" + "(" + trunkCardList.Count + ")");
            first = true;
            foreach (Card obj in trunkCards)
            {
                if (first)
                {
                    Console.Write("[" + obj.GetName());
                    first = false;
                    continue;
                }
                Console.Write("," + obj.GetName());
            }
            Console.WriteLine("]");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //deck
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"res/deckCards.txt"))
            {
                foreach (Card card in deckCards)
                {
                    file.WriteLine(card.GetName().ToLower());
                }
            }
            //trunk
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"res/trunkCards.txt"))
            {
                foreach (Card card in trunkCards)
                {
                    file.WriteLine(card.GetName().ToLower());
                }
            }
            //player money
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"res/playermoney.txt"))
            {
                file.WriteLine(playerMoney);
            }
            Application.Exit();
        }
    }
}
