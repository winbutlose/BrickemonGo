using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class Pack
    {
        private String imageLoc;
        private String name;
        private Card[] cards;//PACKS NEED TO KNOW WHICH CARDS ARE A PART OF THEIR "SET" I HAVENT IMPLEMENTED THIS YET :)

        public Pack(String n, String i)
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
