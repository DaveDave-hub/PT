using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Catalog

    {
        public Dictionary<int, Clothes> products { get; set; } = new Dictionary<int, Clothes>();
    }
}
