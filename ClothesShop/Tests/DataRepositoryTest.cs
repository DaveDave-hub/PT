using System;
using DataLayer;
using DataLayer.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class DataRepositoryTest
    {

        private DataContext our_shop;
        private IDataRepository repository;
        private IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            our_shop = new DataContext();
            repository = new DataRepository(our_shop);
            generator = new FixedGenerator();
            generator.GenerateData(our_shop);
        }


        [TestMethod]
        public void AddAndGetClient()
        {
            Client c = new Client("Tom", "Fitz", "6");
            Assert.AreEqual(repository.GetAllClientsNumber(), 4);
            repository.AddClient(c);
            Assert.AreEqual(repository.GetAllClientsNumber(), 5);
            Client temp = repository.GetClient("6");
            Assert.AreEqual(temp, c);
        }

        [TestMethod]
        public void DeleteClientCorrect()
        {

            repository.DeleteClient("1");
            Assert.AreEqual(repository.GetAllClientsNumber(), 3);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteClientException()
        {

            repository.DeleteClient("EEEEOOO");
            Assert.AreEqual(repository.GetAllClientsNumber(), 3);

        }

        [TestMethod]
        public void UpdateClientInfo()
        {
            Client temp = repository.GetClient("1");
            Assert.AreEqual("James", temp.FirstName);
            Client c = new Client("Alex", "Bond", "1");
            repository.UpdateClientsInfo(c);
            temp = repository.GetClient("1");
            Assert.AreEqual("Alex", temp.FirstName);
        }


        [TestMethod]
        public void AddAndGetClothes()
        {
            Clothes c = new Clothes(7, 35, ClothesType.tshirt);
            Assert.AreEqual(repository.GetClothesNumber(), 2);
            repository.AddClothes(c);
            Assert.AreEqual(repository.GetClothesNumber(), 3);
            Clothes temp = repository.GetClothes(7);
            Assert.AreEqual(temp, c);
        }

        [TestMethod]
        public void DeleteClothesCorrect()
        {

            repository.DeleteClothes(2);
            Assert.AreEqual(repository.GetClothesNumber(), 1);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteClothesException()
        {

            repository.DeleteClothes(12345);
            Assert.AreEqual(repository.GetClothesNumber(), 2);

        }

        [TestMethod]
        public void UpdateClothesInfo()
        {
            Clothes temp = repository.GetClothes(2);
            Assert.AreEqual(45, temp.Price);
            Clothes c = new Clothes(2, 30, ClothesType.tshirt);
            repository.UpdateClothesInfo(c);
            temp = repository.GetClothes(2);
            Assert.AreEqual(30, temp.Price);
        }

        [TestMethod]
        public void EventTests()
        {
            Client temp = repository.GetClient("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void EventTestsDeleteException()
        {
            Client temp = repository.GetClient("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);
            repository.DeleteEvent("cos");

        }

        [TestMethod]
        public void EventCorrectDeleteTests()
        {
            Client temp = repository.GetClient("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);
            repository.DeleteEvent("b1");
            Assert.AreEqual(repository.GetAllEventsNumber(), 0);

        }


        [TestMethod]
        public void StatesTest()
        {
            Assert.AreEqual(repository.GetClothesState(1), 10);
            repository.UpdateClothesStateInfo(1, 13);
            Assert.AreEqual(repository.GetClothesState(1), 13);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ExceptionNoClothesToDeleteTest()
        {
            Assert.AreEqual(repository.GetClothesState(1), 10);
            repository.DeleteOneClothesState(981648);


        }




    }
}
