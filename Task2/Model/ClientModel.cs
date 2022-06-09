using System.Collections.Generic;
using Model.API;
using Services;
using Services.API;

namespace Model;

public class ClientModel : IClientModel
{
    public IClientLogic Logic { get; }

    public ClientModel(IClientLogic logic = default)
    {
        Logic = logic ?? new ClientLogic();
    }

    public IEnumerable<IClientModelData> Clients
    {
        get
        {
            List<IClientModelData> clients = new();
            foreach (var c in Logic.GetAllClients())
            {
                clients.Add(new ClientModelData(c.Id, c.Name));
            }
            return clients;
        }
    }

    public bool Add(int id, string name)
    {
        return Logic.AddClient(id, name);
    }

    public bool Delete(int id)
    {
        return Logic.DeleteClient(id);
    }

    public bool Update(int id, string name)
    {
        return Logic.UpdateClient(id, name);
    }
}