using System.Collections.Generic;
using Data.API;
using Data.DataRepository;
using Services.API;

namespace Services;

public class ClientLogic : IClientLogic
{
    private readonly IClientDataLayerAPI dataAPI;

    public ClientLogic(IClientDataLayerAPI dataLayerAPI = default)
    {
        dataAPI = dataLayerAPI ?? new ClientCRUD();
    }

    private IClientData Transform(IClient client)
    {
        return new ClientData(client.Id, client.Name);
    }

    public IEnumerable<IClientData> GetAllClients()
    {
        List<IClientData> clients = new();
        
        foreach (IClient client in dataAPI.GetAllClients())
        {
            clients.Add(Transform(client));
        }
        
        return clients;
    }

    public IClientData GetClient(int clientId)
    {
        return Transform(dataAPI.GetClient(clientId));
    }

    public bool AddClient(int clientId, string clientName)
    {
        return dataAPI.AddClient(clientId, clientName);
    }

    public bool UpdateClient(int clientId, string clientName)
    {
        return dataAPI.UpdateName(clientId, clientName);
    }

    public bool DeleteClient(int clientId)
    {
        return dataAPI.DeleteClient(clientId);
    }
}