using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDataRepository
    {

        void AddClothes(Clothes d);

        Clothes GetClothes(int id);

        void DeleteClothes(int id);

        Clothes GetClothesByType(ClothesType type);
        int GetClothesNumber();

        IEnumerable<Clothes> GetAllClothes();

        void AddClient(Client c);

        Client GetClient(String id);

        IEnumerable<Client> GetAllClients();

        int GetAllClientsNumber();

        void UpdateClientsInfo(Client C);

        void DeleteClient(String id);


    }
}
