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
		private DataContext our_shop;

		[TestInitialize]
		public void Initialize()
		{
			our_shop = new DataContext();
			service = new DataService(new DataRepository(our_shop));
		}

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
			Assert.AreEqual(service.GetAllClientsNumber(), 4);
			service.AddClient(c);
			Assert.AreEqual(service.GetAllClientsNumber(), 5);
			Client temp = service.GetClientById("6");
			Assert.AreEqual(temp, c);
		}


	}
}