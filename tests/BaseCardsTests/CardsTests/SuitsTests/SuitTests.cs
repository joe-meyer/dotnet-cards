using BaseCards.Cards.Suits;
using Moq;
using Xunit;

namespace BaseCardsTests.CardsTests.SuitsTests
{
    public class SuitTests
    {
        [Theory]
        [InlineData('♣', '♣', true)]
        [InlineData('♣', '♠', false)]
        public void ISuitEqual_Characters(char firstSuit, char secondSuit, bool expectedEqual)
        {
            var suit1 = new Suit(firstSuit, 0, 0);
            var suit2 = new Suit(secondSuit, 0, 0);

            var areEqual = suit1.Equals(suit2);
            Assert.Equal(expectedEqual, areEqual);
        }
        
        [Theory]
        [InlineData(SuitEnum.Clubs, SuitEnum.Clubs, true)]
        [InlineData(SuitEnum.Hearts, SuitEnum.Diamonds, false)]
        public void ISuitEqual_SuitEnum(SuitEnum firstSuit, SuitEnum secondSuit, bool expectedEqual)
        {
            var suit1 = new Suit(' ', firstSuit, 0);
            var suit2 = new Suit(' ', secondSuit, 0);

            var areEqual = suit1.Equals(suit2);
            Assert.Equal(expectedEqual, areEqual);
        }
        
        [Theory]
        [InlineData(SuitEnum.Clubs, SuitEnum.Clubs, true)]
        [InlineData(SuitEnum.Hearts, SuitEnum.Diamonds, false)]
        public void ISuitEqual_NextSuitEnum(SuitEnum firstSuit, SuitEnum secondSuit, bool expectedEqual)
        {
            var suit1 = new Suit(' ', 0, firstSuit);
            var suit2 = new Suit(' ', 0, secondSuit);

            var areEqual = suit1.Equals(suit2);
            Assert.Equal(expectedEqual, areEqual);
        }

        [Fact]
        public void ISuitEqual_CompareNullObject_False()
        {
            var suit = new Suit(' ', (SuitEnum) 2, (SuitEnum) 4);
            var isEqual = suit.Equals((object) null);
            Assert.False(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareSameCastToObject_True()
        {
            var suit = new Suit(' ', (SuitEnum) 2, (SuitEnum) 4);
            var isEqual = suit.Equals((object) suit);
            Assert.True(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareDifferentTypeObjects_False()
        {
            var suit = new Suit(' ', (SuitEnum) 2, (SuitEnum) 4);
            var isEqual = suit.Equals("Test");
            Assert.False(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareInheritedObjectWithSameBase_True()
        {
            var suit = new Suit(' ', (SuitEnum) 2, (SuitEnum) 4);
            var inheritedSuit = new InheritedSuit(' ', (SuitEnum) 2, (SuitEnum) 4);
            var isEqual = suit.Equals((object) inheritedSuit);
            Assert.True(isEqual);
        }

        [Theory]
        [InlineData('♦', SuitEnum.Diamonds, SuitEnum.Hearts)]
        [InlineData('♥', SuitEnum.Hearts, SuitEnum.Diamonds)]
        [InlineData('♣', SuitEnum.Clubs, SuitEnum.Spades)]
        [InlineData('♠', SuitEnum.Spades, SuitEnum.Clubs)]
        public void GetHashCode_SameObjectsAreEqual(char suitChar, SuitEnum suit, SuitEnum nextSuit)
        {
            var suitObject = new Suit(suitChar, suit, nextSuit);
            
            Assert.Equal(suitObject.GetHashCode(), suitObject.GetHashCode());
        }

        public class InheritedSuit : Suit
        {
            public InheritedSuit(char character, SuitEnum suit, SuitEnum nextSuit) : base(character, suit, nextSuit)
            {
            }
        }
    }
}