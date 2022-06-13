using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.API;
using PresentationTest.Fakes;

namespace PresentationTest;

[TestClass]
public class ClientModelTests
{
    private IClientModel model;

    [TestInitialize]
    public void TestInitialize()
    {
        model = new ClientModelFake();
    }

    [TestMethod]
    public void CheckIfAddReturnsTrue()
    {
        Assert.IsTrue(model.Add(1, "Bolek"));
    }
    
    [TestMethod]
    public void CheckIfModelUpdates()
    {
        Assert.IsTrue(model.Add(1, "Bolek"));
        Assert.IsTrue(model.Update(1, "Lolek"));
    }
    
    [TestMethod]
    public void CheckIfModelRemoves()
    {
        Assert.IsTrue(model.Add(1, "Bolek"));
        Assert.IsTrue(model.Delete(1));
    }
}