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
            this.id = ID;  
            this.Time = DATETIME;
            this.State = STATE;
            this.Client = CLIENT;
        }

        public int Id { get { return this.Id; } }
        public DateTime dateTime { get { return this.Time;} }

        public IState state { get { return this.state;} }

        public IClient client { get { return this.client;} }



    }
}
