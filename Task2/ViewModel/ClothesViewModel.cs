using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Model;
using Presentation.ViewModel.AdditionalInterfaces;
using Services;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class ClothesViewModel : BaseViewModel
    {

        public ClothesViewModel()
        {
            this.RefreshClothes();
            AddClothesCommand = new ModelCommand(AddClothes);
            EditClothesCommand = new ModelCommand(EditClothes);
            DeleteClothesCommand = new ModelCommand(DeleteClothes);
            RefreshClothesCommand = new ModelCommand(RefreshClothes);
        }

        private void RefreshClothes()
        {
            Task.Run(() => this.Clothes = GetClothesModelsConverter());
            this.OnPropertyChanged("Clothes");
        }

        private IEnumerable<ClothesModel> clothes;
        public IEnumerable<ClothesModel> Clothes
        {
            get
            {
                return this.clothes;
            }

            set
            {
                this.clothes = value;
                this.OnPropertyChanged("Clothes");
            }
        }


        private static ClothesModel currentClothes;
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



        public ModelCommand AddClothesCommand

        {
            get; private set;
        }
        public ModelCommand DeleteClothesCommand

        {
            get; private set;
        }


        public Lazy<IWindow> ChildWindow { get; set; }

        public Lazy<IWindow> EditWindow { get; set; }


        private void AddClothes()
        {


            IWindow _child = ChildWindow.Value;
            _child.Show();

        }



        private void EditClothes()
        {

            IWindow newWindow = EditWindow.Value;
            newWindow.Show();

        }

        private void DeleteClothes()
        {
            ClothesCRUD.deleteClothes(CurrentClothes.id);
            RefreshClothes();
        }


        public ModelCommand RefreshClothesCommand

        {
            get; private set;
        }


        public ModelCommand EditClothesCommand

        {
            get; private set;
        }

        public static ClothesModel RetriveClothes()
        {
            return currentClothes;
        }

        public IEnumerable<ClothesModel> GetClothesModelsConverter()
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



    }
}
