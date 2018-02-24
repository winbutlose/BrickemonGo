//now on github!
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
            Application.Run(new Battle());

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
