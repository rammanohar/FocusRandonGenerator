﻿namespace Focus.RandomGenerator.DataEntitiyRepository
{
    using Focus.RandomGenerator.DataEntityInterface;
    using FocusRandomGenerator.DataEntities;
    using System.Collections.Generic;
    using System.Linq;

    public class RandomNumberRepository : IRandomNumberRepository
    {
        protected readonly RandomNumberDbContext dbContext;


        public RandomNumberRepository(RandomNumberDbContext dbContext) 
        {

            this.dbContext = dbContext;
        }

        public List<ColorCoding> GetColorCoding()
        {
            return dbContext.ColorCoding.ToList();
        }

        public List<RandomNumber> GetAllRandomNumber()
        {

            return dbContext.RandomNumbers.ToList(); 
        }


        public bool SaveRandomNumber(RandomNumber randomNumber)
        {

            dbContext.RandomNumbers.Add(randomNumber);
           
            var success = dbContext.SaveChanges();

            return success > 0;

        }
    }
}
