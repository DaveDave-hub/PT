using System;

namespace Model.API;

public interface IEventModelData
{
    int Id { get; }
    DateTime Date { get; set; }
    int ClientId { get; set; }
    int ClothesId { get; set; }
}