﻿namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        // klucz obcy
        public virtual int AddressId { get; set; }
        // właściwość nawigacyjna
        public virtual Address Address { get; set; }
        // właściwość nawigacyjna
        public virtual List<Dish> Dishes { get; set; }
    }
}
