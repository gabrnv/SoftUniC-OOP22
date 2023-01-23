using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                string face = input[i].Split(" ")[0].ToString();
                string suit = input[i].Split(" ")[1].ToString();
                cards.Add(CreateCard(face, suit));
            }
            Console.WriteLine(string.Join(" ", cards));
        }

        public static Card CreateCard(string face, string suit)
        {
            bool isCardValid = false;
            string UTFSuit = "";
            try
            {
                bool isFaceValid = false;
                bool isSuitValid = false;
                switch (face)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "A":
                    case "J":
                    case "Q":
                    case "K":
                        isFaceValid = true;
                        break;
                }
                switch(suit)
                {
                    case "S":
                        isSuitValid = true;
                        UTFSuit = "\u2660";
                        break;
                    case "C":
                        isSuitValid = true;
                        UTFSuit = "\u2663";

                        break;

                    case "D":
                        isSuitValid = true;
                        UTFSuit = "\u2666";

                        break;

                    case "H":
                        isSuitValid = true;
                        UTFSuit = "\u2665";

                        break;

                }
                if (isFaceValid != true || isSuitValid != true)
                {
                    throw new Exception("Invalid card!");
                }
                else
                {
                    isCardValid = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isCardValid = false;
            }
            if(isCardValid)
            {
                return new Card(face, UTFSuit);
            }
            else
            {
                return null;
            }
        }
    }
}
