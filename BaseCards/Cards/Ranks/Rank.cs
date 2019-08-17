using System;

namespace BaseCards.Cards.Ranks
{
    /// <summary>
    /// A representation of a rank of a card
    /// </summary>
    public class Rank : IRank
    {
        private readonly RankEnum _rankEnum;
        private readonly string _rankString;

        public Rank(RankEnum rankEnum, string rankString)
        {
            _rankEnum = rankEnum;
            _rankString = rankString;
        }

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return _rankString;
        }

        /// <inheritdoc cref="IRank.AsEnum"/>
        public RankEnum AsEnum()
        {
            return _rankEnum;
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public bool Equals(IRank other)
        {
            if (other == null) return false;
            return AsEnum() == other.AsEnum() 
                   && ToString() == other.ToString();
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Rank);
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _rankEnum * 397) ^ _rankString.GetHashCode();
            }
        }
    }
}