using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    public class Card
    {
        private String imageLoc;
        private String name;
        private String effect;

        public Card(String n, String i)
        {
            name = n;
            imageLoc = i;
        }

        public string GetImageLoc()
        {
            return imageLoc;
        }
        public String GetName()
        {
            return name;
        }
    }
}
