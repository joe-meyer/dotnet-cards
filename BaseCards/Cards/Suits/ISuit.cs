using System;

namespace BaseCards.Cards.Suits
{
    /// <summary>
    /// Represents the suit of a card
    /// </summary>
    public interface ISuit : IEquatable<ISuit>
    {
        /// <summary>
        /// A string representation of the suit
        /// </summary>
        /// <returns>The string that represents a suit</returns>
        char AsCharacter();

        /// <summary>
        /// An enum representation of the suit
        /// </summary>
        /// <returns><see cref="SuitEnum"/></returns>
        SuitEnum AsEnum();

        /// <summary>
        /// The "next" suit / suit of similar color
        /// </summary>
        /// <returns>The "next" <see cref="SuitEnum"/></returns>
        SuitEnum NextSuit();
    }
}