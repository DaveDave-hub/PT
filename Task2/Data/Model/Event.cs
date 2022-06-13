using System;
using Data.API;

namespace Data.Model;

public class Event : IEvent
{
    public int Id { get; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }
    public int ClothesId { get; set; }

    public Event(int id, DateTime date, int clientId, int clothesId)
    {
        Id = id;
        Date = date;
        ClientId = clientId;
        ClothesId = clothesId;
    }
}