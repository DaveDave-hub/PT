using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;

namespace DataLayer
{
    internal class NewBatchEvent : IEvent
    {
        public int Id { get; }
        public DateTime dateTime { get; set; }
        public IState state { get; set; }
        public IClient client { get; set; }

        public NewBatchEvent(int ID, State STATE, Client CLIENT, DateTime DATETIME)
        {
            Id = ID;  
            dateTime = DATETIME;
            state = STATE;
            client = CLIENT;
        }
    }
}
