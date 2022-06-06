using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Model
{
    public class ClothesModel
    {

        public ClothesModel()
        {
        }

        public int id { get; set; }
        public decimal price { get; set; }
        public string type { get; set; }

        public void Converter(Dictionary<String, String> clothesInfo)
        {
            id = Int32.Parse(clothesInfo["id"]);
            price = Decimal.Parse(clothesInfo["price"]);
            type = clothesInfo["type"];
        }
    }
}
