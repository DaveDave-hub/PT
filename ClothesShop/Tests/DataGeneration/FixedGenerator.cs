using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace Tests.DataGeneration
{
    public class FixedGenerator : IGenerator
    {

        public void GenerateData(DataContext data)
        {
            Client c1 = new Client("James", "Bond", "1");
            data.clients.Add(c1);
            Client c2 = new Client("Hermione", "Granger", "2");
            data.clients.Add(c2);
            Client c3 = new Client("Kamil", "Stoch", "3");
            data.clients.Add(c3);
            Client c4 = new Client("Agnieszka", "Osiecka", "4");
            data.clients.Add(c3);


            Clothes cl1 = new Clothes(1, 70, ClothesType.hoodie);
            data.catalog.products.Add(1, cl1);
            Clothes cl2 = new Clothes(2, 45, ClothesType.tshirt);
            data.catalog.products.Add(2, cl2);

            data.shop.catalog = data.catalog;

            for(int i = 1; i <= data.catalog.products.Count; i++)
            {
                data.shop.inventory.Add(data.catalog.products[i].Id, 10);
            }



        }
    }
}
