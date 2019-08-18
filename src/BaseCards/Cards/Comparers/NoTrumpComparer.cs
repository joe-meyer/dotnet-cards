using System;
using System.Collections.Generic;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;

namespace BaseCards.Cards.Comparers
{
    /// <summary>
    /// Used to compare no trump plays
    /// </summary>
    public class NoTrumpComparer : IComparer<Card>
    {
        private readonly ISuit _leadSuit;
        private readonly bool _rankAscending;

        public NoTrumpComparer(ISuit leadSuit, bool sortRankAscending)
        {
            _leadSuit = leadSuit;
            _rankAscending = sortRankAscending;
        }

        /// <inheritdoc cref="IComparer{Card}"/>
        public int Compare(Card x, Card y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            if (!x.Suit.Equals(_leadSuit) && !y.Suit.Equals(_leadSuit))
            {
                return 0;
            }
            
            if (x.Suit.Equals(_leadSuit) && !y.Suit.Equals(_leadSuit))
            {
                return 1;
            }
            
            if (!x.Suit.Equals(_leadSuit) && y.Suit.Equals(_leadSuit))
            {
                return -1;
            }
            return Math.Sign(CompareRank(x.Rank, y.Rank));
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