using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BrickemonGo
{
    class Utils
    {
        public static double[,] typeChart = new double[18, 18]; //typing matchups of all pokemon

        public static void InitTypeChart()
        {
            string[] allLines = System.IO.File.ReadAllLines(@"res/typechart.txt");
            String line;
            String[] split;

            for (int y = 0; y < allLines.Length; y++)
            {
                line = allLines[y];
                split = line.Split(',');
                for (int x = 0; x < split.Length; x++)
                {
                    typeChart[x, y] = Double.Parse(split[x]);
                }
            }
        }

        public static void PrintTypeChart()
        {
            for (int y = 0; y < typeChart.GetUpperBound(0); y++)
            {
                for (int x = 0; x < typeChart.GetUpperBound(1); x++)
                {
                    Console.Write(typeChart[x, y] + ",");
                }
                Console.WriteLine();
            }
        }

        public static Dictionary<string, PokemonJSON> ReadPokemonJSON()
        {
            var rawjson = File.ReadAllText(@"res/Pokemon_JSON/pokedex.ts");
            var serializer = new JavaScriptSerializer();
            var pokedex = serializer.Deserialize<Dictionary<string, PokemonJSON>>(rawjson);
            return pokedex;
        }

        public static Dictionary<string, MoveJSON> ReadMoveJSON()
        {
            var rawjson = File.ReadAllText(@"res/Pokemon_JSON/moves.ts");
            var serializer = new JavaScriptSerializer();
            var movedex = serializer.Deserialize<Dictionary<string, MoveJSON>>(rawjson);
            return movedex;
        } //help! the moves "secondary" info isnt being parsed rn probably have to do it ourselves but aye good work! :D
        
        public static Dictionary<string, LearnsetJSON> ReadLearnsetJSON()
        {
            var rawjson = File.ReadAllText(@"res/Pokemon_JSON/learnsets.ts");
            var serializer = new JavaScriptSerializer();
            var learnsetdex = serializer.Deserialize<Dictionary<string, LearnsetJSON>>(rawjson);
            return learnsetdex;
        }
    }
}
 