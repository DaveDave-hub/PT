using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;

namespace Tests.DataGeneration
{
    public class FixedGenerator : IGenerator
    {

        public void GenerateData(DataLayerAPI data)
        {
            data.AddClient("James", "Bond", 1);
            data.AddClient("Hermione", "Granger", 2);
            data.AddClient("Kamil", "Stoch", 3);
            data.AddClient("Agnieszka", "Osiecka", 4);

            data.AddClothes(1, 70, "hoodie");
            data.AddClothes(2, 45, "tshirt");

            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(1, 10);
            dict.Add(2, 10);

            data.AddStateWithCurrentCatalog(1, dict);

        }
    }
}
