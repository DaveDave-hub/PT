using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;


namespace PresentationTest;

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
}