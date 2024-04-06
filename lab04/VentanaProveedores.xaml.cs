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
    /// Lógica de interacción para VentanaProveedores.xaml
    /// </summary>
    public partial class VentanaProveedores : Window
    {
        public VentanaProveedores()
        {
            InitializeComponent();
            CargaDatos();
        }

        private void CargaDatos()
        {
            string ConnectionString = "Data Source= LAB1504-04\\SQLEXPRESS; Initial Catalog=lab04;" + "User Id = Carlos; Password=carlos99";

            List<Categoria> categorias = new List<Categoria>();

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("ListarCategorias", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idCategoria = reader.GetInt32("idCategoria");
                    string nombreCategoria = reader.GetString("nombreCategoria");
                    string descripcion = reader.GetString("descripcion");
                    bool Activo = reader.GetBoolean("Activo");
                    string CodCategoria = reader.GetString("CodCategoria");

                    categorias.Add(new Categoria { idCategoria = idCategoria, nombreCategoria = nombreCategoria, descripcion = descripcion, Activo = Activo, CodCategoria = CodCategoria });
                  
                    Number03.ItemsSource = categorias;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
