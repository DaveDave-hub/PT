using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dataa;

namespace Services
{
    public class EventCRUD
    {
        public EventCRUD()
        {
        }

        static public bool addEvent(int event_id, DateTime event_date, int event_client_id, int event_clothes_id, int event_amount, bool event_is_buying)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
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

        static public bool deleteEvent(int event_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(ev => ev.id == event_id);
                context.Events.DeleteOnSubmit(myEvent);
                context.SubmitChanges();
                return true;
            }
        }

        static public void DeleteEventsForClient(int event_client_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                IEnumerable<Events> events = context.Events.Where(e => e.client_id == event_client_id);
                foreach (Events e in events)
                {
                    context.Events.DeleteOnSubmit(e);
                    context.SubmitChanges();
                }
            }
        }

        static public bool updateDate(int event_id, DateTime new_date)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                myEvent.date = new_date;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateClient(int event_id, int new_client)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                myEvent.client_id = new_client;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateClothes(int event_id, int new_clothes)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                myEvent.clothes_id = new_clothes;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateAmount(int event_id, int new_amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                myEvent.amount = new_amount;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateType(int event_id, bool buying)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Events myEvent = context.Events.SingleOrDefault(e => e.id == event_id);
                myEvent.is_buying = buying;
                context.SubmitChanges();
                return true;
            }
        }

        static public Events GetEvent(int event_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (Events myevent in context.Events.ToList())
                {
                    if (myevent.id == event_id)
                    {
                        return myevent;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Events> GetAllEvents()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.Events.ToList();
                return result;
            }
        }

        static public IEnumerable<Events> GetEventsByDate(DateTime event_date)
        {
            using (var context = new DataClasses1DataContext())
            {
                List<Events> result = new List<Events>();
                foreach (Events ev in context.Events.ToList())
                {
                    if (ev.date == event_date)
                    {
                        result.Add(ev);
                    }
                }
                return result;
            }
        }

        static public IEnumerable<Events> GetEventsByClient(int event_client_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Events> result = new List<Events>();
                foreach (Events events in context.Events)
                {
                    if (events.client_id.Equals(event_client_id))
                    {
                        result.Add(events);
                    }
                }
                return result;
            }
        }

        static public IEnumerable<Events> GetEventsByClothes(int event_clothes_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Events> result = new List<Events>();
                foreach (Events myevent in context.Events)
                {
                    if (myevent.clothes_id.Equals(event_clothes_id))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }


        static public IEnumerable<Events> GetEventsByType(bool event_type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Events> result = new List<Events>();
                foreach (Events myevent in context.Events)
                {
                    if (myevent.is_buying.Equals(event_type))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }

        static public IEnumerable<Events> GetEventsByClientName(string client_name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clients client = (Clients)ClientCRUD.GetClientByName(client_name);

                List<Events> events = new List<Events>();
                foreach (Events ev in context.Events.ToList())
                {
                    if (ev.client_id == client.id)
                    {
                        events.Add(ev);
                    }
                }
                return events;
            }
        }

        static public List<Dictionary<string, string>> GetEventsInfoforClient(string client_name)

        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();
            List<Events> tempE = GetEventsByClientName(client_name).ToList();
            foreach (Events e in tempE)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("id", e.id.ToString());
                temp.Add("date", e.date.ToString());
                temp.Add("client_id", e.client_id.ToString());
                temp.Add("clothes_id", e.clothes_id.ToString());
                temp.Add("amount", e.amount.ToString());
                temp.Add("is_buying", e.is_buying.ToString());

                returnList.Add(temp);
            }
            return returnList;
        }

        static public IEnumerable<Events> GetEventsByAmount(int event_amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Events> result = new List<Events>();
                foreach (Events myevent in context.Events)
                {
                    if (myevent.amount.Equals(event_amount))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }

        static public bool BuyClothes(int event_id, int clothes_id, int client_id, int amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
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
