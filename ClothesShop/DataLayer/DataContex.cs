using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    internal class DataContext

    {
        internal Catalog catalog = new Catalog();
        internal List<Event> events = new List<Event>();
        internal State shop = new State();
        internal List<Client> clients = new List<Client>();

    }
}

