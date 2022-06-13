using System;
using System.Collections.Generic;
using Model;
using Model.API;
using Services.API;

namespace PresentationTest.Fakes;

public class EventModelFake : IEventModel
{
    private List<IEventModelData> events = new();
    
    public IEventLogic Logic { get; }
    public IEnumerable<IEventModelData> Events => events;
    public bool Add(int id, DateTime date, int clientId, int clothesId)
    {
        if (events.Exists(x => x.Id == id)) return false;
        events.Add(new EventModelData(id, date, clientId, clothesId));
        return true;
    }

    public bool Delete(int id)
    {
        if (!events.Exists(x => x.Id == id)) return false;
        events.Remove(events.Find(x => x.Id == id));
        return true;
    }

    public bool Update(int id, DateTime date, int clientId, int clothesId)
    {
        if (!events.Exists(x => x.Id == id)) return false;
        events.Remove(events.Find(x => x.Id == id));
        events.Add(new EventModelData(id, date, clientId, clientId));
        return true;
    }
}