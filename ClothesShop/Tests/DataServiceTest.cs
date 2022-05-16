using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using LogicLayer;
using Tests.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataServiceTest
    {

		/*private DataService service;
		private DataContext our_shop;
		private IGenerator generator;
	
		[TestInitialize]
		public void Initialize()
		{
			our_shop = new DataContext();
			service = new DataService(new DataRepository(our_shop));
			generator = new FixedGenerator();
			generator.GenerateData(our_shop);
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

		[TestMethod]
		public void UpdateClientInfo()
		{

			Assert.AreEqual("James", service.GetClientById("1").FirstName);
			service.UpdateClientInfo("Alex", "Bond ", "1");
			Assert.AreEqual("Alex", service.GetClientById("1").FirstName);
		}

		[TestMethod]
		public void DeleteClientCorrect()
		{

			service.DeleteClient("1");
			Assert.AreEqual(service.GetAllClientsNumber(), 3);


		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void DeleteClientException()
		{

			service.DeleteClient("LKSDMV");
			Assert.AreEqual(service.GetAllClientsNumber(), 3);

		}

		[TestMethod]
		public void ClothesTest()
		{
			Clothes clothes = new Clothes(99, 40, ClothesType.tshirt);
			service.AddClothes(clothes);
			Assert.AreEqual(clothes, service.GetClothesById(99));
			service.DeleteClothes(99);
		}




		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void DeleteClothesException()
		{

			service.DeleteClothes(999999);
			Assert.AreEqual(service.GetNumberOfClothes(), 1);

		}



		[TestMethod]
		public void EventCorrectDeleteTests()
		{
			Client temp = service.GetClientById("1");
			DateTime now = DateTime.Now;
			Event b = new BuyingEvent("b1", service.GetState(), temp, now);
			service.AddEvent(b);
			Assert.AreEqual(service.GetAllEventsNumber(), 1);
			service.DeleteEvent("b1");
			Assert.AreEqual(service.GetAllEventsNumber(), 0);

		}

		[TestMethod]
		public void EventUserBuyingTests()
		{

			DateTime now = DateTime.Now;
			service.BuyClothes("1", 1, now, 5);
			Assert.AreEqual(service.GetAllEventsNumber(), 1);
			Assert.AreEqual(5, service.GetStateOfClothes(1));
			IEnumerable<Event> lista = service.GetEventsForTheClient("1");
			Assert.AreEqual(1, lista.Count());
			service.BuyClothes("1", 2, now, 4);
			lista = service.GetEventsForTheClient("1");
			Assert.AreEqual(2, lista.Count());

		}

		[TestMethod]
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
		}

		[TestMethod]
		public void EventUserNewBatchTests()
		{

			DateTime now = DateTime.Now;
			service.NewBatch("1", 1, now, 5);
			Assert.AreEqual(service.GetAllEventsNumber(), 1);
			Assert.AreEqual(15, service.GetStateOfClothes(1));
			IEnumerable<Event> lista = service.GetEventsForTheClient("1");
			Assert.AreEqual(1, lista.Count());


		}






*/
	}
}