using System;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;

namespace BaseCards.Cards
{
    /// <summary>
    /// A card object consisting of a suit/rank
    /// </summary>
    public class Card : IEquatable<Card>
    {
        /// <summary>
        /// Gets the suit of the card
        /// </summary>
        public ISuit Suit { get; }
        
        /// <summary>
        /// Gets the rank of the card
        /// </summary>
        public IRank Rank { get; }

        /// <summary>
        /// Constructor for creating a card
        /// </summary>
        /// <param name="rank"><see cref="IRank"/></param>
        /// <param name="suit"><see cref="ISuit"/></param>
        public Card(IRank rank, ISuit suit)
        {
            Suit = suit;
            Rank = rank;
        }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Suit, other.Suit) && Equals(Rank, other.Rank);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Card other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Suit != null ? Suit.GetHashCode() : 0) * 397) ^ (Rank != null ? Rank.GetHashCode() : 0);
            }
        }
    }
}