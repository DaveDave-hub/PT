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


    }
}