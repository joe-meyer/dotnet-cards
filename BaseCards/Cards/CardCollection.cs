using System;
using System.Collections.Generic;

namespace BaseCards.Cards
{
    /// <summary>
    /// A collection of cards
    /// </summary>
    public class CardCollection : List<Card>
    {
        private static readonly Random Random = new Random();
        /// <summary>
        /// Shuffles the cards, this implementation uses the Fisher-Yates method
        /// </summary>
        public void Shuffle()
        {
            var n = Count;
            while (n > 1)
            {
                n--;
                var k = Random.Next(n+1);
                var value = this[k];  
                this[k] = this[n];  
                this[n] = value;  
            }
        }
    }
}