// See https://aka.ms/new-console-template for more information

using DomainDrivenDesign.Ordering;
using DomainDrivenDesign.Ordering.Models;

var items = new List<Item>
{
    new Item { Id = Guid.NewGuid(), Name = "Burger", Price = 10 },
    new Item { Id = Guid.NewGuid(), Name = "Fries", Price = 10 },
};

var service = new OrderService();
var order = service.CreateOrder(.1m, items);

Console.WriteLine("Order created, total: {0:C}", order.Total);

var burger = items.First();

service.RemoveItem(order.Id, burger.Id);

Console.WriteLine("Burger removed, total: {0:C}", order.Total);

Console.ReadKey();
