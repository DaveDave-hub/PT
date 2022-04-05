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


    }
}
