using AutoMapper;
using System;

namespace Flattening
{
    /// <summary>
    /// One of the common usages of object-object mapping is to take a complex object model and flatten it to a simpler model.
    /// </summary>
    internal class Flatten
    {
        static void Main(string[] args)
        {
            // Complex model
            var customer = new Customer
            {
                Name = "George Costanza"
            };
            var order = new Order
            {
                Customer = customer
            };
            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };
            order.AddOrderLineItem(bosco, 15);

            // Configure AutoMapper
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());
            var mapper = configuration.CreateMapper();

            // Perform mapping
            OrderDto dto = mapper.Map<Order, OrderDto>(order);
            if( dto.CustomerName.Equals("George Costanza") && dto.Total.Equals(74.85m))
            {
                Console.WriteLine("Flattening Mapped successfully!");
            }
        }
    }
}
