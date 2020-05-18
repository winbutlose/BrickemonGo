using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    public class Move
    {
        private String name; //the name of the move
        private Type type; //type of the move ie. fire, electric, etc.
        private int moveId; //ID of the move 
        private int effectId; //ID mapping move's secondary effect to a function call
        private int damage; //damage of the move
        private int accuracy; //accuracy of the move
        private int moveCategory; //is the move physical or special or status?
        private String moveCategoryString; //string formal for physical or special or status
        private int pp; //amount of times you can use the move

        public Move()
        {
            this.name = "undefined";
            //this.type = new Type();
            this.moveId = 0;
            this.damage = 0;
            this.accuracy = 0;
            this.moveCategory = 0;
            this.pp = 0;
        }

        //constructor to generate the move based on ID
        public Move(int moveId)
        {
            this.moveId = moveId;
            //this.type = new Type();
            AddMove(moveId);
        }
        //getters and setters
        //NAME
        public String GetName()
        {
            return this.name;
        }
        public void SetName(String name)
        {
            this.name = name;
        }
        //TYPE
        public Type GetType()
        {
            return this.type;
        }
        public void SetType(Type type)
        {
            this.type = type;
        }
        //MOVE ID
        public int GetMoveId()
        {
            return this.moveId;
        }
        public void SetMoveId(int moveId)
        {
            this.moveId = moveId;
        }
        //DAMAGE
        public int GetDamage()
        {
            return this.damage;
        }
        public void SetDamage(int damage)
        {
            this.damage = damage;
        }
        //ACCURACY
        public int GetAccuracy()
        {
            return this.accuracy;
        }
        public void SetAccuracy(int accuracy)
        {
            this.accuracy = accuracy;
        }
        //EFFECT ID
        public int GetEffectId()
        {
            return this.effectId;
        }
        public void SetEffectId(int eff)
        {
            this.effectId = eff;
        }
        //MOVE CATEGORY INT
        public int GetMoveCategory()
        {
            return this.moveCategory;
        }
        public void SetMoveCategory(int moveCategory)
        {
            this.moveCategory = moveCategory;
            MoveCategoryToString();
        }
        //MOVE CATEGORY STRING
        public String GetMoveCategoryString()
        {
            return this.moveCategoryString;
        }
        public void SetMoveCategoryString(String moveCategoryString)
        {
            this.moveCategoryString = moveCategoryString;
            MoveCategoryStringToInt();
        }
        //PP
        public int GetPP()
        {
            return this.pp;
        }
        public void SetPP(int pp)
        {
            this.pp = pp;
        }

        public void MoveCategoryToString()
        {
            switch (moveCategory)
            {
                case 1:
                    this.moveCategoryString = "PHYSICAL";
                    break;
                case 2:
                    this.moveCategoryString = "SPECIAL";
                    break;
                case 3:
                    this.moveCategoryString = "STATUS";
                    break;
                default:
                    return;
            }
        }
        public void MoveCategoryStringToInt()
        {
            switch (moveCategoryString)
            {
                case "PHYSICAL":
                    this.moveCategory = 1;
                    break;
                case "SPECIAL":
                    this.moveCategory = 2;
                    break;
                case "STATUS":
                    this.moveCategory = 3;
                    break;
                default:
                    return;
            }
        }
        //creating a move and adding it to a pokemon
        //needs finishing
        public void AddMove(int id)
        {
            //reading from file
            String moveString = ReadMovesFromFile();
            //splitting it up
            String[] split = moveString.Split(',');
            //assigning correct stats
            this.SetMoveId(int.Parse(split[0]));
            this.SetName(split[1]);
            Type t = new Type(split[2]);
            this.type = t;
            this.SetMoveCategoryString(split[3]);
            this.MoveCategoryStringToInt();
            this.SetPP(int.Parse(split[4]));
            //error checking for -'s in text file
            if (split[5].Equals("-"))
            {
                this.SetDamage(0);
            }
            else
            {
                this.SetDamage(int.Parse(split[5]));
            }
            if (split[6].Equals("-") || split[6].Equals("- "))
                this.SetAccuracy(-1); //these moves never miss and are exempt from accuracy calculations
             else
                 this.SetAccuracy(int.Parse(split[6]));
        }
        
        public String ReadMovesFromFile()
        {
            string[] allmoves = System.IO.File.ReadAllLines(@"res/moves.txt");
            String line = "";
            try
            {
                line = allmoves[this.moveId - 1];
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR AT THIS MOVE:"+ (this.moveId - 1));
                throw ex;
            }
            //Console.WriteLine(line);
            return line;

            //old java code

            //  String line;
            //  try(BufferedReader br = new BufferedReader(new FileReader(textFile))) //reading the file
            //{
            //      int counter = 1;

            //      while ((line = br.readLine()) != null)
            //      {
            //          if (counter == this.moveId)
            //          {
            //              return line;
            //          }
            //          counter++;
            //      }
            //      br.close();
            //  }
            //  return "Move Not Found";
            //  }
        }

        public override String ToString()
        {
            return "[" + this.moveId + " " + this.name + "]";
        }

        //this is like a toString with literally every piece of information a move has, for debugging
        public String Data()
        {
            StringBuilder bob = new StringBuilder();
            bob.Append("|Name: " + this.name + "|");
            bob.Append("\t|Type: " + this.type + "|");
            bob.Append("\t|Category: " + this.moveCategoryString + "|");
            bob.Append("\n|Damage: " + this.damage + "|");
            bob.Append("\t|Accuracy: " + this.accuracy + "|");
            bob.Append("\t|PP: " + this.pp + "|");
            return bob.ToString();

        }

        public void ReadMoveJson()
        {

        }
    }
}
