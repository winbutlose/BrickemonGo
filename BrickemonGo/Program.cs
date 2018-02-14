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
            Pokemon x = new Pokemon(248,100);
            Console.WriteLine(x);
            x.GiveExp(1000000);
            Console.WriteLine(x.EstimateLevel());
            Console.WriteLine("-----------------");
            Console.WriteLine(x.Data());
            //Application.Run(new Form1(x));
            //Application.Run(new DeckMaker());
        }
    }
}
