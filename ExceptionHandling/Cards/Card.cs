using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    internal class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
