//Matthew Silbermann Shea Luskey Ryan Maurer 7/28/17
using System;
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
            PictureBoxUserPoke.ImageLocation = (@"res/sprites/sugimori/" + P1.GetDexNum() + ".png");
            PictureBoxUserPoke.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxOppPoke.ImageLocation = (@"res/sprites/sugimori/" + P2.GetDexNum() + ".png");
            PictureBoxOppPoke.SizeMode = PictureBoxSizeMode.Zoom;
            //hp bars hehe
            SolidBrush brush = new SolidBrush(Color.Black);
            e.Graphics.FillRectangle(brush, 0, 305, P1.GetRemainingHp(), 10);
            e.Graphics.FillRectangle(brush, 900, 305, P2.GetRemainingHp(), 10);

            //buttons

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

            //main battle loop
            //while (fighting)
            {
               


            }
        }

        public void CheckFainted()
        {
            //check fainted
            if (P1.isFainted())
            {
                Console.WriteLine(P1.GetName() + " fainted!");
                textboxwords.Text = (P1.GetName() + " fainted!");
                //switch T1
                SwitchPoke(T1, findValidSwitch(T2, 0));
            }
            if (P2.isFainted())
            {
                Console.WriteLine(P2.GetName() + " fainted!");
                textboxwords.Text = (P2.GetName() + " fainted!");
                //switch T2
                SwitchPoke(T2, findValidSwitch(T2, 0));
            }

            Console.WriteLine(P1 + "\n" + P1.HpString());
            Console.WriteLine(P2 + "\n" + P2.HpString());
            Console.WriteLine("CHECKING WIN CONDITION");
            //check if trainer is blacked out
            if (T1.IsBlackedOut())
            {
                MessageBox.Show(T2.GetName() + " Wins!");
                System.Windows.Forms.Application.Exit();
            }
            if (T2.IsBlackedOut())
            {
                MessageBox.Show(T1.GetName() + " Wins!");
                System.Windows.Forms.Application.Exit();
            }
        }

        public void processChoice()
        {
            //*********
            // DO SHIT
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
                        Attack(P2, moveT2, P1);
                    }
                    else
                    {
                        Attack(P2, moveT2, P1);
                        Thread.Sleep(500);
                        Attack(P1, moveT1, P2);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }
        }




        //attack
        public void Attack(Pokemon A, int m, Pokemon B)
        {
            //which move is it?
            Move move = null;
            if (m == 1)
            {
                textboxwords.Text = (A.GetName() + " used " + A.GetMove1().GetName() + "!\n");
                move = A.GetMove1();
                Console.WriteLine(A.GetMove1());
            }
            else if (m == 2)
            {
                textboxwords.Text = (A.GetName() + " used " + A.GetMove2().GetName() + "!\n");
                move = A.GetMove2();
                Console.WriteLine(A.GetMove2());
            }
            else if (m == 3)
            {
                textboxwords.Text = (A.GetName() + " used " + A.GetMove3().GetName() + "!\n");
                move = A.GetMove3();
                Console.WriteLine(A.GetMove3());
            }
            else if (m == 4)
            {
                textboxwords.Text = (A.GetName() + " used " + A.GetMove4().GetName() + "!\n");
                move = A.GetMove4();
                Console.WriteLine(A.GetMove4());
            }
            else
            {
                Console.WriteLine("Invalid Move entered for " + A.GetName());
                return;
            }
            Thread.Sleep(500);

            //calculate modifiers
            double modifier = 1;//targets*weather*crit*random(85%-100%)*stab*type(effectiveness)*burn*other
            double effectiveness = move.GetType().GetDamageModifier(B.GetType());
            Console.WriteLine(move.GetType());
            Console.WriteLine(B.GetType());

            modifier *= effectiveness;


            //calculate damage
            double damage = 0;
            if (move.GetMoveCategory() == 1)
            {//physical
                Console.WriteLine("Level: " + A.GetLevel());
                Console.WriteLine("Atk: " + A.GetAtk());
                Console.WriteLine("B def: " + B.GetDef());
                Console.WriteLine("move dmg: " + move.GetDamage());

                damage = ((((((2 * (double)A.GetLevel()) / 5) + 2) * (move.GetDamage()) * ((double)A.GetAtk() / (double)B.GetDef())) / 50) + 2) * modifier;
                //936
            }
            if (move.GetMoveCategory() == 2)
            {//special
                Console.WriteLine("Level: " + A.GetLevel());
                Console.WriteLine("Atk: " + A.GetSpAtk());
                Console.WriteLine("B def: " + B.GetSpDef());
                damage = ((((((2 * (double)A.GetLevel()) / 5) + 2) * (move.GetDamage()) * ((double)A.GetSpAtk() / (double)B.GetSpDef())) / 50) + 2) * modifier;
            }
            Console.WriteLine(A.GetName() + " used " + move.GetName() + "!");
            Console.WriteLine("eff: " + effectiveness);
            Console.WriteLine("MOD: " + modifier);
            Console.WriteLine("Did " + damage + " damage");

            B.SetRemainingHp(B.GetRemainingHp() - (int)damage);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveT1 = 1;
            processChoice();
            CheckFainted();
            //update GUI
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveT1 = 2;
            processChoice();
            CheckFainted();
            //update GUI
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveT1 = 3;
            processChoice();
            CheckFainted();
            //update GUI
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveT1 = 4;
            processChoice();
            CheckFainted();
            //update GUI
            Refresh();
        }


        //bag
        void Bag(Trainer x)
        {
            Console.WriteLine(x.GetName() + " opened their bag... thats it lmao");
        }

        //loops through the party in ascending order until it finds a valid pokemon to switch to
        int findValidSwitch(Trainer x, int y)
        {
            int swap = y;
            while (x.GetPartyAt(swap).isFainted() && !x.IsBlackedOut())
            {
                Console.WriteLine(x.GetPartyAt(swap).GetHp());
                if (swap < 5)
                    swap++;
                else
                    swap = 0;
                if (!x.GetPartyAt(swap).isFainted())
                    break;
            }
            return swap;
        }

        //switch
        void SwitchPoke(Trainer x, int y)
        {//if y > 5 this will crash. on purpose. this method shouldnt do the error handling bruh. it doesnt bruh lol 
            if (x == T1)
            {
                P1 = T1.GetPartyAt(y);
                Console.WriteLine(T1.GetName() + ": Go! " + P1.GetName() + "!\n");
                textboxwords.Text = (T1.GetName() + ": Go! " + P1.GetName() + "!\n");
            }
            if (x == T2)
            {
                P2 = T2.GetPartyAt(y);
                Console.WriteLine(T2.GetName() + ": Go! " + P2.GetName() + "!\n");
                textboxwords.Text = (T2.GetName() + ": Go! " + P2.GetName() + "!\n");
            }
        }

        //run
        void Run(Trainer x)
        {//for the wild method

        }

        public void GetInput()
        {
            Console.WriteLine("waiting for user input...");

            outputbox.Text = P1 + "\r\n" + P1.HpString() + "\r\n" + P2 + "\r\n" + P2.HpString();


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
    }
}