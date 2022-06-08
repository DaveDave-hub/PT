using System.Collections.Generic;
using System.Linq;
using Data;
using Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace ServicesTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void AddAndDeleteClientTest()
        {
            Assert.IsTrue(ClientCRUD.AddClient(100, "NEW CLIENT"));
            IEnumerable<Clients> clients = ClientCRUD.GetAllClients();
            Assert.AreEqual(clients.Count(), 9);
            Assert.IsTrue(ClientCRUD.DeleteClient(100));
            IEnumerable<Clients> c2 = ClientCRUD.GetAllClients();
            Assert.AreEqual(c2.Count(), 8);
        }

        [TestMethod]
        public void UpdateClientNameTest()
        {
            ClientCRUD.AddClient(200, "Mariusz Szalpuk");
            Assert.IsTrue(ClientCRUD.UpdateName(200, "Mariusz Wlazły"));
            Assert.AreEqual(ClientCRUD.GetClient(200).name, "Mariusz Wlazły");
            ClientCRUD.DeleteClient(200);
        }

        [TestMethod]
        public void GetClientTest()
        {
            Assert.AreEqual(ClientCRUD.GetClient(1).name, "Piotr Nowakowski");
        }


        [TestMethod]
        public void GetClientByNameTest()
        {
            ClientCRUD.AddClient(1313, "Michał Kubiak");
            IEnumerable<Clients> clients = ClientCRUD.GetClientByName("Michał Kubiak");
            Assert.AreEqual(clients.Count(), 2);
            Assert.AreEqual(clients.ElementAt(0).id, 13);
            Assert.AreEqual(clients.ElementAt(1).id, 1313);
            ClientCRUD.DeleteClient(1313);
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            IEnumerable<Clients> clients = ClientCRUD.GetAllClients();
            Assert.AreEqual(clients.Count(), 8);
        }
    }
}
