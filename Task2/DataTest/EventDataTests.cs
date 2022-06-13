using System;
using Data;
using Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest;

[TestClass]
public class EventDataTests
{
    private DataClasses1DataContext database;
    private IEventDataRepositoryAPI eventDataLayerAPI;
        
    [TestInitialize]
    public void TestInitialize()
    {
        database = new DataClasses1DataContext();
        eventDataLayerAPI = new EventCRUD();
            
        database.ExecuteCommand("DELETE FROM Events");
        database.ExecuteCommand("DELETE FROM Clients");
        database.ExecuteCommand("DELETE FROM Clothes");
            
        eventDataLayerAPI.AddEvent(0, DateTime.MinValue, 1, 0);
    }
    
    [TestMethod]
    public void CheckIfNull()
    {
        Assert.IsNotNull(eventDataLayerAPI.GetEvent(0));
    }
    
    [TestMethod]
    public void CheckDataCorrectness()
    {
        Assert.AreEqual(1, eventDataLayerAPI.GetEvent(0).ClientId);
    }

    [TestMethod]
    public void AddToDatabase()
    {
        eventDataLayerAPI.AddEvent(1, DateTime.MaxValue, 0, 1);
        Assert.IsNotNull(eventDataLayerAPI.GetEvent(1));
    }

    [TestMethod]
    public void UpdateInfo()
    {
        eventDataLayerAPI.Update(1, DateTime.MinValue, 2, 2);
        Assert.AreEqual(2, eventDataLayerAPI.GetEvent(1).ClothesId);
    }
}