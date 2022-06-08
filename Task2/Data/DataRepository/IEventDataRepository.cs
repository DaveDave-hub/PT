using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.DataRepository
{
    public interface IEventDataRepository
    {
        bool addEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id, int event_amount, bool event_is_buying);
        bool deleteEvent(int event_id);
        bool updateDate(int event_id, DateTime new_date);
        bool updateClient(int event_id, int new_client);
        bool updateClothes(int event_id, int new_clothes);
        bool updateAmount(int event_id, int new_amount);
        bool updateType(int event_id, bool buying);
        IEvent GetEvent(int event_id);
        IEnumerable<IEvent> GetAllEvents();
        bool BuyClothes(int event_id, int clothes_id, int client_id, int amount);


    }
}
