using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.API;

namespace Tests.DataGeneration
{
    public class RandomGenerator : IGenerator
    {

        public void GenerateData(DataLayerAPI data)
        {
            for (int i = 1; i <= 9; i++)
            {
                data.AddClothes(i, randomPrice(5.00, 15.90), randomClothesType());
                data.AddClient(GenerateRandomString(6), GenerateRandomString(13), i);
            }

        }

        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public String randomClothesType()
        {
            String[] values = new String[5] { "trousers", "tshirt", "hoodie", "sneakers", "dress" };
            String randomClothesType = (string)values.GetValue(random.Next(values.Length));
            return randomClothesType;
        }

        public double randomPrice(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }


    }
}
