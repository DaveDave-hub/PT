using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Linq;
using System.Collections.Generic;
using Data;

namespace ServicesTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void AddandDeleteEventTest()
        {
            Assert.IsTrue(EventCRUD.addEvent(666, DateTime.Now, 17, 31, 2, true));
            IEnumerable<Events> events = EventCRUD.GetAllEvents();
            Assert.AreEqual(events.Count(), 11);
            Assert.IsTrue(EventCRUD.deleteEvent(666));
            IEnumerable<Events> ev = EventCRUD.GetAllEvents();
            Assert.AreEqual(ev.Count(), 10);
        }

        [TestMethod]
        public void GetEventTest()
        {
            Assert.AreEqual(EventCRUD.GetEvent(9).clothes_id, 12);
        }

        [TestMethod]
        public void UpdateEventTest()
        {
            EventCRUD.addEvent(999, DateTime.Now, 17, 12, 2, true);
            Assert.IsTrue(EventCRUD.updateDate(999, DateTime.Now));
            Assert.IsTrue(EventCRUD.updateClient(999, 3));
            Assert.AreEqual(EventCRUD.GetEvent(999).client_id, 3);
            Assert.IsTrue(EventCRUD.updateClothes(999, 1));
            Assert.AreEqual(EventCRUD.GetEvent(999).clothes_id, 1);
            Assert.IsTrue(EventCRUD.updateAmount(999, 1));
            Assert.AreEqual(EventCRUD.GetEvent(999).amount, 1);
            Assert.IsTrue(EventCRUD.updateType(999, false));
            Assert.AreEqual(EventCRUD.GetEvent(999).is_buying, false);
            EventCRUD.deleteEvent(999);
        }
        
        [TestMethod]
        public void GetAllEventsTest()
        {
            IEnumerable<Events> events = EventCRUD.GetAllEvents();
            Assert.AreEqual(events.Count(), 10);
            Assert.AreEqual(events.ElementAt(3).clothes_id, 31);
        }
        
        [TestMethod]
        public void GetEventsByDateTest()
        {
            IEnumerable<Events> events = EventCRUD.GetEventsByDate(DateTime.Now);
            Assert.AreEqual(events.Count(), 0);
        }
        
        [TestMethod]
        public void GetEventsByClientTest()
        {

            IEnumerable<Events> events = EventCRUD.GetEventsByClient(13);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).id, 5);
            Assert.AreEqual(events.ElementAt(1).clothes_id, 21);
        }
        
        [TestMethod]
        public void GetEventsByClothesTest()
        {
            IEnumerable<Events> events = EventCRUD.GetEventsByClothes(2);
            Assert.AreEqual(events.Count(), 3);
            Assert.AreEqual(events.ElementAt(0).amount, 1);
            Assert.AreEqual(events.ElementAt(1).client_id, 17);
            Assert.AreEqual(events.ElementAt(2).id, 10);
        }
        
        [TestMethod]
        public void GetEventsByAmountTest()
        {


            IEnumerable<Events> events = EventCRUD.GetEventsByAmount(3);
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).client_id, 6);
        }
        
        [TestMethod]
        public void GetEventsByTypeTest()
        {

            IEnumerable<Events> events = EventCRUD.GetEventsByType(false);
            Assert.AreEqual(events.Count(), 3);
            Assert.AreEqual(events.ElementAt(2).client_id, 90);
        }
    }
}
