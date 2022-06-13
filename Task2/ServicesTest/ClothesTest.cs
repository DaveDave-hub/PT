using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.API;
using ServicesTest.Fakes;

namespace ServicesTest;

[TestClass]
public class ClothesTest
{
    private IClothesLogic clothesLogic;
        
    [TestInitialize]
    public void TestInitialize()
    {
        clothesLogic = new ClothesLogicFake();
    }
    
    [TestMethod]
    public void AddandDeleteClothesTest()
    {
        Assert.IsTrue(clothesLogic.AddClothes(123, 100, "hoodie"));
        IEnumerable<IClothesData> clothes = clothesLogic.GetAllClothes();
        Assert.AreEqual(clothes.Count(), 1);
        Assert.IsTrue(clothesLogic.DeleteClothes(123));
        IEnumerable<IClothesData> c2 = clothesLogic.GetAllClothes();
        Assert.AreEqual(c2.Count(), 0);
    }
    
    [TestMethod]
    public void UpdateClothesTest()
    {
        clothesLogic.AddClothes(666, 80, "jacket");
        Assert.IsTrue(clothesLogic.UpdateClothes(666, 60, "jacket"));
        Assert.AreEqual(clothesLogic.GetClothes(666).Price, 60);
        Assert.IsTrue(clothesLogic.UpdateClothes(666, 60, "jumper"));
        Assert.AreEqual(clothesLogic.GetClothes(666).Type, "jumper");
        clothesLogic.DeleteClothes(666);
    }
    
    
    [TestMethod]
    public void GetClothesTest()
    {
        clothesLogic.AddClothes(1, 80, "shoes");
        Assert.AreEqual(clothesLogic.GetClothes(1).Type, "shoes");
    }
    
    [TestMethod]
    public void GetAllClothesTest()
    {
        clothesLogic.AddClothes(1, 80, "shoes");
        IEnumerable<IClothesData> clothes = clothesLogic.GetAllClothes();
        Assert.AreEqual(clothes.Count(), 1);
    }
}