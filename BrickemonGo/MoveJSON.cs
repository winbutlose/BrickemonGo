using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class MoveJSON
    {
        private int num;
        private string accuracy;
        private int basepower;
        private string category;
        private string desc;
        private string shortDesc;
        private string name;
        private int pp;
        private int priority;
        private Dictionary<string, int> flags;
        //private Dictionary<string, string> secondary;
        //private List<string> secondaries;
        private string target;
        private string type;
        private string contestType;

        public int Num { get => num; set => num = value; }
        public int Basepower { get => basepower; set => basepower = value; }
        public string Category { get => category; set => category = value; }
        public string Desc { get => desc; set => desc = value; }
        public string ShortDesc { get => shortDesc; set => shortDesc = value; }
        public string Name { get => name; set => name = value; }
        public int Pp { get => pp; set => pp = value; }
        public int Priority { get => priority; set => priority = value; }
        public Dictionary<string, int> Flags { get => flags; set => flags = value; }
        public string Target { get => target; set => target = value; }
        public string Type { get => type; set => type = value; }
        public string ContestType { get => contestType; set => contestType = value; }
        public string Accuracy { get => accuracy; set => accuracy = value; }
        //public Dictionary<string, string> Secondary { get => secondary; set => secondary = value; }
       // public List<string> Secondaries { get => secondaries; set => secondaries = value; }
    }
}
