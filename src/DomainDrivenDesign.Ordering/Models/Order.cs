namespace DomainDrivenDesign.Ordering.Models
{
    public class Order
    {
        public Order()
        {
            this.Items = new List<Item>();
        }

        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxRate { get; set; }
        public ICollection<Item> Items { get; set; }

        public static Order Create(decimal taxRate)
        {
            return new Order()
            {
                Id = Guid.NewGuid(),
                TaxRate = taxRate,
            };
        }
    }
}
