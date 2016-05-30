using System;

namespace NH.Lab.Market.WebApi.Models
{
    public class ProductDTO
    {
        public Guid Id { get; internal set; }
        public string Name { get; set; }
        public string MarketDescrip { get; set; }
    }
}