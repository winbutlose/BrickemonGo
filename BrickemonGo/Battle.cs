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
            DrawText("Battle! " + P1.GetName() + " vs " + P2.GetName());
            Boolean fighting = true;

            //main battle loop
            while (fighting)
            {
                //update GUI
                Refresh();
                //reset button choices
                choiceT1 = -1;
                choiceT2 = -1;
                moveT1 = -1;
                moveT2 = -1;

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

                if (CheckFainted(P1))
                {
                    DrawText(P1.GetName() + " fainted!");
                    GetSwitchInput();
                }
                if (CheckFainted(P2))
                {
                    DrawText(P2.GetName() + " fainted!");
                    SwitchPoke(T2, 1);
                }

                //*************
                //Get decisions
                //*************
                GetInput();

                //*********
                // DO SHIT
                //*********


                int choices = choiceT1 * 10 + choiceT2;
                //main giant switch statement
                switch (choices)
                {//1:run 2:bag 3:switch 4:atk
                    case 11://both run
                        Console.WriteLine("Both players ended the battle");
                        fighting = false;
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
                            if (CheckFainted(P2))
                            {
                                break;
                            }
                            Attack(P2, moveT2, P1);
                        }
                        else
                        {
                            Attack(P2, moveT2, P1);
                            if (CheckFainted(P1))
                            {
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
        }

        //attack
        public void Attack(Pokemon A, int m, Pokemon B)
        {
            //which move is it?
            Move move = null;
            if (m == 1)
            {
                DrawText(A.GetName() + " used " + A.GetMove1().GetName() + "!");
                move = A.GetMove1();
                Console.WriteLine(A.GetMove1());
            }
            else if (m == 2)
            {
                DrawText(A.GetName() + " used " + A.GetMove2().GetName() + "!");
                move = A.GetMove2();
                Console.WriteLine(A.GetMove2());
            }
            else if (m == 3)
            {
                DrawText(A.GetName() + " used " + A.GetMove3().GetName() + "!");
                move = A.GetMove3();
                Console.WriteLine(A.GetMove3());
            }
            else if (m == 4)
            {
                DrawText(A.GetName() + " used " + A.GetMove4().GetName() + "!");
                move = A.GetMove4();
                Console.WriteLine(A.GetMove4());
            }
            else
            {
                Console.WriteLine("Invalid Move entered for " + A.GetName());
                return;
            }



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

            DrawText(EffString(effectiveness));

            B.SetRemainingHp(B.GetRemainingHp() - (int)damage);
            Refresh();
        }

        //bag
        void Bag(Trainer x)
        {
            Console.WriteLine(x.GetName() + " opened their bag... thats it lmao");
        }



        //switch
        void SwitchPoke(Trainer x, int y)
        {//if y > 5 this will crash. on purpose. this method shouldnt do the error handling bruh. it doesnt bruh lol 
            if (x == T1)
            {
                P1 = T1.GetPartyAt(y);
                Console.WriteLine(T1.GetName() + ": Go! " + P1.GetName() + "!");
                DrawText(T1.GetName() + ": Go! " + P1.GetName() + "!");
            }
            if (x == T2)
            {
                P2 = T2.GetPartyAt(y);
                Console.WriteLine(T2.GetName() + ": Go! " + P2.GetName() + "!");
                DrawText(T2.GetName() + ": Go! " + P2.GetName() + "!");
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

            MoveChoiceForm c = new MoveChoiceForm(P1);
            var result = c.ShowDialog();
            if (result == DialogResult.OK)
            {
                moveT1 = c.GetChoice(); 
            }
            Console.WriteLine("CHOICET1=" + choiceT1);
            Random random = new Random();
            moveT2 = random.Next(1, 5);//for testing we make T2 pick random move btwn 1 and 4
        }

        //when you gotta switch pokemon we use this
        public void GetSwitchInput()
        {
            Console.WriteLine("waiting for user input...");
            SwitchChoiceForm c = new SwitchChoiceForm(T1);
            var result = c.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.WriteLine(c.GetChoice());
                SwitchPoke(T1,c.GetChoice());
            }
        }

        //--------------//
        //HELPER METHODS//
        //--------------//

        //draw text writes text letter by letter like pokemon games do in their textboxes and makes it pretty
        public void DrawText(String append)
        {
            textboxwords.Clear();
            foreach (char x in append)
            {
                textboxwords.AppendText("" + x);
                Thread.Sleep(20);
            }
            Thread.Sleep(500);
        }

        //returns string to print based on effectiveness of attack
        public String EffString(double e)
        {
            String str = "";
            switch (e)
            {
                case 0.25:
                    str = "It's barely effective...";
                    break;
                case 0.5:
                    str = "It's not very effective...";
                    break;
                case 1:
                    //do nothing cause 1 is normally effective
                    break;
                case 2:
                    str = "It's super effective!";
                    break;
                case 4:
                    str = "It's ultra effective!!";
                    break;
                default:
                    Console.WriteLine("ERROR IN EFFSTRING");
                    break;
            }
            return str;
        }

        //checks if a pokemon is fainted so we can make the trainer switch to another or end the game
        public Boolean CheckFainted(Pokemon x)
        {
            if (x.GetRemainingHp() == 0)
            {
                return true;
            }
            return false;
        }
    }
}