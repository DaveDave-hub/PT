using Data.API;

namespace Data.Model;

public class Client : IClient
{
    public int Id { get; }
    public string Name { get; set; }
        
    public Client(int id, string name)
    {
        Id = id;
        Name = name;
    }
}