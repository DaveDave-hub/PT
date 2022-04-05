using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
//using DataLayer.DataGeneration;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataServiceTest
    {

		private DataService service;

		[TestMethod]
		public void ClothesTest()
		{
			Clothes clothes = new Clothes(1, 40, ClothesType.tshirt);
			service.AddClothes(clothes);
			Assert.AreEqual(clothes, service.GetClothesById(1));
			service.DeleteClothes(1);

		}
	}
}