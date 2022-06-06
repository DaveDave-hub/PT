using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Presentation.ViewModel.AdditionalInterfaces;
using Presentation.ViewModel;

namespace Presentation
{
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
}
