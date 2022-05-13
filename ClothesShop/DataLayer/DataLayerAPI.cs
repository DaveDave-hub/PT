using System;
using System.Collections.Generic;
using DataLayer;

namespace DataLayer.API
{
    public interface IGenerator
    {
        public void GenerateData(DataLayerAPI data);
    }

    public abstract class DataLayerAPI
    {

        public abstract void AddClient(String firstName, String lastName, int id);
        public abstract String GetClientFirstName(int id);
        public abstract String GetClientLastName(int id);
        public abstract int GetAllClientsNumber();
        public abstract void UpdateClientsInfo(String firstName, String lastName, int id);
        public abstract void DeleteClient(int id);



        public abstract void AddClothes(int id, double price, String type);
        public abstract void UpdateClothesInfo(int id, double price, String type);
        public abstract void DeleteClothes(int id);
        public abstract int GetClothesNumber();
        public abstract String GetClothes(int id);
        


        public abstract int GetAllEventsNumber();  
        public abstract int GetEventClientId(int id);  
        public abstract int GetEventStateId(int id); 
        public abstract DateTime GetEventTime(int id); 
        public abstract void AddNewBatchEvent(int id, int stateId, int clientId, DateTime dateTime); 
        public abstract void DeleteEvent(int id);  
        public abstract void UpdateEvent(int id, int stateId, int clientId, DateTime dateTime); 



        public abstract int GetClothesState(int id, int stateId);
        public abstract Dictionary<int, int> GetAllStates(int stateId);
        public abstract void UpdateClothesStateInfo(int ID, int new_state, int stateId);
        public abstract void DeleteOneClothesState(int id, int stateId);

    }
}
