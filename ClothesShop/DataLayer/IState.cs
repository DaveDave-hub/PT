using System;
using System.Collections.Generic;


namespace DataLayer.API
{
    public interface IState
    {
        public Dictionary<int, int> inventory { get; set; }
        public ICatalog catalog { get; set; }
        public int stateId { get; }
    }
}

