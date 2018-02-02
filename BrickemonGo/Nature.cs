using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    class Nature
    {
            private String name; //name of the nature
            private int id; //ID of the nature (will be ordered alphabetically)
            private int boostedStat; //stat the nature boosts (list of ints, 1 - ATK, 2 - DEF, 3 - SPATK, 4 - SPDEF, 5 - SPEED)
            private int reducedStat; //stat the nature reduces (list of ints, 1 - ATK, 2 - DEF, 3 - SPATK, 4 - SPDEF, 5 - SPEED)

            public Nature()
            {
                GenerateNature();
            }

            //GETTERS AND SETTERS
            //NAME
            public String GetName()
            {
                return this.name;
            }
            public int GetId()
            {
                return this.id;
            }
            public void SetName(String n)
            {
                this.name = n;
            }
            public int GetBoostedStat()
            {
                return this.boostedStat;
            }
            public int GetReducedStat()
            {
                return this.boostedStat;
            }

            public void GenerateNature()
            {
                //the randomly generated nature (from 1 to 25)
                Random random = new Random();
                id = random.Next(1, 26);
                //this.id = (int)(Math.random() * ((25 - 1) + 1) + 1);

                switch (this.id)
                {
                    case 1:
                        this.SetName("Adamant");
                        this.boostedStat = 1;
                        this.reducedStat = 3;
                        break;
                    case 2:
                        this.SetName("Bashful");
                        this.boostedStat = 0;
                        this.reducedStat = 0;
                        break;
                    case 3:
                        this.SetName("Bold");
                        this.boostedStat = 2;
                        this.reducedStat = 1;
                        break;
                    case 4:
                        this.SetName("Brave");
                        this.boostedStat = 1;
                        this.reducedStat = 5;
                        break;
                    case 5:
                        this.SetName("Calm");
                        this.boostedStat = 4;
                        this.reducedStat = 1;
                        break;
                    case 6:
                        this.SetName("Careful");
                        this.boostedStat = 4;
                        this.reducedStat = 3;
                        break;
                    case 7:
                        this.SetName("Docile");
                        this.boostedStat = 0;
                        this.reducedStat = 0;
                        break;
                    case 8:
                        this.SetName("Gentle");
                        this.boostedStat = 4;
                        this.reducedStat = 2;
                        break;
                    case 9:
                        this.SetName("Hardy");
                        this.boostedStat = 0;
                        this.reducedStat = 0;
                        break;
                    case 10:
                        this.SetName("Hasty");
                        this.boostedStat = 5;
                        this.reducedStat = 2;
                        break;
                    case 11:
                        this.SetName("Impish");
                        this.boostedStat = 2;
                        this.reducedStat = 3;
                        break;
                    case 12:
                        this.SetName("Jolly");
                        this.boostedStat = 5;
                        this.reducedStat = 3;
                        break;
                    case 13:
                        this.SetName("Lax");
                        this.boostedStat = 2;
                        this.reducedStat = 4;
                        break;
                    case 14:
                        this.SetName("Lonely");
                        this.boostedStat = 1;
                        this.reducedStat = 2;
                        break;
                    case 15:
                        this.SetName("Mild");
                        this.boostedStat = 3;
                        this.reducedStat = 2;
                        break;
                    case 16:
                        this.SetName("Modest");
                        this.boostedStat = 3;
                        this.reducedStat = 1;
                        break;
                    case 17:
                        this.SetName("Naive");
                        this.boostedStat = 5;
                        this.reducedStat = 4;
                        break;
                    case 18:
                        this.SetName("Naughty");
                        this.boostedStat = 1;
                        this.reducedStat = 4;
                        break;
                    case 19:
                        this.SetName("Quiet");
                        this.boostedStat = 3;
                        this.reducedStat = 5;
                        break;
                    case 20:
                        this.SetName("Quirky");
                        this.boostedStat = 0;
                        this.reducedStat = 0;
                        break;
                    case 21:
                        this.SetName("Rash");
                        this.boostedStat = 3;
                        this.reducedStat = 4;
                        break;
                    case 22:
                        this.SetName("Relaxed");
                        this.boostedStat = 2;
                        this.reducedStat = 5;
                        break;
                    case 23:
                        this.SetName("Sassy");
                        this.boostedStat = 4;
                        this.reducedStat = 5;
                        break;
                    case 24:
                        this.SetName("Serious");
                        this.boostedStat = 0;
                        this.reducedStat = 0;
                        break;
                    case 25:
                        this.SetName("Timid");
                        this.boostedStat = 5;
                        this.reducedStat = 1;
                        break;
                }
            }

            public String ModifiedStatString()
            {
                String boosted = "";
                String reduced = "";

                switch (boostedStat)
                {
                    case 1:
                        boosted = "Attack";
                        break;
                    case 2:
                        boosted = "Defence";
                        break;
                    case 3:
                        boosted = "Sp. Attack";
                        break;
                    case 4:
                        boosted = "Sp. Defence";
                        break;
                    case 5:
                        boosted = "Speed";
                        break;
                }

                switch (reducedStat)
                {
                    case 1:
                        reduced = "Attack";
                        break;
                    case 2:
                        reduced = "Defence";
                        break;
                    case 3:
                        reduced = "Sp. Attack";
                        break;
                    case 4:
                        reduced = "Sp. Defence";
                        break;
                    case 5:
                        reduced = "Speed";
                        break;
                }

                return "+" + boosted + ", -" + reduced;
            }

            public override String ToString()
            {
                return "id:" + this.id + "|" + this.name + ": " + ModifiedStatString();
            }
    }

}
