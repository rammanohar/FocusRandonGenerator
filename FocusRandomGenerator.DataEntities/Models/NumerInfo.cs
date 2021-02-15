namespace FocusRandomGenerator.DataEntities
{

    /// <summary>
    /// RandonNumber entity
    /// </summary>
    public class NumberInfo
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets FocusRandomNumber
        /// </summary>
        public int Number { get; set; }


        /// <summary>
        /// Gets or Sets ColorName
        /// </summary>
        public ColorCoding ColorCoding { get; set; }

        /// <summary>
        /// Gets or Sets ColorCodingId
        /// </summary>
        public int ColorCodingId { get; set; }

    }
}
