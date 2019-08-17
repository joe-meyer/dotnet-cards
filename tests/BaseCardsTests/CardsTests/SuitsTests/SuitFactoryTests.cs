using BaseCards.Cards.Suits;
using Xunit;

namespace BaseCardsTests.CardsTests.SuitsTests
{
    public class SuitFactoryTests
    {
        [Theory]
        [InlineData(SuitEnum.Clubs, '♣')]
        [InlineData(SuitEnum.Hearts, '♥')]
        [InlineData(SuitEnum.Spades, '♠')]
        [InlineData(SuitEnum.Diamonds, '♦')]
        public void GetSuit_SuitWithCorrectCharactersGenerated(SuitEnum suit, char expectedChar)
        {
            var factory = ConstructSuitFactory();

            var character = factory.GetSuit(suit).AsCharacter();

            Assert.Equal(expectedChar.ToString(), character.ToString());
        }

        [Fact]
        public void GetSuit_UnmatchedSuitEnum_ReturnsNull()
        {
            var factory = ConstructSuitFactory();

            var suit = factory.GetSuit((SuitEnum) 99);
            
            Assert.Null(suit);
        }

        private SuitFactory ConstructSuitFactory()
        {
            return new SuitFactory();
        }
    }
}