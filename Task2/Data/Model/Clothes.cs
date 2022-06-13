using Data.API;

namespace Data.Model;

public class Clothes : IClothes
{
    public int Id { get; }
    public int Price { get; set; }
    public string Type { get; set; }
    
    public Clothes(int id, int price, string type)
    {
        Id = id;
        Price = price;
        Type = type;
    }
}