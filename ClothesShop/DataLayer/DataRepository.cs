using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.API
{
    internal class DataRepository : DataLayerAPI
    {
        private readonly DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }


        #region Client
        public override void AddClient(String firstName, String lastName, int id)
        {
            Client c = new Client(firstName, lastName, id);

            context.Clients.Add(c);
        }

        public override String GetClientFirstName(int id)
        {
            foreach (Client c in context.Clients)
            {
                if (c.Id == id)
                {
                    Console.WriteLine(c.FirstName);
                    return c.FirstName;
                }
            }
            throw new Exception("There is no client with this ID");
        }

        public override String GetClientLastName(int id)
        {
            foreach (Client C in context.Clients)
            {
                if (C.Id == id)
                {
                    return C.LastName;
                }
            }
            throw new Exception("There is no client with this ID");
        }

        public override int GetAllClientsNumber()
        {
            return context.Clients.Count;
        }
        public override void UpdateClientsInfo(String firstName, String lastName, int id)
        {
            Client C = new Client(firstName, lastName, id);

            for (int i = 0; i < context.Clients.Count; i++)
            {
                if (context.Clients[i].Id == C.Id)
                {
                    context.Clients[i].FirstName = C.FirstName;
                    context.Clients[i].LastName = C.LastName;
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        public override void DeleteClient(int id)
        {
            for (int i = 0; i < context.Clients.Count; i++)
            {
                if (context.Clients[i].Id == id)
                {
                    context.Clients.Remove(context.Clients[i]);
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }
        #endregion

        #region Catalog

        public override void AddClothes(int id, double price, String type)
        {
            ClothesType clothesType = new ClothesType();
            switch (type)
            {
                case "trousers":
                    clothesType = ClothesType.trousers;
                    break;
                case "tshirt":
                    clothesType = ClothesType.tshirt;
                    break;
                case "hoodie":
                    clothesType = ClothesType.hoodie;
                    break;
                case "sneakers":
                    clothesType = ClothesType.sneakers;
                    break;
                case "dress":
                    clothesType = ClothesType.dress;
                    break;
            }

            Clothes d = new Clothes(id, price, clothesType);

            context.Catalog.Products.Add(d.Id, d);
        }

        public override int GetClothesNumber()
        {
            return context.Catalog.Products.Count();

        }

        public override String GetClothes(int id)
        {
            foreach(var clothes in context.Catalog.Products)
            {
                if (clothes.Value.Id == id)
                {
                    return clothes.Value.ClothesType.ToString();
                }
            }
            throw new Exception("No such clothes in our shop");
        }




        public override void UpdateClothesInfo(int id, double price, String type)
        {
            ClothesType clothesType = new ClothesType();
            switch (type)
            {
                case "trousers":
                    clothesType = ClothesType.trousers;
                    break;
                case "tshirt":
                    clothesType = ClothesType.tshirt;
                    break;
                case "hoodie":
                    clothesType = ClothesType.hoodie;
                    break;
                case "sneakers":
                    clothesType = ClothesType.sneakers;
                    break;
                case "dress":
                    clothesType = ClothesType.dress;
                    break;
            }

            Clothes D = new Clothes(id, price, clothesType);

            if (context.Catalog.Products.ContainsKey(D.Id))
            {
                context.Catalog.Products[D.Id].Price = D.Price;
                context.Catalog.Products[D.Id].ClothesType = D.ClothesType;
                return;
            }
            throw new Exception("No such clothes in our shop");
        }

        public override void DeleteClothes(int id)
        {
            foreach (var product in context.Catalog.Products)
            {
                if (product.Key == id)
                {
                    context.Catalog.Products.Remove(id);
                    return;
                }
            }
            throw new Exception("There is no such clothes already");
        }

        #endregion

        #region Event

        public override int GetAllEventsNumber()
        {
            return context.Events.Count;
        }

        public override int GetEventClientId(int id)
        {
            for (int i = 0; i < context.Events.Count; i++)
            {
                if (context.Events[i].Id == id)
                {
                    return context.Events[i].client.Id;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        public override int GetEventStateId(int id)
        {
            for (int i = 0; i < context.Events.Count; i++)
            {
                if (context.Events[i].Id == id)
                {
                    return context.Events[i].state.StateId;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        public override DateTime GetEventTime(int id)
        {
            for (int i = 0; i < context.Events.Count; i++)
            {
                if (context.Events[i].Id == id)
                {
                    return context.Events[i].dateTime;
                }
            }
            throw new Exception("Event with such id does not exist");
        }


        public override void AddNewBatchEvent(int id, int stateId, int clientId, DateTime dateTime)
        {
            State state1 = null;
            foreach (State state in context.Shop)
            {
                if(state.StateId == stateId)
                {
                    state1 = state;
                }
            }

            Client client1 = null;
            foreach (Client client in context.Clients)
            {
                if (client.Id == clientId)
                {
                    client1 = client;
                }
            }

            if (state1 == null) throw new Exception("State with such stateid does not exist");
            if (client1 == null) throw new Exception("Client with such clientid does not exist");

            IEvent e = new NewBatchEvent(id, state1, client1, dateTime);

            context.Events.Add(e);
        }

        public override void DeleteEvent(int id)
        {
            for (int i = 0; i < context.Events.Count; i++)
            {
                if (context.Events[i].Id == id)
                {
                    context.Events.Remove(context.Events[i]);
                    return;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        public override void UpdateEvent(int id, int stateId, int clientId, DateTime dateTime)
        {
            State state1 = null;
            foreach (State state in context.Shop)
            {
                if (state.StateId == stateId)
                {
                    state1 = state;
                }
            }

            Client client1 = null;
            foreach (Client client in context.Clients)
            {
                if (client.Id == clientId)
                {
                    client1 = client;
                }
            }

            if (state1 == null) throw new Exception("State with such stateid does not exist");
            if (client1 == null) throw new Exception("Client with such clientid does not exist");


            for (int i = 0; i < context.Events.Count; i++)
            {
                if (context.Events[i].Id == id)
                {
                    context.Events[i].state = state1;
                    context.Events[i].client = client1;
                    context.Events[i].dateTime = dateTime;
                    return;
                }
            }
            throw new Exception("Event with such ID does not exist");
        }




        #endregion

        #region State

        public override void AddStateWithCurrentCatalog(int id, Dictionary<int, int> inventory)
        {
            context.Shop.Add(new State(inventory, context.Catalog, id));
        }

        public override int GetClothesState(int id, int stateId)
        {
            State state = null;
            foreach (var s in context.Shop)
            {
                if (s.StateId == stateId)
                {
                    state = s;
                }
            }
            return state.Inventory[id];
        }

        public override Dictionary<int, int> GetAllStates(int stateId)
        {
            State state = null;
            foreach (var s in context.Shop)
            {
                if (s.StateId == stateId)
                {
                    state = s;
                }
            }
            return context.Shop[stateId].Inventory;
        }

        public override void UpdateClothesStateInfo(int ID, int new_state, int stateId)
        {
            State state = null;
            foreach (var s in context.Shop)
            {
                if (s.StateId == stateId)
                {
                    state = s;
                }
            }
            
            if (context.Catalog.Products.ContainsKey(ID))
            {

                state.Inventory[ID] = new_state;
                return;
            }
            throw new Exception("No Clothes with such ID");
        }

        public override void DeleteOneClothesState(int id, int stateId)
        {
            State state = null;
            foreach (var s in context.Shop)
            {
                if (s.StateId == stateId)
                {
                    state = s;
                }
            }

            if (context.Shop[stateId].Inventory.ContainsKey(id))
            {
                context.Shop[stateId].Inventory.Remove(id);
                return;
            }
            throw new Exception("There is no such clothes already");
        }


        #endregion

    }
}
