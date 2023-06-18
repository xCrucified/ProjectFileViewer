using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ListBox = System.Windows.Controls.ListBox;

namespace ProjectFileViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        ViewModels viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModels();
            this.DataContext = viewModel;

        }

        private void OpenBtnClick(object sender, RoutedEventArgs e)
        {
            viewModel.OpenFileDialog();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewModel.OpenFile();
        }

    }
}
