using System;
using System.Collections.Generic;
using Data.API;

namespace Data.DataRepository;

public interface IEventDataRepositoryAPI
{
    bool AddEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id);
    bool DeleteEvent(int event_id);
    bool Update(int event_id, DateTime new_date, int new_client, int new_clothes);
    IEvent GetEvent(int event_id);
    IEnumerable<IEvent> GetAllEvents();
}