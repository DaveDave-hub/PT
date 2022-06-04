using System;
using Dataa;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class ClientCRUD
    {
        public ClientCRUD()
        {

        }

        static public bool addClient(int client_id, string client_name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clients newCustomer = new Clients
                {
                    id = client_id,
                    name = client_name

                };
                context.Clients.InsertOnSubmit(newCustomer);
                context.SubmitChanges();

                return true;


            }
        }

        static public bool deleteClient(int client_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clients myclient = context.Clients.SingleOrDefault(client => client.id == client_id); //tu patrzyłam na różne metody żeby zmienić ale tylko ta się nadaje
                context.Clients.DeleteOnSubmit(myclient);
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateName(int client_id, string client_name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clients mycustomer = context.Clients.SingleOrDefault(client => client.id == client_id);
                mycustomer.name = client_name;
                context.SubmitChanges();
                return true;
            }
        }


        static public Clients GetClient(int client_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (Clients client in context.Clients.ToList())
                {
                    if (client.id == client_id)
                    {
                        return client;
                    }
                }
                return null;
            }
        }

        static public Clients GetCustomerByName(string client_name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (Clients client in context.Clients.ToList())
                {
                    if (client.name == client_name)
                    {
                        return client;
                    }
                }
                return null;
            }
        }


        static public IEnumerable<Clients> GetAllClients()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.Clients.ToList();
                return result;
            }
        }


        static public List<Dictionary<string, string>> GetClientsInfo()

        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();
            List<Clients> tempC = GetAllClients().ToList();
            foreach (Clients client in tempC)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("name", client.name);
                temp.Add("id", client.id.ToString());

                returnList.Add(temp);

            }
            return returnList;
        }



    }
}
