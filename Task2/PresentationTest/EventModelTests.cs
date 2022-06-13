using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.API;
using PresentationTest.Fakes;

namespace PresentationTest;

[TestClass]
public class EventModelTests
{
    private IEventModel model;

    [TestInitialize]
    public void TestInitialize()
    {
        model = new EventModelFake();
    }

    [TestMethod]
    public void CheckIfAddReturnsTrue()
    {
        Assert.IsTrue(model.Add(1, DateTime.Now, 1, 1));
    }
    
    [TestMethod]
    public void CheckIfModelUpdates()
    {
        Assert.IsTrue(model.Add(1, DateTime.Now, 1, 1));
        Assert.IsTrue(model.Update(1, DateTime.MaxValue, 2, 3));
    }
    
    [TestMethod]
    public void CheckIfModelRemoves()
    {
        Assert.IsTrue(model.Add(1, DateTime.Now, 1, 1));
        Assert.IsTrue(model.Delete(1));
    }
}