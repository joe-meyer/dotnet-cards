namespace BaseCards.Cards.Suits
{
    /// <summary>
    /// Factory used to create a suit
    /// </summary>
    public class SuitFactory
    {
        /// <summary>
        /// Creates a new ISuit instance
        /// </summary>
        /// <param name="suit"><see cref="SuitEnum"/></param>
        /// <returns>An instance of ISuit for the given enum</returns>
        public ISuit GetSuit(SuitEnum suit)
        {
            switch (suit)
            {                
                case SuitEnum.Diamonds:
                    return new Suit('♦', suit, SuitEnum.Hearts);
                case SuitEnum.Clubs:
                    return new Suit('♣', suit, SuitEnum.Spades);
                case SuitEnum.Hearts:
                    return new Suit('♥', suit, SuitEnum.Diamonds);
                case SuitEnum.Spades:
                    return new Suit('♠', suit, SuitEnum.Clubs);
            }

            return null;
        }
    }
}