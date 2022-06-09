using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.API;

namespace ServicesTest
{
    [TestClass]
    public class ClientTest
    {
        private ClientLogic clientLogic;
        
        [TestInitialize]
        public void TestInitialize()
        {
            clientLogic = new ClientLogic();
        }
        
        [TestMethod]
        public void AddAndDeleteClientTest()
        {
            Assert.IsTrue(clientLogic.AddClient(100, "NEW CLIENT"));
            IEnumerable<IClientData> clients = clientLogic.GetAllClients();
            Assert.AreEqual(clients.Count(), 9);
            Assert.IsTrue(clientLogic.DeleteClient(100));
            IEnumerable<IClientData> c2 = clientLogic.GetAllClients();
            Assert.AreEqual(c2.Count(), 8);
        }

        [TestMethod]
        public void UpdateClientNameTest()
        {
            clientLogic.AddClient(200, "Mariusz Szalpuk");
            Assert.IsTrue(clientLogic.UpdateClient(200, "Mariusz Wlazły"));
            Assert.AreEqual(clientLogic.GetClient(200).Name, "Mariusz Wlazły");
            clientLogic.DeleteClient(200);
        }

        [TestMethod]
        public void GetClientTest()
        {
            Assert.AreEqual(clientLogic.GetClient(1).Name, "Piotr Nowakowski");
        }
        
        [TestMethod]
        public void GetAllClientsTest()
        {
            IEnumerable<IClientData> clients = clientLogic.GetAllClients();
            Assert.AreEqual(clients.Count(), 8);
        }
    }
}
