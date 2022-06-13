using System;
using System.Collections.Generic;
using Services;
using Services.API;

namespace ServicesTest.Fakes;

public class EventLogicFake : IEventLogic
{
    private List<IEventData> clothes = new();

    public IEnumerable<IEventData> GetAllEvents()
    {
        return clothes;
    }

    public IEventData GetEvent(int event_id)
    {
        return clothes.Find(x => x.Id == event_id);
    }

    public bool AddEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id)
    {
        if (GetEvent(event_id) != null) return false; 
        clothes.Add(new EventData(event_id, event_date, event_client_id, event_clothes_id));
        return true;
    }

    public bool Update(int event_id, DateTime event_date, int event_client_id, int event_clothes_id)
    {
        var toUpdate = GetEvent(event_id);
        if (toUpdate == null) return false;
        clothes.Remove(toUpdate);
        clothes.Add(new EventData(event_id, event_date, event_client_id, event_clothes_id));
        return true;
    }

    public bool DeleteEvent(int event_id)
    {
        if (GetEvent(event_id) == null) return false; 
        clothes.Remove(clothes.Find(x => x.Id == event_id));
        return true;
    }
}