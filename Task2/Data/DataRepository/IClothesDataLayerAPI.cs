using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.API;
using System.Threading.Tasks;

namespace Data.DataRepository;

public interface IClothesDataLayerAPI
{
    bool AddClothes(int clothes_id, int clothes_price, string clothes_type);

    bool DeleteClothes(int clothes_id);

    bool Update(int clothes_id, int clothes_price, string clothes_type);
        
    IClothes GetClothes(int clothes_id);
    IEnumerable<IClothes> GetAllClothes();

}