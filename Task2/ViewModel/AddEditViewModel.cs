using System;
using Model;
using Model.API;
using ViewModel.MVVM;

namespace ViewModel;

public class AddEditViewModel : BaseViewModel
{
    private IClothesModel model;
    
    public AddEditViewModel()
    {
        AddClothesCommand = new ModelCommand(AddClothes);
        EditClothesCommand = new ModelCommand(EditClothes);
        model = new ClothesModel();
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

        bool added = model.Add(newClothes.Id, newClothes.Price, newClothes.Type);
        if (added)
        {

            actionText = "Clothes Added";
        }
        else
        {
            actionText = "Clothes with such ID already exists in the database";
        }
        MessageBoxShowDelegate(ActionText);

    }

    public void EditClothes()
    {

        bool edited = model.Update(currentClothes.Id, currentClothes.Price, currentClothes.Type);

        if (edited)
        {
            actionText = "Clothes Edited";
        }
        else
        {
            actionText = "Clothes with such ID already exists in the database";
        }
        MessageBoxShowDelegate(ActionText);

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

    private ClothesModelData newClothes;
    public ClothesModelData NewClothes
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