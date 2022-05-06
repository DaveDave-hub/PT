﻿using System;
using DataLayer;
using Tests.DataGeneration;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class RandomTest

    {

        private DataContext our_shop;
        private IDataRepository repository;
        private IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            our_shop = new DataContext();
            repository = new DataRepository(our_shop);
            generator = new RandomGenerator();
            generator.GenerateData(our_shop);
        }

        [TestMethod]
        public void NotNull()
        {
            Assert.IsNotNull(repository.GetAllClothes());
            Assert.IsNotNull(repository.GetAllClients());
            Assert.IsNotNull(repository.GetAllEvents());

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
