namespace FocusRandomGenerator.Interface
{
    using Focus.RandomGenerator.Models;
    using System.Collections.Generic;

    /// <summary>
    /// IRandomNumberService
    /// </summary>
    public interface IRandomNumberService
    {
        /// <summary>
        /// RandomGenerator
        /// </summary>
        /// <param name="noOfNumbers"></param>
        /// <returns></returns>
        int[] RandomGenerator(int noOfNumbers);

        /// <summary>
        /// RandomGeneratorwithColorCodes
        /// </summary>
        /// <param name="noOfNumbers"></param>
        /// <returns></returns>
        GeneratedRandonNumber RandomGeneratorwithColorCodes(int noOfNumbers);

        /// <summary>
        /// GetColorCoding
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string GetColorCoding(int value);


        /// <summary>
        /// ColorRanges
        /// </summary>
        /// <returns></returns>
        IEnumerable<ColorRanges> GetColorRanges();


        /// <summary>
        /// Get the List of random numbers
        /// </summary>
        /// <returns></returns>
        IEnumerable<GeneratedRandonNumber> GetAllRandomNumbers();


        /// <summary>
        /// SaveRandomNumber
        /// </summary>
        /// <returns></returns>
        bool SaveRandomNumber(GeneratedRandonNumber generatedRandonNumber);

    }
}
