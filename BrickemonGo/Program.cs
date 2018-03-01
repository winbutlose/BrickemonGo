//now on github!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickemonGo
{
    static class Program //testing github desktop --thanks! looks like its working!
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Pokemon x = new Pokemon(157, 100);
            //Console.WriteLine(x);
            //x.GiveExp(1000000);
            //Console.WriteLine(x.EstimateLevel());
            //Console.WriteLine("-----------------");
            //Console.WriteLine(x.Data());
            //Application.Run(new Form1(x));
            //Application.Run(new DeckMaker());
            Pokemon pokeA = new Pokemon(6,50);
            Pokemon pokeAA = new Pokemon(484, 50);
            Pokemon[] ATeam = {pokeA,pokeAA};
            Trainer A = new Trainer("player1", ATeam, null, 0, 0);
            Pokemon pokeY = new Pokemon(9,50);
            Pokemon pokeYY = new Pokemon(234, 50);
            Pokemon[] BTeam = {pokeY,pokeYY};
            Trainer B = new Trainer("player2", BTeam, null, 0, 0);
            Application.Run(new Battle(A, B));

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
