using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace ServicesTest;

[TestClass]
public class ClothesTest
{
    // [TestMethod]
    // public void AddandDeleteClothesTest()
    // {
    //     Assert.IsTrue(ClothesCRUD.addClothes(123, 100, "hoodie"));
    //     IEnumerable<Clothes> clothes = ClothesCRUD.GetAllClothes();
    //     Assert.AreEqual(clothes.Count(), 7);
    //     Assert.IsTrue(ClothesCRUD.deleteClothes(123));
    //     IEnumerable<Clothes> c2 = ClothesCRUD.GetAllClothes();
    //     Assert.AreEqual(c2.Count(), 6);
    // }
    //
    // [TestMethod]
    // public void UpdateClothesTest()
    // {
    //     ClothesCRUD.addClothes(666, 80, "jacket");
    //     Assert.IsTrue(ClothesCRUD.updatePrice(666, 60));
    //     Assert.AreEqual(ClothesCRUD.GetClothes(666).price, 60);
    //     Assert.IsTrue(ClothesCRUD.updateType(666, "jumper"));
    //     Assert.AreEqual(ClothesCRUD.GetClothes(666).type, "jumper");
    //     ClothesCRUD.deleteClothes(666);
    // }
    //
    //
    // [TestMethod]
    // public void GetClothesTest()
    // {
    //     Assert.AreEqual(ClothesCRUD.GetClothes(1).type, "shoes");
    // }
    //
    // [TestMethod]
    // public void GetAllClothesTest()
    // {
    //     IEnumerable<Clothes> clothes = ClothesCRUD.GetAllClothes();
    //     Assert.AreEqual(clothes.Count(), 6);
    // }
    //
    // [TestMethod]
    // public void GetClothesByTypeTest()
    // {
    //     IEnumerable<Clothes> clothes = ClothesCRUD.GetClothesByType("shoes");
    //     Assert.AreEqual(clothes.Count(), 2);
    //     Assert.AreEqual(clothes.ElementAt(0).price, 350);
    //     Assert.AreEqual(clothes.ElementAt(1).price, 500);
    // }
    //
    // [TestMethod]
    // public void GetClothesByPriceTest()
    // {
    //     IEnumerable<Clothes> clothes = ClothesCRUD.GetClothesByPrice(16);
    //     Assert.AreEqual(clothes.Count(), 1);
    //     Assert.AreEqual(clothes.ElementAt(0).type, "socks");
    // }
}