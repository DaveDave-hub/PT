using System.Collections.Generic;
using Model;
using Model.API;
using ViewModel.MVVM;

namespace ViewModel;

public class ClientViewModel : BaseViewModel
{
    private readonly IClientModel model;
        
    public ClientViewModel(IClientModel model = default)
    {
        this.model = model ??  new ClientModel();
            
        AddClientCommand = new ModelCommand(AddClient);
        EditClientCommand = new ModelCommand(EditClient);
        DeleteClientCommand = new ModelCommand(DeleteClient);
        RefreshClientCommand = new ModelCommand(RefreshClients);
            
        RefreshClients();
    }

    private void RefreshClients()
    {
        Clients = model.Clients;
    }

    private IEnumerable<IClientModelData> clients;
    public IEnumerable<IClientModelData> Clients
    {
        get => clients;
        set
        {
            clients = value;
            OnPropertyChanged("Clients");
        }
    }

    private IClientModelData currentClient;
    public IClientModelData CurrentClient
    {
        get => currentClient;

        set
        {
            currentClient = value;
            OnPropertyChanged("CurrentClient");
        }
    }

    public ModelCommand AddClientCommand { get; }
    public ModelCommand EditClientCommand { get; }
    public ModelCommand RefreshClientCommand { get; }
    public ModelCommand DeleteClientCommand { get; }

    private void AddClient()
    {
        model.Logic.AddClient(CurrentClient.Id, CurrentClient.Name);
    }

    private void EditClient()
    {
        model.Logic.UpdateClient(CurrentClient.Id, CurrentClient.Name);
        RefreshClients();
    }
        
    private void DeleteClient()
    {
        model.Logic.DeleteClient(CurrentClient.Id);
        RefreshClients();
    }

    public IClientModelData RetrieveClient()
    {
        return currentClient;
    }
}