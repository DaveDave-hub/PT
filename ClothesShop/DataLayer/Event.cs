using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.API
{
    public interface IEvent
    {
        public int Id { get; }
        public DateTime dateTime { get; }
        public IState state { get; }
        public IClient client { get; }

        /*
        internal Event(string id, State state, Client client, DateTime dateTime)
        {
            this.Id = id;
            this.state = state;
            this.client = client;
            this.dateTime = dateTime;

        }

        internal override bool Equals(object obj)
        {
            var @event = obj as Event;
            return @event != null &&
                   Id == @event.Id;
        }
        */
    }
}
