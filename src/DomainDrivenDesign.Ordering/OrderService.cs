using DomainDrivenDesign.Ordering.Models;

namespace DomainDrivenDesign.Ordering
{
    public class OrderService
    {
        private readonly Dictionary<Guid, Order> _db;

        public OrderService()
        {
            _db = new Dictionary<Guid, Order>();
        }

        public Order CreateOrder(decimal taxRate, IEnumerable<Item> items)
        {
            var order = Order.Create(taxRate);

            foreach (var item in items)
            {
                // Use extension method to add and calc totals
                order.AddItem(item);
            }


            _db.Add(order.Id, order);

            return order;
        }

        public Order RemoveItem(Guid orderId, Guid itemId)
        {
            if (!_db.ContainsKey(orderId))
                throw new ArgumentException("Invalid order id");

            var order = _db[orderId];
            order.RemoveItem(itemId);

            return order;
        }
    }
}
