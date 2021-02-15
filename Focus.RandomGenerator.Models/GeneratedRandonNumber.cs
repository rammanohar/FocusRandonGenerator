
namespace Focus.RandomGenerator.Models
{
    using System;
    using System.Collections.Generic;

    public class GeneratedRandonNumber
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Gets or Sets RandonNumbers
        /// </summary>
        public List<NumberInfo> RandonNumbers { get; set; }


        /// <summary>
        /// Gets or Sets GeneratorDateTime
        /// </summary>
        public DateTime GeneratorDateTime { get; set; }
    }
}
