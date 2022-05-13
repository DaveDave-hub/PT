using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;



namespace DataLayer
{



    internal class State : IState
    {
        public Dictionary<int, int> inventory { get; set; }
        public ICatalog catalog { get; set; }
        public int stateId { get; }

        public State() { }

        public State(Dictionary<int, int> _inventory, ICatalog _catalog, int id)
        {
            inventory = _inventory;
            catalog = _catalog;
            stateId = id;

         }
    }
}