using System;
using System.Collections.Generic;
using Data.API;
using Data.DataRepository;
using Services.API;

namespace Services;

public class EventLogic : IEventLogic
{
    private readonly IEventDataRepositoryAPI dataAPI;

    public EventLogic(IEventDataRepositoryAPI dataLayerAPI = default)
    {
        dataAPI = dataLayerAPI ?? new EventCRUD();
    }

    private IEventData Transform(IEvent events)
    {
        return new EventData(events.Id, events.Date, events.ClientId, events.ClothesId);
    }

    public bool AddEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id)
    {
        return dataAPI.AddEvent(event_id, event_date, event_client_id, event_clothes_id);
    }

    public bool DeleteEvent(int event_id)
    {
        return dataAPI.DeleteEvent(event_id);
    }

    public bool Update(int event_id, DateTime new_date, int new_client, int new_clothes)
    {
        return dataAPI.Update(event_id, new_date, new_client, new_clothes);
    }

    public IEventData GetEvent(int event_id)
    {
        return Transform(dataAPI.GetEvent(event_id));
    }

    public IEnumerable<IEventData> GetAllEvents()
    {
        List<IEventData> events = new();

        foreach (IEvent @event in dataAPI.GetAllEvents())
        {
            events.Add(Transform(@event));
        }
        
        return events;
    }

}
    


