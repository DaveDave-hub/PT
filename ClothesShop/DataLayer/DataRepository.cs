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

            context.clients.Add(c);
        }

        public override String GetClientFirstName(int id)
        {
            foreach (Client C in context.clients)
            {
                if (C.Id == id)
                {
                    return C.FirstName;
                }
            }
            throw new Exception("There is no client with this ID");
        }

        public override String GetClientLastName(int id)
        {
            foreach (Client C in context.clients)
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
            return context.clients.Count;
        }
        public override void UpdateClientsInfo(String firstName, String lastName, int id)
        {
            Client C = new Client(firstName, lastName, id);

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

        public override void DeleteClient(int id)
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

            if (context.catalog.products.ContainsKey(d.Id))
            {
                throw new Exception("No such clothes in our shop");
            }
            context.catalog.products.Add(d.Id, d);
        }

        public override int GetClothesNumber()
        {
            return context.catalog.products.Count();

        }

        public override String GetClothes(int id)
        {
            foreach(var clothes in context.catalog.products)
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

            if (context.catalog.products.ContainsKey(D.Id))
            {
                context.catalog.products[D.Id].Price = D.Price;
                context.catalog.products[D.Id].ClothesType = D.ClothesType;
                return;
            }
            throw new Exception("No such clothes in our shop");
        }

        public override void DeleteClothes(int id)
        {
            if (context.catalog.products.ContainsKey(id))
            {
                context.catalog.products.Remove(id);
                return;
            }
            throw new Exception("There is no such clothes already");
        }

        #endregion

        #region Event

        public override int GetAllEventsNumber()
        {
            return context.events.Count;
        }

        public override int GetEventClientId(int id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    return context.events[i].client.Id;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        public override int GetEventStateId(int id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    return context.events[i].state.stateId;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        public override DateTime GetEventTime(int id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    return context.events[i].dateTime;
                }
            }
            throw new Exception("Event with such id does not exist");
        }


        public override void AddNewBatchEvent(int id, int stateId, int clientId, DateTime dateTime)
        {
            State state1 = null;
            foreach (State state in context.shop)
            {
                if(state.stateId == stateId)
                {
                    state1 = state;
                }
            }

            Client client1 = null;
            foreach (Client client in context.clients)
            {
                if (client.clientId == clientId)
                {
                    client1 = client;
                }
            }

            if (state1 == null) throw new Exception("State with such stateid does not exist");
            if (client1 == null) throw new Exception("Client with such clientid does not exist");

            IEvent e = new NewBatchEvent(id, state1, client1, dateTime);

            context.events.Add(e);
        }

        public override void DeleteEvent(int id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    context.events.Remove(context.events[i]);
                    return;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        public override void UpdateEvent(int id, int stateId, int clientId, DateTime dateTime)
        {
            State state1 = null;
            foreach (State state in context.shop)
            {
                if (state.stateId == stateId)
                {
                    state1 = state;
                }
            }

            Client client1 = null;
            foreach (Client client in context.clients)
            {
                if (client.clientId == clientId)
                {
                    client1 = client;
                }
            }

            if (state1 == null) throw new Exception("State with such stateid does not exist");
            if (client1 == null) throw new Exception("Client with such clientid does not exist");


            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    context.events[i].state = state1;
                    context.events[i].client = client1;
                    context.events[i].dateTime = dateTime;
                    return;
                }
            }
            throw new Exception("Event with such ID does not exist");
        }




        #endregion

        #region State

        public override void AddStateWithCurrentCatalog(int id, Dictionary<int, int> inventory)
        {
            context.shop.Add(new State(inventory, context.catalog, id));
        }

        public override int GetClothesState(int id, int stateId)
        {
            State state = (State)context.shop.Where(s => s.stateId == stateId);
            return state.inventory[id];
        }

        public override Dictionary<int, int> GetAllStates(int stateId)
        {
            State state = (State)context.shop.Where(s => s.stateId == stateId);
            return context.shop[stateId].inventory;
        }

        public override void UpdateClothesStateInfo(int ID, int new_state, int stateId)
        {
            State state = (State)context.shop.Where(s => s.stateId == stateId);

            if (context.catalog.products.ContainsKey(ID))
            {

                context.shop[stateId].inventory[ID] = new_state;
                return;
            }
            throw new Exception("No Clothes with such ID");
        }

        public override void DeleteOneClothesState(int id, int stateId)
        {
            State state = (State)context.shop.Where(s => s.stateId == stateId);

            if (context.shop[stateId].inventory.ContainsKey(id))
            {
                context.shop[stateId].inventory.Remove(id);
                return;
            }
            throw new Exception("There is no such clothes already");
        }


        #endregion

    }
}
