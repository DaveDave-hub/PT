using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.API;

namespace DataLayer
{
    internal class BuyingEvent : IEvent
    {
        private int id;
        private DateTime Time;
        private IState State;
        private IClient Client;

        public BuyingEvent(int ID, State STATE, Client CLIENT, DateTime DATETIME)
        {
            this.id = ID;  
            this.Time = DATETIME;
            this.State = STATE;
            this.Client = CLIENT;
        }

        public int Id { get { return this.id; } }
        public DateTime dateTime { get { return this.Time;} }

        public IState state { get { return this.State;} }

        public IClient client { get { return this.Client;} }



    }
}
