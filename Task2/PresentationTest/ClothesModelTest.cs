using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.API;
using PresentationTest.Fakes;

namespace PresentationTest;

[TestClass]
public class ClothesModelTest
{
    private IClothesModel model;

    [TestInitialize]
    public void TestInitialize()
    {
        model = new ClothesModelFake();
    }

    [TestMethod]
    public void CheckIfAddReturnsTrue()
    {
        Assert.IsTrue(model.Add(1, 100, "shoes"));
    }
    
    [TestMethod]
    public void CheckIfModelUpdates()
    {
        Assert.IsTrue(model.Add(1, 100, "shoes"));
        Assert.IsTrue(model.Update(1, 200, "jacket"));
    }
    
    [TestMethod]
    public void CheckIfModelRemoves()
    {
        Assert.IsTrue(model.Add(1, 100, "shoes"));
        Assert.IsTrue(model.Delete(1));
    }
}