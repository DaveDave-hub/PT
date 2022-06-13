using System;
using System.Collections.Generic;
using Services.API;

namespace Model.API;

public interface IEventModel
{
    IEventLogic Logic { get; }
    IEnumerable<IEventModelData> Events { get; } 
    bool Add(int id, DateTime date, int clientId, int clothesId);
    bool Delete(int id);
    bool Update(int id, DateTime date, int clientId, int clothesId);
}