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
    /// Lógica de interacción para ProveNom.xaml
    /// </summary>
    public partial class ProveNom : Window
    {
        public ProveNom()
        {
            CargaDatos();
        }

        private void CargaDatos()
        {
            string ConnectionString = "Data Source= LAB1504-04\\SQLEXPRESS; Initial Catalog=lab04;" + "User Id = Carlos; Password=carlos99";

            List<Proveeedores> proveedores = new List<Proveeedores>();

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("LisarProveNom", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nombreContacto = reader.GetString("nombrecontacto");
                    string ciudad = reader.GetString("ciudad");
                    
                    proveedores.Add(new Proveeedores {nombreContacto = nombreContacto, ciudad = ciudad});

                    Number04.ItemsSource = proveedores;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

