using System.Collections.Generic;


namespace DataLayer.API
{
    internal class Catalog : ICatalog
    {
        private Dictionary<int, IClothes> Products;


        public Catalog()
        {

        }

        public Catalog(Dictionary<int, IClothes> PRODUCTS)
        {
            Products = PRODUCTS;
        }



        public Dictionary<int, IClothes> products
        {
            get { return Products; }
            set { Products = value; }
        }

    }
}