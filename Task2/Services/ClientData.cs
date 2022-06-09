using Services.API;

namespace Services;

public class ClientData : IClientData
{
    public int Id { get; }
    public string Name { get; set; }
    
    public ClientData(int id, string name)
    {
        Id = id;
        Name = name;
    }
}