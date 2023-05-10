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
using System.Collections.ObjectModel;
using Prueba_Proyecto.Clases;
using Prueba_Proyecto.Servicios;
using System.Globalization;

namespace Prueba_Proyecto.VM
{
    internal class MainWindowVM : ObservableObject
    {
        private ObservableCollection<Producto> listaProductos;
        private Producto productoSelecionado;
        private ObservableCollection<Empleado> listaEmpleados;
        private Empleado empleadoSelecionado;
        private ObservableCollection<CompaniaEnvio> listaCompanias;
        private CompaniaEnvio companiaSelecionado;
        private ObservableCollection<Pedido> listaPedidos;
        private ObservableCollection<DetallesPedido> listaDetallesPedidos;
        private ObservableCollection<DetallesPedido> listaDetallesPedidosBuscados;
        private ObservableCollection<Cliente> listaClientes;

        private PdfServicio pdfServicio = new PdfServicio();
        
        


        public ObservableCollection<Producto> ListaProductos
        {
            get { return listaProductos; }
            set { SetProperty(ref listaProductos, value); }
        }

        public Producto ProductoSelecionado
        {
            get { return productoSelecionado; }
            set { SetProperty(ref productoSelecionado, value); }
        }

        public ObservableCollection<Empleado> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { SetProperty(ref listaEmpleados, value); }
        }

        public Empleado EmpleadoSelecionado
        {
            get { return empleadoSelecionado; }
            set { SetProperty(ref empleadoSelecionado, value); }
        }

        public ObservableCollection<CompaniaEnvio> ListaCompanias
        {
            get { return listaCompanias; }
            set { SetProperty(ref listaCompanias, value); }
        }

        public CompaniaEnvio CompaniaSelecionado
        {
            get { return companiaSelecionado; }
            set { SetProperty(ref companiaSelecionado, value); }
        }

        public ObservableCollection<Pedido> ListaPedidos
        {
            get { return listaPedidos; }
            set { SetProperty(ref listaPedidos, value); }
        }

        public ObservableCollection<DetallesPedido> ListaDetallesPedidos
        {
            get { return listaDetallesPedidos; }
            set { SetProperty(ref listaDetallesPedidos, value); }
        }

        public ObservableCollection<DetallesPedido> ListaDetallesPedidosBuscados
        {
            get { return listaDetallesPedidosBuscados; }
            set { SetProperty(ref listaDetallesPedidosBuscados, value); }
        }

        public ObservableCollection<Cliente> ListaClientes
        {
            get { return listaClientes; }
            set { SetProperty(ref listaClientes, value); }
        }

        public MainWindowVM()
        {
            AzureServicio azure = new AzureServicio();
            BaseDatosServicio bd = new BaseDatosServicio();

            this.ListaProductos = bd.SacarProductos();
            this.ListaEmpleados = bd.SacarEmpleados();
            this.ListaCompanias = bd.SacarCompaniasEnvio();
            this.listaClientes = bd.SacarClientes();

            ObservableCollection<Pedido> pedidos = new ObservableCollection<Pedido>()
            {
                new Pedido(1, 1, 1, 1, new DateTime(2022, 1, 1), new DateTime(2022, 1, 8), new DateTime(2022, 1, 2), "Express", "Juan Perez", "Calle 123"),
                new Pedido(2, 2, 2, 2, new DateTime(2022, 1, 2), new DateTime(2022, 1, 9), new DateTime(2022, 1, 3), "Normal", "Maria Gomez", "Avenida 456"),
                new Pedido(3, 3, 3, 3, new DateTime(2022, 1, 3), new DateTime(2022, 1, 10), new DateTime(2022, 1, 4), "Express", "Luis Rodriguez", "Plaza 789"),
                new Pedido(4, 4, 4, 4, new DateTime(2022, 1, 4), new DateTime(2022, 1, 11), new DateTime(2022, 1, 5), "Normal", "Ana Lopez", "Calle 321"),
                new Pedido(5, 5, 5, 5, new DateTime(2022, 1, 5), new DateTime(2022, 1, 12), new DateTime(2022, 1, 6), "Express", "Jose Martinez", "Avenida 654"),
                new Pedido(6, 6, 6, 6, new DateTime(2022, 1, 6), new DateTime(2022, 1, 13), new DateTime(2022, 1, 7), "Normal", "Laura Perez", "Plaza 987"),
                new Pedido(7, 7, 7, 7, new DateTime(2022, 1, 7), new DateTime(2022, 1, 14), new DateTime(2022, 1, 8), "Express", "Carlos Garcia", "Calle 555"),
            };
            this.ListaPedidos = pedidos;

            ObservableCollection<DetallesPedido> detallesPedido = new ObservableCollection<DetallesPedido>
            {
                new DetallesPedido(1, 1, 10.0m, 2, 5.0m),
                new DetallesPedido(1, 2, 15.0m, 1, 0.0m),
                new DetallesPedido(2, 3, 20.0m, 3, 10.0m),
                new DetallesPedido(2, 1, 10.0m, 2, 0.0m),
                new DetallesPedido(3, 2, 15.0m, 1, 0.0m)
            };
            this.ListaDetallesPedidos = detallesPedido;
        }

        public void BuscarPorID(string id)
        {
            ListaDetallesPedidosBuscados = new ObservableCollection<DetallesPedido>();
            foreach (DetallesPedido detapedido in ListaDetallesPedidos)
            {
                if(detapedido.IdPedido.Equals(int.Parse(id)))
                {
                    ListaDetallesPedidosBuscados.Add(detapedido);
                }
            }
        }

        public void QuitarProducto()
        {
            ProductoSelecionado = null;
        }

        public void QuitarEmpleado()
        {
            EmpleadoSelecionado = null;
        }

        public void QuitarCompania()
        {
            CompaniaSelecionado = null;
        }

        public void ImprimirProducto()
        {
            pdfServicio.GenerarPDFProducto(productoSelecionado);
        }

        public void ImprimirProductos()
        {
            pdfServicio.GenerarPDFProductos(ListaProductos);
        }

        public void ImprimirEmpleados()
        {
            pdfServicio.GenerarPDFEmpleados(ListaEmpleados);
        }

        public void ImprimirCompanias()
        {
            pdfServicio.GenerarPDFCompañias(ListaCompanias);
        }

        public void ImprimirClientes()
        {
            pdfServicio.GenerarPDFClientes(ListaClientes);
        }

        public void ImprimirPedidos()
        {
            pdfServicio.GenerarPDFPedidos(ListaPedidos);
        }

        public void ImprimirDetallesPedidos()
        {
            pdfServicio.GenerarPDFDetallesPedido(ListaDetallesPedidos);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
