using System;
using Model;
using Model.API;
using ViewModel.MVVM;

namespace ViewModel;

public class AddEditClientViewModel : BaseViewModel
{
    private IClientModel model;
    
    public AddEditClientViewModel()
    {
        AddClientCommand = new ModelCommand(AddClient);
        EditClientCommand = new ModelCommand(EditClient);
        currentClient = new ClientViewModel().RetrieveClient();
        model = new ClientModel();
    }

    public ModelCommand AddClientCommand

    {
        get; private set;
    }
    public ModelCommand EditClientCommand

    {
        get; private set;
    }

    public void AddClient()
    {

        bool added = model.Add(newClient.Id, newClient.Name);
        if (added)
        {

            actionText = "Client Added";
        }
        else
        {
            actionText = "Client with such ID already exists in the database";
        }
        MessageBoxShowDelegate(ActionText);

    }

    public void EditClient()
    {

        bool editedN = model.Update(currentClient.Id, currentClient.Name);

        if (editedN)
        {
            actionText = "Client Edited";
        }
        else
        {
            actionText = "Oh nooo something went wrong";
        }
        MessageBoxShowDelegate(ActionText);

    }

    private IClientModelData currentClient;
    public IClientModelData CurrentClient
    {
        get
        {

            return currentClient;
        }
        set
        {
            currentClient = value;
            OnPropertyChanged("CurrentClient");

        }

    }

    private IClientModelData newClient;
    public IClientModelData NewClient
    {
        get
        {
            return newClient;
        }
        set
        {
            newClient = value;
            OnPropertyChanged("NewClient");

        }

    }

    private string actionText;
    public string ActionText
    {
        get
        {
            return actionText;
        }
        set
        {
            actionText = value;
            OnPropertyChanged("ActionText");
        }
    }

    public ModelCommand DisplayPopUpCommand { get; private set; }

    public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");

}