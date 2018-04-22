using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belstar
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Start:
            Console.Write("Hello, and welcome to the realm of The Ghost Vale.");
            Console.ReadLine();
            Repeat:
            Console.Write("Have you been to these lands before (Y/N)? ");
            String skip = Convert.ToString(Console.ReadLine()).ToUpper();
            if (skip.Equals("Y") || skip.Equals("N"))
            {
                if (skip.Equals("Y"))
                {
                    Console.Write("Well then, you must know you're way around, but let's get a look at you first.");
                    Console.ReadLine();
                    Console.WriteLine();
                    charCreate();
                }
                else
                {
                    tutorial();
                }
            }
            else
            {
                goto Repeat;
            }
            


            Console.WriteLine();
        }
        static void charCreate()
        {
        Restart:
            Random rnd = new Random();
            int statPoint = 20, str = 0, dex = 0, wis = 0, lck = 0, gld = 0;
            Console.WriteLine("Welcome to character creation.");
            Console.Write("Would you like your stats randomized (Y/N)? ");
            String random = Convert.ToString(Console.ReadLine()).ToUpper();
            if (random.Equals("Y"))
            {
                randomStats();
            }
            else if (random.Equals("N"))
            {
                ReDo:
                statPoint = 20;
                BackStr:
                Console.WriteLine("You have " + statPoint + " points remaining.");
                Console.Write("Strength: ");
                str = Convert.ToInt32(Console.ReadLine());
                if (str > statPoint)
                {
                    goto BackStr;
                }
                statPoint -= str;
                if (statPoint < 1)
                {
                    goto Done;
                }
                BackDex:
                Console.WriteLine("You have " + statPoint + " points remaining.");
                Console.Write("Dexterity: ");
                dex = Convert.ToInt32(Console.ReadLine());
                if (str > statPoint)
                {
                    goto BackDex;
                }
                statPoint -= dex;
                if (statPoint < 1)
                {
                    goto Done;
                }
                BackWis:
                Console.WriteLine("You have " + statPoint + " points remaining.");
                Console.Write("Wisdom: ");
                wis = Convert.ToInt32(Console.ReadLine());
                if (str > statPoint)
                {
                    goto BackWis;
                }
                statPoint -= wis;
                if (statPoint < 1)
                {
                    goto Done;
                }
                BackLck:
                Console.WriteLine("You have " + statPoint + " points remaining.");
                Console.Write("Luck: ");
                lck = Convert.ToInt32(Console.ReadLine());
                if (str > statPoint)
                {
                    goto BackLck;
                }
                statPoint -= lck;
                Done:
                Console.WriteLine();
                Console.WriteLine("Strength: " + str + "\nDexterity: " + dex + "\nWisdom: " + wis + "\nLuck: " + lck);
                Console.Write("You have " + statPoint + " points remaining, are you happy with these stats (Y/N)?");
                random = Convert.ToString(Console.ReadLine()).ToUpper();
                if (random.Equals("Y"))
                {
                    gld = rnd.Next(1, 21);
                    Console.Write("Here is " + gld + " gold pieces to get you started.");
                    Console.ReadLine();
                    Console.WriteLine();
                    mainWorld(str, dex, wis, lck, gld);
                }
                else if (random.Equals("N"))
                {
                    goto ReDo;
                }
                else
                {
                    goto Done;
                }
            }
            else
            {
                goto Restart;
            }
        }
        static void tutorial()
        {
            Console.Write("Well then welcome to The Ghost Vale.\nI promise this realm isn't as scary as the name implies.");
            Console.ReadLine();
            Console.Write("This realm lies in the northern region of Rushend. Rumor has it that the original king of this realm still rules, despite having been dead for nearly 3 centuries. This is what gives this land its weird name. Whatever the original name of this realm was has been long forgotten.");
            Console.ReadLine();
            Console.Write("Many of the brightest minds have come to this realm to disprove these rumors, but all have fallen to the lawless of these lands before they could.");
            Console.ReadLine();
            Console.Write("Anyways, enough of my rambling, let's get a look at you.");
            Console.ReadLine();
            Console.WriteLine();
            charCreate();
        }
        static void battle(int str, int dex, int wis, int lck, int gld)
        {
            Random rnd = new Random();
            Console.WriteLine("Please select an enemy.");
            ReDo:
            Console.Write("Goblin(1), Orc(2), Troll(3), or Giant(4): ");
            int enmyNum = Convert.ToInt32(Console.ReadLine());
            if (enmyNum > 4 || enmyNum < 1)
            {
                goto ReDo;
            }
            else
            {
                combat(str, dex, wis, lck, gld, enmyNum);
            }
        }
        static void combat(int str, int dex, int wis, int lck, int gld, int enmyNum)
        {
            Random rnd = new Random();
            int physAtt, rangAtt, mgckAtt, crtPer;
            physAtt = rnd.Next((str % 3), str);
            rangAtt = rnd.Next((dex % 3), dex);
            mgckAtt = rnd.Next((wis % 3), wis);
        }
        static void mainWorld(int str, int dex, int wis, int lck, int gld)
        {
            ReDo:
            Console.WriteLine("Where would you like to go?");
            Console.Write("Shop/Battle: ");
            String dec = Convert.ToString(Console.ReadLine()).ToLower();
            if (dec.Equals("shop"))
            {
                Console.WriteLine();
                shop(str, dex, wis, lck, gld);
            }
            else if (dec.Equals("battle"))
            {
                Console.WriteLine();
                battle(str, dex, wis, lck, gld);
            }
            else
            {
                Console.WriteLine("Make up your mind!");
                Console.WriteLine();
                goto ReDo;
            }
        }
        static void shop(int str, int dex, int wis, int lck, int gld)
        {
            Console.WriteLine("Welcome to the shop, how may I help you?");
            Shop:
            Console.Write("Buy/Sell/Upgrade/Leave: ");
            String pizzas = Convert.ToString(Console.ReadLine()).ToLower();
            if (pizzas.Equals("buy"))
            {
                Console.Write("Nothing Available.");
                Console.ReadLine();
                Console.WriteLine();
                goto Shop;
            }
            else if (pizzas.Equals("sell"))
            {
                Console.Write("Nothing Available.");
                Console.ReadLine();
                Console.WriteLine();
                goto Shop;
            }
            else if (pizzas.Equals("upgrade") && gld >= 10)
            {
            Upgrade:
                Console.WriteLine();
                Console.WriteLine("Each upgrade costs 10 gold each.");
                Console.WriteLine("You have " + gld + " gold.");
                Console.Write("Sword/Bow/Staff/Charm/Leave: ");
                pizzas = Convert.ToString(Console.ReadLine()).ToLower();
                if (pizzas.Equals("sword") && gld >= 10)
                {
                    Console.WriteLine("You have upgraded your sword!");
                    str += 3;
                    gld -= 10;
                    goto Upgrade;
                }
                else if (pizzas.Equals("bow") && gld >= 10)
                {
                    Console.WriteLine("You have upgraded your bow!");
                    dex += 3;
                    gld -= 10;
                    goto Upgrade;
                }
                else if (pizzas.Equals("staff") && gld >= 10)
                {
                    Console.WriteLine("You have upgraded your staff!");
                    wis += 3;
                    gld -= 10;
                    goto Upgrade;
                }
                else if (pizzas.Equals("charm") && gld >= 10)
                {
                    Console.WriteLine("You have upgraded your charm!");
                    lck += 3;
                    gld -= 10;
                    goto Upgrade;
                }
                else if(gld < 10)
                {
                    Console.WriteLine("You don't have enough money!");
                    goto Shop;
                }
                else if (pizzas.Equals("leave"))
                {
                    goto Shop;
                }
                else
                {
                    Console.WriteLine("Make up your damn mind!");
                    goto Upgrade;
                }
            }
            else if (pizzas.Equals("upgrade") && gld < 10)
            {
                Console.WriteLine("You don't have enough money!");
                Console.WriteLine();
                goto Shop;
            }
            else if (pizzas.Equals("leave"))
            {
                Console.WriteLine();
                mainWorld(str, dex, wis, lck, gld);
            }
            else
            {
                Console.WriteLine("Make up your damn mind!");
                goto Shop;
            }
            
        }
        static void randomStats()
        {
            Random rnd = new Random();
            int statPoint, str = 0, dex = 0, wis = 0, lck = 0, gld = 0;
            String random;
        ReDo:
            statPoint = 20;
            int select = rnd.Next(1, 5);
            switch (select)
            {
                case 1:
                    str = rnd.Next(0, statPoint - 2);
                    statPoint -= str;
                    dex = rnd.Next(0, statPoint - 1);
                    statPoint -= dex;
                    wis = rnd.Next(0, statPoint);
                    statPoint -= wis;
                    lck = rnd.Next(0, statPoint + 1);
                    break;
                case 2:
                    dex = rnd.Next(0, statPoint - 2);
                    statPoint -= dex;
                    wis = rnd.Next(0, statPoint - 1);
                    statPoint -= wis;
                    lck = rnd.Next(0, statPoint);
                    statPoint -= lck;
                    str = rnd.Next(0, statPoint + 1);
                    break;
                case 3:
                    wis = rnd.Next(0, statPoint - 2);
                    statPoint -= wis;
                    lck = rnd.Next(0, statPoint - 1);
                    statPoint -= lck;
                    str = rnd.Next(0, statPoint);
                    statPoint -= str;
                    dex = rnd.Next(0, statPoint + 1);
                    break;
                case 4:
                    lck = rnd.Next(0, statPoint - 2);
                    statPoint -= lck;
                    str = rnd.Next(0, statPoint - 1);
                    statPoint -= str;
                    dex = rnd.Next(0, statPoint);
                    statPoint -= dex;
                    wis = rnd.Next(0, statPoint + 1);
                    break;
            }
            Console.WriteLine("Strength: " + str + "\nDexterity: " + dex + "\nWisdom: " + wis + "\nLuck: " + lck);
            Answer:
            Console.Write("Are you happy with these stats (Y/N)? ");
            random = Convert.ToString(Console.ReadLine()).ToUpper();
            if (random.Equals("Y"))
            {
                gld = rnd.Next(1, 21);
                Console.Write("Here is " + gld + " gold to start you on your journey.");
                Console.ReadLine();
                Console.WriteLine();
                mainWorld(str, dex, wis, lck, gld);
            }
            else if (random.Equals("N"))
            {
                goto ReDo;
            }
            else
            {
                goto Answer;
            }
        }
    }
}
