using DataLayer.API;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;



namespace LogicLayer.API
{

    public abstract class DataServiceAPI
    {
        private DataLayerAPI repository;

        public DataServiceAPI(DataLayerAPI repository)
        {
            this.repository = repository;
        }

        public abstract Clothes GetClothesByType(DataLayer.ClothesType type)
        {
            return repository.GetClothesByType(type);
        }
        public abstract Clothes GetClothesById(int id)
        {
            return repository.GetClothes(id);
        }
        public abstract int GetNumberOfClothes()
        {
            return repository.GetClothesNumber();
        }

        public abstract int GetAllClientsNumber()
        {
            return repository.GetAllClientsNumber();

        }

        public abstract int GetStateOfClothes(int id)
        {
            return repository.GetClothesState(id, 2);
        }

        public abstract void AddClothes(Clothes clothes)
        {
            repository.AddClothes(clothes);
        }

        public abstract void DeleteClothes(int id)
        {
            repository.DeleteClothes(id);
        }

        public abstract Client GetClientById(string id)
        {
            return repository.GetClient(id);
        }
        public abstract void AddClient(Client client)
        {
            repository.AddClient(client);
        }

        public abstract void UpdateClientInfo(String first_name, String last_name, String Id)
        {
            Client C = new Client(first_name, last_name, Id);
            repository.UpdateClientsInfo(C);
        }

        public abstract void DeleteClient(String id)
        {
            repository.DeleteClient(id);
        }

        public abstract int GetClientNumber()
        {
            return repository.GetAllClientsNumber();
        }


        public abstract State GetState()
        {
            return repository.GetState();
        }

        public abstract void UpdateClothesStateInfo(int ID, int new_state)
        {
            repository.UpdateClothesStateInfo(ID, new_state);
        }

        public abstract void DeleteOneClothesState(int id)
        {
            repository.DeleteOneClothesState(id);

        }

        public abstract void AddEvent(Event e)
        {
            repository.AddEvent(e);
        }

        public abstract int GetAllEventsNumber()
        {
            return repository.GetAllEventsNumber();
        }


        public abstract void DeleteEvent(string id)
        {
            repository.DeleteEvent(id);
        }
        public abstract void GetEventByID(string id)
        {
            repository.GetEventById(id);
        }

        public abstract IEnumerable<Event> GetEventsForTheClient(string id)
        {
            Client client = repository.GetClient(id);
            List<Event> allEvents = new List<Event>();

            foreach (Event myEvent in repository.GetAllEvents())
            {
                if (myEvent.client.Equals(client))
                {
                    allEvents.Add(myEvent);
                }
            }
            return allEvents;
        }

        public abstract void BuyClothes(string customerId, int clothesId, DateTime dayOfBuying, int amount)
        {
            Client client = repository.GetClient(customerId);
            Clothes clothes = repository.GetClothes(clothesId);
            int amountLeft = GetStateOfClothes(clothesId) - amount;
            if (GetStateOfClothes(clothesId) < amount)
            {
                throw new InvalidOperationException("There is not enough clothes in the shop.");
            }

            BuyingEvent buyEvent = new BuyingEvent(customerId, repository.GetState(), client, dayOfBuying);
            repository.AddEvent(buyEvent);
            UpdateClothesStateInfo(clothesId, amountLeft);

        }

        public abstract void NewBatch(string supplierId, int clothesId, DateTime dayOfRestock, int amountProvided)
        {
            Client supplier = repository.GetClient(supplierId);
            int newAmount = amountProvided + GetStateOfClothes(clothesId);

            NewBatchEvent restockEvent = new NewBatchEvent(supplierId, repository.GetState(), supplier, dayOfRestock);
            repository.AddEvent(restockEvent);
            UpdateClothesStateInfo(clothesId, newAmount);

        }

        public abstract void AddandUpdate(Clothes clothes, int amount)
        {

            AddClothes(clothes);
            UpdateClothesStateInfo(clothes.Id, amount);
        }
    }
}