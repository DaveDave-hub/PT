using System;
using DataLayer;
using Tests.DataGeneration;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.API;

namespace TestingData
{
    [TestClass]
    public class RandomTest

    {
        private DataLayerAPI repository;
        private Tests.IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            repository = DataLayerAPI.GetDataRepository();
            generator = new RandomGenerator();
            generator.GenerateData(repository);
        }

        [TestMethod]
        public void NotNull()
        {
            Assert.IsNotNull(repository.GetAllClientsNumber());
            Assert.IsNotNull(repository.GetAllEventsNumber());

        }

        [TestMethod]
        public void Checkquantity()
        {
            Assert.AreEqual(repository.GetClothesNumber(), 9);
            Assert.AreEqual(repository.GetAllClientsNumber(), 9);
            Assert.AreEqual(repository.GetAllEventsNumber(), 0);
        }
    }
}
