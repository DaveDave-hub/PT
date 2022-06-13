namespace Services.API;

public interface IClothesData
{
        int Id { get; }
        int Price { get; set; }
        string Type { get; set; }
}

