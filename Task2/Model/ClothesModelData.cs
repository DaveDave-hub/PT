using Model.API;

namespace Model;

public class ClothesModelData : IClothesModelData
{
    public int Id { get; }
    public int Price { get; set; }
    public string Type { get; set; }
    
    public ClothesModelData(int id, int price, string type)
    {
        Id = id;
        Price = price;
        Type = type;
    }

}