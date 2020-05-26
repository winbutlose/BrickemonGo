using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class Pokedex
    {
        public Pokedex()
        {
            Dictionary<string, PokemonJSON> pokemonDex = Utils.ReadPokemonJson();
            Dictionary<string, PokemonJSON> moveDex = Utils.ReadPokemonJson();
            Dictionary<string, PokemonJSON> learnsetDex = Utils.ReadPokemonJson();
        }
    }
}
