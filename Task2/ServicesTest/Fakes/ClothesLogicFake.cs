using System.Collections.Generic;
using Services;
using Services.API;

namespace ServicesTest.Fakes;

public class ClothesLogicFake : IClothesLogic
{
    private List<IClothesData> clothes = new();

    public IEnumerable<IClothesData> GetAllClothes()
    {
        return clothes;
    }

    public IClothesData GetClothes(int clothes_id)
    {
        return clothes.Find(x => x.Id == clothes_id);
    }

    public bool AddClothes(int clothes_id, int clothes_price, string clothes_type)
    {
        if (GetClothes(clothes_id) != null) return false; 
        clothes.Add(new ClothesData(clothes_id, clothes_price, clothes_type));
        return true;
    }

    public bool UpdateClothes(int clothes_id, int clothes_price, string clothes_type)
    {
        var toUpdate = GetClothes(clothes_id);
        if (toUpdate == null) return false;
        clothes.Remove(toUpdate);
        clothes.Add(new ClothesData(clothes_id, clothes_price, clothes_type));
        return true;
    }

    public bool DeleteClothes(int clothes_id)
    {
        if (GetClothes(clothes_id) == null) return false; 
        clothes.Remove(clothes.Find(x => x.Id == clothes_id));
        return true;
    }
}