using DomainDrivenDesign.Ordering.Models;

namespace DomainDrivenDesign.Ordering
{
    /// <summary>
    /// Domain logic for order
    /// </summary>
    public static class OrderExtensions
    {
        /// <summary>
        /// Add item to order and calc totals.
        /// </summary>
        /// <param name="order">Current order instance to extend</param>
        /// <param name="item">Item to be added</param>
        public static void AddItem(this Order order, Item item)
        {
            order.Items.Add(item);

            var itemTax = order.TaxRate * item.Price;

            order.Tax += itemTax;
            order.Total += item.Price + itemTax;
        }

        /// <summary>
        /// Remove item from order
        /// </summary>
        /// <param name="order">Current order instance to extend</param>
        /// <param name="itemId">Identifier of item to be removed</param>
        public static void RemoveItem(this Order order, Guid itemId)
        {
            var existing = order.Items.FirstOrDefault(i => i.Id == itemId);
            if (existing == null)
                return;

            var itemTax = order.TaxRate * existing.Price;

            order.Items.Remove(existing);
            order.Tax -= itemTax;
            order.Total -= itemTax + existing.Price;
        }
    }
}
