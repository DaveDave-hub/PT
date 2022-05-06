using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;



namespace DataLayer
{



    internal class State : IState
    {
        private Dictionary<int, int> Inventory;
        private ICatalog Catalog;



        public State(Dictionary<int, int> _inventory, ICatalog _catalog)
        {
            Inventory = _inventory;
            Catalog = _catalog;
        }

        public Dictionary<int, int> inventory 
        {

            get { return Inventory; }
            set { Inventory = value; }
        }

        public ICatalog catalog
        {
            get { return Catalog; }
            set { Catalog = value; }
        }
    }
}