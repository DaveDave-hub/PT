using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;



namespace DataLayer
{
    internal class State : IState
    {
        public Dictionary<int, int> Inventory { get; set; }
        public ICatalog Catalog { get; set; }
        public int StateId { get; }

        public State(Dictionary<int, int> _inventory, ICatalog _catalog, int id)
        {
            Inventory = _inventory;
            Catalog = _catalog;
            StateId = id;
        }
    }
}