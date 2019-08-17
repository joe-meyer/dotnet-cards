using System.Collections.Generic;
using BaseCards.Cards;
using BaseCards.Cards.Decks;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;
using Xunit;

namespace BaseCardsTests.CardsTests.DecksTests
{
    public class DeckFactoryTests
    {
        [Fact]
        public void TurnUpDeck_ContainsExpectedCards()
        {
            var deck = BuildNineThroughAceOfEachSuit();

            var builtDeck = BuildDeckFactory().BuildDeck(DeckEnum.TurnUp);
            
            Assert.Equal(deck, builtDeck);
        }
        
        [Fact]
        public void PinochleDeck_ContainsExpectedCards()
        {
            var deck = BuildNineThroughAceOfEachSuit();
            deck.AddRange(BuildNineThroughAceOfEachSuit());

            var builtDeck = BuildDeckFactory().BuildDeck(DeckEnum.Pinochle);
            
            Assert.Equal(deck, builtDeck);
        }

        [Fact]
        public void UnknownDeck_ReturnsNull()
        {
            Assert.Null(BuildDeckFactory().BuildDeck((DeckEnum) 99));
        }

        private DeckFactory BuildDeckFactory()
        {
            return new DeckFactory(new SuitFactory(), new RankFactory());
        }
        
        private CardCollection BuildNineThroughAceOfEachSuit()
        {
            var suitFactory = new SuitFactory();
            var rankFactory = new RankFactory();
            var nineThroughAces = new List<IRank>
            {
                rankFactory.GetRank(RankEnum.Ace),
                rankFactory.GetRank(RankEnum.King),
                rankFactory.GetRank(RankEnum.Queen),
                rankFactory.GetRank(RankEnum.Jack),
                rankFactory.GetRank(RankEnum.Ten),
                rankFactory.GetRank(RankEnum.Nine),
            };

            var suits = new List<ISuit>
            {
                suitFactory.GetSuit(SuitEnum.Diamonds),
                suitFactory.GetSuit(SuitEnum.Clubs),
                suitFactory.GetSuit(SuitEnum.Hearts),
                suitFactory.GetSuit(SuitEnum.Spades),
            };

            var cardCollection = new CardCollection();
            foreach (var suit in suits)
            {
                foreach (var rank in nineThroughAces)
                {
                    cardCollection.Add(new Card(rank, suit));
                }
            }

            return cardCollection;
        }
    }
}