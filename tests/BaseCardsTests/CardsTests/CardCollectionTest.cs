using System;
using System.Collections.Generic;
using System.Linq;
using BaseCards.Cards;
using BaseCards.Cards.Ranks;
using Xunit;

namespace BaseCardsTests.CardsTests
{
    public class CardCollectionTest
    {
        private static readonly Random Random = new Random();
        
        [Fact]
        public void Shuffle_CardsAreNotInSameOrder()
        {
            var randomRanks = GenerateRandomRankEnums(12);
            var cards = new CardCollection();
            foreach (var randomRank in randomRanks)
            {
                cards.Add(new Card(new Rank(randomRank, ""), null));
            }
            
            cards.Shuffle();
            
            Assert.NotEqual(randomRanks, cards.Select(c => c.Rank.AsEnum()));
        }

        private List<RankEnum> GenerateRandomRankEnums(int numberOfItems)
        {
            var enums = new List<RankEnum>()
            {
                RankEnum.Ace,
                RankEnum.King,
                RankEnum.Queen,
                RankEnum.Jack,
                RankEnum.Ten,
                RankEnum.Nine
            };

            var list = new List<RankEnum>();

            for (var i = 0; i < numberOfItems; i++)
            {
                list.Add(enums[Random.Next(enums.Count-1)]);
            }

            return list;
        }
    }
}