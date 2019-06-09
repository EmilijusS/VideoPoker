using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Video Poker!\n");

            new Program().Game();
        }

        public void Game()
        {
            while (true)
            {
                var dealer = new Dealer();
                var hand = new List<Card>();

                for (int i = 0; i < 5; ++i)
                {
                    hand.Add(dealer.Draw());
                }

                PrintHand(hand);

                DiscardCards(hand);

                for (int i = hand.Count; i < 5; ++i)
                {
                    hand.Add(dealer.Draw());
                }

                PrintHand(hand);

                PrintScore(hand);

                if (!WillPlayAgain())
                {
                    return;
                }
            }
        }

        private void PrintHand(List<Card> hand)
        {
            Console.WriteLine("Your hand:");

            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine($"{i + 1}. {hand[i]}");
            }
        }

        private void DiscardCards(List<Card> hand)
        {
            Console.WriteLine("Type card numbers (1-5) to discard and press enter. Example: \"235\"");

            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (!IsDiscardInputValid(input))
                {
                    Console.WriteLine("Invalid input. Try again:");
                    continue;
                }

                break;
            }

            var toDiscard = new List<Card>();

            foreach (char digit in input)
            {
                // Subtracting '1' converts char to list index
                toDiscard.Add(hand[digit - '1']);
            }

            foreach (Card card in toDiscard)
            {
                hand.Remove(card);
            }
        }

        private bool IsDiscardInputValid(string input)
        {
            if (input.Length > 5)
            {
                return false;
            }

            // Only digits 1-5 are allowed
            foreach (char symbol in input)
            {
                if (symbol < '1' || symbol > '5')
                {
                    return false;
                }
            }

            // Repeating digits not allowed
            if (input.Distinct().ToArray().Length != input.Length)
            {
                return false;
            }

            return true;
        }

        private void PrintScore(List<Card> hand)
        {
            Console.WriteLine("SCORE CALCULATION NOT IMPLEMENTED.");
        }

        private bool WillPlayAgain()
        {
            Console.WriteLine("Play again? y/n");

            while (true)
            {
                var input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    return true;
                }

                if (input.ToLower() == "n")
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Try again:");
            }
        }
    }
}
