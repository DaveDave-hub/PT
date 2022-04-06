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

        public void AddClothes(Clothes clothes)
        {
            repository.AddClothes(clothes);
        }

        public void DeleteClothes(int id)
        {
            repository.DeleteClothes(id);
        }

        public Clothes GetClothesByType(DataLayer.ClothesType type)
        {
            return repository.GetClothesByType(type);
        }
        public Clothes GetClothesById(int id)
        {
            return repository.GetClothes(id);
        }

         public void AddClient(Client client)
        {
            repository.AddClient(client);
        }

          public Client GetClientById(string id)
        {
           return repository.GetClient(id);
        }

        public int GetAllClientsNumber()
        {
            return repository.GetAllClientsNumber();

        }






    }
}