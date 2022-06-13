using Data;
using Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest;

[TestClass]
public class ClientDataTests
{
    private DataClasses1DataContext database;
    private IClientDataLayerAPI clientDataLayerAPI;
        
    [TestInitialize]
    public void TestInitialize()
    {
        database = new DataClasses1DataContext();
        clientDataLayerAPI = new ClientCRUD();
            
        database.ExecuteCommand("DELETE FROM Events");
        database.ExecuteCommand("DELETE FROM Clients");
        database.ExecuteCommand("DELETE FROM Clothes");
            
        clientDataLayerAPI.AddClient(0, "Jack Sparrow");
    }
    
    [TestMethod]
    public void CheckIfNull()
    {
        Assert.IsNotNull(clientDataLayerAPI.GetClient(0));
    }
    
    [TestMethod]
    public void CheckDataCorrectness()
    {
        Assert.AreEqual("Jack Sparrow", clientDataLayerAPI.GetClient(0).Name);
    }

    [TestMethod]
    public void AddToDatabase()
    {
        clientDataLayerAPI.AddClient(1, "Jack Daniels");
        Assert.IsNotNull(clientDataLayerAPI.GetClient(1));
    }

    [TestMethod]
    public void UpdateInfo()
    {
        clientDataLayerAPI.UpdateName(0, "Jack Turner");
        Assert.AreEqual("Jack Turner", clientDataLayerAPI.GetClient(1).Name);
    }
}