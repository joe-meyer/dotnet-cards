namespace BaseCards.Cards.Ranks
{
    /// <summary>
    /// Factory for creating IRank instances
    /// </summary>
    public class RankFactory
    {
        /// <summary>
        /// Builds a Rank object for a given Enum
        /// </summary>
        /// <param name="rankEnum">The Rank Enum to generate the rank for</param>
        /// <returns><see cref="IRank"/></returns>
        public IRank GetRank(RankEnum rankEnum)
        {
            switch (rankEnum)
            {
                case RankEnum.Nine:
                    return new Rank(rankEnum, "9");
                case RankEnum.Ten:
                    return new Rank(rankEnum, "10");
                case RankEnum.Jack:
                    return new Rank(rankEnum, "J");
                case RankEnum.Queen:
                    return new Rank(rankEnum, "Q");
                case RankEnum.King:
                    return new Rank(rankEnum, "K");
                case RankEnum.Ace:
                    return new Rank(rankEnum, "A");
                default:
                    return null;
            }
        }
    }
}