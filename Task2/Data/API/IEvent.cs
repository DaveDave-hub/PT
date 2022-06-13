using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API;

public interface IEvent
{
    public int Id { get; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }
    public int ClothesId { get; set; }
}