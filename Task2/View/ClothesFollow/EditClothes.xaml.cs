using System.Windows;
using ViewModel;
using ViewModel.MVVM;

namespace View.ClothesFollow;

/// <summary>
/// Logika interakcji dla klasy Window1.xaml
/// </summary>
public partial class EditClothes : Window, IWindow
{
    private AddEditViewModel viewModel = new AddEditViewModel();
    public EditClothes()
    {
        InitializeComponent();
        this.Loaded += (s, e) => { this.DataContext = this.viewModel; };
        viewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}