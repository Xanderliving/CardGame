using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardGame.Backend
{
    public class Inputs
    {
        private const string Value = "Recorded jk";
        //The Deck of cards
        string[][] Deck = new string[][]
{       //Card
        new string[] { "ac", "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "tc", "jc", "qc", "kc", "ad", "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "td", "jd", "qd", "kd", "ah", "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "th", "jh", "qh", "kh", "as", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "ts", "js", "qs", "ks", "jk" },
        //Its Value
        new string[] { "14", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "28", "4", "6", "8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "42", "6", "9", "12", "15", "18", "21", "24", "27", "30", "33", "36", "39", "56", "8", "12", "16", "20", "24", "28", "32", "36", "40", "44", "48", "52", "2" },
        //How many exist
        new string[] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "2" }};
        int jk = 2;

        public string Checker(string Card)
        {
            //checks if its valid
            if (Card.Contains('\\') || Card.Contains('/') || Card.Contains('|') || Card.Contains('!')){
                Console.WriteLine("Invalid input string");
                return "a";
            }


            bool cardFound = false;
            Card.ToLower();
            if (Card == "score")
            {
                Score();
                cardFound = true;
                
            }
            if (Card.ToLower() == "stop")
            {
                return "stop";

            }

            //Checks if the card exists
            for (int i = 0; i < Deck[0].Length; i++)
            {

                String[] test = Card.Split(',');

                for (int j = 0; j < test.Length; j++)
                {
                   
                    if (test[j].Trim().ToLower() == Deck[0][i])
                    {
                        if ("1" == Deck[2][i])
                        {
                            Deck[2][i] = "0";
                            Console.WriteLine("Recorded");
                            cardFound = true;

                        }

                        else if ("0" == Deck[2][i])
                        {
                            Console.WriteLine("Cards cannot be duplicated");
                            cardFound = true;
                        }
                        else if (test[j].ToLower() == "jk")
                        {
                            if (jk > 0)
                            {
                                jk -= 1;
                                Console.WriteLine(Value);
                                cardFound = true;
                            }
                            else
                            {
                                Console.WriteLine("A hand cannot contain more than two Jokers");
                                cardFound = true;
                            }
                        }
                    }
                }

                
            }
            if (cardFound != true)
            {
                Console.WriteLine("Card not recognised");
            }

            return "Failed input";
        }

        public string Score()
        {
            List<String> Score = new List<String>();
            int cardValue = 0;
            //Checks if card has been used and adds it
            for (int i = 0; i < Deck[0].Length; i++)
            {
                if (Deck[2][i] == "0")
                {
                   
                    cardValue += Convert.ToInt32(Deck[1][i]);

                }
            }
            foreach (var Card in Score)
            {
                Console.WriteLine(Card);
            }
            if (jk == 1)
            {
                cardValue *= 2;
                Console.WriteLine(cardValue.ToString());
            }
            else if (jk == 0)
            {
                cardValue *= 4;
                Console.WriteLine(cardValue.ToString());
            }
            else
            {
                Console.WriteLine(cardValue.ToString());
            }
            return "h";
        }
    
    }
}
