using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using ViewModel.MVVM;

namespace ViewModel;

public class BuyClothesViewModel : BaseViewModel
{
    public BuyClothesViewModel()
    {
        RefreshClothes();
        RefreshClients();
        BuyClothesCommand = new ModelCommand(BuyClothes);
        RefreshClothesCommand = new ModelCommand(RefreshEverything);
    }

    private void RefreshEverything()
    {
        RefreshClients();
        RefreshClothes();
    }

    private void BuyClothes()
    {
        bool ordered = false;
        //if (this.currentClothes != null && this.currentClient != null)
        //ordered = EventCRUD.BuyClothes(NewOrderID, currentClothes.id, currentClient.Id, newQuantity);

        if (ordered)
        {
            actionText = "Clothess Ordered";
        }
        else
        {
            actionText = "Something went wrong upss";
        }
        MessageBoxShowDelegate(ActionText);
    }

    private void RefreshClothes()
    {
        Task.Run(() => Clothess = GetClothessModelsConverter());
        OnPropertyChanged("Clothess");
    }

    private IEnumerable<ClothesModel> donuts;
    public IEnumerable<ClothesModel> Clothess
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
        Task.Run(() => Clients = GetClientsModelsConverter());
    }

    private IEnumerable<ClientModelData> clients;
    public IEnumerable<ClientModelData> Clients
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

    private ClothesModel currentClothes;
    public ClothesModel CurrentClothes
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

    public IEnumerable<ClothesModel> GetClothessModelsConverter()
    {
        // List<Dictionary<string, string>> retrived = ClothesCRUD.GetAllClothesInfo();
        List<ClothesModel> temp = new List<ClothesModel>();

        //foreach (Dictionary<string, string> dict in retrived)
        {
            //ClothesModel t = new ClothesModel();
            //t.Converter(dict);
            //temp.Add(t);
        }
        return temp;
    }
    public IEnumerable<ClientModelData> GetClientsModelsConverter()
    {
        // List<Dictionary<string, string>> retrived = ClientCRUD.GetClientsInfo();
        List<ClientModelData> temp = new List<ClientModelData>();

        //foreach (Dictionary<string, string> dict in retrived)
        {
            //ClientModelData t = new ClientModelData();
            //t.Converter(dict);
            //temp.Add(t);
        }
        return temp;
    }

}