using System;
using System.Collections.Generic;
using Model.API;
using Services;
using Services.API;

namespace Model;

public class EventModel : IEventModel
{
    public IEventLogic Logic { get; }

    public EventModel(IEventLogic logic = default)
    {
        Logic = logic ?? new EventLogic();
    }
    
    public IEnumerable<IEventModelData> Events
    {
        get
        {
            List<IEventModelData> events = new();
            foreach (var e in Logic.GetAllEvents())
            {
                events.Add(new EventModelData(e.Id, e.Date, e.ClientId, e.ClothesId));
            }
            return events;
        }
    }

    public bool Add(int id, DateTime date, int clientId, int clothesId)
    {
        return Logic.AddEvent(id, date, clientId, clothesId);
    }

    public bool Delete(int id)
    {
        return Logic.DeleteEvent(id);
    }

    public bool Update(int id, DateTime date, int clientId, int clothesId)
    {
        return Logic.Update(id, date, clientId, clothesId);
    }
}