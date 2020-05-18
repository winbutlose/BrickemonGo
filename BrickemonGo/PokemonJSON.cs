using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class PokemonJSON
    {
        private String name;
        private int num;
        private double heightm;
        private double weightkg;
        private string color;
        private string prevo;
        private List<string> types;
        private List<string> evos;
        private Dictionary<string, int> basestats;
        private Dictionary<string, string> abilities;
        private string baseForme;
        private string gender;
        private List<string> eggGroups;
        private List<string> otherFormes;
        private List<string> formeOrder;
        private int evoLevel;

        public PokemonJSON()
        {
            //readJSON();
           // Account account = JsonConvert.DeserializeObject<Account>(json);
        }

        public string Name { get => name; set => name = value; }
        public int Num { get => num; set => num = value; }
        public Dictionary<string, int> Basestats { get => basestats; set => basestats = value; }
        public Dictionary<string, string> Abilities { get => abilities; set => abilities = value; }
        public List<string> Types { get => types; set => types = value; }
        public string Gender { get => gender; set => gender = value; }
        public double Heightm { get => heightm; set => heightm = value; }
        public double Weightkg { get => weightkg; set => weightkg = value; }
        public string Color { get => color; set => color = value; }
        public List<string> EggGroups { get => eggGroups; set => eggGroups = value; }
        public List<string> OtherFormes { get => otherFormes; set => otherFormes = value; }
        public List<string> FormeOrder { get => formeOrder; set => formeOrder = value; }
        public string BaseForme { get => baseForme; set => baseForme = value; }
        public List<string> Evos { get => evos; set => evos = value; }
        public string Prevo { get => prevo; set => prevo = value; }
        public int EvoLevel { get => evoLevel; set => evoLevel = value; }

        public static void readJSON()
        {
            //var text = File.ReadAllText(@"res/Pokemon_JSON/jsontest.json");
            
        }
    }
}
