using System;
using Services.API;

namespace Services;

    public class EventData : IEventData
{
    public int Id { get; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }
    public int ClothesId { get; set; }


    public EventData(int id, DateTime date, int clientId, int clothesId)
    {
        Id = id;

        Date = date;

        ClientId = clientId;

        ClothesId = clothesId;
    }
} 


