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









      
        public abstract void AddClient(string FirstName, string LastName, string Id);
        public abstract void DeleteClient(String id);
        public abstract void UpdateClientsInfo(string Id);
        public abstract int GetAllClientsNumber();
        public abstract void GetClient(String id);
        public abstract IEnumerable<Client> GetAllClients();

       
        
        public abstract void AddClothes(int id, double price, ClothesType type);
        public abstract void UpdateClothesInfo(int id);
        public abstract void DeleteClothes(int id);
        public abstract int GetClothesNumber();
        public abstract void GetClothesByType(ClothesType type);
        public abstract void GetClothes(int id);
        IEnumerable<Clothes> GetAllClothes();

        
        
        
        public abstract int GetAllEventsNumber();
        public abstract void GetEventById(String id);
        public abstract void AddNewBatchEvent(string id);

        List<Event> GetAllEvents();


        


        


        void DeleteEvent(String id);

        int GetClothesState(int id);


        Dictionary<int, int> GetAllStates();


        void UpdateClothesStateInfo(int ID, int new_state);


        void DeleteOneClothesState(int id);

        State GetState();

       

    }
}
