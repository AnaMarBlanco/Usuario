using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Usuario.BLL;
using Usuario.Entidades;

namespace Usuario.UI
{
    /// <summary>
    /// Interaction logic for RegistrosUsuarios.xaml
    /// </summary>
    public partial class RegistrosUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public RegistrosUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void Limpiar()
        {
            usuario = new Usuarios();
            this.DataContext = usuario;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = UsuariosBLL.Buscar(int.Parse(UsuarioIdTextBox.Text));

            if (encontrado != null)
            {
                this.usuario = encontrado;

                this.DataContext = encontrado;
            }

            else
                this.usuario = new Usuarios();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ClaveTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }



            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        

    }
}
