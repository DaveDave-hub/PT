using System.Collections.Generic;
using Model;
using Model.API;
using Services.API;

namespace PresentationTest.Fakes;

public class ClientModelFake : IClientModel
{
    private List<IClientModelData> clients = new();

    public IClientLogic Logic { get; }

    public IEnumerable<IClientModelData> Clients => clients;

    public bool Add(int id, string name)
    {
        if (clients.Exists(x => x.Id == id)) return false;
        clients.Add(new ClientModelData(id, name));
        return true;
    }

    public bool Delete(int id)
    {
        if (!clients.Exists(x => x.Id == id)) return false;
        clients.Remove(clients.Find(x => x.Id == id));
        return true;
    }

    public bool Update(int id, string name)
    {
        if (!clients.Exists(x => x.Id == id)) return false;
        clients.Remove(clients.Find(x => x.Id == id));
        clients.Add(new ClientModelData(id, name));
        return true;
    }
}