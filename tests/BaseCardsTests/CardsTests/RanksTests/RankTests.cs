using BaseCards.Cards.Ranks;
using Xunit;

namespace BaseCardsTests.CardsTests.RanksTests
{
    public class RanksTests
    {
        [Theory]
        [InlineData("9", "9", true)]
        [InlineData("9", "J", false)]
        public void IRankEqual_ToString(string firstRank, string secondRank, bool expectedEqual)
        {
            var rank1 = new Rank((RankEnum)2, firstRank);
            var rank2 = new Rank((RankEnum)2, secondRank);

            var areEqual = rank1.Equals(rank2);
            Assert.Equal(expectedEqual, areEqual);
        }
        
        [Theory]
        [InlineData(RankEnum.Nine, RankEnum.Nine, true)]
        [InlineData(RankEnum.Ten, RankEnum.Ace, false)]
        public void IRankEqual_RankEnum(RankEnum firstRank, RankEnum secondRank, bool expectedEqual)
        {
            var rank1 = new Rank(firstRank, " ");
            var rank2 = new Rank(secondRank, " ");

            var areEqual = rank1.Equals(rank2);
            Assert.Equal(expectedEqual, areEqual);
        }
        
        [Fact]
        public void IRankEqual_CompareNullObject_False()
        {
            var rank = new Rank((RankEnum) 2, " ");
            var isEqual = rank.Equals((object) null);
            Assert.False(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareSameCastToObject_True()
        {
            var rank = new Rank((RankEnum) 2, " ");
            var isEqual = rank.Equals((object) rank);
            Assert.True(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareDifferentTypeObjects_False()
        {
            var rank = new Rank((RankEnum) 2, " ");
            var isEqual = rank.Equals("Test");
            Assert.False(isEqual);
        }

        [Fact]
        public void ObjectEqual_CompareInheritedObjectWithSameBase_True()
        {
            var rank = new Rank((RankEnum) 2, " ");
            var inheritedRank = new InheritedRank((RankEnum) 2, " ");
            var isEqual = rank.Equals((object) inheritedRank);
            Assert.True(isEqual);
        }

        [Fact]
        public void GetHashCode_SameObjectsAreEqual()
        {
            var rankObject = new Rank(RankEnum.Ace, "A");
            
            Assert.Equal(rankObject.GetHashCode(), rankObject.GetHashCode());
        }

        public class InheritedRank : Rank
        {
            public InheritedRank(RankEnum rankEnum, string rankString) : base(rankEnum, rankString)
            {
            }
        }
    }
}