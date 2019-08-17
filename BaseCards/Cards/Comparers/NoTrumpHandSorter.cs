using System;
using System.Collections.Generic;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;

namespace BaseCards.Cards.Comparers
{
    /// <summary>
    /// Used to sort the cards without a trump suit
    /// </summary>
    public class NoTrumpHandSorter : IComparer<Card>
    {
        private readonly bool _rankAscending;
        private readonly bool _suitAscending;

        /// <summary>
        /// Constructor for the comparer
        /// </summary>
        /// <param name="rankAscending">True to sort rank ascending, false to sort descending</param>
        /// <param name="suitAscending">True to sort suit ascending, false to sort descending</param>
        public NoTrumpHandSorter(bool rankAscending, bool suitAscending)
        {
            _rankAscending = rankAscending;
            _suitAscending = suitAscending;
        }
        
        /// <inheritdoc cref="IComparer{Card}"/>
        public int Compare(Card x, Card y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            var suitSort = CompareSuit(x.Suit, y.Suit);
            return Math.Sign(suitSort != 0 ? suitSort : CompareRank(x.Rank, y.Rank));
        }

        private int CompareSuit(ISuit x, ISuit y)
        {
            if (_suitAscending)
            {
                return x.AsEnum() - y.AsEnum();
            }
            return y.AsEnum() - x.AsEnum();
        }

        private int CompareRank(IRank x, IRank y)
        {
            if (_rankAscending)
            {
                return x.AsEnum() - y.AsEnum();
            }
            return y.AsEnum() - x.AsEnum();
        }
        
    }
}