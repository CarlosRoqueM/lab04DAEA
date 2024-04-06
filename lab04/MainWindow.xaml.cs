using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace lab04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargaDatos();
        }

        private void CargaDatos()
        {
            string ConnectionString = "Data Source= LAB1504-04\\SQLEXPRESS; Initial Catalog=lab04;" + "User Id = Carlos; Password=carlos99";

            List<Productos> producto = new List<Productos>();

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("ListarProductos", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idProducto = reader.GetInt32("idProducto");
                    string nombreProducto = reader.GetString("nombreProducto");
                    int idProveedor = reader.GetInt32("idProveedor");
                    int idCategoria = reader.GetInt32("idCategoria");
                    string cantidadPorUnidad = reader.GetString("cantidadPorUnidad");
                    int unidadesEnExistencia = reader.GetInt16("unidadesEnExistencia");
                    int unidadesEnPedido = reader.GetInt16("unidadesEnPedido");
                    int nivelNuevoPedido = reader.GetInt16("nivelNuevoPedido");
                    int suspendidos = reader.GetInt16("suspendido");
                    string categoriaProducto = reader.GetString("nombreProducto");

                    producto.Add(new Productos { idProducto = idProducto , nombreProducto = nombreProducto, idProveedor = idProveedor, idCategoria = idCategoria, cantidadPorUnidad = cantidadPorUnidad, unidadesEnExistencia =unidadesEnExistencia, unidadesEnPedido = unidadesEnPedido, nivelNuevoPedido = nivelNuevoPedido, suspendidos = suspendidos, categoriaProducto = categoriaProducto});
                }
                connection.Close();
                Number02.ItemsSource = producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}