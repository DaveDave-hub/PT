using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DataRepository;
using Model;
using Presentation.Model;
using Presentation.ViewModel.AdditionalInterfaces;
using Services;

namespace Presentation.ViewModel
{
    public class BuyClothesViewModel : BaseViewModel
    {
        public BuyClothesViewModel()
        {
            this.RefreshClothes();
            this.RefreshClients();
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
            if (this.currentClothes != null && this.currentClient != null)
                ordered = EventCRUD.BuyClothes(NewOrderID, currentClothes.id, currentClient.Id, newQuantity);

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
            Task.Run(() => this.Clothess = GetClothessModelsConverter());
            this.OnPropertyChanged("Clothess");
        }

        private IEnumerable<ClothesModel> donuts;
        public IEnumerable<ClothesModel> Clothess
        {
            get
            {
                return this.donuts;
            }

            set
            {
                this.donuts = value;
                this.OnPropertyChanged("Clothess");
            }
        }


        private void RefreshClients()
        {
            Task.Run(() => this.Clients = GetClientsModelsConverter());
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
                this.OnPropertyChanged("NewOrderID");
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
                this.OnPropertyChanged("NewQuantity");
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
                this.OnPropertyChanged("CurrentClothes");

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
                return this.actionText;
            }
            set
            {
                this.actionText = value;
                OnPropertyChanged("ActionText");
            }
        }

        public ModelCommand DisplayPopUpCommand { get; private set; }

        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");

        public IEnumerable<ClothesModel> GetClothessModelsConverter()
        {
            List<Dictionary<string, string>> retrived = ClothesCRUD.GetAllClothesInfo();
            List<ClothesModel> temp = new List<ClothesModel>();

            foreach (Dictionary<string, string> dict in retrived)
            {
                ClothesModel t = new ClothesModel();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }
        public IEnumerable<ClientModelData> GetClientsModelsConverter()
        {
            List<Dictionary<string, string>> retrived = ClientCRUD.GetClientsInfo();
            List<ClientModelData> temp = new List<ClientModelData>();

            foreach (Dictionary<string, string> dict in retrived)
            {
                ClientModelData t = new ClientModelData();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }

    }
}
