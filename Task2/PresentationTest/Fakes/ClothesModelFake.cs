using System.Collections.Generic;
using Model;
using Model.API;
using Services.API;

namespace PresentationTest.Fakes;

public class ClothesModelFake : IClothesModel
{
    private List<IClothesModelData> clothes = new();
    
    public IClothesLogic Logic { get; }
    public IEnumerable<IClothesModelData> Clothes => clothes;
    public bool Add(int id, int price, string type)
    {
        if (clothes.Exists(x => x.Id == id)) return false;
        clothes.Add(new ClothesModelData(id, price, type));
        return true;
    }

    public bool Delete(int id)
    {
        if (!clothes.Exists(x => x.Id == id)) return false;
        clothes.Remove(clothes.Find(x => x.Id == id));
        return true;
    }

    public bool Update(int id, int price, string type)
    {
        if (!clothes.Exists(x => x.Id == id)) return false;
        clothes.Remove(clothes.Find(x => x.Id == id));
        clothes.Add(new ClothesModelData(id, price, type));
        return true;
    }
}