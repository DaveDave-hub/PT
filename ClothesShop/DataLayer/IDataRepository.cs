using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDataRepository
    {


        void AddClient(Client c);

        Client GetClient(String id);


        IEnumerable<Client> GetAllClients();

        void UpdateClientsInfo(Client C);


        void DeleteClient(String id);

        void AddClothes(Clothes d);

        int GetAllEventsNumber();

        int GetAllClientsNumber();

        Clothes GetClothes(int id);

        Clothes GetClothesByType(ClothesType type);
        int GetClothesNumber();


        IEnumerable<Clothes> GetAllClothes();

        void UpdateClothesInfo(Clothes D);


        void DeleteClothes(int id);


        List<Event> GetAllEvents();


        Event GetEventById(String id);


        void AddEvent(Event e);


        void DeleteEvent(String id);

        int GetClothesState(int id);


        Dictionary<int, int> GetAllStates();


        void UpdateClothesStateInfo(int ID, int new_state);


        void DeleteOneClothesState(int id);

        State GetState();



    }
}
