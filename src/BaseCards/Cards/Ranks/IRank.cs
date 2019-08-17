using System;

namespace BaseCards.Cards.Ranks
{
    /// <summary>
    /// Represents the rank of a card
    /// </summary>
    public interface IRank: IEquatable<IRank>
    {        
        /// <summary>
        /// A string representation of the rank
        /// </summary>
        /// <returns>The string that represents a suit</returns>
        string ToString();

        /// <summary>
        /// An enum representation of the rank
        /// </summary>
        /// <returns><see cref="RankEnum"/></returns>
        RankEnum AsEnum();
    }
}