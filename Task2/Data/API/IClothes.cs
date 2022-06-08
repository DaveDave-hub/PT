using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IClothes
    {
        int Id { get; }
        string Price { get; set; }
        string Type { get; set; }

        }
}
