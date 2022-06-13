using System.Collections.Generic;
using Model.API;
using Services;
using Services.API;

namespace Model;

public class ClothesModel
{
    private IClothesLogic Logic { get; }

    public ClothesModel(IClothesLogic logic = default)
    {
        Logic = logic ?? new ClothesLogic();
    }

    public IEnumerable<IClothesModelData> Clothes
    {
        get
        {
            List<IClothesModelData> clients = new();
            foreach (var c in Logic.GetAllClothes())
            {
                clients.Add(new ClothesModelData(c.Id, c.Price, c.Type));
            }
            return clients;
        }
    }

    public bool Add(int id, int price, string type)
    {
        return Logic.AddClothes(id, price, type);
    }

    public bool Delete(int id)
    {
        return Logic.DeleteClothes(id);
    }

    public bool Update(int id, int price, string type)
    {
        return Logic.UpdateClothes(id, price, type);
    }
}