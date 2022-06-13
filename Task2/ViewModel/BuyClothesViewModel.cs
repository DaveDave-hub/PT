using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DataRepository;
using Model;
using Model.API;
using ViewModel.MVVM;

namespace ViewModel;

public class BuyClothesViewModel : BaseViewModel
{
    private IEventModel model;
    private IClientModel clientModel;
    private IClothesModel clothesModel;
    
    public BuyClothesViewModel()
    {
        RefreshClothes();
        RefreshClients();
        BuyClothesCommand = new ModelCommand(BuyClothes);
        RefreshClothesCommand = new ModelCommand(RefreshEverything);
        model = new EventModel();
        clientModel = new ClientModel();
        clothesModel = new ClothesModel();
    }

    private void RefreshEverything()
    {
        RefreshClients();
        RefreshClothes();
    }

    private void BuyClothes()
    {
        bool ordered = false;
        if (this.currentClothes != null && this.currentClient != null)
            ordered = model.Add(NewOrderID,DateTime.Now,  currentClothes.Id, currentClient.Id);

        actionText = ordered ? "Clothes Ordered" : "Something went wrong upss";
        MessageBoxShowDelegate(ActionText);
    }

    private void RefreshClothes()
    {
        Clothes = clothesModel.Clothes;
        OnPropertyChanged("Clothes");
    }

    private IEnumerable<IClothesModelData> donuts;
    public IEnumerable<IClothesModelData> Clothes
    {
        get
        {
            return donuts;
        }

        set
        {
            donuts = value;
            OnPropertyChanged("Clothess");
        }
    }


    private void RefreshClients()
    {
        Clients = clientModel.Clients;
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

    /*Master detail - displays events for selected client*/
    private ClientModelData currentClient;
    public ClientModelData CurrentClient
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

    private int newOrderID;
    public int NewOrderID
    {
        get
        {
            return newOrderID;
        }

        set
        {
            newOrderID = value;
            OnPropertyChanged("NewOrderID");
        }
    }

    private int newQuantity;
    public int NewQuantity
    {
        get
        {
            return newQuantity;
        }

        set
        {
            newQuantity = value;
            OnPropertyChanged("NewQuantity");
        }
    }

    private ClothesModelData currentClothes;
    public ClothesModelData CurrentClothes
    {
        get
        {
            return currentClothes;
        }
        set
        {
            currentClothes = value;
            OnPropertyChanged("CurrentClothes");

        }

    }

    public ModelCommand RefreshClothesCommand

    {
        get; private set;
    }
    public ModelCommand BuyClothesCommand

    {
        get; private set;
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