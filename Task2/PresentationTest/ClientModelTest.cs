using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;


namespace PresentationTest
{
    [TestClass]
    public class ClientModelTest
    {

        [TestMethod]
        public void CreatorTestMethodListView()
        {
            ClientViewModel vm = new ClientViewModel();

            Assert.IsNotNull(vm.AddClientCommand);
            Assert.IsNotNull(vm.EditClientCommand);
            Assert.IsNotNull(vm.RefreshClientCommand);
            Assert.IsNotNull(vm.DeleteClientCommand);

            Assert.IsTrue(vm.AddClientCommand.CanExecute(null));
            Assert.IsTrue(vm.EditClientCommand.CanExecute(null));
            Assert.IsTrue(vm.RefreshClientCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteClientCommand.CanExecute(null));
        }

        [TestMethod]
        public void CreatorTestMethodAddEditView()
        {
            AddEditClientViewModel vm = new AddEditClientViewModel();

            Assert.IsTrue(String.IsNullOrEmpty(vm.ActionText));
            Assert.IsNotNull(vm.MessageBoxShowDelegate);

            Assert.IsNotNull(vm.AddClientCommand);
            Assert.IsNotNull(vm.EditClientCommand);

            Assert.IsTrue(vm.AddClientCommand.CanExecute(null));
            Assert.IsTrue(vm.EditClientCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddReaderPopUpWasShownTest()
        {
            ClientViewModel vm = new ClientViewModel();

            vm.CurrentClient = new Presentation.Model.ClientModel();

            vm.CurrentClient.id = 0;
            vm.CurrentClient.name = "Test";

            AddEditClientViewModel evm = new AddEditClientViewModel();

            int _boxShowCount = 0;
            evm.MessageBoxShowDelegate = (messageBoxText) =>
            {
                _boxShowCount++;
                Assert.AreEqual("Client Added", messageBoxText);
            };

            evm.ActionText = "Client Added";


            Assert.IsTrue(vm.AddClientCommand.CanExecute(null));
            Assert.IsTrue(vm.RefreshClientCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteClientCommand.CanExecute(null));

            evm.AddClientCommand.Execute(null);
            Assert.AreEqual(1, _boxShowCount);

            vm.RefreshClientCommand.Execute(null);

            Thread.Sleep(3000);
            Assert.IsTrue(vm.Clients.Count() > 4);

            vm.CurrentClient = vm.Clients.FirstOrDefault();
            Assert.IsNotNull(vm.CurrentClient);

            vm.DeleteClientCommand.Execute(null);
        }



        [TestMethod]
        public void RefreshClients()
        {
            ClientViewModel vm = new ClientViewModel();

            //view loads readers after 3s
            Thread.Sleep(3000);
            Assert.IsTrue(vm.Clients.Count() > 0);
        }


        [TestMethod]
        public void RefreshEventsCurrentClient()
        {
            ClientViewModel vm = new ClientViewModel();

            Thread.Sleep(3000);

            var eventRefreshEventRaised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Events")
                {
                    eventRefreshEventRaised = true;
                }
            };

            vm.CurrentClient = vm.Clients.Skip(1).First();
            Assert.IsNotNull(vm.CurrentClient);

            Thread.Sleep(3000);
            Assert.IsTrue(eventRefreshEventRaised);
        }
    }
}
