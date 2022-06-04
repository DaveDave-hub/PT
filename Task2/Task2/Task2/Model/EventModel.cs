using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public class EventModel
    {
        public EventModel()
        {

        }

        public int event_id { get; set; }
        public DateTime event_time { get; set; }
        public int event_client_id { get; set; }
        public int event_clothes_id { get; set; }
        public int event_amount { get; set; }
        public Boolean event_is_buying { get; set; }

        public void Converter(Dictionary<String, String> eventInfo)
        {
            event_id = Int32.Parse(eventInfo["id"]);
            event_time = DateTime.Parse(eventInfo["date"]);
            event_client_id = Int32.Parse(eventInfo["client_id"]);
            event_clothes_id = Int32.Parse(eventInfo["clothes_id"]);
            event_amount = Int32.Parse(eventInfo["amount"]);
            event_is_buying = Boolean.Parse(eventInfo["is_buying"]);

        }
    }
}
