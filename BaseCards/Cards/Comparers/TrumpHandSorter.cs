using System;
using System.Collections.Generic;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;

namespace BaseCards.Cards.Comparers
{
    /// <summary>
    /// Used to sort a hand for trump
    /// </summary>
    public class TrumpHandSorter : IComparer<Card>
    {
        private readonly ISuit _trumpSuit;
        private readonly bool _suitAscending;
        private readonly bool _rankAscending;

        /// <summary>
        /// Constructor for Trump Hand Sorter
        /// </summary>
        /// <param name="trumpSuit"></param>
        /// <param name="suitAscending"></param>
        /// <param name="rankAscending"></param>
        public TrumpHandSorter(ISuit trumpSuit, bool suitAscending, bool rankAscending)
        {
            _trumpSuit = trumpSuit;
            _suitAscending = suitAscending;
            _rankAscending = rankAscending;
        }

        public int Compare(Card x, Card y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            var suitSort = CompareSuit(GetCardSuit(x), GetCardSuit(y));
            return Math.Sign(suitSort != 0 ? suitSort : CompareRank(x, y));
        }

        private int CompareSuit(ISuit x, ISuit y)
        {
            if (_suitAscending)
            {
                return x.AsEnum() - y.AsEnum();
            }
            return y.AsEnum() - x.AsEnum();
        }

        private ISuit GetCardSuit(Card c)
        {
            if (c.Rank.AsEnum() == RankEnum.Jack && c.Suit.AsEnum() == _trumpSuit.NextSuit())
            {
                return _trumpSuit;
            }

            return c.Suit;
        }
        
        

        private int CompareRank(Card x, Card y)
        {
            if (x.Suit.Equals(_trumpSuit) || y.Suit.Equals(_trumpSuit))
            {
                if (_rankAscending)
                {
                    return GetTrumpRank(x) - GetTrumpRank(y);
                }
                return GetTrumpRank(y) - GetTrumpRank(x);  
            }
            if (_rankAscending)
            {
                return x.Rank.AsEnum() - y.Rank.AsEnum();
            }
            return y.Rank.AsEnum() - x.Rank.AsEnum();   
        }

        private int GetTrumpRank(Card card)
        {
            if (card.Rank.AsEnum() == RankEnum.Jack)
            {
                if (card.Suit.Equals(_trumpSuit))
                {
                    return 7;
                }
                return 6;
            }
            if (card.Rank.AsEnum() == RankEnum.Ace)
            {
                return 5;
            }

            if (card.Rank.AsEnum() == RankEnum.King)
            {
                return 4;
            }

            if (card.Rank.AsEnum() == RankEnum.Queen)
            {
                return 3;
            }

            if (card.Rank.AsEnum() == RankEnum.Ten)
            {
                return 2;
            }

            if (card.Rank.AsEnum() == RankEnum.Nine)
            {
                return 1;
            }
            return 0;
        }
    }
}