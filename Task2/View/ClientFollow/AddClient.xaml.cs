using System.Windows;
using ViewModel;
using ViewModel.MVVM;

namespace View.ClientFollow;

/// <summary>
/// Logika interakcji dla klasy Window1.xaml
/// </summary>
public partial class AddClient : Window, IWindow
{
    private AddEditClientViewModel viewModel = new AddEditClientViewModel();
    public AddClient()
    {
        InitializeComponent();
        this.Loaded += (s, e) => { this.DataContext = this.viewModel; };
        viewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}