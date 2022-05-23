using System.Collections.Generic;

namespace DataLayer.API
{
    public interface ICatalog
    {
        public Dictionary<int, IClothes> Products { get; set; }
    }
}
