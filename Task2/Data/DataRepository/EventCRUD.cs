using System;
using System.Collections.Generic;
using System.Linq;
using Data.API;
using Data.Model;

namespace Data.DataRepository
{
    public class EventCRUD : IEventDataRepositoryAPI
    {
        private DataClasses1DataContext context;
        public EventCRUD(DataClasses1DataContext context = default)
        {
            this.context = context ?? new DataClasses1DataContext();
        }

        private IClient Transform(Events events)
        {
            return new Events(events.id, events.date, events.client_id, events.clothes_id, events.amount, events.is_buying);
        }


        public bool addEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id, int event_amount, bool event_is_buying)
        {
            if (GetEvent(event_id) != null) return false;
            {
                Events newevent = new Events
                {
                    id = event_id,
                    date = event_date,
                    client_id = event_client_id,
                    clothes_id = event_clothes_id,
                    amount = event_amount,
                    is_buying = event_is_buying
                };
                context.Events.InsertOnSubmit(newevent);
                context.SubmitChanges();

                return true;
            }
        }

        public bool deleteEvent(int event_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(ev => ev.id == event_id);
                if (events == null) return false;


                context.Events.DeleteOnSubmit(myEvent);
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateDate(int event_id, DateTime new_date)
        {
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                if (events == null) return false;

                myEvent.date = new_date;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateClient(int event_id, int new_client)
        {
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                if (events == null) return false;

                myEvent.client_id = new_client;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateClothes(int event_id, int new_clothes)
        {
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                if (events == null) return false;

                myEvent.clothes_id = new_clothes;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateAmount(int event_id, int new_amount)
        {
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                if (events == null) return false;

                myEvent.amount = new_amount;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateType(int event_id, bool buying)
        {
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                if (events == null) return false;

                myEvent.is_buying = buying;
                context.SubmitChanges();
                return true;
            }
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

            List<Events> events = context.Clients.ToList();
            List<IEvent> result = new List<IEvent>();

            foreach (Events events in events)
            {
                result.Add(Transform(events));
            }

            return result;
        }



        public bool BuyClothes(int event_id, int clothes_id, int client_id, int amount)
        {
            {
                if (ClothesCRUD.GetClothes(clothes_id) != null && ClientCRUD.GetClient(client_id) != null)
                {

                    addEvent(event_id, DateTime.Today, ClientCRUD.GetClient(client_id).id, ClothesCRUD.GetClothes(clothes_id).id, amount, true);
                    return true;
                }
            }
            return false;
        }
    }
}
