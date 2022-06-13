using System;
using Model;
using ViewModel.MVVM;

namespace ViewModel;

public class AddEditViewModel : BaseViewModel
{
    public AddEditViewModel()
    {
        AddClothesCommand = new ModelCommand(AddClothes);
        EditClothesCommand = new ModelCommand(EditClothes);
        currentClothes = new ClothesViewModel().RetriveClothes();
        NewClothes = new ClothesModel();
    }

    public ModelCommand AddClothesCommand

    {
        get; private set;
    }
    public ModelCommand EditClothesCommand

    {
        get; private set;
    }

    public void AddClothes()
    {

        //bool added = ClothesCRUD.addClothes(newClothes.id, newClothes.price, newClothes.type);
        //if (added)
        {

            actionText = "Clothes Added";
        }
        //else
        {
            actionText = "Clothes with such ID already exists in the database";
        }
        MessageBoxShowDelegate(ActionText);

    }

    public void EditClothes()
    {

        //bool editedP = ClothesCRUD.updatePrice(currentClothes.id, currentClothes.price);
        //bool editedT = ClothesCRUD.updateType(currentClothes.id, currentClothes.type);
            
        //if (editedP && editedT)
        {
            actionText = "Clothes Edited";
        }
        //else
        {
            actionText = "Clothes with such ID already exists in the database";
        }
        MessageBoxShowDelegate(ActionText);

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

    private ClothesModel newClothes;
    public ClothesModel NewClothes
    {
        get
        {
            return newClothes;
        }
        set
        {
            newClothes = value;
            OnPropertyChanged("NewClothes");

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