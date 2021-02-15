namespace Focus.RandomGenerator.Service
{
    using Focus.RandomGenerator.DataEntityInterface;
    using Focus.RandomGenerator.Models;
    using FocusRandomGenerator.DataEntities;
    using FocusRandomGenerator.Interface;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    /// <summary>
    /// RandomNumberService
    /// </summary>
    public class RandomNumberService : IRandomNumberService
    {

        private readonly IRandomNumberRepository randomNumberRepository;

        /// <summary>
        /// IRandomNumberRepository
        /// </summary>
        /// <param name="randomNumberRepository"></param>
        public RandomNumberService(IRandomNumberRepository randomNumberRepository)
        {
            this.randomNumberRepository = randomNumberRepository;
        }
        /// <summary>
        /// RandonNumberLimit
        /// </summary>
        private readonly int RandonNumberLimit = 49;

        public IEnumerable<ColorRanges> GetColorRanges()
        {
            var colorranges = randomNumberRepository.GetColorCoding();

            return colorranges.Select(c => new ColorRanges
            {
                Id = c.Id,
                Color = c.Color,
                LowerLimit = c.LowerLimit,
                UpperLimit = c.UpperLimit
            }).ToList();
        }

        /// <summary>
        /// Business Rules
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetColorCoding(int value)
        {

            var colorName = this.randomNumberRepository.GetColorCoding().FindLast(c => value >= c.LowerLimit).Color;

            if (string.IsNullOrEmpty(colorName))
            {
                colorName = Color.Black.Name;
            }

            return colorName;
        }

        /// <summary>
        /// RandomGenerator
        /// </summary>
        /// <param name="noOfNumbers"></param>
        /// <returns></returns>
        public int[] RandomGenerator(int noOfNumbers)
        {
            var generatedRandonNumber = RandomGeneratorwithColorCodes(noOfNumbers);
            var onlylist = generatedRandonNumber.RandonNumbers.OrderBy(n => n.Number).Select(s => s.Number).ToArray();

            return onlylist;
        }


        /// <summary>
        /// GetAllRandomNumber
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GeneratedRandonNumber> GetAllRandomNumber()
        {
            return this.randomNumberRepository.GetAllRandomNumber().Select(r => new GeneratedRandonNumber
            { 
                 Id = r.Id,
                  GeneratorDateTime = r.GeneratorDateTime,
                  RandonNumbers =  r.Numbers.Select(n => new Models.NumberInfo { Id = n.Id, Number = n.Number, ColorName = n.ColorCoding.Color }).ToList() 
            }).ToList();
        }



        /// <summary>
        /// RandomGeneratorwithColorCodes
        /// </summary>
        /// <param name="noOfNumbers"></param>
        /// <returns></returns>
        public GeneratedRandonNumber RandomGeneratorwithColorCodes(int noOfNumbers)
        {
            List<Models.NumberInfo> listofNumbers = new List<Models.NumberInfo>();
            var colorCodings = this.randomNumberRepository.GetColorCoding();
            //Generates the Random number
            Random RandomClass = new Random();
            int randomNumber;

            for (int i = 0; i < noOfNumbers; i++)
            {
                do
                {
                    randomNumber = RandomClass.Next(1, RandonNumberLimit);
                }
                while (listofNumbers.Any(n => n.Number == randomNumber));

                var colorInfo = colorCodings.FindLast(c => randomNumber >= c.LowerLimit);
                listofNumbers.Add(new Models.NumberInfo
                {
                    Number = randomNumber,
                    ColorName = colorInfo.Color,
                    ColorId = colorInfo.Id
                }); ;
            }

            //Init the GeneratedRandonNumber
            GeneratedRandonNumber generatedRandonNumber = new GeneratedRandonNumber();
            generatedRandonNumber.GeneratorDateTime = DateTime.Now;

            // orders the random numbers
            generatedRandonNumber.RandonNumbers = listofNumbers.OrderBy(n => n.Number).Select(n => new Models.NumberInfo
            {
                Number = n.Number,
                ColorName = n.ColorName,
                 ColorId = n.ColorId
            }).ToList();

            SaveRandomNumber(generatedRandonNumber);

            return generatedRandonNumber;
        }


        public bool SaveRandomNumber(GeneratedRandonNumber generatedRandonNumber)
        {
           return  this.randomNumberRepository.SaveRandomNumber(new RandomNumber
            {
                GeneratorDateTime = generatedRandonNumber.GeneratorDateTime,
                Numbers = generatedRandonNumber.RandonNumbers.Select(r => new FocusRandomGenerator.DataEntities.NumberInfo
                {
                    Number = r.Number,
                    ColorCodingId = r.ColorId,

                }).ToList(),
            });
        }

    }
}
