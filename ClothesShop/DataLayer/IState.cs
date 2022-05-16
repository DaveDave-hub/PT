using System;
using System.Collections.Generic;


namespace DataLayer.API
{
    public interface IState
    {
        internal Dictionary<int, int> inventory { get; set; }
        internal ICatalog catalog { get; set; }
        internal int stateId { get; }
    }
}

