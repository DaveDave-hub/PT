using System.Collections.Generic;
using Data.API;

namespace Data.DataRepository;

public interface IClientDataLayerAPI
{
    bool AddClient(int client_id, string client_name);
    bool DeleteClient(int client_id);
    bool UpdateName(int client_id, string client_name);
    IClient GetClient(int client_id);
    IEnumerable<IClient> GetAllClients();
}