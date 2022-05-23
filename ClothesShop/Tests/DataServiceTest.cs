using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.API;
using LogicLayer.API;
using Tests.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataServiceTest
    {

		private DataService service;
		private DataLayerAPI data;
		private IGenerator generator;
	
		[TestInitialize]
		public void Initialize()
		{
			data = DataLayerAPI.GetDataRepository();
			service = new DataService(data);
			generator = new FixedGenerator();
			generator.GenerateData(data);
		}

        [TestMethod]
		public void AddAndGetClient()
		{
			Assert.AreEqual(service.GetAllClientsNumber(), 4);
			service.AddClient("Ula", "Brzydula", 6);
			Assert.AreEqual(service.GetAllClientsNumber(), 5);
			String temp = service.GetClientFirstName(6);
			Assert.AreEqual(temp, "Ula");
		}

		[TestMethod]
		public void UpdateClientInfo()
		{

			Assert.AreEqual("James", service.GetClientFirstName(1));
			service.UpdateClientsInfo("Alex", "Bond", 1);
			Assert.AreEqual("Alex", service.GetClientFirstName(1));
		}

		[TestMethod]
		public void DeleteClientCorrect()
		{
			service.DeleteClient(1);
			Assert.AreEqual(service.GetAllClientsNumber(), 3);
		}

		[TestMethod]
		public void DeleteClientException()
		{
			Assert.ThrowsException<Exception>(() => service.DeleteClient(1253));
		}

		[TestMethod]
		public void ClothesTest()
		{
			service.AddClothes(99, 40, "tshirt");
			Assert.AreEqual("tshirt", service.GetClothes(99));
			service.DeleteClothes(99);
		}




		[TestMethod]
		public void DeleteClothesException()
		{
			Assert.ThrowsException<Exception>(() => service.DeleteClothes(999999));
		}



		[TestMethod]
		public void EventCorrectDeleteTests()
		{
			DateTime now = DateTime.Now;
			service.AddNewBatchEvent(1, 1, 1, now);
			Assert.AreEqual(service.GetAllEventsNumber(), 1);
			service.DeleteEvent(1);
			Assert.AreEqual(service.GetAllEventsNumber(), 0);
		}
		

		/*[TestMethod]
		public void BuyClothesTest()
		{
			Client client = new Client("Ann", "Smith", "5");
			service.AddClient(client);
			Clothes clothes = new Clothes(3, 100, ClothesType.dress);
			DateTime now = DateTime.Now;
			service.AddandUpdate(clothes, 50);
			int stateThen = service.GetStateOfClothes(3);
			service.BuyClothes("5", 3, now, 2);
			Assert.AreEqual(stateThen - 2, service.GetStateOfClothes(3));
		}


		[TestMethod]
		public void NewBatchTest()
		{
			Client supplier = new Client("Bershka", "", "5");
			service.AddClient(supplier);
			Clothes clothes = new Clothes(4, 100, ClothesType.sneakers);
			DateTime now = DateTime.Now;
			service.AddandUpdate(clothes, 0);
			int stateThen = service.GetStateOfClothes(4);
			service.NewBatch("5", 4, now, 99);
			Assert.AreEqual(stateThen + 99, service.GetStateOfClothes(4));
		}*/

		[TestMethod]
		public void EventUserNewBatchTests()
		{
			DateTime now = DateTime.Now;
			service.AddNewBatchEvent(1, 1, 2, now);
			Assert.AreEqual(service.GetAllEventsNumber(), 1);
			Assert.AreEqual("hoodie", service.GetClothes(1));
		}
    }
}