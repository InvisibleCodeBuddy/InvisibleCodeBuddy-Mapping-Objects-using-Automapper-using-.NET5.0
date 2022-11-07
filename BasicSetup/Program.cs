using AutoMapper;
using System;
using System.Collections.Generic;

namespace BasicCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make mapper configuration with source and destination type, left is source, right is destination
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            //create mapper
            var mapper = config.CreateMapper();  // or   var mapper = new Mapper(config);


            //create source object
            var source = new Source { Value = 12 };

            //get destination object using mapper
            Destination destination = mapper.Map<Destination>(source);

            if (destination.Value.Equals(source.Value))
            {
                Console.WriteLine("Mapped successfully!");
            }

            /// <summary>
            /// *** Array and List ***
            /// AutoMapper only requires configuration of element types, not of any array or list type that might be used. 
            /// All the basic generic collection types are supported.
            /// To be specific, the source collection types supported include:
            //      * IEnumerable
            //      * IEnumerable\<T\>
            //      * ICollection
            //      * ICollection\<T\>
            //      * IList
            //      * IList\<T\>
            //      * List\<T\>
            //      * Arrays
            /// </summary>
            var sources = new[]
                {
                new Source { Value = 5 },
                new Source { Value = 6 },
                new Source { Value = 7 }
            };

            IEnumerable<Destination> ienumerableDest = mapper.Map<Source[], IEnumerable<Destination>>(sources);
            ICollection<Destination> icollectionDest = mapper.Map<Source[], ICollection<Destination>>(sources);
            IList<Destination> ilistDest = mapper.Map<Source[], IList<Destination>>(sources);
            List<Destination> listDest = mapper.Map<Source[], List<Destination>>(sources);
            Destination[] arrayDest = mapper.Map<Source[], Destination[]>(sources);


        }
    }

    /// <summary>
    /// source type
    /// </summary>
    public class Source
    {
        /// <summary>
        /// source member property
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    /// destination type
    /// </summary>
    public class Destination
    {
        /// <summary>
        /// a property having same name as source member
        /// </summary>
        public int Value { get; set; }
    }
}
