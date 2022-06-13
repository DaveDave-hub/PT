using Data;
using Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest;

[TestClass]
public class ClothesDataTests
{
    private DataClasses1DataContext database;
    private IClothesDataLayerAPI clothesDataLayerAPI;
        
    [TestInitialize]
    public void TestInitialize()
    {
        database = new DataClasses1DataContext();
        clothesDataLayerAPI = new ClothesCRUD();
            
        database.ExecuteCommand("DELETE FROM Events");
        database.ExecuteCommand("DELETE FROM Clients");
        database.ExecuteCommand("DELETE FROM Clothes");
            
        clothesDataLayerAPI.AddClothes(0, 100, "Sweater");
    }
    
    [TestMethod]
    public void CheckIfNull()
    {
        Assert.IsNotNull(clothesDataLayerAPI.GetClothes(0));
    }
    
    [TestMethod]
    public void CheckDataCorrectness()
    {
        Assert.AreEqual(100, clothesDataLayerAPI.GetClothes(0).Price);
    }

    [TestMethod]
    public void AddToDatabase()
    {
        clothesDataLayerAPI.AddClothes(1, 100, "Jacket");
        Assert.IsNotNull(clothesDataLayerAPI.GetClothes(1));
    }

    [TestMethod]
    [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
    public void ConnectingToNonExsistingDb()
    {
        using DataClasses1DataContext fake = new DataClasses1DataContext("Data Source = DESKTOP-H5C7HVQ; Initial Catalog = Fakeee; Integrated Security = True");
        Clothes clothes = new Clothes
        {
            id = 12345,
            price = 1000,
            type = "top"
        };

        fake.Clothes.InsertOnSubmit(clothes);
        fake.SubmitChanges();
    }
}