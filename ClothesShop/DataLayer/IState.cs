using System;
using System.Collections.Generic;


namespace DataLayer.API
{
    public interface IState
    {
        public Dictionary<int, int> Inventory { get; set; }
        public ICatalog Catalog { get; set; }
        public int StateId { get; }
    }
}

