using System.Collections.Generic;
using Services.API;

namespace Model.API;

public interface IClientModel
{
    IClientLogic Logic { get; }
    IEnumerable<IClientModelData> Clients { get; } 
    bool Add(int id, string name);
    bool Delete(int id);
    bool Update(int id, string name);
}