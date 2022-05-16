using System;
using DataLayer;
using Tests;
using Tests.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.API;

namespace TestingData
{
    [TestClass]
    public class FixedGenerationTest

    {
        private DataLayerAPI repository;
        private Tests.IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            repository = DataLayerAPI.GetDataRepository();
            generator = new FixedGenerator();
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
            Assert.AreEqual(repository.GetAllClientsNumber(), 4);
            Assert.AreEqual(repository.GetClothesNumber(), 2);
        }
    }
}

