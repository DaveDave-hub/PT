using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    internal class DataContext

    {
        internal Catalog catalog = new Catalog();
        internal List<IEvent> events = new List<IEvent>();
        internal List<State> shop = new List<State>();
        internal List<Client> clients = new List<Client>();

    }
}

