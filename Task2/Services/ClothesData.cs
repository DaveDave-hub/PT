using Services.API;

namespace Services;

    public class ClothesData : IClothesData
    {
    public int Id { get; }
    public int Price { get; set; }
    public string Type { get; set; }

    public ClothesData(int id, int price, string type)
    {
        Id = id;
        Price = price;
        Type = type;
    }
}

