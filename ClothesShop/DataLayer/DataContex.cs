using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    internal class DataContext
    {
        internal Catalog Catalog = new();
        internal List<IEvent> Events = new();
        internal List<State> Shop = new();
        internal List<Client> Clients = new();
    }
}

