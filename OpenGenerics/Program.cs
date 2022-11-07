using AutoMapper;
using System;

namespace OpenGenerics
{
    /// <summary>
    /// AutoMapper can support an open generic type map.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the mapping
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap(typeof(Source<>), typeof(Destination<>)));
            var mapper = configuration.CreateMapper();

            var source = new Source<int> { Value = 10 };

            var dest = mapper.Map<Source<int>, Destination<int>>(source);

            if (dest.Value.Equals(10))
            {
                Console.WriteLine("OpenGeneric succeeded!");
            }
        }
    }

    public class Source<T>
    {
        public T Value { get; set; }
    }

    public class Destination<T>
    {
        public T Value { get; set; }
    }
}
