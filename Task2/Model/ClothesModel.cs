using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public class ClothesModel
    {
        public ClothesModel()
        {

        }

        public int clothes_id { get; set; }
        public double clothes_price { get; set; }
        public string clothes_type { get; set; }

        public void Converter(Dictionary<String, String> clothesInfo)
        {
            clothes_id = Int32.Parse(clothesInfo["id"]);
            clothes_price = Double.Parse(clothesInfo["price"]);
            clothes_type = clothesInfo["type"];
        }
    }
}
