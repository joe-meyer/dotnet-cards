using BaseCards.Cards.Ranks;
using Xunit;

namespace BaseCardsTests.CardsTests.RanksTests
{
    public class RankFactoryTests
    {
        [Theory]
        [InlineData(RankEnum.Ace, "A")]
        [InlineData(RankEnum.King, "K")]
        [InlineData(RankEnum.Queen, "Q")]
        [InlineData(RankEnum.Jack, "J")]
        [InlineData(RankEnum.Ten, "10")]
        [InlineData(RankEnum.Nine, "9")]
        public void GetRank_RankWithCorrectStringGenerated(RankEnum rank, string expectedChar)
        {
            var factory = ConstructFactory();

            var s = factory.GetRank(rank).ToString();

            Assert.Equal(expectedChar, s);
        }

        [Fact]
        public void GetSuit_UnmatchedSuitEnum_ReturnsNull()
        {
            var factory = ConstructFactory();

            var suit = factory.GetRank((RankEnum) 99);
            
            Assert.Null(suit);
        }

        private RankFactory ConstructFactory()
        {
            return new RankFactory();
        }
    }
}