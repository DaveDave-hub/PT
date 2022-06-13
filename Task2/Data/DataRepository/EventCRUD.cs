using System;
using System.Collections.Generic;
using System.Linq;
using Data.API;
using Data.Model;

namespace Data.DataRepository;

public class EventCRUD : IEventDataRepositoryAPI
{
    private DataClasses1DataContext context;
    public EventCRUD(DataClasses1DataContext context = default)
    {
        this.context = context ?? new DataClasses1DataContext();
    }

    private IEvent Transform(Events events)
    {
        return new Event(events.id, events.date, events.client_id, events.clothes_id);
    }


    public bool AddEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id)
    {
        if (GetEvent(event_id) != null) return false;
        {
            Events newevent = new Events
            {
                id = event_id,
                date = event_date,
                client_id = event_client_id,
                clothes_id = event_clothes_id
            };
            context.Events.InsertOnSubmit(newevent);
            context.SubmitChanges();

            return true;
        }
    }

    public bool DeleteEvent(int event_id)
    {
        Events myEvent = context.Events.SingleOrDefault(ev => ev.id == event_id);
        if (myEvent == null) return false;
            
        context.Events.DeleteOnSubmit(myEvent);
        context.SubmitChanges();
        return true;
    }

    public bool Update(int event_id, DateTime new_date, int new_client, int new_clothes)
    {
        Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
        if (myEvent == null) return false;

        myEvent.date = new_date;
        myEvent.client_id = new_client;
        myEvent.clothes_id = new_clothes;
        context.SubmitChanges();
            
        return true;
    }

    public IEvent GetEvent(int event_id)
    {
        {
            foreach (Events myevent in context.Events.ToList())
            {
                if (myevent.id == event_id)
                {
                    return Transform(myevent);
                }
            }
            return null;
        }
    }

    public IEnumerable<IEvent> GetAllEvents()
    {

        List<Events> events = context.Events.ToList();
        List<IEvent> result = new();

        foreach (Events @event in events)
        {
            result.Add(Transform(@event));
        }

        return result;
    }
}