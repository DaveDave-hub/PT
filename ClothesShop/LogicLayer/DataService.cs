using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;



namespace LogicLayer
{

    public class DataService
    {
        private IDataRepository repository;

        public DataService(IDataRepository repository)
        {
            this.repository = repository;
        }

        public Clothes GetClothesByType(DataLayer.ClothesType type)
        {
            return repository.GetClothesByType(type);
        }
        public Clothes GetClothesById(int id)
        {
            return repository.GetClothes(id);
        }
        public int GetNumberOfClothes()
        {
            return repository.GetClothesNumber();
        }

        public int GetAllClientsNumber()
        {
            return repository.GetAllClientsNumber();

        }

        public int GetStateOfClothes(int id)
        {
            return repository.GetClothesState(id);
        }

        public void AddClothes(Clothes clothes)
        {
            repository.AddClothes(clothes);
        }

        public void DeleteClothes(int id)
        {
            repository.DeleteClothes(id);
        }

        public Client GetClientById(string id)
        {
            return repository.GetClient(id);
        }
        public void AddClient(Client client)
        {
            repository.AddClient(client);
        }

        public void UpdateClientInfo(String first_name, String last_name, String Id)
        {
            Client C = new Client(first_name, last_name, Id);
            repository.UpdateClientsInfo(C);
        }

        public void DeleteClient(String id)
        {
            repository.DeleteClient(id);
        }

        public int GetClientNumber()
        {
            return repository.GetAllClientsNumber();
        }


        public State GetState()
        {
            return repository.GetState();
        }

        public void UpdateClothesStateInfo(int ID, int new_state)
        {
            repository.UpdateClothesStateInfo(ID, new_state);
        }

        public void DeleteOneClothesState(int id)
        {
            repository.DeleteOneClothesState(id);

        }

        public void AddEvent(Event e)
        {
            repository.AddEvent(e);
        }

        public int GetAllEventsNumber()
        {
            return repository.GetAllEventsNumber();
        }


        public void DeleteEvent(string id)
        {
            repository.DeleteEvent(id);
        }
        public void GetEventByID(string id)
        {
            repository.GetEventById(id);
        }

        public IEnumerable<Event> GetEventsForTheClient(string id)
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

        public void BuyClothes(string customerId, int clothesId, DateTime dayOfBuying, int amount)
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

        public void NewBatch(string supplierId, int clothesId, DateTime dayOfRestock, int amountProvided)
        {
            Client supplier = repository.GetClient(supplierId);
            int newAmount = amountProvided + GetStateOfClothes(clothesId);

            NewBatchEvent restockEvent = new NewBatchEvent(supplierId, repository.GetState(), supplier, dayOfRestock);
            repository.AddEvent(restockEvent);
            UpdateClothesStateInfo(clothesId, newAmount);

        }

        public void AddandUpdate(Clothes clothes, int amount)
        {

            AddClothes(clothes);
            UpdateClothesStateInfo(clothes.Id, amount);
        }
    }
}