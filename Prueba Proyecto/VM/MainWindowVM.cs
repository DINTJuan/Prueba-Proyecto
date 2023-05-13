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
        private Pedido pedidoSeleccionado;
        private Cliente clienteSeleccionado;
        private ObservableCollection<Pedido> listaPedidos;
        private ObservableCollection<DetallesPedido> listaDetallesPedidos;
        private ObservableCollection<DetallesPedido> listaDetallesPedidosBuscados;
        private ObservableCollection<Cliente> listaClientes;

        private PdfServicio pdfServicio = new PdfServicio();
        private AzureServicio azure = new AzureServicio();
        private BaseDatosServicio bd = new BaseDatosServicio();



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

        public Pedido PedidoSeleccionado
        {
            get { return pedidoSeleccionado; }
            set { SetProperty(ref pedidoSeleccionado, value); }
        }
        public Cliente ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
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
            this.ListaProductos = bd.SacarProductos();
            this.ListaEmpleados = bd.SacarEmpleados();
            this.ListaCompanias = bd.SacarCompaniasEnvio();
            this.listaClientes = bd.SacarClientes();
            this.ListaPedidos = bd.SacarPedidos();
            this.ListaDetallesPedidos = bd.SacarDetallesPedidos();
        }

        public void BuscarPorID(string id)
        {
            ListaDetallesPedidosBuscados = new ObservableCollection<DetallesPedido>();
            foreach (DetallesPedido detapedido in ListaDetallesPedidos)
            {
                if(detapedido.DetallespedidosPK.IdPedido.Equals(int.Parse(id)))
                {
                    ListaDetallesPedidosBuscados.Add(detapedido);
                }
            }
        }

        public void EliminarProducto()
        {
            bd.EliminarProducto(ProductoSelecionado.IdProducto);
            ListaProductos.Remove(ProductoSelecionado);
        }
        public void EliminarEmpleado()
        {
            bd.EliminarEmpleado(EmpleadoSelecionado.IdEmpleado);
            ListaEmpleados.Remove(EmpleadoSelecionado);
        }
        public void EliminarCliente()
        {
            bd.EliminarCliente(ClienteSeleccionado.IdCliente);
            ListaClientes.Remove(ClienteSeleccionado);
        }
        public void EliminarPedido()
        {
            bd.EliminarPedido(PedidoSeleccionado.IdPedido);
            ListaPedidos.Remove(PedidoSeleccionado);
        }
        public void EliminarCompaniaEnvios()
        {
            bd.EliminarCompaniaEnvio(CompaniaSelecionado.IdCompaniasEnvios);
            ListaCompanias.Remove(CompaniaSelecionado);
        }
        public void SubirProductos()
        {
            bd.SubirProductos(ListaProductos);
        }
        public void SubirEmpleados()
        {
            bd.SubirEmpleados(ListaEmpleados);
        }
        public void SubirClientes()
        {
            bd.SubirClientes(ListaClientes);
        }
        public void SubirCompania()
        {
            bd.SubirCompaniasEnvio(ListaCompanias);
        }
        public void SubirPedidos()
        {
            bd.SubirPedidos(ListaPedidos);
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
