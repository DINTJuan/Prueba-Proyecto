using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Prueba_Proyecto.VM
{
    internal class MainWindowVM : ObservableObject , INotifyPropertyChanged
    {
        public TabControl VentanaTabControl { get; set; }

        public ICommand SelectInicioCommand { get; }
        public ICommand SelectPedidosCommand { get; }
        public ICommand SelectFacturasCommand { get; }
        public ICommand SelectClientesCommand { get; }
        public ICommand SelectTransporteCommand { get; }
        public ICommand SelectEmpleadosCommand { get; }

        public MainWindowVM()
        {
            // Inicializar los comandos correspondientes para cada TabItem
            SelectInicioCommand = new RelayCommand(SelectInicio);
            SelectPedidosCommand = new RelayCommand(SelectPedidos);
            SelectFacturasCommand = new RelayCommand(SelectFacturas);
            SelectClientesCommand = new RelayCommand(SelectClientes);
            SelectTransporteCommand = new RelayCommand(SelectTransporte);
            SelectEmpleadosCommand = new RelayCommand(SelectEmpleados);
        }



        // Métodos que serán ejecutados cuando se active el comando correspondiente
        private void SelectInicio()
        {
            VentanaTabControl.SelectedIndex = 0;
        }

        private void SelectPedidos()
        {
            VentanaTabControl.SelectedIndex = 1;
        }

        private void SelectFacturas()
        {
            VentanaTabControl.SelectedIndex = 2;
        }

        private void SelectClientes()
        {
            VentanaTabControl.SelectedIndex = 3;
        }

        private void SelectTransporte()
        {
            VentanaTabControl.SelectedIndex = 4;
        }

        private void SelectEmpleados()
        {
            VentanaTabControl.SelectedIndex = 5;
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
