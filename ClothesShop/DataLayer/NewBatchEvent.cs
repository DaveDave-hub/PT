using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;

namespace DataLayer
{
    internal class NewBatchEvent : IEvent
    {
        private int id;
        private DateTime Time;
        private IState State;
        private IClient Client;

        public NewBatchEvent(int ID, State STATE, Client CLIENT, DateTime DATETIME)
        {
            id = ID;  
            Time = DATETIME;
            State = STATE;
            Client = CLIENT;
        }


        public int Id { get; }
        public DateTime dateTime { get; set; }
        public DateTime DateTime { get; set; }
        public IState state { get; set; }
        public IClient client { get; set; }

        
    }
}
