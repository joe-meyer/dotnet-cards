using BaseCards.Cards;
using BaseCards.Cards.Comparers;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;
using Xunit;

namespace BaseCardsTests.CardsTests.ComparersTests
{
    public class NoTrumpHandSorterTests
    {

        [Fact]
        public void Compare_FirstCardNull_SortsLow()
        {
            var card = new Card(null, null);
            
            var comparer = new NoTrumpHandSorter(true, true);

            var result = comparer.Compare(null, card);

            Assert.Equal(-1, result);
        }
        
        [Fact]
        public void Compare_SecondCardNull_SortsHigh()
        {
            var card = new Card(null, null);
            
            var comparer = new NoTrumpHandSorter(true, true);

            var result = comparer.Compare(card, null);

            Assert.Equal(1, result);
        }
        
        [Theory]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ace, 0)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.King, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Queen, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Jack, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ten, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Nine, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Queen, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Jack, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Ten, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Nine, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Jack, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Ten, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Nine, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, RankEnum.Nine, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, -1)]
        public void Compare_AscendingSuitAscendingRank(SuitEnum card1Suit, RankEnum card1Rank, SuitEnum card2Suit,
            RankEnum card2Rank, int expectedCompareValue)
        {
            var card1 = new Card(
                new Rank(card1Rank, null), 
                new Suit(' ', card1Suit, SuitEnum.Unknown)
                );
            var card2 = new Card(
                new Rank(card2Rank, null), 
                new Suit(' ', card2Suit, SuitEnum.Unknown)
                );

            var comparer = new NoTrumpHandSorter(true, true);
            var comparison = comparer.Compare(card1, card2);
            
            Assert.Equal(expectedCompareValue, comparison);
        }
        
        [Theory]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ace, 0)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.King, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Queen, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Jack, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ten, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Nine, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Queen, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Jack, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Ten, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Nine, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Jack, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Ten, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Nine, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, RankEnum.Nine, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, 1)]
        public void Compare_DescendingSuitDescendingRank(SuitEnum card1Suit, RankEnum card1Rank, SuitEnum card2Suit,
            RankEnum card2Rank, int expectedCompareValue)
        {
            var card1 = new Card(
                new Rank(card1Rank, null), 
                new Suit(' ', card1Suit, SuitEnum.Unknown)
                );
            var card2 = new Card(
                new Rank(card2Rank, null), 
                new Suit(' ', card2Suit, SuitEnum.Unknown)
                );

            var comparer = new NoTrumpHandSorter(false, false);
            var comparison = comparer.Compare(card1, card2);
            
            Assert.Equal(expectedCompareValue, comparison);
        }
    }
}