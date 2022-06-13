using System;
using System.Collections.Generic;
using Model;
using Model.API;
using ViewModel.MVVM;

namespace ViewModel;

public class ClothesViewModel : BaseViewModel
{
    private readonly IClientModel model;

    public ClothesViewModel(IClientModel model = default)
    {
        this.model = model ?? new ClientModel();
            
        AddClothesCommand = new ModelCommand(AddClothes);
        EditClothesCommand = new ModelCommand(EditClothes);
        DeleteClothesCommand = new ModelCommand(DeleteClothes);
        RefreshClothesCommand = new ModelCommand(RefreshClothes);
            
        RefreshClothes();
    }

    private void RefreshClothes()
    {
        //Task.Run(() => this.Clothes = GetClothesModelsConverter());
        OnPropertyChanged("Clothes");
    }

    private IEnumerable<ClothesModelData> clothes;
    public IEnumerable<ClothesModelData> Clothes
    {
        get
        {
            return clothes;
        }

        set
        {
            clothes = value;
            OnPropertyChanged("Clothes");
        }
    }


    private ClothesModelData currentClothes;
    public ClothesModelData CurrentClothes
    {
        get => currentClothes;
        set
        {
            currentClothes = value;
            OnPropertyChanged("CurrentClothes");

        }

    }
        
    public ModelCommand AddClothesCommand { get; private set; }
    public ModelCommand DeleteClothesCommand { get; private set; }


    public Lazy<IWindow> ChildWindow { get; set; }
    public Lazy<IWindow> EditWindow { get; set; }


    private void AddClothes()
    {
        IWindow child = ChildWindow.Value; 
        child.Show();

    }

    private void EditClothes()
    {
        IWindow newWindow = EditWindow.Value;
        newWindow.Show();
    }

    private void DeleteClothes()
    {
        //IClothesLogic.deleteClothes(CurrentClothes.id);
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

    public ClothesModel RetriveClothes()
    {
        return new ClothesModel();
    }
}