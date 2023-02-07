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

namespace WpfApplicationINotifyPropertyChanged
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassSongVM _VM;
        private int count;
        public MainWindow()
        {

            // Cet appel est requis par le concepteur.
            InitializeComponent();

            // Ajoutez une initialisation quelconque après l'appel InitializeComponent().

            _VM = new ClassSongVM();  // Sans ce code behind, il faut déclarer <Window.Datacontext... dans xaml
            DataContext = _VM;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("I want to change the name of this artist")
            // _VM = New ClassSongVM
            count += 1;
            _VM._artistName = "Name Updated" + count.ToString();
        }
    }
}
