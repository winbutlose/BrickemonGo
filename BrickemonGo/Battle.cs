﻿//Matthew Silbermann Shea Luskey Ryan Maurer 7/28/17
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickemonGo
{
    public partial class Battle : Form
    {
        private Trainer T1, T2;
        private Pokemon P1, P2;
        private int choiceT1, choiceT2;
        private int moveT1, moveT2;
        private int turn = 1;

        public Battle(Trainer a, Trainer b)
        {
            T1 = a;
            T2 = b;
            P1 = T1.GetPartyAt(0);
            P2 = T2.GetPartyAt(0);
            InitializeComponent();
            this.Shown += Battle_shown;
        }

        private void Battle_shown(Object sender, EventArgs e)
        {

            //MessageBox.Show("You are in the Form.Shown event.");
            CreateBattle();
            DoBattle();

        }

        public void CreateBattle()
        {
            this.MainPanel.Paint += new PaintEventHandler(Main_paint);
            PictureBoxOppPoke.Update();
            Refresh();
        }

        private void Main_paint(object sender, PaintEventArgs e)
        {
            //Pokemon Pictures
            Bitmap bm1 = new Bitmap(@"res/sprites/sugimori/" + this.P1.GetDexNum() + ".png"); //flip user pkmn to face opponent
            bm1.RotateFlip(RotateFlipType.Rotate180FlipY);
            this.PictureBoxUserPoke.Image = bm1;
            //PictureBoxUserPoke.ImageLocation = (@"res/sprites/sugimori/" + P1.GetDexNum() + ".png");
            PictureBoxUserPoke.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxOppPoke.ImageLocation = (@"res/sprites/sugimori/" + P2.GetDexNum() + ".png");
            PictureBoxOppPoke.SizeMode = PictureBoxSizeMode.Zoom;

            pokename.Text = "" + P1.GetName();
            opppokename.Text = "" + P2.GetName();
            pokehp.Text = "HP: " + P1.GetRemainingHp() + "/" + P1.GetHp();
            opppokehp.Text = "HP: " + P2.GetRemainingHp() + "/" + P2.GetHp();

            //hp bars hehe        <---put these back in later when this is closer to being done 

            //SolidBrush brush = new SolidBrush(Color.Black);
            //e.Graphics.DrawString(P1.GetName(), new Font("Arial", 24), brush, 10, 265);
            //e.Graphics.DrawString(P2.GetName(), new Font("Arial", 24), brush, 650, 265);
            //e.Graphics.FillRectangle(brush, 0, 305, P1.GetRemainingHp(), 10);
            //e.Graphics.FillRectangle(brush, 650, 305, P2.GetRemainingHp(), 10);
            //e.Graphics.DrawString(P1.GetRemainingHp() + "/" + P1.GetHp(), new Font("Arial", 24), brush, 10, 330);
            //e.Graphics.DrawString(P2.GetRemainingHp() + "/" + P2.GetHp(), new Font("Arial", 24), brush, 650, 330);
            //e.Graphics.DrawString("Shiny: " + P1.GetShiny(), new Font("Arial", 24), brush, 10, 355);
            //e.Graphics.DrawString("Shiny: " + P2.GetShiny(), new Font("Arial", 24), brush, 650, 355);

            //status effect pictures
            statuspicbox.ImageLocation = (@"res/status/" + P1.GetStatus() + ".png");
            oppstatuspicbox.ImageLocation = (@"res/status/" + P2.GetStatus() + ".png");
        }

        public void DoBattle()
        {
            //init battle vars
            textboxwords.Text = ("Battle! " + P1.GetName() + " vs " + P2.GetName());
            Boolean fighting = true;

            //reset button choices
            choiceT1 = 4;//-1;
            choiceT2 = 4;//-1;
            moveT1 = -1;
            moveT2 = 3;//-1;

            UpdateButtons();
            //main battle loop
            //while (fighting)
            //{
            //}
        }

        public void CheckFainted()
        {
            Console.WriteLine(P1 + "\n" + P1.HpString());
            Console.WriteLine(P2 + "\n" + P2.HpString());
            Console.WriteLine("CHECKING WIN CONDITION");
            //check if trainer is blacked out
            if (T1.IsBlackedOut())
            {
                Refresh();
                textboxwords.Text = (T2.GetName() + " Wins!");
                outputbox.AppendText(T2.GetName() + " Wins!" + "\n");
                MessageBox.Show(T2.GetName() + " Wins!");
                System.Windows.Forms.Application.Exit();
                return;
            }
            if (T2.IsBlackedOut())
            {
                Refresh();
                textboxwords.Text = (T1.GetName() + " Wins!");
                outputbox.AppendText(T1.GetName() + " Wins!" + "\n");
                MessageBox.Show(T1.GetName() + " Wins!");
                System.Windows.Forms.Application.Exit();
                return;
            }

            //check fainted
            if (P1.IsFainted())
            {
                PrintToTextBox(P1.GetName() + " fainted!");
                //Console.WriteLine(P1.GetName() + " fainted!");
                //textboxwords.Text = (P1.GetName() + " fainted!");
                //outputbox.AppendText(P1.GetName() + " fainted!" + "\n");

                //switch T1
                SwitchPoke(T1, findValidSwitch(T1, 0));
            }
            if (P2.IsFainted())
            {
                PrintToTextBox(P2.GetName() + " fainted!");
                //Console.WriteLine(P2.GetName() + " fainted!");
                //textboxwords.Text = (P2.GetName() + " fainted!");
                //outputbox.AppendText(P2.GetName() + " fainted!"+"\n");

                //switch T2
                SwitchPoke(T2, findValidSwitch(T2, 0));
            }
        }

        public void ProcessChoice()
        {
            //*********
            // DO STUFF
            //*********


            int choices = choiceT1 * 10 + choiceT2;
            //main giant switch statement
            switch (choices)
            {//1:run 2:bag 3:switch 4:atk
                case 11://both run
                    Console.WriteLine("Both players ended the battle");
                    //fighting = false;
                    break;
                case 12://t1 run t2 bag
                    Console.WriteLine("No! There's no running from a trainer battle!");
                    Bag(T2);
                    break;
                case 13://t1 run t2 switch
                    Console.WriteLine("No! There's no running from a trainer battle!");
                    SwitchPoke(T2, 1);
                    break;
                case 14://t1 run t2 attack
                    Console.WriteLine("No! There's no running from a trainer battle!");
                    Attack(P2, moveT2, P1);
                    break;
                case 21://t1 bag t2 run
                    Console.WriteLine("No! There's no running from a trainer battle!");
                    Bag(T1);
                    break;
                case 22://t1 bag t2 bag
                        //speed goes first
                    if (P1.GetSpeed() >= P2.GetSpeed())
                    {
                        Bag(T1);
                        Bag(T2);
                    }
                    else
                    {
                        Bag(T2);
                        Bag(T1);
                    }
                    break;
                case 23://t1 bag t2 switch
                        //speed goes first
                    if (P1.GetSpeed() >= P2.GetSpeed())
                    {
                        Bag(T1);
                        SwitchPoke(T2, moveT2);
                    }
                    else
                    {
                        SwitchPoke(T2, moveT2);
                        Bag(T1);
                    }
                    break;
                case 24://t1 bag t2 attack
                    Bag(T1);
                    Attack(P2, moveT2, P1);
                    break;
                case 31://t1 switch t2 run
                    Console.WriteLine("No! There's no running from a trainer battle!");
                    SwitchPoke(T2, moveT2);
                    break;
                case 32://t1 switch t2 bag
                        //speed goes first
                    if (P1.GetSpeed() >= P2.GetSpeed())
                    {
                        SwitchPoke(T1, moveT1);
                        Bag(T2);
                    }
                    else
                    {
                        SwitchPoke(T1, moveT1);
                        Bag(T2);
                    }
                    break;
                case 33://t1 switch t2 switch
                        //speed goes first
                    if (P1.GetSpeed() >= P2.GetSpeed())
                    {
                        SwitchPoke(T1, moveT1);
                        SwitchPoke(T2, moveT2);
                    }
                    else
                    {
                        SwitchPoke(T2, moveT2);
                        SwitchPoke(T1, moveT1);
                    }
                    break;
                case 34://t1 switch t2 attack
                    SwitchPoke(T1, moveT1);
                    Attack(P2, moveT2, P1);
                    break;
                case 41://t1 attack t2 run
                    Console.WriteLine("No! There's no running from a trainer battle!");
                    Attack(P1, moveT1, P2);
                    break;
                case 42://t1 attack t2 bag
                    Bag(T2);
                    Attack(P1, moveT1, P2);
                    break;
                case 43://t1 attack t2 switch
                    SwitchPoke(T2, moveT2);
                    Attack(P1, moveT1, P2);
                    break;
                case 44://BOTH ATTACK! :)
                    if (P1.GetSpeed() >= P2.GetSpeed())
                    {
                        Attack(P1, moveT1, P2);
                        Thread.Sleep(500);
                        if (P2.IsFainted())
                        {
                            CheckFainted();
                            break;
                        }
                        Attack(P2, moveT2, P1);
                    }
                    else
                    {
                        Attack(P2, moveT2, P1);
                        Thread.Sleep(500);
                        if (P1.IsFainted())
                        {
                            CheckFainted();
                            break;
                        }
                        Attack(P1, moveT1, P2);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }
        }

        //attack (A attacks B)
        public void Attack(Pokemon A, int m, Pokemon B)
        {
            //which move is it?
            Move move = null;
            if (m == 1 && A.GetMove1() != null)
                move = A.GetMove1();
            else if (m == 2 && A.GetMove2() != null)
                move = A.GetMove2();
            else if (m == 3 && A.GetMove3() != null)
                move = A.GetMove3();
            else if (m == 4 && A.GetMove4() != null)
                move = A.GetMove4();
            else
            {
                Console.WriteLine("Invalid Move entered for " + A.GetName() + ", Defaulting to Move1");
                move = A.GetMove1();
            }

            Thread.Sleep(500);

            //calculate modifiers
            double modifier = 1;//targets*weather*crit*random(85%-100%)*stab*type(effectiveness)*burn*other
            if (A.GetStatus() == 1 && move.GetMoveCategory()==1)/*burn and physical move = 1/2 dmg*/
            {
                modifier *= 0.5;
            }
            double effectiveness = move.GetType().GetDamageModifier(B.GetType());
            Console.WriteLine(move.GetType());
            Console.WriteLine(B.GetType());

            modifier *= effectiveness;

            //if attacker is paralyzed, might not move (25% chance)
            if (A.GetStatus() == 2)
            {
                Random random = new Random();
                int randomNum = random.Next(0, 100);
                if (randomNum<25)
                {
                    PrintToTextBox(A.GetName() + "is Paralyzed! It can't move!");
                    return;
                }
            }


            //Does the move hit? or Miss? P = M x A x (1-E)

            if (move.GetAccuracy() < 0)
            {
                Console.WriteLine("This Atk never misses, skipping accuracy calc");
            }
            else
            { //moves with -1 accuracy will always hit and are exempt from this calculation
                double moveHitChance = (move.GetAccuracy() * A.GetAccuracy() * (1 - B.GetEvasion()) / 100.0);
                Random random = new Random();
                int randomNumber = random.Next(0, 100);
                Console.WriteLine("Chance for atk to hit = " + moveHitChance + "%, randomNum = " + randomNumber);
                if (randomNumber < moveHitChance)//atk hits
                {
                    Console.WriteLine("Atk hits!");
                }
                else
                {
                    Console.WriteLine("Atk Misses!");
                    PrintToTextBox(A.GetName() + "'s attack missed!");
                    return;
                }
            }

            //calculate damage
            double damage = 0;
            if (move.GetMoveCategory() == 1)
            {//physical
                Console.WriteLine("Level: " + A.GetLevel());
                Console.WriteLine("Atk: " + A.GetAtk());
                Console.WriteLine("B def: " + B.GetDef());
                Console.WriteLine("move dmg: " + move.GetDamage());

                damage = ((((((2 * (double)A.GetLevel()) / 5) + 2) * (move.GetDamage()) * ((double)A.GetAtk() / (double)B.GetDef())) / 50) + 2) * modifier;
            }
            if (move.GetMoveCategory() == 2)
            {//special
                Console.WriteLine("Level: " + A.GetLevel());
                Console.WriteLine("Atk: " + A.GetSpAtk());
                Console.WriteLine("B def: " + B.GetSpDef());
                damage = ((((((2 * (double)A.GetLevel()) / 5) + 2) * (move.GetDamage()) * ((double)A.GetSpAtk() / (double)B.GetSpDef())) / 50) + 2) * modifier;
            }
            Console.WriteLine(move);
            //Console.WriteLine(A.GetName() + " used " + move.GetName() + "!");
            //textboxwords.Text = (A.GetName() + " used " + move.GetName() + "!\n");
            //outputbox.AppendText(A.GetName() + " used " + move.GetName() + "!\n");
            PrintToTextBox(A.GetName() + " used " + move.GetName() + "!");
            if (effectiveness == 0 && move.GetMoveCategory() != 3)
                PrintToTextBox("It doesn't effect " + P2.GetName() + "\n");
            else if (effectiveness > 1 && move.GetMoveCategory() != 3)
                PrintToTextBox("It's super effective!\n");
            else if (effectiveness < 1 && move.GetMoveCategory() != 3)
                PrintToTextBox("It's not very effective...\n");

            Console.WriteLine("eff: " + effectiveness);
            Console.WriteLine("MOD: " + modifier);
            Console.WriteLine("Did " + damage + " damage");
            outputbox.AppendText("Did " + damage + " damage" + "!\n");

            B.SetRemainingHp(B.GetRemainingHp() - (int)damage);
            Refresh();
        }


        private void UpdateButtons()
        {
            List<Control> list = new List<Control>();
            ArrayList buttons = new ArrayList();

            GetAllControl(this, list);

            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Button))
                {
                    buttons.Add((Button)control);
                }
            }

            for (int i = 0; i < buttons.Count; i++)
            {
                Button b = (Button)buttons[i];
                switch (i)
                {
                    case 0:
                        b.Text = P1.GetMove4().GetName();
                        break;
                    case 1:
                        b.Text = P1.GetMove2().GetName();
                        break;
                    case 2:
                        b.Text = P1.GetMove3().GetName();
                        break;
                    case 3:
                        b.Text = P1.GetMove1().GetName();
                        break;
                }
            }
        }


        private void GetAllControl(Control c, List<Control> list)
        {
            foreach (Control control in c.Controls)
            {
                list.Add(control);

                if (control.GetType() == typeof(Panel))
                    GetAllControl(control, list);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveT1 = 1;
            DoTurn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveT1 = 2;
            DoTurn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveT1 = 3;
            DoTurn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveT1 = 4;
            DoTurn();
        }

        private void DoTurn()
        {
            outputbox.AppendText("-----TURN " + turn + "-----\n");
            ProcessChoice();
            CheckFainted();
            //update GUI
            Refresh();
            PrintToTextBox("What will " + P1.GetName() + " do?");
            turn++;
        }

        //bag
        void Bag(Trainer x)
        {
            Console.WriteLine(x.GetName() + " opened their bag... thats it lmao");
        }

        private void outputbox_TextChanged(object sender, EventArgs e)
        {
            //automatically scrolls to the bottom
            outputbox.SelectionStart = outputbox.Text.Length;
            outputbox.ScrollToCaret();
        }

        //loops through the party in ascending order until it finds a valid pokemon to switch to
        int findValidSwitch(Trainer x, int y)
        {
            int swap = y;
            while (x.GetPartyAt(swap).IsFainted() && !x.IsBlackedOut())
            {
                if (swap < 5)
                    swap++;
                else
                    swap = 0;
                Console.WriteLine("Checking to swap to: " + x.GetPartyAt(swap).GetName() + " Remaining HP: " + x.GetPartyAt(swap).GetRemainingHp());
                if (!x.GetPartyAt(swap).IsFainted())
                    break;
            }
            return swap;
        }

        //switch
        void SwitchPoke(Trainer x, int y)
        {   //if y > 5 exit, there are only 6 pokemon on a team
            if (y > 5)
            {
                throw new Exception("Tried to switch to a pokemon that doesn't exist (array out of bounds, >5)");
            }
            if (x == T1)
            {
                //reset appropriate stats of poke that fainted/switched out
                P1.ResetStageMultipliers();
                P1.SetAccuracy(100);
                P1.SetEvasion(0);
                //find new pokemon to switch in
                P1 = T1.GetPartyAt(y);
                PrintToTextBox(T1.GetName() + ": Go! " + P1.GetName() + "!\n");
                UpdateButtons();
            }
            if (x == T2)
            {
                //reset appropriate stats of poke that fainted/switched out
                P2.ResetStageMultipliers();
                P1.SetAccuracy(100);
                P1.SetEvasion(0);
                //find new pokemon to switch in
                P2 = T2.GetPartyAt(y);
                PrintToTextBox(T2.GetName() + ": Go! " + P2.GetName() + "!\n");
            }
        }

        //run
        void Run(Trainer x)
        {//for the wild method
            Console.WriteLine("Run?");
        }

        public void GetInput()
        {
            Console.WriteLine("waiting for user input...");

            //outputbox.Text = P1 + "\r\n" + P1.HpString() + "\r\n" + P2 + "\r\n" + P2.HpString();


            //for now
            choiceT1 = 4;
            choiceT2 = 4; //make them both attack

            //MoveChoiceForm c = new MoveChoiceForm(P1);
            //var result= c.ShowDialog();
            //if (result== DialogResult.OK)
            //{
            //    moveT1=c.GetChoice();   // public property on your form of the result selected
            //}

            Console.WriteLine("CHOICET1=" + choiceT1);
            moveT2 = 3; //for testing
        }

        //for printing to the main text box, with delay
        public void PrintToTextBox(string text)
        {
            textboxwords.Text = (text);
            Thread.Sleep(1000);
            Console.WriteLine(text);
            outputbox.AppendText(text);
        }

        private void BreakinToolStripMenuItem_Click(object sender, EventArgs e) //menu item to open the break-in panel
        {
            new BreakInPanel(T1,T2).Show();
        }
    }
}