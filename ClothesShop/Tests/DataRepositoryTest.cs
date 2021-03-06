using System;
using DataLayer.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.DataGeneration;

namespace Tests
{
    [TestClass]
    public class DataRepositoryTest
    {
        private DataLayerAPI data;
        private IGenerator generator;

        [TestInitialize]
        public void Initialize()
        {
            data = DataLayerAPI.GetDataRepository();
            generator = new FixedGenerator();
            generator.GenerateData(data);
        }


        [TestMethod]
        public void AddAndGetClient()
        {
            Assert.AreEqual(data.GetAllClientsNumber(), 4);
            data.AddClient("Tom", "Fitz", 6);
            Assert.AreEqual(data.GetAllClientsNumber(), 5);
            String firstName = data.GetClientFirstName(6);
            Assert.AreEqual(firstName, "Tom");
        }

        [TestMethod]
        public void DeleteClientCorrect()
        {
            data.DeleteClient(1);
            Assert.AreEqual(data.GetAllClientsNumber(), 3);
        }

        [TestMethod]
        public void DeleteClientException()
        {
            Assert.ThrowsException<Exception>(() => data.DeleteClient(2834));
        }

        [TestMethod]
        public void UpdateClientInfo()
        {
            String temp = data.GetClientFirstName(1);
            Assert.AreEqual("James", temp);
            data.UpdateClientsInfo("Alex", "Bond", 1);
            temp = data.GetClientFirstName(1);
            Assert.AreEqual("Alex", temp);
        }


        [TestMethod]
        public void AddAndGetClothes()
        {
            Assert.AreEqual(data.GetClothesNumber(), 2);
            data.AddClothes(7, 35, "tshirt");
            Assert.AreEqual(data.GetClothesNumber(), 3);
            String temp = data.GetClothes(7);
            Assert.AreEqual(temp, "tshirt");
        }

        [TestMethod]
        public void DeleteClothesCorrect()
        {
            data.DeleteClothes(2);
            Assert.AreEqual(data.GetClothesNumber(), 1);
        }

        [TestMethod]
        public void UpdateClothesInfo()
        {
            String temp = data.GetClothes(2);
            Assert.AreEqual("tshirt", temp);
            data.UpdateClothesInfo(2, 30, "hoodie");
            temp = data.GetClothes(2);
            Assert.AreEqual("hoodie", temp);
        }

        [TestMethod]
        public void EventTests()
        {
            DateTime now = DateTime.Now;
            data.AddNewBatchEvent(1, 1, 1, now);
            Assert.AreEqual(data.GetAllEventsNumber(), 1);

        }

        [TestMethod]
        public void EventTestsDeleteException()
        {
            DateTime now = DateTime.Now;
            data.AddNewBatchEvent(1,1,1, now);
            Assert.AreEqual(data.GetAllEventsNumber(), 1);
            Assert.ThrowsException<Exception>(() => data.DeleteEvent(2));

        }

        [TestMethod]
        public void EventCorrectDeleteTests()
        {
            DateTime now = DateTime.Now;
            data.AddNewBatchEvent(1, 1, 1, now);
            Assert.AreEqual(data.GetAllEventsNumber(), 1);
            data.DeleteEvent(1);
            Assert.AreEqual(data.GetAllEventsNumber(), 0);

        }


        [TestMethod]
        public void StatesTest()
        {
            Assert.AreEqual(data.GetClothesState(1, 1), 10);
            data.UpdateClothesStateInfo(1, 13, 1);
            Assert.AreEqual(data.GetClothesState(1, 1), 13);

        }

        [TestMethod]
        public void ExceptionNoClothesToDeleteTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => data.DeleteOneClothesState(981648, 1));
        }
    }
}
