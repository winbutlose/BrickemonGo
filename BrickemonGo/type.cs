using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    public class Type
    {
        private Boolean monotype; //if the pokemon has only 1 type
        private int primaryType; //primary typing of the pokemon
        private int secondaryType; //secondary typing of the pokemon
        private String primaryTypeString; //primary typing of the pokemon in string forme 
        private String secondaryTypeString; //secondary typing of the pokemon in string forme

        //CONSTRUCTORS
        public Type()
        {

        }
        //if you want to just type in what the type is
        public Type(String type)
        {
            this.primaryTypeString = type;
            UpdateTypingToInt();
            CheckMonotype();
        }
        //same as above but for dual types
        public Type(String type1, String type2)
        {
            this.primaryTypeString = type1;
            this.secondaryTypeString = type2;
            UpdateTypingToInt();
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
            UpdateTypingToString();
        }
        //SECONDARY TYPE
        public int GetSecondaryType()
        {
            return this.secondaryType;
        }
        public void SetSecondaryType(int t)
        {
            this.secondaryType = t;
            UpdateTypingToString();
        }
        //PRIMARY TYPE STRING
        public String GetPrimaryTypeString()
        {
            return this.primaryTypeString;
        }
        public void SetPrimaryTypeString(String t)
        {
            this.primaryTypeString = t;
            UpdateTypingToInt();
        }
        //SECONDARY TYPE STRING
        public String GetSecondaryTypeString()
        {
            return this.secondaryTypeString;
        }
        public void SetSecondaryTypeString(String t)
        {
            this.secondaryTypeString = t;
            UpdateTypingToInt();
        }

        public Boolean GetMonotype()
        {
            return this.monotype;
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

        public void UpdateTypingToString()
        {
            switch (primaryType)
            {
                case 1:
                    primaryTypeString = "NORMAL";
                    break;
                case 2:
                    primaryTypeString = "FIRE";
                    break;
                case 3:
                    primaryTypeString = "WATER";
                    break;
                case 4:
                    primaryTypeString = "ELECTRIC";
                    break;
                case 5:
                    primaryTypeString = "GRASS";
                    break;
                case 6:
                    primaryTypeString = "ICE";
                    break;
                case 7:
                    primaryTypeString = "FIGHTING";
                    break;
                case 8:
                    primaryTypeString = "POISON";
                    break;
                case 9:
                    primaryTypeString = "GROUND";
                    break;
                case 10:
                    primaryTypeString = "FLYING";
                    break;
                case 11:
                    primaryTypeString = "PSYCHIC";
                    break;
                case 12:
                    primaryTypeString = "BUG";
                    break;
                case 13:
                    primaryTypeString = "ROCK";
                    break;
                case 14:
                    primaryTypeString = "GHOST";
                    break;
                case 15:
                    primaryTypeString = "DRAGON";
                    break;
                case 16:
                    primaryTypeString = "DARK";
                    break;
                case 17:
                    primaryTypeString = "STEEL";
                    break;
                case 18:
                    primaryTypeString = "FAIRY";
                    break;
            }
            //secondary type
            switch (secondaryType)
            {
                case 1:
                    secondaryTypeString = "NORMAL";
                    break;
                case 2:
                    secondaryTypeString = "FIRE";
                    break;
                case 3:
                    secondaryTypeString = "WATER";
                    break;
                case 4:
                    secondaryTypeString = "ELECTRIC";
                    break;
                case 5:
                    secondaryTypeString = "GRASS";
                    break;
                case 6:
                    secondaryTypeString = "ICE";
                    break;
                case 7:
                    secondaryTypeString = "FIGHTING";
                    break;
                case 8:
                    secondaryTypeString = "POISON";
                    break;
                case 9:
                    secondaryTypeString = "GROUND";
                    break;
                case 10:
                    secondaryTypeString = "FLYING";
                    break;
                case 11:
                    secondaryTypeString = "PSYCHIC";
                    break;
                case 12:
                    secondaryTypeString = "BUG";
                    break;
                case 13:
                    secondaryTypeString = "ROCK";
                    break;
                case 14:
                    secondaryTypeString = "GHOST";
                    break;
                case 15:
                    secondaryTypeString = "DRAGON";
                    break;
                case 16:
                    secondaryTypeString = "DARK";
                    break;
                case 17:
                    secondaryTypeString = "STEEL";
                    break;
                case 18:
                    secondaryTypeString = "FAIRY";
                    break;
            }
            this.CheckMonotype();
        }

        public void UpdateTypingToInt()
        {
            switch (primaryTypeString)
            {
                case "NORMAL":
                    primaryType = 1;
                    break;
                case "FIRE":
                    primaryType = 2;
                    break;
                case "WATER":
                    primaryType = 3;
                    break;
                case "ELECTRIC":
                    primaryType = 4;
                    break;
                case "GRASS":
                    primaryType = 5;
                    break;
                case "ICE":
                    primaryType = 6;
                    break;
                case "FIGHTING":
                    primaryType = 7;
                    break;
                case "POISON":
                    primaryType = 8;
                    break;
                case "GROUND":
                    primaryType = 9;
                    break;
                case "FLYING":
                    primaryType = 10;
                    break;
                case "PSYCHIC":
                    primaryType = 11;
                    break;
                case "BUG":
                    primaryType = 12;
                    break;
                case "ROCK":
                    primaryType = 13;
                    break;
                case "GHOST":
                    primaryType = 14;
                    break;
                case "DRAGON":
                    primaryType = 15;
                    break;
                case "DARK":
                    primaryType = 16;
                    break;
                case "STEEL":
                    primaryType = 17;
                    break;
                case "FAIRY":
                    primaryType = 18;
                    break;
            }

            if (secondaryTypeString != null)
                switch (secondaryTypeString)
                {
                    case "NORMAL":
                        secondaryType = 1;
                        break;
                    case "FIRE":
                        secondaryType = 2;
                        break;
                    case "WATER":
                        secondaryType = 3;
                        break;
                    case "ELECTRIC":
                        secondaryType = 4;
                        break;
                    case "GRASS":
                        secondaryType = 5;
                        break;
                    case "ICE":
                        secondaryType = 6;
                        break;
                    case "FIGHTING":
                        secondaryType = 7;
                        break;
                    case "POISON":
                        secondaryType = 8;
                        break;
                    case "GROUND":
                        secondaryType = 9;
                        break;
                    case "FLYING":
                        secondaryType = 10;
                        break;
                    case "PSYCHIC":
                        secondaryType = 11;
                        break;
                    case "BUG":
                        secondaryType = 12;
                        break;
                    case "ROCK":
                        secondaryType = 13;
                        break;
                    case "GHOST":
                        secondaryType = 14;
                        break;
                    case "DRAGON":
                        secondaryType = 15;
                        break;
                    case "DARK":
                        secondaryType = 16;
                        break;
                    case "STEEL":
                        secondaryType = 17;
                        break;
                    case "FAIRY":
                        secondaryType = 18;
                        break;
                }
            this.CheckMonotype();
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
                    if (t.GetSecondaryType() == 15)
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
                s = primaryTypeString;
            else
                s = primaryTypeString + "," + secondaryTypeString;
            return s;
        }


    }
}
