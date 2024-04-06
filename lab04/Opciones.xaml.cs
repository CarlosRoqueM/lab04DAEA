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
using System.Windows.Shapes;

namespace lab04
{
    /// <summary>
    /// Lógica de interacción para Opciones.xaml
    /// </summary>
    public partial class Opciones : Window
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void DataReadBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Proveedores_Click(object sender, RoutedEventArgs e)
        {
            VentanaProveedores provee = new VentanaProveedores();
            provee.Show();
            Close();
        }

        private void ProveNomBtn_Click(object sender, RoutedEventArgs e)
        {
            ProveNom proveNom = new ProveNom();
            proveNom.Show();
            Close();
        }
    }
}
