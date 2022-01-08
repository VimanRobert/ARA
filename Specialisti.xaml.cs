using Consultatii;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ARA
{
    /// <summary>
    /// Interaction logic for Specialisti.xaml
    /// </summary>
    public partial class Specialisti : Window
    {
        CollectionViewSource cadruViewSource;
        ConsultatiiClienti cons1 = new ConsultatiiClienti();

        public Specialisti()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource cadruViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cadruViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // cadruViewSource.Source = [generic data source]
            cadruViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cadruViewSource")));
            cadruViewSource.Source = cons1.Cadrus.Local;
            cons1.Cadrus.Load();
            
        }
        private void btnInapoi_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();

        }

        private void cadruDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
