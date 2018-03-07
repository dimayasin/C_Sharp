using System.Collections.Generic;
using System;
namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        private string[] SV = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        private string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };
        public Deck()
        {
            resetDeck();

        }
        public Card deal()
        {
            Card dealt = cards[0];
            cards.RemoveAt(0);
            return dealt;
        }

        public void resetDeck()
        {
            cards.Clear();

            // for (int i = 0; i < suits.Length; i++)
            // {
            //     
            foreach (string suit in suits)

            {
                for (int j = 0; j < SV.Length; j++)
                {
                    cards.Add(new Card(SV[j], suit, j + 1));
                }
            }
            foreach (Card mycard in cards)
            {
                Console.WriteLine("{0} of {1} and value is {2}",
                     mycard.stringVal, mycard.suit, mycard.val);


            }
            System.Console.WriteLine("Card Count is: {0}", cards.Count);

        }
        public Deck shuffle()
        {
            int shuffling = cards.Count-1;
            Card temp = new Card();
            int randomCard;
            Random rand = new Random();
            while (shuffling > 0)
            {
                randomCard = rand.Next(0, 52);

                temp = cards[shuffling];
                cards[shuffling] = cards[randomCard];
                cards[randomCard] = temp;
                shuffling--;
            }
            DisplayDeck();
            return this;
        }

        public void DisplayDeck()
        {

            foreach (Card mycard in cards)
            {
                Console.WriteLine(" {0} of {1} and value is {2}",
                     mycard.stringVal, mycard.suit, mycard.val);


            }
            System.Console.WriteLine("Card Count is: {0}", cards.Count);
        }

    }




}