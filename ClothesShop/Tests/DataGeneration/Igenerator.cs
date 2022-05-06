using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;


namespace Tests
{
    public interface IGenerator
    {

        void GenerateData(DataContext data);

    }
}