using System.Collections.Generic;
using Data.API;
using Data.DataRepository;
using Services.API;

namespace Services;

public class ClothesLogic : IClothesLogic
{
    private readonly IClothesDataLayerAPI dataAPI;

    public ClothesLogic(IClothesDataLayerAPI dataLayerAPI = default)
    {
        dataAPI = dataLayerAPI ?? new ClothesCRUD();
    }

    private IClothesData Transform(IClothes clothes)
    {
        return new ClothesData(clothes.Id, clothes.Price, clothes.Type);
    }

    public bool AddClothes(int clothes_id, int clothes_price, string clothes_type)
    {
        return dataAPI.AddClothes(clothes_id, clothes_price, clothes_type);
    }

    public bool DeleteClothes(int clothes_id) 
    { 
        return dataAPI.DeleteClothes(clothes_id);
    }

    public bool UpdateClothes(int clothes_id, int clothes_price, string clothes_type)
    {
        return dataAPI.Update(clothes_id, clothes_price, clothes_type);
    }
    
    public IClothesData GetClothes(int clothes_id)
    {
        return Transform(dataAPI.GetClothes(clothes_id));
    }

    public IEnumerable<IClothesData> GetAllClothes()
    {
        List<IClothesData> clothes = new();

        foreach (IClothes clothes1 in dataAPI.GetAllClothes())
        {
            clothes.Add(Transform(clothes1));
        }

        return clothes;
    }

}

