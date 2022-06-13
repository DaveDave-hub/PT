using Data.API;
using System.Collections.Generic;

namespace Services.API;

public interface IClothesLogic
{
    IEnumerable<IClothesData> GetAllClothes();
    bool AddClothes(int clothes_id, int clothes_price, string clothes_type);
    bool DeleteClothes(int clothes_id);
    bool UpdateClothes(int clothes_id, int clothes_price, string clothes_type);
    IClothesData GetClothes(int clothes_id);

}