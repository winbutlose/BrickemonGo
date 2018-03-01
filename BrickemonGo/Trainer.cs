using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    public class Trainer
    {

        private String name;
        private Pokemon[] pokemonParty;
        private List<Pokemon> pokemonStorage;
        private int pokeMoney;
        private int storageSpace;

        //used for making new profiles
        public Trainer()
        {
            this.name = "";
            this.pokemonParty = new Pokemon[6];
            this.pokemonStorage = new List<Pokemon>();
            this.pokeMoney = 0;
            this.storageSpace = 150;
        }

        //will be used for loading save files for trainers.
        public Trainer(String n, Pokemon[] pP, List<Pokemon> pS, int pM, int sS)
        {
            this.name = n;
            this.pokemonParty = pP;
            this.pokemonStorage = pS;
            this.pokeMoney = pM;
            this.storageSpace = sS;
        }

        //GETTERS AND SETTERS
        public String GetName()
        {
            return this.name;
        }
        public void SetName(String n)
        {
            if (n.ToLower().Contains("fuck") || n.ToLower().Contains("shit") || n.ToLower().Contains("bitch") || n.ToLower().Contains("nigger") || n.ToLower().Contains("cunt") ||
               n.ToLower().Contains("ass") || n.ToLower().Contains("nigga"))
            {
                this.name = n;
            }
        }

        public Pokemon[] GetPokemonParty()
        {
            return this.pokemonParty;
        }

        public List<Pokemon> GetPokemonStorage()
        {
            return this.pokemonStorage;
        }

        public int GetPokeMoney()
        {
            return this.pokeMoney;
        }
        public void SetPokeMoney(int pM)
        {
            this.pokeMoney = pM;
        }

        //returns pokemon at specific location in party.
        public Pokemon GetPartyAt(int slotNum)
        {
            return this.pokemonParty[slotNum];
        }

        //returns pokemon at specific location in storage
        public Pokemon GetStorageAt(int slotNum)
        {
            return this.pokemonStorage.ElementAt(slotNum);
        }

        //adds pokemon to the trainers party
        public void AddPokemonToParty(Pokemon p)
        {
            for (int i = 0; i < this.pokemonParty.Length; i++)
            {
                if (pokemonParty[i] == null)
                {
                    this.pokemonParty[i] = p;
                }
            }
        }

        //swaps pokemon in slot1 and slot2
        public void SwapPokemonInParty(int slot1, int slot2)
        {
            if ((slot1 < 0 || slot1 > 5) || (slot2 < 0 || slot2 > 5))
            {
                Console.WriteLine("Invalid slots, please choose valid slots.");
                return;
            }

            Pokemon temp = pokemonParty[slot1];
            pokemonParty[slot1] = pokemonParty[slot2];
            pokemonParty[slot2] = temp;
        }

        //adds pokemon to the trainers storage
        public void AddPokemonToStorage(Pokemon p)
        {
            if (this.pokemonStorage.Count() < this.storageSpace)
            {
                this.pokemonStorage.Add(p);
            }
            else
            {
                Console.WriteLine("Your storage is full! Buy more storage here --> $10 USD for 100 slots!");
            }
        }

        //checking if the trainer is able to battle still, (if he/she has useable pokemon still)
        public Boolean IsBlackedOut()
        {
            for (int i = 0; i < pokemonParty.Length; i++)
            {
                if (pokemonParty[i].GetRemainingHp() > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

}