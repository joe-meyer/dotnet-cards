using System.Collections.Generic;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;

namespace BaseCards.Cards.Decks
{
    public class DeckFactory
    {
        private readonly SuitFactory _suitFactory;
        private readonly RankFactory _rankFactory;

        public DeckFactory(SuitFactory suitFactory, RankFactory rankFactory)
        {
            _suitFactory = suitFactory;
            _rankFactory = rankFactory;
        }
        
        /// <summary>
        /// Used to create a deck for the specified type
        /// </summary>
        /// <param name="deck">The type of deck to generate</param>
        /// <returns><see cref="CardCollection"/></returns>
        public CardCollection BuildDeck(DeckEnum deck)
        {
            switch (deck)
            {
                case DeckEnum.TurnUp:
                    return BuildNineThroughAceOfEachSuit();
                case DeckEnum.Pinochle:
                    var pinochleDeck = BuildNineThroughAceOfEachSuit();
                    pinochleDeck.AddRange(BuildNineThroughAceOfEachSuit());
                    return pinochleDeck;
                default:
                    return null;
            }
        }

        private CardCollection BuildNineThroughAceOfEachSuit()
        {
            var nineThroughAces = new List<IRank>
            {
                _rankFactory.GetRank(RankEnum.Ace),
                _rankFactory.GetRank(RankEnum.King),
                _rankFactory.GetRank(RankEnum.Queen),
                _rankFactory.GetRank(RankEnum.Jack),
                _rankFactory.GetRank(RankEnum.Ten),
                _rankFactory.GetRank(RankEnum.Nine),
            };

            var suits = new List<ISuit>
            {
                _suitFactory.GetSuit(SuitEnum.Diamonds),
                _suitFactory.GetSuit(SuitEnum.Clubs),
                _suitFactory.GetSuit(SuitEnum.Hearts),
                _suitFactory.GetSuit(SuitEnum.Spades),
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