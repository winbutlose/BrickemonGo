//Matthew Silbermann Shea Luskey Ryan Maurer 7/28/17
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
    public partial class Battle : Form
    {
        private Trainer T1, T2;
        private Pokemon P1, P2;

        public Battle(Trainer a, Trainer b)
        {
            T1 = a;
            T2 = b;
            P1 = T1.GetPartyAt(0);
            P2 = T2.GetPartyAt(0);
            //InitializeComponent();
            //CreateBattle();
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
            PictureBoxUserPoke.ImageLocation = (@"res/sprites/sugimori/6.png");
            PictureBoxUserPoke.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxOppPoke.ImageLocation = (@"res/sprites/sugimori/9.png");
            PictureBoxOppPoke.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void DoBattle()
        {
            //init battle vars
            int choiceT1, choiceT2;
            int moveT1 = 1, moveT2 = 1;
            Boolean fighting = true;

            //main battle loop
            while (fighting)
            {
                //check fainted
                if (P1.GetRemainingHp() == 0)
                {
                    Console.WriteLine(P1.GetName() + " fainted!");
                    //switch T1
                }
                if (P2.GetRemainingHp() == 0)
                {
                    Console.WriteLine(P2.GetName() + " fainted!");
                    //switch T2
                }

                //*************
                //Get decisions
                //*************
                Console.WriteLine(P1);
                Console.WriteLine(P1.HpString());
                Console.WriteLine("Enter action T1");
                Console.WriteLine("1.) Run, 2.) Bag, 3.) Switch, 4.) Attack");

                choiceT1 = Convert.ToInt32(Console.ReadLine());
                if (choiceT1 < 0 || choiceT1 > 4)
                {
                    Console.WriteLine("Invalid entry. Enter action T1");
                    choiceT1 = Convert.ToInt32(Console.ReadLine());
                }
                //what move u want or what u wanna switch to?
                if (choiceT1 == 4)
                {
                    Console.WriteLine("What move?");
                    moveT1 = Convert.ToInt32(Console.ReadLine());
                }
                if (choiceT1 == 3)
                {
                    Console.WriteLine("Switch to who?");
                    moveT1 = Convert.ToInt32(Console.ReadLine());
                }


                Console.WriteLine(P2);
                Console.WriteLine(P2.HpString());
                Console.WriteLine("Enter action T2");
                choiceT2 = Console.Read();
                if (choiceT2 < 0 || choiceT2 > 4)
                {
                    Console.WriteLine("Invalid entry. Enter action T2");
                    choiceT2 = Convert.ToInt32(Console.ReadLine());
                }
                //what move u want or what u wanna switch to?
                if (choiceT2 == 4)
                {
                    Console.WriteLine("What move?");
                    moveT2 = Convert.ToInt32(Console.ReadLine());
                }
                if (choiceT2 == 3)
                {
                    Console.WriteLine("Switch to who?");
                    moveT2 = Convert.ToInt32(Console.ReadLine());
                }


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
                            Attack(P2, moveT2, P1);
                        }
                        else
                        {
                            Attack(P2, moveT2, P1);
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
        public static void Attack(Pokemon A, int m, Pokemon B)
        {
            //which move is it?
            Move move = null;
            if (m == 1)
            {
                //Console.WriteLine(A.getName()+" used "+A.getMove1().getName()+"!");
                move = A.GetMove1();
                Console.WriteLine(A.GetMove1());
            }
            else if (m == 2)
            {
                //Console.WriteLine(A.getName()+" used "+A.getMove2().getName()+"!");
                move = A.GetMove2();
                Console.WriteLine(A.GetMove2());
            }
            else if (m == 3)
            {
                //Console.WriteLine(A.getName()+" used "+A.getMove3().getName()+"!");
                move = A.GetMove3();
                Console.WriteLine(A.GetMove3());
            }
            else if (m == 4)
            {
                //Console.WriteLine(A.getName()+" used "+A.getMove4().getName()+"!");
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

            B.SetRemainingHp(B.GetRemainingHp() - (int)damage);

        }

        //bag
        void Bag(Trainer x)
        {
            Console.WriteLine(x.GetName() + " opened their bag... thats it lmao");
        }

        private void inputbox_Enter(object sender, EventArgs e)
        {

        }

        //switch
        void SwitchPoke(Trainer x, int y)
        {//if y > 5 this will crash. on purpose. this method shouldnt do the error handling bruh. it doesnt bruh lol 
            if (x == T1)
            {
                P1 = T1.GetPartyAt(y);
                Console.WriteLine(T1.GetName() + ": Go! " + P1.GetName() + "!");
            }
            if (x == T2)
            {
                P2 = T2.GetPartyAt(y);
                Console.WriteLine(T2.GetName() + ": Go! " + P2.GetName() + "!");
            }
        }

        //run
        void Run(Trainer x)
        {//for the wild method

        }
    }
}