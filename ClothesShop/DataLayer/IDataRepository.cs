﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDataRepository
    {

        void AddClothes(Clothes d);

        Clothes GetClothes(int id);

        void DeleteClothes(int id);

 //       Clothes GetClothes(int id);

        Clothes GetClothesByType(ClothesType type);
        int GetClothesNumber();

        void AddClient(Client c);

        Client GetClient(String id);

  //      IEnumerable<Client> GetAllClients();

        int GetAllClientsNumber();


    }
}
