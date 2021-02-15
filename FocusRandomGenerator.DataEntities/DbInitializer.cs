

namespace FocusRandomGenerator.DataEntities
{
    using System.Linq;
    public static class DbInitializer
    {
        public static void Initialize(RandomNumberDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any ColorCoding.
            if (context.ColorCoding.Any())
            {
                return;   // DB has been seeded
            }

            var colorCodings = new ColorCoding[]
                {
                     new ColorCoding {
                    Color = "Grey",
                     LowerLimit =1,
                      UpperLimit= 9
                },
                 new ColorCoding
                 {
                     Color = "Blue",
                     LowerLimit = 10,
                     UpperLimit = 19
                 },
                  new ColorCoding
                  {
                      Color = "Pink",
                      LowerLimit = 20,
                      UpperLimit = 29
                  },
                   new ColorCoding
                   {
                       Color = "Green",
                       LowerLimit = 30,
                       UpperLimit = 39
                   },
                   new ColorCoding
                   {
                       Color = "Yellow",
                       LowerLimit = 40,
                       UpperLimit = 49
                   }
                };

            foreach (ColorCoding cc in colorCodings)
            {
                context.ColorCoding.Add(cc);
            }
            context.SaveChanges();
        }
    }
}
