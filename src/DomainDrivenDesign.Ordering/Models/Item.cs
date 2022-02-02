﻿namespace DomainDrivenDesign.Ordering.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
