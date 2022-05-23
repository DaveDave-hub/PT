using System.Collections.Generic;

namespace DataLayer.API
{
    internal class Catalog : ICatalog
    {
        public Dictionary<int, IClothes> Products { get; set; } = new Dictionary<int, IClothes>() { };

        public Catalog()
        {
            Products = new Dictionary<int, IClothes>();
        }

        public Catalog(Dictionary<int, IClothes> products)
        {
            Products = products;
        }
    }
}