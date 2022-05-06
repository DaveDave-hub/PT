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
        private String FIRSTNAME;
        private String LASTNAME;
        private int ID;

        public Client(String name, String surname, int id)
        {
            FIRSTNAME = name;
            LASTNAME = surname;
            ID = id;
        }

        public string FirstName
        {
            get { return FIRSTNAME; }
            set { FIRSTNAME = value; }
        }

        public String LastName
        {
            get { return LASTNAME; }
            set { LASTNAME = value; }
        }

        public int Id
        {
            get { return ID; } 
            set { ID = value; }
        }

        public override bool Equals(object obj)
        {
            Client other = (Client)obj;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
