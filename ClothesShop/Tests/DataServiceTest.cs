using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
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

        [TestMethod]
		public void AddAndGetClient()
		{
			Client c = new Client("Ula", "Brzydula", "6");
			Assert.AreEqual(service.GetAllClientsNumber(), 0);
			service.AddClient(c);
			Assert.AreEqual(service.GetAllClientsNumber(), 1);
			Client temp = service.GetClientById("6");
			Assert.AreEqual(temp, c);
		}


	}
}