using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Linq;
using System.Collections.Generic;
using Data;
using Data.DataRepository;
using Services.API;
using ServicesTest.Fakes;

namespace ServicesTest;

[TestClass]
public class EventTest
{
    private IEventLogic eventLogic;
        
    [TestInitialize]
    public void TestInitialize()
    {
        eventLogic = new EventLogicFake();
    }
    
    [TestMethod]
    public void AddAndDeleteEventTest()
    {
        Assert.IsTrue(eventLogic.AddEvent(666, DateTime.Now, 17, 31));
        IEnumerable<IEventData> events = eventLogic.GetAllEvents();
        Assert.AreEqual(events.Count(), 1);
        Assert.IsTrue(eventLogic.DeleteEvent(666));
        IEnumerable<IEventData> ev = eventLogic.GetAllEvents();
        Assert.AreEqual(ev.Count(), 0);
    }
    
    [TestMethod]
    public void GetEventTest()
    {
        Assert.IsTrue(eventLogic.AddEvent(9, DateTime.Now, 17, 12));
        Assert.AreEqual(eventLogic.GetEvent(9).ClothesId, 12);
    }
    
    [TestMethod]
    public void UpdateEventTest()
    {
        eventLogic.AddEvent(999, DateTime.Now, 17, 12);
        Assert.IsTrue(eventLogic.Update(999, DateTime.Now, 3, 1));
        Assert.AreEqual(eventLogic.GetEvent(999).ClientId, 3);
        Assert.AreEqual(eventLogic.GetEvent(999).ClothesId, 1);
        eventLogic.DeleteEvent(999);
    }
    
    [TestMethod]
    public void GetAllEventsTest()
    {
        eventLogic.AddEvent(1, DateTime.Now, 17, 12);
        eventLogic.AddEvent(2, DateTime.Now, 17, 12);
        eventLogic.AddEvent(3, DateTime.Now, 17, 31);
        IEnumerable<IEventData> events = eventLogic.GetAllEvents();
        IEnumerable<IEventData> eventDatas = events.ToList();
        Assert.AreEqual(eventDatas.Count(), 3);
        Assert.AreEqual(eventDatas.ElementAt(2).ClothesId, 31);
    }
    
}