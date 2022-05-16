using System.Collections.Generic;

namespace DataLayer.API
{
    internal interface ICatalog
    {
        internal Dictionary<int, IClothes> products { get; set; }
    }
}
