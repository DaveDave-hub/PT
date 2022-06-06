using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Model
{
    public class EventModel
    {
        public EventModel()
        { 
        }

        public int id { get; set; }
        public DateTime date { get; set; }
        public int client_id { get; set; }
        public int clothes_id { get; set; }
        public int amount { get; set; }
        public Boolean is_buying { get; set; }

        public void Converter(Dictionary<String, String> eventInfo)
        {
            id = Int32.Parse(eventInfo["id"]);
            date = DateTime.Parse(eventInfo["date"]);
            client_id = Int32.Parse(eventInfo["client_id"]);
            clothes_id = Int32.Parse(eventInfo["clothes_id"]);
            amount = Int32.Parse(eventInfo["amount"]);
            is_buying = Boolean.Parse(eventInfo["is_buying"]);

        }

    }
}
