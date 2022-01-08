using Consultatii;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace ARA
{
    enum ActiuniProgramari
    {
        Adauga,
        Sterge,
        Modifica,
        Nimic
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CollectionViewSource programaresViewSource;
        ConsultatiiClienti cons = new ConsultatiiClienti();
        CollectionViewSource cadruProgramaresViewSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pacientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pacientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pacientViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource cadruViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cadruViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // cadruViewSource.Source = [generic data source]

            //programaresViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("programaresViewSource")));
            //programaresViewSource.Source = cons.Programares.Local;
            //cons.Programares.Load();
            cadruProgramaresViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cadruProgramaresViewSource")));
            cadruProgramaresViewSource.Source = cons.Programares.Local;
            cons.Programares.Load();
        }

        private void pacientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSpecialisti_Click(object sender, RoutedEventArgs e)
        {
            Specialisti specialisti = new Specialisti();
            this.Visibility = Visibility.Hidden;
            specialisti.Show();
        }

        private void btnProgramari_Click(object sender, RoutedEventArgs e)
        {
            Programari programari = new Programari();
            this.Visibility = Visibility.Hidden;
            programari.Show();
        }

    }
}
