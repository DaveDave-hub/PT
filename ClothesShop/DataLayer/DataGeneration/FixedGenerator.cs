using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataGeneration
{
    public class FixedGenerator : IGenerator
    {

        public void GenarateData(DataContext data)
        {
            Client c1 = new Client("Artur", "Rojek", "1");
            data.clients.Add(c1);
            Client c2 = new Client("John", "Rambo", "2");
            data.clients.Add(c2);
            Client c3 = new Client("Robert", "Kubica", "3");
            data.clients.Add(c3);
            Client c4 = new Client("Bartek", "Stasiak", "4");
            data.clients.Add(c3);

        }
    }
}
