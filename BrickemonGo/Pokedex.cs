using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class Pokedex
    {
        private Dictionary<string, PokemonJSON> pokemonDex = Utils.ReadPokemonJSON();
        private Dictionary<string, MoveJSON> moveDex = Utils.ReadMoveJSON();
        private Dictionary<string, LearnsetJSON> learnsetDex = Utils.ReadLearnsetJSON();

        public Pokedex()
        {
           // Console.WriteLine(pokemonDex["typhlosion"].Types[1]);
        }

        public string GetName(string name)
        {
            return pokemonDex[name].Name;
        }

        public int GetNum(string name)
        {
            return pokemonDex[name].Num;
        }

        public Type GetType(string name)
        {
            Type t = new Type();
            if (pokemonDex[name].Types.Count == 1)
            {
                string type1 = pokemonDex[name].Types[0];
                t = new Type(type1.ToUpper());
            }
            else if (pokemonDex[name].Types.Count == 2)
            {
                string type1 = pokemonDex[name].Types[0];
                string type2 = pokemonDex[name].Types[1];
                t = new Type(type1.ToUpper(),type2.ToUpper());
            }
            else
            {
                throw new Exception("Pokedex.cs:GetType(): Pokemon has something other than 2 types... ?");
            }
            return t;
        }

        public int[] GetBaseStats(string name)
        {
            int[] stats = new int[6];
            stats[0] = pokemonDex[name].Basestats["hp"];
            stats[1] = pokemonDex[name].Basestats["atk"];
            stats[2] = pokemonDex[name].Basestats["def"];
            stats[3] = pokemonDex[name].Basestats["spa"];
            stats[4] = pokemonDex[name].Basestats["spd"];
            stats[5] = pokemonDex[name].Basestats["spe"];
            return stats;
        }

        public List<string> GetAbilities(string name)
        {
            List<string> abils = new List<string>();
            if (pokemonDex[name].Types.Count == 1)
            {
                abils.Add(pokemonDex[name].Abilities["0"]);
            }
            else if (pokemonDex[name].Types.Count == 2)
            {
                abils.Add(pokemonDex[name].Abilities["0"]);
                abils.Add(pokemonDex[name].Abilities["H"]);
            }
            else if (pokemonDex[name].Types.Count == 3)
            {
                abils.Add(pokemonDex[name].Abilities["0"]);
                abils.Add(pokemonDex[name].Abilities["1"]);
                abils.Add(pokemonDex[name].Abilities["H"]);
            }
            else
            {
                throw new Exception("Pokedex.cs:GetAbilities(): Pokemon has an unanticipated number of abilities ");
            }

             return abils;
        }

        public string[] GetOtherFormes(string name)
        {
            if (pokemonDex[name].OtherFormes != null)
            {
                return pokemonDex[name].OtherFormes.ToArray();
            }
            return new string[0];
        }

        public string GetPrevo(string name)
        {
            if (pokemonDex[name].Prevo!=null)
            {
                return pokemonDex[name].Prevo;
            }
            return null;
        }
        public string[] GetEvos(string name)
        {
            if (pokemonDex[name].Evos != null)
            {
                return pokemonDex[name].Evos.ToArray();
            }
            return new string[0];
        }
    }
}
