using System;

namespace DeckOfCards
{
    class Program
    {
        public static void drawing(Player p, Deck D)
        {
            Card newcard = new Card();
            newcard = p.draw(D);
            Console.WriteLine("{0} of {1} Was drawn by {2}", newcard.stringVal, newcard.suit, p.name);
            

        }
        static void Main(string[] args)
        {
            Player player1 = new Player("Mark");

            Console.WriteLine("=====================");
            Console.WriteLine("Initializing the Deck");
            Console.WriteLine("=====================");

            Deck deck1 = new Deck();

            Console.WriteLine("=====================");
            Console.WriteLine(" Shuffling the Deck");
            Console.WriteLine("=====================");

            deck1.shuffle();
            Console.WriteLine("=====================");
            Console.WriteLine(" Player - Draw cards");
            Console.WriteLine("=====================");
            drawing(player1,deck1);
            drawing(player1,deck1);
            drawing(player1,deck1);
            drawing(player1,deck1);
            drawing(player1,deck1);
            Console.WriteLine("Deck Count is: {0}", deck1.cards.Count);





            Console.WriteLine("=====================");
            Console.WriteLine(" Resetting the Deck");
            Console.WriteLine("=====================");


            deck1.resetDeck();

        }
    }
}
