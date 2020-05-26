using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class LearnsetJSON
    {
        private string name;
        private Dictionary<string, List<string>> learnset;

        public string Name { get => name; set => name = value; }
        public Dictionary<string, List<string>> Learnset { get => learnset; set => learnset = value; }
    }
}
