using DataLayer.API;
using System;
using System.Collections.Generic;

namespace LogicLayer.API
{
    
    public class DataService : ILogicAPI
    {
        private readonly DataLayerAPI _repository;


        public DataService(DataLayerAPI repository)
        {
            _repository = repository;
        }

        #region Client
        public void AddClient(String firstName, String lastName, int id)
        {
            _repository.AddClient(firstName, lastName, id);
        }

        public void DeleteClient(int id)
        {
            _repository.DeleteClient(id);
        }

        public void UpdateClientsInfo(String firstName, String lastName, int id)
        {
            _repository.UpdateClientsInfo(firstName, lastName, id);
        }

        public int GetAllClientsNumber()
        {
            return _repository.GetAllClientsNumber();
        }

        public String GetClientFirstName(int id)
        {
            return _repository.GetClientFirstName(id);
        }

        public String GetClientLastName(int id)
        {
            return _repository.GetClientLastName(id);
        }

        #endregion

        #region Catalog

        public void AddClothes(int id, double price, String type) { _repository.AddClothes(id, price, type); }
        public void UpdateClothesInfo(int id, double price, String type) { _repository.UpdateClothesInfo(id, price, type); }
        public void DeleteClothes(int id) { _repository.DeleteClothes(id); }
        public int GetClothesNumber() { return _repository.GetClothesNumber(); }
        public String GetClothes(int id) { return _repository.GetClothes(id); }

        #endregion

        #region Event

        public int GetAllEventsNumber() { return _repository.GetAllEventsNumber(); }
        public int GetEventClientId(int id) { return _repository.GetEventClientId(id); }
        public int GetEventStateId(int id) { return _repository.GetEventStateId(id); }
        public DateTime GetEventTime(int id) { return _repository.GetEventTime(id); }
        public void AddNewBatchEvent(int id, int stateId, int clientId, DateTime dateTime) { _repository.AddNewBatchEvent(id, stateId, clientId, dateTime); }
        public void DeleteEvent(int id) { _repository.DeleteEvent(id); }
        public void UpdateEvent(int id, int stateId, int clientId, DateTime dateTime) { _repository.UpdateEvent(id, stateId, clientId, dateTime); }

        #endregion

        #region State

        public void AddStateWithCurrentCatalog(int id, Dictionary<int, int> inventory)
        {
            _repository.AddStateWithCurrentCatalog(id, inventory);
        }
        public int GetClothesState(int id, int stateId) { return _repository.GetClothesState(id, stateId); }
        public Dictionary<int, int> GetAllStates(int stateId) { return _repository.GetAllStates(stateId); }
        public void UpdateClothesStateInfo(int id, int newState, int stateId) { _repository.UpdateClothesStateInfo(id, newState, stateId); }
        public void DeleteOneClothesState(int id, int stateId) { _repository.DeleteOneClothesState(id, stateId); }

        #endregion
    }
}