using System.Collections.Generic;
using System;
namespace DeckOfCards
{

    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public Player(string n)
        {
            name = n;
        }
        public Card draw(Deck D)
        {
            Card NewCard = D.deal();
            hand.Add(NewCard);
            return NewCard;
        }

        public Card discard(int index)
        {
            if (hand.Count > index)
            {
                Card discarded = hand[index];
                hand.RemoveAt(index);
                return discarded;
            }
            else
            {
                return null;
            }

        }



    }
}