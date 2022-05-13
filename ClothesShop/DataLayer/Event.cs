using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.API
{
    public interface IEvent
    {
        public int Id { get; }
        public DateTime dateTime { get; set; }
        public IState state { get; set; }
        public IClient client { get; set; }
    }

    internal class Event : IEvent
    {
        public int Id { get; }
        public DateTime dateTime { get; set; }
        public IState state { get; set; }
        public IClient client { get; set; }

        Event(int id, State state, Client client, DateTime dateTime)
        {
            this.Id = id;
            this.state = state;
            this.client = client;
            this.dateTime = dateTime;

        }
    }
}
