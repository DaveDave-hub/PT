using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.DataRepository;
using Presentation.Model;
using Presentation.ViewModel.AdditionalInterfaces;
using Presentation.ViewModel;
using Services;

namespace Presentation.ViewModel
{
    public class AddEditClientViewModel : BaseViewModel
    {
        public AddEditClientViewModel()
        {
            AddClientCommand = new ModelCommand(AddClient);
            EditClientCommand = new ModelCommand(EditClient);
            currentClient = ClientViewModel.RetriveClient();
            newClient = new ClientModel();

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

            bool added = ClientCRUD.AddClient(newClient.id, newClient.name);
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

            bool editedN = ClientCRUD.UpdateName(currentClient.id, currentClient.name);

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

        private ClientModel currentClient;
        public ClientModel CurrentClient
        {
            get
            {

                return this.currentClient;
            }
            set
            {
                this.currentClient = value;
                this.OnPropertyChanged("CurrentClient");

            }

        }

        private ClientModel newClient;
        public ClientModel NewClient
        {
            get
            {
                return this.newClient;
            }
            set
            {
                this.newClient = value;
                this.OnPropertyChanged("NewClient");

            }

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

    }
}
