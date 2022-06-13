using System.Collections.Generic;
using System.Linq;
using Data.API;
using Data.Model;

namespace Data.DataRepository;

public class ClientCRUD : IClientDataLayerAPI
{
    private DataClasses1DataContext context;
    public ClientCRUD(DataClasses1DataContext context = default)
    {
        this.context = context ?? new DataClasses1DataContext();
    }

    private IClient Transform(Clients client)
    {
        return new Client(client.id, client.name);
    }

    public bool AddClient(int client_id, string client_name)
    {
        if (GetClient(client_id) != null) return false;
            
        Clients newCustomer = new Clients
        {
            id = client_id,
            name = client_name

        };
        context.Clients.InsertOnSubmit(newCustomer);
        context.SubmitChanges();

        return true;
    }

    public bool DeleteClient(int client_id)
    {
        Clients clients = context.Clients.SingleOrDefault(client => client.id == client_id);
        if (clients == null) return false;
            
        context.Clients.DeleteOnSubmit(clients);
        context.SubmitChanges();
        return true;

    }

    public bool UpdateName(int client_id, string client_name)
    {
        Clients clients = context.Clients.SingleOrDefault(client => client.id == client_id);
        if (clients == null) return false;
            
        clients.name = client_name;
        context.SubmitChanges();
        return true;
    }


    public IClient GetClient(int client_id)
    {
        foreach (Clients client in context.Clients)
        {
            if (client.id == client_id)
            {
                return Transform(client);
            }
        }

        return null;
    }

    public IEnumerable<IClient> GetAllClients()
    {
        List<Clients> clients = context.Clients.ToList();
        List<IClient> result = new List<IClient>();

        foreach (Clients client in clients)
        {
            result.Add(Transform(client));
        }
            
        return result;
    }
}