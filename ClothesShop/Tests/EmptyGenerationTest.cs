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
        private DataContext our_shop;
        private DataLayerAPI repository;
        private IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            our_shop = new DataContext();
            repository = new DataRepository(our_shop);
            generator = new EmptyGenerator();
            generator.GenerateData(our_shop);
        }


        [TestMethod]
        public void TestMethod1()
        {

            Assert.AreEqual(0, repository.GetClothesNumber());

        }
    }
}
