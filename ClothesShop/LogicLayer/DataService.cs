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

        #region Client
        public void AddClient(String firstName, String lastName, int id)
        {
            repository.AddClient(firstName, lastName, id);
        }

        public void DeleteClient(int id)
        {
            repository.DeleteClient(id);
        }

        public void UpdateClientsInfo(String firstName, String lastName, int id)
        {
            repository.UpdateClientsInfo(firstName, lastName, id);
        }

        public int GetAllClientsNumber()
        {
            return repository.GetAllClientsNumber();
        }

        public String GetClientFirstName(int id)
        {
            return repository.GetClientFirstName(id);
        }

        public String GetClientLastName(int id)
        {
            return repository.GetClientLastName(id);
        }

        #endregion

        #region Catalog

        public void AddClothes(int id, double price, String type) { repository.AddClothes(id, price, type); }
        public void UpdateClothesInfo(int id, double price, String type) { repository.UpdateClothesInfo(id, price, type); }
        public void DeleteClothes(int id) { repository.DeleteClothes(id); }
        public int GetClothesNumber() { return repository.GetClothesNumber(); }
        public String GetClothes(int id) { return repository.GetClothes(id); }

        #endregion

        #region Event

        public int GetAllEventsNumber() { return repository.GetAllEventsNumber(); }
        public int GetEventClientId(int id) { return repository.GetEventClientId(id); }
        public int GetEventStateId(int id) { return repository.GetEventStateId(id); }
        public DateTime GetEventTime(int id) { return repository.GetEventTime(id); }
        public void AddNewBatchEvent(int id, int stateId, int clientId, DateTime dateTime) { repository.AddNewBatchEvent(id, stateId, clientId, dateTime); }
        public void DeleteEvent(int id) { repository.DeleteEvent(id); }
        public void UpdateEvent(int id, int stateId, int clientId, DateTime dateTime) { repository.UpdateEvent(id, stateId, clientId, dateTime); }

        #endregion

        #region Event

        public int GetClothesState(int id, int stateId) { return repository.GetClothesState(id, stateId); }
        public Dictionary<int, int> GetAllStates(int stateId) { return repository.GetAllStates(stateId); }
        public void UpdateClothesStateInfo(int ID, int new_state, int stateId) { repository.UpdateClothesStateInfo(ID, new_state, stateId); }
        public void DeleteOneClothesState(int id, int stateId) { repository.DeleteOneClothesState(id, stateId); }

        #endregion



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

        public void AddandUpdate(int id, double price, String type, int ID, int new_state, int stateId)
        {

            AddClothes(id, price, type);
            UpdateClothesStateInfo(ID, new_state, stateId);
        }
    }
}