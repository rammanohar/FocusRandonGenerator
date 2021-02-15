
namespace Focus.RandomGenerator.DataEntityInterface
{
    using FocusRandomGenerator.DataEntities;
    using System.Collections.Generic;
    public interface IRandomNumberRepository
    {
        /// <summary>
        /// Get the List of random numbers
        /// </summary>
        /// <returns></returns>
        List<RandomNumber> GetAllRandomNumber();

        /// <summary>
        /// Save randomNumber
        /// </summary>
        /// <param name="randomNumber"></param>
        bool SaveRandomNumber(RandomNumber randomNumber);

        /// <summary>
        /// Save random Number
        /// </summary>
        /// <returns></returns>
        List<ColorCoding> GetColorCoding();
    }
}
