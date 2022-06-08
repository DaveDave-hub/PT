using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IEvent
    {
        int Id { get; }
        DateTime date { get; set; }
        int client_id { get; set; }
        int clothes_id { get; set; }
        int amount { get; set; }
        bool isbuying { get; set; }
    }
}
