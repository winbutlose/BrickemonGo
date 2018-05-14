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
            if (primaryType == secondaryType)
            {
                monotype = true;
            }
            else
            {
                monotype = false;
            }
        }

        //checking if this typing is super effective against type T
        //NEEDS FINISHING
        public double GetDamageModifier(Type t)
        {
            double damageModifier = 1.0;
            //NORMAL
            if (this.primaryType == 1)
            {
                if (t.GetPrimaryType() == 13)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 14)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 14)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }
            //FIRE
            if (this.primaryType == 2)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 3)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 6)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 12)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 15)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 2.0;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 3)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 6)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 12)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 2.0;
                }
            }
            //WATER
            if (this.primaryType == 3)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 3)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 9)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 15)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 3)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 9)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 0.5;
                }
            }
            //ELECTRIC
            if (this.primaryType == 4)
            {
                if (t.GetPrimaryType() == 3)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 4)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 9)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 15)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 3)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 4)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 9)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 0.5;
                }
            }
            //GRASS
            if (this.primaryType == 5)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 3)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 4)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 9)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 12)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 15)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 3)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 4)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 9)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 12)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }
            //ICE
            if (this.primaryType == 6)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 3)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 6)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 9)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 15)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 3)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 6)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 9)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }
            //FIGHTING
            if (this.primaryType == 7)
            {
                if (t.GetPrimaryType() == 1)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 6)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 11)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 12)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 14)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 16)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 18)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 1)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 6)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 11)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 12)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 14)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 16)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 18)
                        damageModifier *= 0.5;
                }
            }
            //POISON
            if (this.primaryType == 8)
            {
                if (t.GetPrimaryType() == 5)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 9)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 14)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 18)
                    damageModifier = 2.0;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 9)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 14)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 18)
                        damageModifier *= 2.0;
                }
            }
            //GROUND
            if (this.primaryType == 9)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 4)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 12)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 2.0;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 4)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 12)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 2.0;
                }
            }
            //FLYING
            if (this.primaryType == 10)
            {
                if (t.GetPrimaryType() == 4)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 7)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 12)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 4)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 7)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 12)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }
            //PSYCHIC
            if (this.primaryType == 11)
            {
                if (t.GetPrimaryType() == 7)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 11)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 16)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 7)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 11)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 16)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }
            //BUG
            if (this.primaryType == 12)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 5)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 7)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 11)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 14)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 16)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 18)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 5)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 7)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 11)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 14)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 16)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 18)
                        damageModifier *= 0.5;
                }
            }
            //ROCK
            if (this.primaryType == 13)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 6)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 7)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 9)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 10)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 12)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 6)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 7)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 9)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 10)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 12)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }
            //GHOST
            if (this.primaryType == 14)
            {
                if (t.GetPrimaryType() == 1)
                    damageModifier = 0.0;
                if (t.GetPrimaryType() == 11)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 14)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 16)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 1)
                        damageModifier *= 0.0;
                    if (t.GetSecondaryType() == 11)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 14)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 16)
                        damageModifier *= 0.5;
                }
            }
            //DRAGON
            if (this.primaryType == 15)
            {
                if (t.GetPrimaryType() == 15)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 18)
                    damageModifier = 0.0;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 18)
                        damageModifier *= 0.0;
                }
            }
            //DARK
            if (this.primaryType == 16)
            {
                if (t.GetPrimaryType() == 7)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 11)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 14)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 16)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 18)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 7)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 11)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 14)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 16)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 18)
                        damageModifier *= 0.5;
                }
            }
            //STEEL
            if (this.primaryType == 17)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 3)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 4)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 6)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 13)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 18)
                    damageModifier = 2.0;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 3)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 4)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 6)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 13)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 18)
                        damageModifier *= 2.0;
                }
            }
            //FAIRY
            if (this.primaryType == 18)
            {
                if (t.GetPrimaryType() == 2)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 7)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 8)
                    damageModifier = 0.5;
                if (t.GetPrimaryType() == 15)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 16)
                    damageModifier = 2.0;
                if (t.GetPrimaryType() == 17)
                    damageModifier = 0.5;

                //if it has a secondary type, add calculations.
                if (!t.GetMonotype())
                {
                    if (t.GetSecondaryType() == 2)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 7)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 8)
                        damageModifier *= 0.5;
                    if (t.GetSecondaryType() == 15)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 16)
                        damageModifier *= 2.0;
                    if (t.GetSecondaryType() == 17)
                        damageModifier *= 0.5;
                }
            }

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
