using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.API;
using ServicesTest.Fakes;

namespace ServicesTest;

[TestClass]
public class ClientTest
{
    private IClientLogic clientLogic;
        
    [TestInitialize]
    public void TestInitialize()
    {
        clientLogic = new ClientLogicFake();
    }
        
    [TestMethod]
    public void AddAndDeleteClientTest()
    {
        Assert.IsTrue(clientLogic.AddClient(100, "NEW CLIENT"));
        Assert.IsTrue(clientLogic.DeleteClient(100));
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
        clientLogic.AddClient(1, "Piotr Nowakowski");
        Assert.AreEqual(clientLogic.GetClient(1).Name, "Piotr Nowakowski");
    }
        
    [TestMethod]
    public void GetAllClientsTest()
    {
        clientLogic.AddClient(1, "Piotr Nowakowski");
        clientLogic.AddClient(2, "Piotr Nowakowski");
        IEnumerable<IClientData> clients = clientLogic.GetAllClients();
        Assert.AreEqual(clients.Count(), 2);
    }
}