using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectFileViewer
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        ViewModels viewModel;
        public SecondWindow()
        {
            InitializeComponent();
            viewModel = new ViewModels();
            this.DataContext = viewModel;
            
        }

        private void PreviousBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button pressed");
        }

        private void OpenFileBtnClick(object sender, RoutedEventArgs e)
        {
            viewModel.OpenFileDialog();
        }

        private void NextBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button pressed");
        }
    }

}
