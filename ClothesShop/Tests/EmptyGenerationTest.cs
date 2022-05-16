using System;
using DataLayer.API;
using Tests;
using Tests.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class EmptyGenerationTests
    {
        private DataLayerAPI repository;
        private Tests.IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            repository = DataLayerAPI.GetDataRepository();
            generator = new EmptyGenerator();
            generator.GenerateData(repository);
        }


        [TestMethod]
        public void TestMethod1()
        {

            Assert.AreEqual(0, repository.GetClothesNumber());

        }
    }
}
