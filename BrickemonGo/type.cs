using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    public class Type
    {
        //public enum types{NULL, NORMAL, FIGHTING, FLYING, POISON, GROUND, ROCK, BUG, GHOST, STEEL, FIRE, WATER, GRASS, ELECTRIC, PSYCHIC, ICE, DRAGON, DARK, FAIRY};
        public enum types{NULL, NORMAL, FIRE, WATER, ELECTRIC, GRASS, ICE, FIGHTING, POISON, GROUND, FLYING, PSYCHIC, BUG, ROCK, GHOST, DRAGON, DARK, STEEL, FAIRY };

        private Boolean monotype; //if the pokemon has only 1 type
        private int primaryType; //primary typing of the pokemon
        private int secondaryType; //secondary typing of the pokemon
        //private String primaryTypeString; //primary typing of the pokemon in string forme 
        //private String secondaryTypeString; //secondary typing of the pokemon in string forme

        //CONSTRUCTORS
        public Type()
        {

        }
        //if you want to just type in what the type is
        public Type(String type)
        {
            primaryType = (int)Enum.Parse(typeof(types), type);
            this.monotype = true;
            //CheckMonotype();
        }
        //same as above but for dual types
        public Type(String type1, String type2)
        {
            primaryType = (int)Enum.Parse(typeof(types), type1);
            secondaryType = (int)Enum.Parse(typeof(types), type2);

            CheckMonotype();
        }

        //getters and setters
        //PRIMARY TYPE
        public int GetPrimaryType()
        {
            return this.primaryType;
        }
        public void SetPrimaryType(int t)
        {
            this.primaryType = t;
        }
        //SECONDARY TYPE
        public int GetSecondaryType()
        {
            return this.secondaryType;
        }
        public void SetSecondaryType(int t)
        {
            this.secondaryType = t;
        }

        public string getPrimaryTypeAsString()
        {
            return Enum.GetName(typeof(types), primaryType);
        }

        public string getSecondaryTypeAsString()
        {
            return Enum.GetName(typeof(types), secondaryType);
        }

        public Boolean GetMonotype()
        {
            return this.monotype;
        }
        public void SetMonotype(Boolean x)
        {
            this.monotype = x;
        }
        public void CheckMonotype()
        {
            if (primaryType == secondaryType || secondaryType == -1)
                monotype = true;
            else
                monotype = false;
        }

        //checking if this typing is super effective against type T
        //NEEDS FINISHING
        public double GetDamageModifier(Type t)
        {
            double damageModifier = 1.0;

            damageModifier *= Utils.typeChart[t.primaryType-1, this.primaryType-1];
            if(!t.GetMonotype())
                damageModifier *= Utils.typeChart[t.secondaryType - 1, this.primaryType - 1];

            return damageModifier;
        }

        public override String ToString()
        {
            String s = "";
            if (this.monotype)
                s = Enum.GetName(typeof(types), primaryType);
            else
                s = Enum.GetName(typeof(types), primaryType) + "," + Enum.GetName(typeof(types), secondaryType);
            return s;
        }
    }
}
