using DataLayer;
using System;

namespace DataLayer
{
    public class Clothes
    {

        public Clothes(int Id, double Price, ClothesType Type)
        {
            this.Id = Id;
            this.Price = Price;
            this.Type = Type;

        }

        public int Id { get; set; }
        public double Price { get; set; }

        public ClothesType Type { get; set; }
    }
}