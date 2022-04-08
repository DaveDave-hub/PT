using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
{
    public interface IGenerator
    {

        void GenerateData(DataContext data);

    }
}