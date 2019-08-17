using BaseCards.Cards;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;
using Xunit;

namespace BaseCardsTests.CardsTests
{
    public class CardTests
    {
        [Fact]
        public void SuitGetter_MatchesConstructor()
        {
            var rank = new Rank(0, null);
            var suit = new Suit(' ', 0, 0);
            var card = new Card(rank, suit);
            
            Assert.Equal(suit, card.Suit);
        }
        
        [Fact]
        public void RankGetter_MatchesConstructor()
        {
            var rank = new Rank(0, null);
            var suit = new Suit(' ', 0, 0);
            var card = new Card(rank, suit);
            
            Assert.Equal(rank, card.Rank);
        }
        
        [Fact]
        public void CardEqual_CompareNullObject_False()
        {
            var card = new Card(null, null);
            var isEqual = card.Equals(null);
            Assert.False(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareSameCastToObject_True()
        {
            var card = new Card(null, null);
            var isEqual = card.Equals(card);
            Assert.True(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareDifferentTypeObjects_False()
        {
            var card = new Card(null, null);
            var isEqual = card.Equals("Test");
            Assert.False(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareInheritedObjectWithSameBase_True()
        {
            var card = new Card(null, null);
            var inheritedCard = new InheritedCard(null, null);
            var isEqual = card.Equals((object) inheritedCard);
            Assert.True(isEqual);
        }

        [Fact]
        public void GetHashCode_SameObjectsAreEqual()
        {
            var cardObject = new Card(null, null);
            
            Assert.Equal(cardObject.GetHashCode(), cardObject.GetHashCode());
        }

        public class InheritedCard : Card
        {
            public InheritedCard(IRank rank, ISuit suit) : base(rank, suit)
            {
            }
        }
    }
}