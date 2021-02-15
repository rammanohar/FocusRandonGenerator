namespace FocusRandomGenerator.DataEntities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// GeneratedRandonNumber
    /// </summary>
    public class RandomNumber
    {
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Gets or Sets RandonNumbers
        /// </summary>
        public ICollection<NumberInfo> Numbers { get; set; }

        
        /// <summary>
        /// Gets or Sets GeneratorDateTime
        /// </summary>
        public DateTime GeneratorDateTime { get; set; }

    }
}
