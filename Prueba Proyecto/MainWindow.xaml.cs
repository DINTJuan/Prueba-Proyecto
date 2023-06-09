﻿using Microsoft.Toolkit.Mvvm.Input;
using Prueba_Proyecto.Clases;
using Prueba_Proyecto.Servicios;
using Prueba_Proyecto.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
            VentanaTabControl.SelectedIndex = 4;
        }

        private void ComTranporteButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaTabControl.SelectedIndex = 3;
        }

        private void ClientesButton_Click(object sender, RoutedEventArgs e)
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
            VentanaTabControl.SelectedIndex = 5;
        }

        private void LimpiarSecButton_Click(object sender, RoutedEventArgs e)
        {
            vm.QuitarProducto();
        }

        private void PDFButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirProducto();
        }

        private void ListaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirProductos();
        }

        private void ListaButtonE_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirEmpleados();
        }

        private void LimpiarSecButtonE_Click(object sender, RoutedEventArgs e)
        {
            vm.QuitarEmpleado();
        }

        private void ListaButtonC_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirCompanias();
        }

        private void LimpiarSecButtonC_Click(object sender, RoutedEventArgs e)
        {
            vm.QuitarCompania();
        }

        private void Detalles_Click(object sender, RoutedEventArgs e)
        {
            VentanaEmergenteId.IsOpen = true;
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaEmergenteId.IsOpen = false;
            IdTextBox.Text = "";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.BuscarPorID(IdTextBox.Text);
            VentanaEmergenteBuscado.IsOpen = true;
        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaEmergenteBuscado.IsOpen = false;
        }

        private void PDFClientesButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirClientes();
        }

        private void PDFDetallesButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirDetallesPedidos();
        }

        private void PDFPedidosButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ImprimirPedidos();
        }

        private void EliminarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarProducto();
        }

        private void EliminarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarEmpleado();
        }

        private void EliminarCompania_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarCompaniaEnvios();
        }

        private void EliminarPedido_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarPedido();
        }

        private void EliminarClienteButtom_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarCliente();
        }
        private void SubirPedidoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SubirPedidos();
        }

        private void SubirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SubirClientes();
        }

        private void SubirEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SubirEmpleados();
        }

        private void SubirProductoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SubirProductos();
        }

        private void SubirCompaniaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SubirCompania();
        }

        private void ProductoFotoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.CambiarImagenProducto();
        }

        private void EmpleadoFotoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.CambiarImagenEmpleado();
        }

        private void CompaniaFotoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.CambiarImagenCompania();
        }

        private void NuevoProductoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ProductoNuevo();
            NuevoProductoPopup.IsOpen = true;
        }

        private void ProductoFotoNuevoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NuevoProductoPopup.IsOpen = false;
            vm.CambiarImagenProductoNuevo();
            NuevoProductoPopup.IsOpen = true;
        }

        private void CancelarNButton_Click(object sender, RoutedEventArgs e)
        {
            NuevoProductoPopup.IsOpen = false;
        }

        private void CrearButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirNuevoProducto();
            NuevoProductoPopup.IsOpen = false;
        }

        private void EmpleadoFotoNuevoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NuevoEmpladoPopup.IsOpen = false;
            vm.CambiarImagenEmpleadoNuevo();
            NuevoEmpladoPopup.IsOpen = true;
        }

        private void CancelarNButtonE_Click(object sender, RoutedEventArgs e)
        {
            NuevoEmpladoPopup.IsOpen = false;
        }

        private void NuevoEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EmpleadoNuevo();
            NuevoEmpladoPopup.IsOpen = true;
        }

        private void CrearButtonE_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirNuevoEmpleado();
            NuevoEmpladoPopup.IsOpen = false;
        }

        private void CompaniaFotoNuevoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NuevaCompaniaPopup.IsOpen = false;
            vm.CambiarImagenCompaniaNuevo();
            NuevaCompaniaPopup.IsOpen = true;
        }

        private void CrearButtonC_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirNuevaCompania();
            NuevaCompaniaPopup.IsOpen = false;
        }

        private void CancelarNButtonC_Click(object sender, RoutedEventArgs e)
        {
            NuevaCompaniaPopup.IsOpen = false;
        }

        private void NuevacompaniadoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CompaniaNuevo();
            NuevaCompaniaPopup.IsOpen = true;
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                // Obtener la celda y columna seleccionada
                DataGridCellInfo cellInfo = dataGrid.CurrentCell;

                if (cellInfo != null)
                {
                    if (cellInfo.Column.Header.ToString() == "Fecha Pedido")
                    {
                        FechaPTextBox.Text = vm.PedidoSeleccionado.FechaPedido.ToString("dd/MM/yyyy");
                        VentanaEmergenteFechaP.IsOpen = true;
                    }
                    else if (cellInfo.Column.Header.ToString() == "Fecha Envío")
                    {
                        FechaETextBox.Text = vm.PedidoSeleccionado.FechaEnvio.ToString("dd/MM/yyyy");
                        VentanaEmergenteFechaE.IsOpen = true;
                    }
                    else if (cellInfo.Column.Header.ToString() == "Fecha Entrega")
                    {
                        FechaTTextBox.Text = vm.PedidoSeleccionado.FechaEntrega.ToString("dd/MM/yyyy");
                        VentanaEmergenteFechaT.IsOpen = true;
                    }
                }
            }
        }

        private void AceptarFPButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParseExact(FechaPTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPedido))
            {
                vm.PedidoSeleccionado.FechaPedido = fechaPedido;
            }
            VentanaEmergenteFechaP.IsOpen = false;

        }

        private void CancelarFPButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaEmergenteFechaP.IsOpen = false;
        }

        private void AceptarFEButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParseExact(FechaETextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPedido))
            {
                vm.PedidoSeleccionado.FechaEnvio = fechaPedido;
            }
            VentanaEmergenteFechaE.IsOpen = false;
        }

        private void CancelarFEButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaEmergenteFechaE.IsOpen = false;
        }

        private void AceptarFTButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParseExact(FechaTTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPedido))
            {
                vm.PedidoSeleccionado.FechaEntrega = fechaPedido;
            }
            VentanaEmergenteFechaT.IsOpen = false;
        }

        private void CancelarFTButton_Click(object sender, RoutedEventArgs e)
        {
            VentanaEmergenteFechaT.IsOpen = false;
        }
    }
}
