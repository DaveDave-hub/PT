using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    internal interface IClothes
    {
        int Id { get; set; }
        double Price { get; set; }
        ClothesType ClothesType { get; set; }
    }
}
