using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace DataLayer
{
    internal class Client : IClient
    {
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public int Id { get; set; }

        public Client(String name, String surname, int id)
        {
            FirstName = name;
            LastName = surname;
            Id = id;
        }
    }
}
