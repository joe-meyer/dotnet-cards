using BaseCards.Cards;
using BaseCards.Cards.Comparers;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;
using Xunit;

namespace BaseCardsTests.CardsTests.ComparersTests
{
    public class TrumpComparerTests
    {
        
        [Fact]
        public void Compare_FirstCardNull_SortsLow()
        {
            var card = new Card(null, null);
            
            var comparer = new TrumpComparer(FromFactory(SuitEnum.Clubs), FromFactory(SuitEnum.Clubs));

            var result = comparer.Compare(null, card);

            Assert.Equal(-1, result);
        }
        
        [Fact]
        public void Compare_SecondCardNull_SortsHigh()
        {
            var card = new Card(null, null);
            
            var comparer = new TrumpComparer(FromFactory(SuitEnum.Clubs), FromFactory(SuitEnum.Clubs));

            var result = comparer.Compare(card, null);

            Assert.Equal(1, result);
        }
        
        [Theory]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, SuitEnum.Diamonds, 0)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Spades, RankEnum.Nine, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Clubs, 0)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.King, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Queen, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Jack, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ten, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Nine, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Clubs, 1)]
        [InlineData(SuitEnum.Spades, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Clubs, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, SuitEnum.Clubs, 0)]
        public void Compare_TrumpAndLeadSuit_ExpectedValuesMatch(SuitEnum card1Suit, RankEnum card1Rank, SuitEnum card2Suit,
            RankEnum card2Rank, SuitEnum trumpSuit, SuitEnum leadSuit, int expectedCompareValue)
        {
            var card1 = new Card(
                new Rank(card1Rank, null), 
                FromFactory(card1Suit)
            );
            var card2 = new Card(
                new Rank(card2Rank, null), 
                FromFactory(card2Suit)
            );

            var comparer = new TrumpComparer(FromFactory(trumpSuit), FromFactory(leadSuit));
            var comparison = comparer.Compare(card1, card2);
            
            Assert.Equal(expectedCompareValue, comparison);
        }

        private static ISuit FromFactory(SuitEnum suit)
        {
            var factory = new SuitFactory();
            return factory.GetSuit(suit);
        }
    }
}