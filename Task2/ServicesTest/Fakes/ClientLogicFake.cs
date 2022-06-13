using System.Collections.Generic;
using Services;
using Services.API;

namespace ServicesTest.Fakes;

public class ClientLogicFake : IClientLogic
{
    private List<IClientData> clients = new();

    public IEnumerable<IClientData> GetAllClients()
    {
        return clients;
    }

    public IClientData GetClient(int clientId)
    {
        return clients.Find(x => x.Id == clientId);
    }

    public bool AddClient(int clientId, string clientName)
    {
        if (GetClient(clientId) != null) return false; 
        clients.Add(new ClientData(clientId, clientName));
        return true;
    }

    public bool UpdateClient(int clientId, string clientName)
    {
        var toUpdate = GetClient(clientId);
        if (toUpdate == null) return false;
        clients.Remove(toUpdate);
        clients.Add(new ClientData(clientId, clientName));
        return true;
    }

    public bool DeleteClient(int clientId)
    {
        if (GetClient(clientId) == null) return false; 
        clients.Remove(clients.Find(x => x.Id == clientId));
        return true;
    }
}