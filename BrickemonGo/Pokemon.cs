using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickemonGo
{
    public class Pokemon
    {
        //TEXT FILE WITH ALL POKEMON
        private readonly String textFile = "res/pokemon.txt";
        //MISC
        private String name; //actual name of the pokemon eg. Charizard
        private String nickname; //nickname of the pokemon given by the player
        private String gender; //gender of the pokemon
        private String OT; //original trainer
        private Nature nature; //nature of the pokemon
        private Boolean shiny; //whether the pokemon is shiny or not
        private Type type; // typing of the pokemon
        //STATS
        private int dexNum; //can also be used as ID for pokemon
        private int baseHp; //base HP of the pokemon
        private int baseAtk; //base Atk of the pokemon
        private int baseDef; //base Def of the pokemon
        private int baseSpAtk; //base SpAtk of the pokemon
        private int baseSpDef; //base SpDef of the pokemon
        private int baseSpeed; //base Speed of the pokemon
        private int hp; //actual HP stat of the pokemon
        private int atk; //actual Atk stat of the pokemon
        private int def; //actual Def stat of the pokemon
        private int spAtk; //actual SpAtk stat of the pokemon
        private int spDef; //actual SpDef stat of the pokemon
        private int speed; //actual Speed stat of the pokemon
        //MOVES
        private Move move1; //move#1 of current pokemon
        private Move move2; //move#2 of current pokemon
        private Move move3; //move#3 of current pokemon
        private Move move4; //move#4 of current pokemon

        //mega pokemon stuff (separate stats for mega pokemon)

        private int hasMega; // does this pokemon have the ability to mega evolve? (0=no 1=single mega 2=two different mega formes)
        private String megaName; //ex: "Mega Charizard X" or "Primal Kyogre"
        private String megaNameY; //ex "Mega Charizard Y" or "Mega Mewtwo Y"
        private Type megaType;
        private Type megaTypeY;


        //mega poke stats
        private int megaBaseHp;
        private int megaBaseAtk;
        private int megaBaseDef;
        private int megaBaseSpAtk;
        private int megaBaseSpDef;
        private int megaBaseSpeed;
        private int megaHp;
        private int megaAtk;
        private int megaDef;
        private int megaSpAtk;
        private int megaSpDef;
        private int megaSpeed;

        //second set of mega poke stats (for pokemon that have 2 mega formes like charizard or mewtwo)
        //this set will be the 2nd/Y forme stats while X will be default
        private int megaBaseHpY;
        private int megaBaseAtkY;
        private int megaBaseDefY;
        private int megaBaseSpAtkY;
        private int megaBaseSpDefY;
        private int megaBaseSpeedY;
        private int megaHpY;
        private int megaAtkY;
        private int megaDefY;
        private int megaSpAtkY;
        private int megaSpDefY;
        private int megaSpeedY;


        private int remainingHp;

        private Dictionary<int, Move> moveset;
        private int lastAddedMoveIndex;

        private int level, exp; //track how much experience this pokemon has gained
        private int hpIV, atkIV, defIV, spaIV, spdIV, speIV; //ivs for calculation of stats
        private int hpEV, atkEV, defEV, spaEV, spdEV, speEV; //evs for calculation of stats
        private int hpEvGiven, atkEvGiven, defEvGiven, spaEvGiven, spdEvGiven, speEvGiven; //sorry idk what to name these lol
                                                                                           //when you defeat this pokemon, these are the IV's YOU will earn. this will have to be in the text file :/

        private int[] expTable;//how much exp a pokemon needs to grow a level
                               //using MEDIUM-FAST curve @ https://bulbapedia.bulbagarden.net/wiki/Experience#Experience_at_each_level 

        //MAIN CONSTRUCTOR
        public Pokemon(int dexNum)
        {
            if (dexNum > 721 || dexNum < 1)
            {
                throw new Exception("INVALID POKEDEX NUMBER");
            }
            this.dexNum = dexNum;
            this.type = new Type();
            this.nature = new Nature();
            this.InitDefaultPokemon(textFile);
            this.nickname = name;
            this.GenerateIvs();
            this.GenerateEvs();
            this.nature = new Nature();
            this.InitExpTable();
            this.SetLevel(1);
            this.CalculateStats();
            this.InitMegaForme();
            this.CalculateMegaStats(hasMega);
            //this.shiny = ((int)(Math.random() *4096+1)==4096) ? true:false; old java code, 1/4096 chance to be shiny on instantiation
            Random random = new Random();
            int shinyint = random.Next(1, 4097);
            if (shinyint == 4096) { shiny = true; }
            this.exp = 0;
            this.GenerateMoveset();
            this.remainingHp = this.hp;
        }

        //constructor for nickname
        public Pokemon(int dexNum, String nickname)
                : this(dexNum)
        {
            this.nickname = nickname;
            CheckNickname();
        }

        //constructor for level (for use with wild pokemon)
        public Pokemon(int dexNum, int lv)
                : this(dexNum)
        {

            this.SetLevel(lv);//ALWAYS USE SETLEVEL PLS, otherwise u gotta do other shit too when u change the level
            this.CalculateStats();
            this.CalculateMegaStats(hasMega);
            this.GenerateMoveset();
            this.remainingHp = this.hp;
        }

        //getters and setters 
        //DEX NUMBER
        public int GetDexNum()
        {
            return this.dexNum;
        }
        //NAME
        public String GetName()
        {
            return this.name;
        }
        public void SetName(String n)
        {
            this.name = n;
        }
        //mega formes
        public int HasMega()
        {
            return this.hasMega;
        }
        public String GetMegaName()
        {
            return this.megaName;
        }
        public String GetMegaNameY()
        {
            return this.megaNameY;
        }
        //real HP
        public int GetRemainingHp()
        {
            if (this.remainingHp < 0)
            {
                return 0;
            }
            return this.remainingHp;
        }
        public void SetRemainingHp(int hp)
        {
            this.remainingHp = hp;
        }
        //HP
        public int GetHp()
        {
            return this.hp;
        }
        public void SetHp(int hp)
        {
            this.hp = hp;
        }
        public void SetMegaHp(int hp)
        {
            this.megaHp = hp;
        }
        public int GetBaseHp()
        {
            return this.baseHp;
        }
        public int GetMegaHp()
        {
            return this.megaHp;
        }
        public int GetMegaBaseHp()
        {
            return this.megaBaseHp;
        }
        public int GetMegaHpY()
        {
            return this.hp;
        }
        public int GetMegaBaseHpY()
        {
            return this.baseHp;
        }
        //ATTACK
        public int GetAtk()
        {
            return this.atk;
        }
        public void SetAtk(int atk)
        {
            this.atk = atk;
        }
        public int GetBaseAtk()
        {
            return this.baseAtk;
        }
        public int GetMegaAtk()
        {
            return this.megaAtk;
        }
        public void SetMegaAtk(int atk)
        {
            this.megaAtk = atk;
        }
        public int GetMegaBaseAtk()
        {
            return this.megaBaseAtk;
        }
        public int GetMegaAtkY()
        {
            return this.megaAtkY;
        }
        public void SetMegaAtkY(int atk)
        {
            this.megaAtkY = atk;
        }
        public int GetMegaBaseAtkY()
        {
            return this.megaBaseAtkY;
        }
        //DEFENSE
        public int GetDef()
        {
            return this.def;
        }
        public void SetDef(int def)
        {
            this.def = def;
        }
        public int GetBaseDef()
        {
            return this.baseDef;
        }
        public int GetMegaDef()
        {
            return this.megaDef;
        }
        public void SetMegaDef(int def)
        {
            this.megaDef = def;
        }
        public int GetMegaBaseDef()
        {
            return this.megaBaseDef;
        }
        public int GetMegaDefY()
        {
            return this.megaDefY;
        }
        public void SetMegaDefY(int def)
        {
            this.megaDefY = def;
        }
        public int GetMegaBaseDefY()
        {
            return this.megaBaseDefY;
        }
        //SPECIAL ATTACK
        public int GetSpAtk()
        {
            return this.spAtk;
        }
        public void SetSpAtk(int spAtk)
        {
            this.spAtk = spAtk;
        }
        public int GetBaseSpAtk()
        {
            return this.baseSpAtk;
        }
        public int GetMegaSpAtk()
        {
            return this.megaSpAtk;
        }
        public void SetMegaSpAtk(int spAtk)
        {
            this.megaSpAtk = spAtk;
        }
        public int GetMegaBaseSpAtk()
        {
            return this.megaBaseSpAtk;
        }
        public int GetMegaSpAtkY()
        {
            return this.megaSpAtkY;
        }
        public void SetMegaSpAtkY(int spAtk)
        {
            this.megaSpAtkY = spAtk;
        }
        public int GetMegaBaseSpAtkY()
        {
            return this.megaBaseSpAtkY;
        }
        //SPECIAL DEFENCE
        public int GetSpDef()
        {
            return this.spDef;
        }
        public void SetSpDef(int spDef)
        {
            this.spDef = spDef;
        }
        public int GetBaseSpDef()
        {
            return this.baseSpDef;
        }
        public int GetMegaSpDef()
        {
            return this.megaSpDef;
        }
        public void SetMegaSpDef(int spDef)
        {
            this.megaSpDef = spDef;
        }
        public int GetMegaBaseSpDef()
        {
            return this.megaBaseSpDef;
        }
        public int GetMegaSpDefY()
        {
            return this.megaSpDefY;
        }
        public void SetMegaSpDefY(int spDef)
        {
            this.megaSpDefY = spDef;
        }
        public int GetMegaBaseSpDefY()
        {
            return this.megaBaseSpDefY;
        }
        //SPEED
        public int GetSpeed()
        {
            return this.speed;
        }
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }
        public int GetBaseSpeed()
        {
            return this.baseSpeed;
        }
        public int GetMegaSpeed()
        {
            return this.megaSpeed;
        }
        public void SetMegaSpeed(int speed)
        {
            this.megaSpeed = speed;
        }
        public int GetMegaBaseSpeed()
        {
            return this.megaBaseSpeed;
        }
        public int GetMegaSpeedY()
        {
            return this.megaSpeedY;
        }
        public void SetMegaSpeedY(int speed)
        {
            this.megaSpeedY = speed;
        }
        public int GetMegaBaseSpeedY()
        {
            return this.megaBaseSpeedY;
        }
        //MOVES
        public Move GetMove1()
        {
            return this.move1;
        }
        public void SetMove1(Move move1)
        {
            this.move1 = move1;
        }
        public Move GetMove2()
        {
            return this.move2;
        }
        public void SetMove2(Move move2)
        {
            this.move2 = move2;
        }
        public Move GetMove3()
        {
            return this.move3;
        }
        public void SetMove3(Move move3)
        {
            this.move3 = move3;
        }
        public Move GetMove4()
        {
            return this.move4;
        }
        public void SetMove4(Move move4)
        {
            this.move4 = move4;
        }
        //entire moveset
        public Dictionary<int, Move> GetMoveset()
        {
            return this.moveset;
        }
        //types
        public Type GetType()
        {
            return type;
        }
        public Type GetMegaType()
        {
            return megaType;
        }
        public Type GetMegaTypeY()
        {
            return megaTypeY;
        }
        //other stuff
        public Boolean GetShiny()
        {
            return shiny;
        }
        public int GetExp()
        {
            return exp;
        }
        public int GetLevel()
        {
            return level;
        }
        //returns true if the pokemon is fained, false if it is alive
        public bool isFainted()
        {
            return remainingHp <= 0;
        }
        //sets level and exp required to be at this level;
        public void SetLevel(int L)
        {
            if (L > 100 || L < 1)
                throw new Exception("INVALID LEVEL");
            this.level = L;
            this.exp = this.expTable[L - 1];
            this.CalculateStats();
        }
        //initialize the exp lookup table for converting level to exp and vice versa
        public void InitExpTable()
        {
            this.expTable = new int[] { 0, 8, 27, 64, 125, 216, 343, 512, 729, 1000, 1331, 1728, 2197, 2744, 3375, 4096, 4913, 5832, 6859, 8000, 9261, 10648, 12167, 13824, 15625, 17576, 19683, 21952, 24389, 27000, 29791, 32768, 35937, 39304, 42875, 46656, 50653, 54872, 59319, 64000, 68921, 74088, 79507, 85184, 91125, 97336, 103823, 110592, 117649, 125000, 132651, 140608, 148877, 157464, 166375, 175616, 185193, 195112, 205379, 216000, 226981, 238328, 250047, 262144, 274625, 287496, 300763, 314432, 328509, 343000, 357911, 373248, 389017, 405224, 421875, 438976, 456533, 474552, 493039, 512000, 531441, 551368, 571787, 592704, 614125, 636056, 658503, 681472, 704969, 729000, 753571, 778688, 804357, 830584, 857375, 884736, 912673, 941192, 970299, 1000000 };
        }

        //give a pokemon some exp :) used when defeating another pokemon and shit
        public void GiveExp(int e)
        {
            this.exp += e;
            if (this.exp > 1000000)
            {
                this.level = 100;
                this.CalculateStats();
                return;//lv 100, no need to increment level. I am gonna keep adding exp to it anyways so if we decide we want more than 100 levels 
            }         //it will be easy to implement
            while (this.exp >= this.expTable[this.level])
            {
                this.level++;
            }
            this.CalculateStats();
        }

        //because its cool, what level would this pokemon be? (>100)
        public int EstimateLevel()
        {
            if (this.level < 100)
                return this.level;
            int L = 100;
            int n = 1000000;
            while (this.exp >= n)
            {
                n = (int)Math.Pow(L, 3);
                L++;
            }
            return L - 2;
        }

        //can be used to filter out nicknames of curse words or invalid ones
        public void CheckNickname()
        {
            if (this.nickname.Equals(""))
            {
                this.nickname = this.name;
            }
            //filter for curse words
            if (nickname.ToLower().Contains("fuck") || nickname.ToLower().Contains("shit") || nickname.ToLower().Contains("bitch") || nickname.ToLower().Contains("nigger") || nickname.ToLower().Contains("cunt") ||
               nickname.ToLower().Contains("ass") || nickname.ToLower().Contains("nigga"))
            {
                nickname = name;
            }
        }

        //generate stats from text file
        public void InitDefaultPokemon(String textFile)
        {
            //reading file
            String line = ReadPokemonFromFile(textFile);
            //splitting it up
            String[] split = line.Split(',');
            //assigning correct stats
            //if its double type
            if (split.Length == 11)
            {
                //first, does it have mega forme?
                this.hasMega = int.Parse(split[10]);
                //dexnum and stats
                this.dexNum = int.Parse(split[0]);
                this.SetName(split[1]);
                this.type.SetPrimaryType(int.Parse(split[2]));
                this.type.SetSecondaryType(int.Parse(split[3]));
                this.baseHp = int.Parse(split[4]);
                this.baseAtk = int.Parse(split[5]);
                this.baseDef = int.Parse(split[6]);
                this.baseSpAtk = int.Parse(split[7]);
                this.baseSpDef = int.Parse(split[8]);
                this.baseSpeed = int.Parse(split[9]);
            }
            //for monotypes
            else
            {
                //first, does it have mega forme?
                this.hasMega = int.Parse(split[9]);
                //dexnum and stats
                this.dexNum = int.Parse(split[0]);
                this.SetName(split[1]);
                this.type.SetPrimaryType(int.Parse(split[2]));
                this.type.SetMonotype(true);
                this.baseHp = int.Parse(split[3]);
                this.baseAtk = int.Parse(split[4]);
                this.baseDef = int.Parse(split[5]);
                this.baseSpAtk = int.Parse(split[6]);
                this.baseSpDef = int.Parse(split[7]);
                this.baseSpeed = int.Parse(split[8]);
            }
        }

        //function for reading file and getting correct line.
        public String ReadPokemonFromFile(String textFile)
        {
            string[] allpokes = System.IO.File.ReadAllLines(@"res/pokemon.txt");
            String line = allpokes[dexNum - 1];
            Console.WriteLine(line);
            return line;
        }

        //generate mega evolution stats / other formes stats?
        public void InitMegaForme()
        {
            //reads in mega stats and other stuff necesscary to have mega evolution
            string[] allpokes = System.IO.File.ReadAllLines(@"res/pokemon-mega.txt");
            for (int i = 0; i < allpokes.Length; i++)
            {

                String line = allpokes[i];
                if (hasMega == 2)  //2 mega formes means x and y forme
                {
                    if (line.Substring(0, line.IndexOf(",")).Equals(this.name.ToLower() + "megax"))
                    {
                        //found mega forme for this pokemon 
                        String[] split = line.Split(',');
                        //types and name
                        this.megaType = new Type();
                        this.megaName = split[0];

                        if (split.Length == 9)
                        {
                            this.megaType.SetPrimaryType(int.Parse(split[1]));
                            this.megaType.SetSecondaryType(int.Parse(split[2]));
                            this.megaBaseHp = int.Parse(split[3]);
                            this.megaBaseAtk = int.Parse(split[4]);
                            this.megaBaseDef = int.Parse(split[5]);
                            this.megaBaseSpAtk = int.Parse(split[6]);
                            this.megaBaseSpDef = int.Parse(split[7]);
                            this.megaBaseSpeed = int.Parse(split[8]);
                        }
                        else if (split.Length == 8)//monotype
                        {
                            this.megaType.SetPrimaryType(int.Parse(split[1]));
                            this.megaType.SetMonotype(true);
                            this.megaBaseHp = int.Parse(split[2]);
                            this.megaBaseAtk = int.Parse(split[3]);
                            this.megaBaseDef = int.Parse(split[4]);
                            this.megaBaseSpAtk = int.Parse(split[5]);
                            this.megaBaseSpDef = int.Parse(split[6]);
                            this.megaBaseSpeed = int.Parse(split[7]);
                        }
                    }
                    if (line.Substring(0, line.IndexOf(",")).Equals(this.name.ToLower() + "megay"))
                    {
                        //found mega forme for this pokemon !!USING second set of mega poke stats!!
                        String[] split = line.Split(',');
                        //types and name
                        this.megaTypeY = new Type();
                        this.megaNameY = split[0];

                        if (split.Length == 9)
                        {
                            this.megaTypeY.SetPrimaryType(int.Parse(split[1]));
                            this.megaTypeY.SetSecondaryType(int.Parse(split[2]));
                            this.megaBaseHpY = int.Parse(split[3]);
                            this.megaBaseAtkY = int.Parse(split[4]);
                            this.megaBaseDefY = int.Parse(split[5]);
                            this.megaBaseSpAtkY = int.Parse(split[6]);
                            this.megaBaseSpDefY = int.Parse(split[7]);
                            this.megaBaseSpeedY = int.Parse(split[8]);
                        }
                        else if (split.Length == 8)//monotype
                        {
                            this.megaTypeY.SetPrimaryType(int.Parse(split[1]));
                            this.megaTypeY.SetMonotype(true);
                            this.megaBaseHpY = int.Parse(split[2]);
                            this.megaBaseAtkY = int.Parse(split[3]);
                            this.megaBaseDefY = int.Parse(split[4]);
                            this.megaBaseSpAtkY = int.Parse(split[5]);
                            this.megaBaseSpDefY = int.Parse(split[6]);
                            this.megaBaseSpeedY = int.Parse(split[7]);
                        }
                    }
                }
                //case for pkmn with 1 mega forme
                else if (line.Substring(0, line.IndexOf(",")).Equals(this.name.ToLower() + "mega") || line.Substring(0, line.IndexOf(",")).Equals(this.name.ToLower() + "primal"))
                {
                    //found mega forme for this pokemon 
                    String[] split = line.Split(',');
                    //types and name
                    this.megaType = new Type();
                    this.megaName = split[0];

                    if (split.Length == 9)
                    {
                        this.megaType.SetPrimaryType(int.Parse(split[1]));
                        this.megaType.SetSecondaryType(int.Parse(split[2]));
                        this.megaBaseHp = int.Parse(split[3]);
                        this.megaBaseAtk = int.Parse(split[4]);
                        this.megaBaseDef = int.Parse(split[5]);
                        this.megaBaseSpAtk = int.Parse(split[6]);
                        this.megaBaseSpDef = int.Parse(split[7]);
                        this.megaBaseSpeed = int.Parse(split[8]);
                    }
                    else if (split.Length == 8)//monotype
                    {
                        this.megaType.SetPrimaryType(int.Parse(split[1]));
                        this.megaType.SetMonotype(true);
                        this.megaBaseHp = int.Parse(split[2]);
                        this.megaBaseAtk = int.Parse(split[3]);
                        this.megaBaseDef = int.Parse(split[4]);
                        this.megaBaseSpAtk = int.Parse(split[5]);
                        this.megaBaseSpDef = int.Parse(split[6]);
                        this.megaBaseSpeed = int.Parse(split[7]);
                    }

                }
            }
        }


        //calculates actual stats of pokemon based on level and base stats and saves in stats data fields
        //this is called either after experience (and EVs) is earned or after pokemon levels up (our choice later)
        public void CalculateStats()
        {
            //first find which stats are boosted
            double atkBoost = 1, defBoost = 1, spaBoost = 1, spdBoost = 1, speBoost = 1;
            switch (this.nature.GetBoostedStat())
            {
                case 1:
                    atkBoost = 1.1;
                    break;
                case 2:
                    defBoost = 1.1;
                    break;
                case 3:
                    spaBoost = 1.1;
                    break;
                case 4:
                    spdBoost = 1.1;
                    break;
                case 5:
                    speBoost = 1.1;
                    break;
                default:  //default means we got a nature that doesn't boost or reduce anything
                    break;
            }
            switch (this.nature.GetReducedStat())
            {
                case 1:
                    atkBoost = 0.9;
                    break;
                case 2:
                    defBoost = 0.9;
                    break;
                case 3:
                    spaBoost = 0.9;
                    break;
                case 4:
                    spdBoost = 0.9;
                    break;
                case 5:
                    speBoost = 0.9;
                    break;
                default: //default means we got a nature that doesn't boost or reduce anything
                    break;
            }
            Double atkplaceholder = (((((2 * this.baseAtk) + this.atkIV + (this.atkEV / 4)) * this.level) / 100) + 5) * atkBoost;
            this.atk = Convert.ToInt32(atkplaceholder);

            Double defplaceholder = (((((2 * this.baseDef) + this.defIV + (this.defEV / 4)) * this.level) / 100) + 5) * defBoost;
            this.def = Convert.ToInt32(defplaceholder);

            Double spaplaceholder = (((((2 * this.baseSpAtk) + this.spaIV + (this.spaEV / 4)) * this.level) / 100) + 5) * spaBoost;
            this.spAtk = Convert.ToInt32(spaplaceholder);

            Double spdplaceholder = (((((2 * this.baseSpDef) + this.spdIV + (this.spdEV / 4)) * this.level) / 100) + 5) * spdBoost;
            this.spDef = Convert.ToInt32(spdplaceholder);

            Double speplaceholder = (((((2 * this.baseSpeed) + this.speIV + (this.speEV / 4)) * this.level) / 100) + 5) * speBoost;
            this.speed = Convert.ToInt32(speplaceholder);

            //HP is calculated differently
            this.hp = ((((2 * this.baseHp) + this.hpIV + (this.hpEV / 4)) * this.level) / 100) + this.level + 10;
        }

        //calculate mega stats
        public void CalculateMegaStats(int multiplemegas) //if multiple megas = 0 this wont do anythings
                                                          //if mult megas = 1 this will calc mega values
        {                                                   //if mult megas = 2 this will calc mega and megaY values
            //first find which stats are boosted
            double atkBoost = 1, defBoost = 1, spaBoost = 1, spdBoost = 1, speBoost = 1;
            switch (this.nature.GetBoostedStat())
            {
                case 1:
                    atkBoost = 1.1;
                    break;
                case 2:
                    defBoost = 1.1;
                    break;
                case 3:
                    spaBoost = 1.1;
                    break;
                case 4:
                    spdBoost = 1.1;
                    break;
                case 5:
                    speBoost = 1.1;
                    break;
                default:  //default means we got a nature that doesn't boost or reduce anything
                    break;
            }
            switch (this.nature.GetReducedStat())
            {
                case 1:
                    atkBoost = 0.9;
                    break;
                case 2:
                    defBoost = 0.9;
                    break;
                case 3:
                    spaBoost = 0.9;
                    break;
                case 4:
                    spdBoost = 0.9;
                    break;
                case 5:
                    speBoost = 0.9;
                    break;
                default: //default means we got a nature that doesn't boost or reduce anything
                    break;
            }
            if (multiplemegas > 0)
            {
                Double megaatkplaceholder = (((((2 * this.megaBaseAtk) + this.atkIV + (this.atkEV / 4)) * this.level) / 100) + 5) * atkBoost;
                this.megaAtk = Convert.ToInt32(megaatkplaceholder);

                Double megadefplaceholder = (((((2 * this.megaBaseDef) + this.defIV + (this.defEV / 4)) * this.level) / 100) + 5) * defBoost;
                this.megaDef = Convert.ToInt32(megadefplaceholder);

                Double megaspaplaceholder = (((((2 * this.megaBaseSpAtk) + this.spaIV + (this.spaEV / 4)) * this.level) / 100) + 5) * spaBoost;
                this.megaSpAtk = Convert.ToInt32(megaspaplaceholder);

                Double megaspdplaceholder = (((((2 * this.megaBaseSpDef) + this.spdIV + (this.spdEV / 4)) * this.level) / 100) + 5) * spdBoost;
                this.megaSpDef = Convert.ToInt32(megaspdplaceholder);

                Double megaspeplaceholder = (((((2 * this.megaBaseSpeed) + this.speIV + (this.speEV / 4)) * this.level) / 100) + 5) * speBoost;
                this.megaSpeed = Convert.ToInt32(megaspeplaceholder);

                //HP is calculated differently
                this.megaHp = ((((2 * this.megaBaseHp) + this.hpIV + (this.hpEV / 4)) * this.level) / 100) + this.level + 10;
            }
            if (multiplemegas == 2)
            {
                Double megaatkplaceholderY = (((((2 * this.megaBaseAtkY) + this.atkIV + (this.atkEV / 4)) * this.level) / 100) + 5) * atkBoost;
                this.megaAtkY = Convert.ToInt32(megaatkplaceholderY);

                Double megadefplaceholderY = (((((2 * this.megaBaseDefY) + this.defIV + (this.defEV / 4)) * this.level) / 100) + 5) * defBoost;
                this.megaDefY = Convert.ToInt32(megadefplaceholderY);

                Double megaspaplaceholderY = (((((2 * this.megaBaseSpAtkY) + this.spaIV + (this.spaEV / 4)) * this.level) / 100) + 5) * spaBoost;
                this.megaSpAtkY = Convert.ToInt32(megaspaplaceholderY);

                Double megaspdplaceholderY = (((((2 * this.megaBaseSpDefY) + this.spdIV + (this.spdEV / 4)) * this.level) / 100) + 5) * spdBoost;
                this.megaSpDefY = Convert.ToInt32(megaspdplaceholderY);

                Double megaspeplaceholderY = (((((2 * this.megaBaseSpeedY) + this.speIV + (this.speEV / 4)) * this.level) / 100) + 5) * speBoost;
                this.megaSpeedY = Convert.ToInt32(megaspeplaceholderY);

                //HP is calculated differently
                this.megaHpY = ((((2 * this.megaBaseHpY) + this.hpIV + (this.hpEV / 4)) * this.level) / 100) + this.level + 10;
            }
        }

        //generates random (as random as we can) IVs. THIS ONLY HAPPENS ONCE!
        //random numbers from 0-31
        public void GenerateIvs()
        {
            Random hprandom = new Random();
            this.hpIV = hprandom.Next(1, 32);
            this.atkIV = hprandom.Next(1, 32);
            this.defIV = hprandom.Next(1, 32); //this makes a random number ranging from 1 (lowest output possible)
                                               // to 31 (highest output possible)
            this.spaIV = hprandom.Next(1, 32);
            this.spdIV = hprandom.Next(1, 32);
            this.speIV = hprandom.Next(1, 32);
        }

        //generates Effort values for pokemon. wild pokemon default to zero for all evs, and pokemon earn them
        //by defeating other pokemon
        public void GenerateEvs()
        {
            this.hpEV = 0;
            this.atkEV = 0;
            this.defEV = 0;
            this.spaEV = 0;
            this.spdEV = 0;
            this.speEV = 0;
        }

        //MOVESET GENERATION
        //-1 is learned on evo and -2 is egg moves and 1 is moves that it should have at lv 1
        public void GenerateMoveset()
        {
            //initialize moveset hashmap
            this.moveset = new Dictionary<int, Move>();
            string[] allmoves = System.IO.File.ReadAllLines(@"res/learnsetsall.txt");
            String line = allmoves[this.dexNum - 1];
            //Console.WriteLine(line);
            //parse the line
            String[] split = line.Split(',');
            String[] keep = split[0].Split(':');//remove the "dexnum:"
            split[0] = keep[1];
            for (int i = 0; i < split.Length; i += 2)
            {
                int learnLevel = int.Parse(split[i]);//level move is learned
                                                     //Console.WriteLine("NUM:" + split[i + 1]);
                Move learnMove = new Move(int.Parse(split[i + 1]));
                //moves learned before this pokemon's level will be added immediately
                //for all other moves, get the data and put into hashmap
                if (learnLevel <= this.level && learnLevel > 0)
                {
                    this.AddMove(new Move(int.Parse(split[i + 1])));//learn now
                }
                if (moveset.ContainsKey(learnLevel))
                    continue;
                this.moveset.Add(learnLevel, learnMove);//learn later (save in dictionary)
            }
        }


        //adds a move to the pokemon. if all are full, it loops back around and
        //replaces the oldest move
        public Boolean AddMove(Move x)
        {
            //if it already knows this move, skip
            if (this.HasMove(x))
            {
                return false;
            }
            if (this.move1 == null)
            {
                this.move1 = x;
                this.lastAddedMoveIndex = 1;
                return true;
            }
            if (this.move2 == null)
            {
                this.move2 = x;
                this.lastAddedMoveIndex = 2;
                return true;
            }
            if (this.move3 == null)
            {
                this.move3 = x;
                this.lastAddedMoveIndex = 3;
                return true;
            }
            if (this.move4 == null)
            {
                this.move4 = x;
                this.lastAddedMoveIndex = 4;
                return true;
            }
            //all 4 moves are full,loop back around
            if (this.lastAddedMoveIndex == 1)
            {
                this.move2 = x;
                this.lastAddedMoveIndex = 2;
                return true;
            }
            if (this.lastAddedMoveIndex == 2)
            {
                this.move3 = x;
                this.lastAddedMoveIndex = 3;
                return true;
            }
            if (this.lastAddedMoveIndex == 3)
            {
                this.move4 = x;
                this.lastAddedMoveIndex = 4;
                return true;
            }
            if (this.lastAddedMoveIndex == 4)
            {
                this.move1 = x;
                this.lastAddedMoveIndex = 1;
                return true;
            }
            return false;
        }

        //checks if pokemon knows a move
        public Boolean HasMove(Move x)
        {
            int id = x.GetMoveId();
            if (this.move1 != null && this.move1.GetMoveId() == id)
                return true;
            if (this.move2 != null && this.move2.GetMoveId() == id)
                return true;
            if (this.move3 != null && this.move3.GetMoveId() == id)
                return true;
            if (this.move4 != null && this.move4.GetMoveId() == id)
                return true;
            return false;
        }

        public override String ToString()
        {
            StringBuilder bob = new StringBuilder(this.name + ", No. " + this.dexNum + ", Lv." + this.level + "\nOT:" + this.OT + " " + this.gender + "\nStats: "
               + "|" + this.hp + "|" + this.atk + "|" + this.def + "|" + this.spAtk + "|" + this.spDef + "|" + this.speed + "|\nMoves: ");
            if (this.move1 != null)
                bob.Append(this.move1 + " ");
            if (this.move2 != null)
                bob.Append(this.move2 + " ");
            if (this.move3 != null)
                bob.Append(this.move3 + " ");
            if (this.move4 != null)
                bob.Append(this.move4 + " ");
            return bob.ToString();
        }

        //this is like a toString with literally every piece of information a pokemon has, for debugging
        public String Data()
        {
            StringBuilder bob = new StringBuilder();
            bob.Append("|Dex Number: " + this.dexNum + "|");
            bob.Append("\t|Name: " + this.name + "|");
            bob.Append("\t|Nickname: " + this.nickname + "|");
            bob.Append("\t|Level: " + this.level + "|");
            bob.Append("\t|Mega Formes: " + this.megaName + "| " + this.megaNameY + "|");
            int estLv = EstimateLevel();
            if (estLv > 100)
            {
                bob.Append("(" + estLv + ")|");
            }
            bob.Append("\n|Type: " + this.type + "|");
            bob.Append("\t|Gender: " + this.gender + "|");
            bob.Append("\t|Original Trainer: " + this.OT + "|");
            bob.Append("\t|Nature: " + this.nature + "|");
            bob.Append("\t|Shiny: " + this.shiny + "|");
            bob.Append("\t|Exp: " + this.exp + "|");

            bob.Append("\n|BASE STATS|");
            bob.Append("\n|HP: " + this.baseHp + "|");
            bob.Append("\t|Atk: " + this.baseAtk + "|");
            bob.Append("\t|Def: " + this.baseDef + "|");
            bob.Append("\t|SpAtk: " + this.baseSpAtk + "|");
            bob.Append("\t|SpDef: " + this.baseSpDef + "|");
            bob.Append("\t|Speed: " + this.baseSpeed + "|");

            bob.Append("\n|CALCULATED STATS|");
            bob.Append("\n|HP: " + this.hp + "|");
            bob.Append("\t|Atk: " + this.atk + "|");
            bob.Append("\t|Def: " + this.def + "|");
            bob.Append("\t|SpAtk: " + this.spAtk + "|");
            bob.Append("\t|SpDef: " + this.spDef + "|");
            bob.Append("\t|Speed: " + this.speed + "|");

            bob.Append("\n|MEGA BASE STATS|");
            bob.Append("\n|HP: " + this.megaBaseHp + "|");
            bob.Append("\t|Atk: " + this.megaBaseAtk + "|");
            bob.Append("\t|Def: " + this.megaBaseDef + "|");
            bob.Append("\t|SpAtk: " + this.megaBaseSpAtk + "|");
            bob.Append("\t|SpDef: " + this.megaBaseSpDef + "|");
            bob.Append("\t|Speed: " + this.megaBaseSpeed + "|");

            bob.Append("\n|MEGA CALCULATED STATS|");
            bob.Append("\n|HP: " + this.megaHp + "|");
            bob.Append("\t|Atk: " + this.megaAtk + "|");
            bob.Append("\t|Def: " + this.megaDef + "|");
            bob.Append("\t|SpAtk: " + this.megaSpAtk + "|");
            bob.Append("\t|SpDef: " + this.megaSpDef + "|");
            bob.Append("\t|Speed: " + this.megaSpeed + "|");

            bob.Append("\n|MEGA (2/Y) BASE STATS|");
            bob.Append("\n|HP: " + this.megaBaseHpY + "|");
            bob.Append("\t|Atk: " + this.megaBaseAtkY + "|");
            bob.Append("\t|Def: " + this.megaBaseDefY + "|");
            bob.Append("\t|SpAtk: " + this.megaBaseSpAtkY + "|");
            bob.Append("\t|SpDef: " + this.megaBaseSpDefY + "|");
            bob.Append("\t|Speed: " + this.megaBaseSpeedY + "|");

            bob.Append("\n|MEGA (2/Y) CALCULATED STATS|");
            bob.Append("\n|HP: " + this.megaHpY + "|");
            bob.Append("\t|Atk: " + this.megaAtkY + "|");
            bob.Append("\t|Def: " + this.megaDefY + "|");
            bob.Append("\t|SpAtk: " + this.megaSpAtkY + "|");
            bob.Append("\t|SpDef: " + this.megaSpDefY + "|");
            bob.Append("\t|Speed: " + this.megaSpeedY + "|");

            bob.Append("\n|IVs|");
            bob.Append("\n|HP: " + this.hpIV + "|");
            bob.Append("\t|Atk: " + this.atkIV + "|");
            bob.Append("\t|Def: " + this.defIV + "|");
            bob.Append("\t|Spa: " + this.spaIV + "|");
            bob.Append("\t|Spd: " + this.spdIV + "|");
            bob.Append("\t|Spe: " + this.speIV + "|");

            bob.Append("\n|EVs|");
            bob.Append("\n|HP: " + this.hpEV + "|");
            bob.Append("\t|Atk: " + this.atkEV + "|");
            bob.Append("\t|Def: " + this.defEV + "|");
            bob.Append("\t|Spa: " + this.spaEV + "|");
            bob.Append("\t|Spd: " + this.spdEV + "|");
            bob.Append("\t|Spe: " + this.speEV + "|");

            if (this.move1 != null)
                bob.Append("\n|Move 1: " + this.move1.Data() + "|");
            if (this.move2 != null)
                bob.Append("\n|Move 2: " + this.move2.Data() + "|");
            if (this.move3 != null)
                bob.Append("\n|Move 3: " + this.move3.Data() + "|");
            if (this.move4 != null)
                bob.Append("\n|Move 4: " + this.move4.Data() + "|");

            return bob.ToString();
        }

        public String HpString()
        {
            StringBuilder bob = new StringBuilder();
            bob.Append("+--------------------+\n");
            bob.Append("[");
            double height = (double)this.GetRemainingHp() / (double)this.GetHp();
            double actual = height * 20;
            int count = 0;
            for (int i = 0; i < actual; i++)
            {
                bob.Append("#");
                count++;
            }
            while (count < 20)
            {
                bob.Append(" ");
                count++;
            }
            bob.Append("]\n");
            bob.Append("+--------------------+\n");

            return bob.ToString();
        }
        public void SavePokemon()
        {
            //StringBuilder bob = new StringBuilder();
            //bob.append("" + this.dexNum);
            //bob.append("," + this.name);
            //bob.append("," + this.nickname);
            //bob.append("," + this.level);
            //bob.append("," + this.type.getPrimaryType());
            //bob.append("," + this.type.getSecondaryType());
            //bob.append("," + this.gender);
            //bob.append("," + this.OT);
            //bob.append("," + this.nature.getId());
            //bob.append("," + this.shiny);
            //bob.append("," + this.exp);

            ////bob.append(",BASE STATS");
            //bob.append("," + this.baseHp);
            //bob.append("," + this.baseAtk);
            //bob.append("," + this.baseDef);
            //bob.append("," + this.baseSpAtk);
            //bob.append("," + this.baseSpDef);
            //bob.append("," + this.baseSpeed);

            ////bob.append(",CALCULATED STATS");
            //bob.append("," + this.hp);
            //bob.append("," + this.atk);
            //bob.append("," + this.def);
            //bob.append("," + this.spAtk);
            //bob.append("," + this.spDef);
            //bob.append("," + this.speed);

            ////bob.append(",IVs");
            //bob.append("," + this.hpIV);
            //bob.append("," + this.atkIV);
            //bob.append("," + this.defIV);
            //bob.append("," + this.spaIV);
            //bob.append("," + this.spdIV);
            //bob.append("," + this.speIV);

            ////bob.append(",EVs");
            //bob.append("," + this.hpEV);
            //bob.append("," + this.atkEV);
            //bob.append("," + this.defEV);
            //bob.append("," + this.spaEV);
            //bob.append("," + this.spdEV);
            //bob.append("," + this.speEV);

            ////bob.append(",Moves");
            //if (this.move1 != null)
            //    bob.append("," + this.move1.getMoveId());
            //if (this.move2 != null)
            //    bob.append("," + this.move2.getMoveId());
            //if (this.move3 != null)
            //    bob.append("," + this.move3.getMoveId());
            //if (this.move4 != null)
            //    bob.append("," + this.move4.getMoveId());
            //BufferedWriter bw = null;
            //FileWriter fw = null;


            //try
            //{
            //    String content = bob.toString();
            //    fw = new FileWriter("res/saveTest.txt");
            //    bw = new BufferedWriter(fw);
            //    bw.write(content);

            //}
            //catch (IOException e)
            //{
            //    e.printStackTrace();
            //}
            //finally
            //{
            //    try
            //    {
            //        if (bw != null)
            //            bw.close();
            //        if (fw != null)
            //            fw.close();
            //    }
            //    catch (IOException ex)
            //    {
            //        ex.printStackTrace();
            //    }
            //}


        }
    }
}

