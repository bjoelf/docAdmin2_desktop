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

namespace docAdmin2_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileImport_Click(object sender, RoutedEventArgs e)
        {

        }
        static int ClientIdentity()
        {
            //Denna metod skall ersättas med ett kundsökning eller en inputbox där kundnummer ges manuellt.!
            //https://www.tutorialspoint.com/xaml/xaml_searchbox.htm
            //https://github.com/microsoft/BotBuilder-Samples
            int ret = 1;
            return ret;
        }
    }
}
