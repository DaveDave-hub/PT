using System.Collections.Generic;
using Services.API;

namespace Model.API;

public interface IClothesModel
{
    IClothesLogic Logic { get; }
    IEnumerable<IClothesModelData> Clothes { get; } 
    bool Add(int id, int price, string type);
    bool Delete(int id);
    bool Update(int id, int price, string type);
}