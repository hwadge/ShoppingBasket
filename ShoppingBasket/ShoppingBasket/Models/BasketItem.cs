﻿namespace ShoppingBasket.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public int BasketId { get; set; }
    }
}
