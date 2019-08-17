using BaseCards.Cards;
using BaseCards.Cards.Comparers;
using BaseCards.Cards.Ranks;
using BaseCards.Cards.Suits;
using Xunit;

namespace BaseCardsTests.CardsTests.ComparersTests
{
    public class TrumpHandSorterTests
    {

        [Fact]
        public void Compare_FirstCardNull_SortsLow()
        {
            var card = new Card(null, null);
            
            var comparer = new TrumpHandSorter(new Suit(' ', SuitEnum.Diamonds, SuitEnum.Hearts),  true, true);

            var result = comparer.Compare(null, card);

            Assert.Equal(-1, result);
        }
        
        [Fact]
        public void Compare_SecondCardNull_SortsHigh()
        {
            var card = new Card(null, null);
            
            var comparer = new TrumpHandSorter(new Suit(' ', SuitEnum.Diamonds, SuitEnum.Hearts),  true, true);

            var result = comparer.Compare(card, null);

            Assert.Equal(1, result);
        }
        
        [Theory]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, 0)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, 0)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.King, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Queen, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Jack, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ten, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Nine, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        public void Compare_AscendingSuitAscendingRank(SuitEnum card1Suit, RankEnum card1Rank, SuitEnum card2Suit,
            RankEnum card2Rank, SuitEnum trumpSuit, int expectedCompareValue)
        {
            var card1 = new Card(
                new Rank(card1Rank, null), 
                FromFactory(card1Suit)
                );
            var card2 = new Card(
                new Rank(card2Rank, null), 
                FromFactory(card2Suit)
                );

            var comparer = new TrumpHandSorter(FromFactory(trumpSuit), true, true);
            var comparison = comparer.Compare(card1, card2);
            
            Assert.Equal(expectedCompareValue, comparison);
        }
        
        
        [Theory]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, 0)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Jack, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.King, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Queen, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ten, SuitEnum.Diamonds, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Diamonds, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Diamonds, 0)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.King, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Queen, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Jack, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Ten, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Clubs, RankEnum.Nine, SuitEnum.Diamonds, -1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Clubs, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        [InlineData(SuitEnum.Hearts, RankEnum.Ace, SuitEnum.Spades, RankEnum.Ace, SuitEnum.Diamonds, 1)]
        public void Compare_DescendingSuitDescendingRank(SuitEnum card1Suit, RankEnum card1Rank, SuitEnum card2Suit,
            RankEnum card2Rank, SuitEnum trumpSuit, int expectedCompareValue)
        {
            var card1 = new Card(
                new Rank(card1Rank, null), 
                FromFactory(card1Suit)
                );
            var card2 = new Card(
                new Rank(card2Rank, null), 
                FromFactory(card2Suit)
                );

            var comparer = new TrumpHandSorter(FromFactory(trumpSuit), false, false);
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