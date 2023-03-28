using Microsoft.Toolkit.Mvvm.Input;
using Prueba_Proyecto.Clases;
using Prueba_Proyecto.Servicios;
using Prueba_Proyecto.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Prueba_Proyecto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
        }

        private void EmpledosButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 5;
            ServicioDocumentos sImagenes = new ServicioDocumentos();
            PdfServicio pdf = new PdfServicio();
            Producto producto1 = new Producto(1, "Jack Daniel's", "Whiskey", 35.99m, "Whiskey de Tennesse", "Whiskey", 40f, "arbol.jpg");
            producto1.Foto = sImagenes.SubirImagen(producto1.Foto);
            pdf.GenerarPDFProducto(producto1);
        }

        private void ComTranporteButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 4;
        }

        private void ClientesButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 3;
        }

        private void FaccturasButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 2;
        }

        private void PedidosButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 1;
        }

        private void InicioButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 0;
        }

        private void ProductosButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 6;
        }
    }
}
