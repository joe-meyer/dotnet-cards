using System;

namespace BaseCards.Cards.Suits
{
    /// <summary>
    /// Representation of a Suit of a card
    /// </summary>
    public class Suit : ISuit
    {
        private readonly char _character;
        private readonly SuitEnum _suit;
        private readonly SuitEnum _nextSuit;

        public Suit(char character, SuitEnum suit, SuitEnum nextSuit)
        {
            _character = character;
            _suit = suit;
            _nextSuit = nextSuit;
        }

        /// <inheritdoc cref="ISuit.AsCharacter"/>
        public char AsCharacter()
        {
            return _character;
        }

        /// <inheritdoc cref="ISuit.AsEnum"/>
        public SuitEnum AsEnum()
        {
            return _suit;
        }

        /// <inheritdoc cref="ISuit.NextSuit"/>
        public SuitEnum NextSuit()
        {
            return _nextSuit;
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public bool Equals(ISuit other)
        {
            if (other == null) return false;
            
            return other.AsCharacter() == AsCharacter() 
                   && other.AsEnum() == AsEnum() 
                   && other.NextSuit() == NextSuit();
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Suit);
        }

        /// <inheritdoc cref="IEquatable{ISuit}"/>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _character.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) (_suit+2);
                hashCode = (hashCode * 397) ^ (int) (_nextSuit+2);
                return hashCode;
            }
        }
    }
}