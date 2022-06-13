namespace Model.API;

public interface IClothesModelData
{
    public int Id { get; }
    public int Price { get; set; }
    public string Type { get; set; }
}