using Data.API;
using System;
using System.Collections.Generic;

namespace Services.API
{
    public interface IEventLogic
    {
        bool AddEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id);
        bool DeleteEvent(int event_id);
        bool Update(int event_id, DateTime new_date, int new_client, int new_clothes);
        IEventData GetEvent(int event_id);
        IEnumerable<IEventData> GetAllEvents();
    }
}
