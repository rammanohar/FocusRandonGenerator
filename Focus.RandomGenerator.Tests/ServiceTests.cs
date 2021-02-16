namespace Focus.RandomGenerator.Tests
{
    using Focus.RandomGenerator.DataEntityInterface;
    using Focus.RandomGenerator.Models;
    using Focus.RandomGenerator.Service;
    using FocusRandomGenerator.DataEntities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ServiceTests 
    /// </summary>
    [TestClass]
    public class ServiceTests
    {

        IRandomNumberRepository randomNumberRepository;

        [TestInitialize]
        public void Setup()
        {
            //Repositories
            var randomNumberRepository = new Mock<IRandomNumberRepository>();

            List<RandomNumber> ListofRandomNumbers = new List<RandomNumber>()
                { 
                     new RandomNumber{
                         Id = 1,
                         GeneratorDateTime = DateTime.UtcNow,
                          Numbers = new List<FocusRandomGenerator.DataEntities.NumberInfo>{ 
                                                            new FocusRandomGenerator.DataEntities.NumberInfo { Id =1, Number=8, ColorCodingId =1 },
                                                            new FocusRandomGenerator.DataEntities.NumberInfo { Id =1, Number=15, ColorCodingId =2 },
                                                            new FocusRandomGenerator.DataEntities.NumberInfo { Id =1, Number=25, ColorCodingId =3 },
                                                            new FocusRandomGenerator.DataEntities.NumberInfo { Id =1, Number=35, ColorCodingId =4 },
                                                            new FocusRandomGenerator.DataEntities.NumberInfo { Id =1, Number=45, ColorCodingId =5 },
                                                            new FocusRandomGenerator.DataEntities.NumberInfo { Id =1, Number=20, ColorCodingId =3 },
                                                        }

                     }

                };


            List<ColorCoding> listColorCodings = new List<ColorCoding>()
              {
                     new ColorCoding {
                    Id =1,
                    Color = "Grey",
                     LowerLimit =1,
                      UpperLimit= 9
                },
                 new ColorCoding
                 {
                      Id =2,
                     Color = "Blue",
                     LowerLimit = 10,
                     UpperLimit = 19
                 },
                  new ColorCoding
                  {
                       Id =3,
                      Color = "Pink",
                      LowerLimit = 20,
                      UpperLimit = 29
                  },
                   new ColorCoding
                   {
                        Id =4,
                       Color = "Green",
                       LowerLimit = 30,
                       UpperLimit = 39
                   },
                   new ColorCoding
                   {
                       Id =5,
                       Color = "Yellow",
                       LowerLimit = 40,
                       UpperLimit = 49
                   }
              };

            randomNumberRepository.Setup(x => x.GetColorCoding()).Returns(listColorCodings);

            randomNumberRepository.Setup(x => x.GetAllRandomNumbers()).Returns(ListofRandomNumbers);

            randomNumberRepository.Setup(x => x.SaveRandomNumber(It.IsAny<RandomNumber>())).Returns(
              (RandomNumber target) =>
              {
                  ListofRandomNumbers.Add(target);
                  return true;
              });


            this.randomNumberRepository = randomNumberRepository.Object;

        }

        /// <summary>
        /// Test for Generate correct number of numbers
        /// </summary>
        [TestMethod]
        public void TestNoofRandomNumbers()
        {
            int NoofRandomNumbers = 8;
            RandomNumberService testService = new RandomNumberService(this.randomNumberRepository);
            var result = testService.RandomGeneratorwithColorCodes(NoofRandomNumbers);
            Assert.AreEqual(result.RandonNumbers.Count, NoofRandomNumbers);
        }


        /// <summary>
        /// Test for Generate correct number of numbers
        /// </summary>
        [TestMethod]
        public void TestDistinctRandomNumbers()
        {
            int NoofRandomNumners = 6;
            RandomNumberService testService = new RandomNumberService(this.randomNumberRepository);
            var result = testService.RandomGeneratorwithColorCodes(NoofRandomNumners);
            int distinctCount = result.RandonNumbers.Distinct().Count();
            Assert.AreEqual(distinctCount, NoofRandomNumners);
        }


        [TestMethod]
        public void SaveRandomNumberTest()
        {
            var randomNumber = new GeneratedRandonNumber
            {
                Id = 1,
                GeneratorDateTime = DateTime.UtcNow,
                 RandonNumbers= new List<Models.NumberInfo>{
                                                            new Models.NumberInfo { Id =1, Number=6, ColorCodingId =1 },
                                                            new Models.NumberInfo { Id =1, Number=16, ColorCodingId =2 },
                                                            new Models.NumberInfo { Id =1, Number=26, ColorCodingId =3 },
                                                            new Models.NumberInfo { Id =1, Number=36, ColorCodingId =4 },
                                                            new Models.NumberInfo { Id =1, Number=45, ColorCodingId =5 },
                                                            new Models.NumberInfo { Id =1, Number=20, ColorCodingId =3 },
                                                        }

            };
            
            RandomNumberService testService = new RandomNumberService(this.randomNumberRepository);

            var result = testService.SaveRandomNumber(randomNumber);
           
            Assert.AreEqual(result, true);

            var count = this.randomNumberRepository.GetAllRandomNumbers().Count();
           
            Assert.AreEqual(count, 2);
        }
    }
}
