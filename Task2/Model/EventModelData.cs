using System;
using Model.API;

namespace Model;

public class EventModelData : IEventModelData
{
    public int Id { get; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }
    public int ClothesId { get; set; }


    public EventModelData(int id, DateTime date, int clientId, int clothesId)
    {
        Id = id;

        Date = date;

        ClientId = clientId;

        ClothesId = clothesId;
    }
}