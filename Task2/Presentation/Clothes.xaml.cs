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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Presentation.ViewModel;
using Presentation.ViewModel.AdditionalInterfaces;

namespace Presentation
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class Clothes : UserControl
    {
        private ClothesViewModel viewModel = new ClothesViewModel();
        public Clothes()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = this.viewModel; };
            viewModel.ChildWindow = new Lazy<IWindow>(() => new AddClothes());
            viewModel.EditWindow = new Lazy<IWindow>(() => new EditClothes());
        }
    }
}
