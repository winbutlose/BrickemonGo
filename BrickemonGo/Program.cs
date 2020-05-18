using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickemonGo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //Utils.ReadPokemonJson();
            Utils.ReadMoveJson();

            Utils.InitTypeChart();
            //Utils.printTypeChart();
            Random rand = new Random();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);  
            //Pokemon x = new Pokemon(384, 100);
            //Console.WriteLine(x);
            //x.GiveExp(1000000);
            //Console.WriteLine(x.EstimateLevel());
            //Console.WriteLine("-----------------");
            //Console.WriteLine(x.Data());
            //Application.Run(new Form1(x));
            //Application.Run(new DeckMaker());    
            //Pokemon pokeA = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeA = new Pokemon(26,100);
            pokeA.SetMove1(new Move(86));
            Pokemon pokeA2 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeA3 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeA4 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeA5 = new  Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeA6 = new  Pokemon(rand.Next(1, 721), 100);
            Pokemon[] ATeam = { pokeA, pokeA2, pokeA3, pokeA4, pokeA5, pokeA6 };

            foreach (Pokemon poke in ATeam)
            {
                Console.WriteLine(poke.Data());
            }



            Trainer A = new Trainer("player1", ATeam, null, 0, 0);
            //Pokemon pokeB = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeB = new Pokemon(129,100);
            Pokemon pokeB2 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeB3 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeB4 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeB5 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon pokeB6 = new Pokemon(rand.Next(1, 721), 100);
            Pokemon[] BTeam = { pokeB, pokeB2, pokeB3, pokeB4, pokeB5, pokeB6 };
            Trainer B = new Trainer("player2", BTeam, null, 0, 0);

            //Application.Run(new BreakInPanel(A,B));

            //Application.Run(new Battle(A, B));

            ////test all mega formes
            //int[] megatest = { 3, 6, 9, 65, 94, 115, 127, 130, 142, 150, 181, 212, 214, 229, 248, 257, 282, 303, 306, 308, 310, 354, 359, 445, 448, 460, 15, 18, 80, 208, 254, 260, 302, 319, 323, 334, 362, 373, 376, 380, 381, 382, 383, 384, 428, 475, 531, 719 };
            //String data = "";
            //for (int i = 0; i < megatest.Length; i++)
            //{
            //    Pokemon y = new Pokemon(megatest[i], 100);
            //    data += (y.Data() + "\n");
            //    data += ("<--------------------------------------------------------------------------->\n");
            //}
            //using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(@"res/megatestdata.txt"))
            //{
            //    file.WriteLine(data);
            //}



        }
    }
}
