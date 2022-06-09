using System.Collections.Generic;

namespace Services.API;

public interface IClientLogic
{
    IEnumerable<IClientData> GetAllClients();
    IClientData GetClient(int clientId);
    bool AddClient(int clientId, string clientName);
    bool UpdateClient(int clientId, string clientName);
    bool DeleteClient(int clientId);
}