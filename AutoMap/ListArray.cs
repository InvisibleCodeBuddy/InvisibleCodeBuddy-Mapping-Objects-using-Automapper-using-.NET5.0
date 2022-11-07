using AutoMapper;
using System;
using System.Collections.Generic;

namespace AutoMap
{
    /// <summary>
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
    internal class ListArray
    {
        static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());
            var mapper = configuration.CreateMapper();

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

            Console.WriteLine("Arry & List Example...");
        }
    }

    public class Source
    {
        public int Value { get; set; }
    }

    public class Destination
    {
        public int Value { get; set; }
    }
}
