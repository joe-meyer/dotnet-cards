using System;
using System.Collections.Generic;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;

namespace BaseCards.Cards.Comparers
{
    /// <summary>
    /// Used to compare no trump plays
    /// </summary>
    public class TrumpComparer : IComparer<Card>
    {
        private readonly ISuit _trumpSuit;
        private readonly ISuit _leadSuit;

        public TrumpComparer(ISuit trumpSuit, ISuit leadSuit)
        {
            _trumpSuit = trumpSuit;
            _leadSuit = leadSuit;
        }

        /// <inheritdoc cref="IComparer{Card}"/>
        public int Compare(Card x, Card y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            if (!GetCardSuit(x).Equals(_trumpSuit) && !GetCardSuit(y).Equals(_trumpSuit))
            {
                return GetNoTrumpComparison(x, y);
            }
            
            if (GetCardSuit(x).Equals(_trumpSuit) && !GetCardSuit(y).Equals(_trumpSuit))
            {
                return 1;
            }
            
            if (!GetCardSuit(x).Equals(_trumpSuit) && GetCardSuit(y).Equals(_trumpSuit))
            {
                return -1;
            }
            return Math.Sign(GetTrumpRank(x) - GetTrumpRank(y));
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

            return 1;
        }
        
        
        private ISuit GetCardSuit(Card c)
        {
            if (c.Rank.AsEnum() == RankEnum.Jack && c.Suit.AsEnum() == _trumpSuit.NextSuit())
            {
                return _trumpSuit;
            }

            return c.Suit;
        }

        private int GetNoTrumpComparison(Card x, Card y)
        {
            if (!x.Suit.Equals(_leadSuit) && !y.Suit.Equals(_leadSuit))
            {
                return 0;
            }
            
            if (!x.Suit.Equals(_leadSuit))
            {
                return -1;
            }

            if (!y.Suit.Equals(_leadSuit))
            {
                return 1;
            }

            return Math.Sign(x.Rank.AsEnum() - y.Rank.AsEnum());
        }
    }
}