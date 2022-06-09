using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Model;
using Presentation.ViewModel.AdditionalInterfaces;
using Services;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.DataRepository;
using Dataa;
using Model;
using Model.API;

namespace Presentation.ViewModel
{
    public class ClientViewModel : BaseViewModel
    {
        private IClientModel model;
        
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

        private static ClientModelData currentClient;
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
                this.RefreshEvents();
            }
        }

        private IEnumerable<EventModel> events;
        public IEnumerable<EventModel> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                OnPropertyChanged("Events");
            }
        }
        private void RefreshEvents()

        {
            if (this.CurrentClient != null)
                Task.Run(() => this.Events = GetEventsforClientModelsConverter(CurrentClient.Id));

        }

        /*Display book for selected event */
        private EventModel currentEvent;
        public EventModel CurrentEvent
        {
            get
            {
                return this.currentEvent;
            }
            set
            {
                this.currentEvent = value;
                OnPropertyChanged("CurrentEvent");
                this.RefreshClothes();
            }
        }

        private ClothesModel clothes;
        public ClothesModel Clothes
        {
            get
            {
                return this.clothes;
            }
            set
            {
                this.clothes = value;
                OnPropertyChanged("Clothes");
            }
        }

        private void RefreshClothes()
        {
            if (currentEvent != null)
            {
                Task.Run(() => this.Clothes = GetClothesModel(CurrentEvent.clothes_id));
            }
            else
            {
                this.Clothes = null;
            }
        }

        public ModelCommand AddClientCommand

        {
            get; private set;
        }

        public ModelCommand EditClientCommand

        {
            get; private set;
        }


        public ModelCommand RefreshClientCommand

        {
            get; private set;
        }

        public ModelCommand DeleteClientCommand

        {
            get; private set;
        }


        public Lazy<IWindow> NewWindow { get; set; }


        public Lazy<IWindow> EditWindow { get; set; }

        private void AddClient()
        {
            IWindow newWindow = NewWindow.Value;
            newWindow.Show();
        }

        private void EditClient()
        {
            IWindow editWindow = EditWindow.Value;
            editWindow.Show();
        }




        private void DeleteClient()
        {
            ClientCRUD.DeleteClient(CurrentClient.Id);
            RefreshClients();
        }

        public static ClientModelData RetriveClient()
        {
            return currentClient;
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

        public IEnumerable<EventModel> GetEventsforClientModelsConverter(int client_id)
        {
            List<Dictionary<string, string>> retrived = (List<Dictionary<string, string>>)EventCRUD.GetEventsByClient(client_id);
            List<EventModel> temp = new List<EventModel>();

            foreach (Dictionary<string, string> dict in retrived)
            {
                EventModel t = new EventModel();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }

        public ClothesModel GetClothesModel(int clothes_id)
        {
            ClothesModel temp = new ClothesModel();
            temp.Converter(ClothesCRUD.GetOneClotheInfo(clothes_id));
            return temp;

        }

    }
}
