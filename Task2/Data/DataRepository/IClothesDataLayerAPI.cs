using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.API;
using System.Threading.Tasks;

namespace Data.DataRepository
{
    public interface IClothesDataLayerAPI
    {
        bool addClothes(int clothes_id, decimal clothes_price, string clothes_type);

        bool deleteClothes(int clothes_id);

        bool updatePrice(int clothes_id, decimal clothes_price);

        bool updateType(int clothes_id, string clothes_type);
        IClothes GetClothes(int clothes_id);
        IEnumerable<IClothes> GetAllClothes();

    }
}
