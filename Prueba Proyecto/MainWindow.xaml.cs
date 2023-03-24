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
            vm.VentanaTabControl = VentanaTabControl;

            ObservableCollection<CompaniaEnvio> companias = new ObservableCollection<CompaniaEnvio>()
            {
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 1,
                    Nombre = "DHL",
                    Telefono = "123456789",
                    Foto = "foto1.png"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 2,
                    Nombre = "FedEx",
                    Telefono = "987654321",
                    Foto = "foto2.png"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 3,
                    Nombre = "UPS",
                    Telefono = "555555555",
                    Foto = "foto3.png"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 4,
                    Nombre = "TNT",
                    Telefono = "111111111",
                    Foto = "foto4.png"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 5,
                    Nombre = "Correos",
                    Telefono = "222222222",
                    Foto = "foto5.png"
                }
            };

            PdfServicio pdf = new PdfServicio();
            pdf.GenerarPDFCompañias(companias);
        }

        private void EmpledosButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 5;
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
    }
}
