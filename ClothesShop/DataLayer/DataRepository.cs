using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DataRepository : IDataRepository
    {
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }


        #region Client
        public void AddClient(Client c)
        {
            context.clients.Add(c);
        }

        public Client GetClient(String id)
        {
            foreach (Client C in context.clients)
            {
                if (C.Id == id)
                {
                    return C;
                }
            }
            throw new Exception("There is no client with this ID");
        }

        public IEnumerable<Client> GetAllClients()
        {
            return context.clients;
        }

        public int GetAllClientsNumber()
        {
            return context.clients.Count;
        }
        public void UpdateClientsInfo(Client C)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == C.Id)
                {
                    context.clients[i].FirstName = C.FirstName;
                    context.clients[i].LastName = C.LastName;
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        public void DeleteClient(String id)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == id)
                {
                    context.clients.Remove(context.clients[i]);
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        public void AddClothes(Clothes d)
        {
            throw new NotImplementedException();
        }

        public Clothes GetClothes(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteClothes(int id)
        {
            throw new NotImplementedException();
        }

        public Clothes GetClothesByType(ClothesType type)
        {
            throw new NotImplementedException();
        }

        public int GetClothesNumber()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
