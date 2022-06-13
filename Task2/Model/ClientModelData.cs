using Model.API;

namespace Model;

public class ClientModelData : IClientModelData
{
    public int Id { get; }
    public string Name { get; set; }
        
    public ClientModelData(int id, string name)
    {
        Id = id;
        Name = name;
    }
}