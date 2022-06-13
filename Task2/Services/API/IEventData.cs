using System;

namespace Services.API
{
    public interface IEventData
    {
        int Id { get; }
        DateTime Date { get; set; }
        int ClientId { get; set; }
        int ClothesId { get; set; }
    }
}
