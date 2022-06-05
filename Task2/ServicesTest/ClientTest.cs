using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataa;
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
            Assert.IsTrue(ClientCRUD.addClient(100, "NEW CLIENT"));
            IEnumerable<Clients> clients = ClientCRUD.GetAllClients();
            Assert.AreEqual(clients.Count(), 9);
            Assert.IsTrue(ClientCRUD.deleteClient(100));
            IEnumerable<Clients> c2 = ClientCRUD.GetAllClients();
            Assert.AreEqual(c2.Count(), 8);
        }

        [TestMethod]
        public void UpdateClientNameTest()
        {
            ClientCRUD.addClient(200, "Mariusz Szalpuk");
            Assert.IsTrue(ClientCRUD.updateName(200, "Mariusz Wlazły"));
            Assert.AreEqual(ClientCRUD.GetClient(200).name, "Mariusz Wlazły");
            ClientCRUD.deleteClient(200);
        }

        [TestMethod]
        public void GetClientTest()
        {
            Assert.AreEqual(ClientCRUD.GetClient(1).name, "Piotr Nowakowski");
        }


        [TestMethod]
        public void GetClientByNameTest()
        {
            ClientCRUD.addClient(1313, "Michał Kubiak");
            IEnumerable<Clients> clients = ClientCRUD.GetClientByName("Michał Kubiak");
            Assert.AreEqual(clients.Count(), 2);
            Assert.AreEqual(clients.ElementAt(0).id, 13);
            Assert.AreEqual(clients.ElementAt(1).id, 1313);
            ClientCRUD.deleteClient(1313);
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            IEnumerable<Clients> clients = ClientCRUD.GetAllClients();
            Assert.AreEqual(clients.Count(), 8);
        }
    }
}
