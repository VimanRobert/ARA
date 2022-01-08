using Consultatii;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Programari.xaml
    /// </summary>
    public partial class Programari : Window
    {
        ActiuniProgramari actiuni = ActiuniProgramari.Nimic;
        CollectionViewSource pacientViewSource;
        CollectionViewSource cadruViewSource;
        ConsultatiiClienti cons = new ConsultatiiClienti();
        CollectionViewSource cadruProgramaresViewSource;

        public int CNP { get; private set; }
        public int Nr_cadru { get; private set; }

        public Programari()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pacientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pacientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pacientViewSource.Source = [generic data source]
            pacientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pacientViewSource")));
            pacientViewSource.Source = cons.Pacients.Local;
            cons.Pacients.Load();
            System.Windows.Data.CollectionViewSource cadruViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cadruViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // cadruViewSource.Source = [generic data source]
            
            cadruProgramaresViewSource = ((CollectionViewSource)(this.FindResource("pacientProgramaresViewSource")));
            cadruProgramaresViewSource.Source = cons.Programares.Local;
            cons.Programares.Load();
            cons.Cadrus.Load();

            cmbPacient.ItemsSource = cons.Pacients.Local;
            cmbPacient.DisplayMemberPath = "Nume";
            cmbPacient.DisplayMemberPath = "Prenume";
            cmbPacient.SelectedValuePath = "CNP";
            cmbCadru.ItemsSource = cons.Cadrus.Local;
            cmbCadru.DisplayMemberPath = "Telefon";
            cmbCadru.DisplayMemberPath = "Specializare";
            cmbCadru.DisplayMemberPath = "Prenume";
            cmbCadru.DisplayMemberPath = "Nume";
            cmbCadru.SelectedValuePath = "Nr_cadru";
            // Load data by setting the CollectionViewSource.Source property:
            // cadruViewSource.Source = [generic data source]
        }
        public void BtAdauga_Click(object sender, RoutedEventArgs e)
        {
            actiuni = ActiuniProgramari.Adauga;
        }
        public void BtSterge_Click(object sender, RoutedEventArgs e)
        {
            actiuni = ActiuniProgramari.Sterge;
        }
        public void BtModifica_Click(object sender, RoutedEventArgs e)
        {
            actiuni = ActiuniProgramari.Modifica;
        }
        public void listaProgramari_Click(object sender, RoutedEventArgs e)
        {
            actiuni = ActiuniProgramari.Modifica;
        }
        private void SavePacient()
        {
            Pacient pacient = null;
            if (actiuni == ActiuniProgramari.Adauga)
            {
                try
                {
                    pacient = new Pacient()
                    {
                        CNP = cNPTextBox.CaretIndex,
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim(),
                    };
                    cons.Pacients.Add(pacient);
                    cons.SaveChanges();
                    pacientViewSource.View.Refresh();
                }
                catch (DataException de)
                {
                    MessageBox.Show(de.Message);
                }
            }
            else if (actiuni == ActiuniProgramari.Modifica)
            {
                try
                {
                    pacient = (Pacient)pacientDataGrid.SelectedItem;

                }
                catch (DataException de)
                {
                    MessageBox.Show(de.Message);
                }
            }
            else if (actiuni == ActiuniProgramari.Sterge)
            {
                try
                {
                    pacient = (Pacient)pacientDataGrid.SelectedItem;
                    cons.Pacients.Remove(pacient);
                    cons.SaveChanges();

                }
                catch (DataException de)
                {
                    MessageBox.Show(de.Message);
                }
                pacientViewSource.View.Refresh();
            }
        }
        private void SetValidationBiding()
        {
           
        }

        private void Inapoi_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void gbOperatiuni_Click(object sender, RoutedEventArgs e)
        {
                Button SelectedButton = (Button)e.OriginalSource;
                Panel panel = (Panel)SelectedButton.Parent;

                foreach (Button B in panel.Children.OfType<Button>())
                {
                    if (B != SelectedButton)
                        B.IsEnabled = false;
                }
                gbActiuni.IsEnabled = true;
            }
        private void gbActiuni_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ReInitialize()
        {

            Panel panel = gbOperatiuni.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActiuni.IsEnabled = false;
        }
        private void pacientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtSalvare_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = pacientDataGrid.SelectedItem as TabItem;
            switch (tabItem.Header)
            {
                case "Pacienti":
                    SavePacient();
                    break;
                case "Programari":
                    SaveProgramare();
                    break;
            }
            ReInitialize();
        }

        private void BtAnulare_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void SaveProgramare()
        {
            Programare programare = null;
            if (actiuni == ActiuniProgramari.Adauga)
            {
                try
                {
                    Pacient pacient = (Pacient)cmbPacient.SelectedItem;
                    Cadru cadru = (Cadru)cmbCadru.SelectedItem;
                    programare = new Programare()
                    {
                        CNP = (int)pacient.CNP,
                        Nr_cadru = (int)cadru.Nr_cadru,
                        Nr_ordine = programare.Nr_ordine

                    };
                    cons.Programares.Add(programare);
                    cons.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void BindDataGrid()
        {
            var qProgramare = from prg in cons.Programares
                              join pnt in cons.Pacients on prg.CNP equals
                              pnt.CNP
                              join cdu in cons.Cadrus on prg.CNP
                      equals cdu.Nr_cadru
                              select new { prg.CNP, prg.Nr_cadru, prg.Nr_ordine };
            cadruProgramaresViewSource.Source = qProgramare.ToList();
        }
    }
}
