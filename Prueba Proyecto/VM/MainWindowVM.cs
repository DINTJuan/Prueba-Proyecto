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
        private Pedido pedidoSelecionado;
        private ObservableCollection<DetallesPedido> listaDetallesPedidos;
        private ObservableCollection<DetallesPedido> listaDetallesPedidosBuscados;

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

        public Pedido PedidoSelecionado
        {
            get { return pedidoSelecionado; }
            set { SetProperty(ref pedidoSelecionado, value); }
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

        public MainWindowVM()
        {
            AzureServicio azure = new AzureServicio();
            ObservableCollection < Producto > productos = new ObservableCollection<Producto>
            {
                new Producto(1, "Jack Daniel's", "Whiskey", 35.99m, "Whiskey de Tennesse", "Whiskey", 40f, "arbol.jpg"),
                new Producto(2, "Johnnie Walker", "Scotch", 49.99m, "Scotch blended", "Whiskey", 40f, "arbol2.jpg"),
                new Producto(3, "Baileys", "Licor", 24.99m, "Licor de crema irlandesa", "Licor", 17f, "arbolmorado.jpg"),
                new Producto(4, "Grey Goose", "Vodka", 29.99m, "Vodka francés", "Vodka", 40f, "esfera.jpg"),
                new Producto(5, "Patron", "Tequila", 54.99m, "Tequila premium", "Tequila", 40f, "espiral.jpg"),
                new Producto(6, "Jägermeister", "Licor", 19.99m, "Licor alemán de hierbas", "Licor", 35f, "google.jpg"),
                new Producto(7, "Hendrick's", "Gin", 39.99m, "Gin escocés", "Gin", 41.4f, "leon.jpg"),
                new Producto(8, "Bacardi", "Ron Superior", 20.99m, "Ron superior de alta calidad", "Ron", 40.0f, "planeta.jpg"),
                new Producto(9, "Smirnoff", "Vodka", 17.99m, "Vodka premium", "Vodka", 37.5f, "sol.jpg"),
                new Producto(10, "Tequila Don Julio", "Tequila Blanco", 39.99m, "Tequila de agave azul 100% puro", "Tequila", 40.0f, "mano.jpg")
            };
            foreach (Producto producto in productos)
            {
                producto.Foto = azure.SubirFoto(producto.Foto);
            }
            this.ListaProductos = productos;

            ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>
            {
                new Empleado(1, "Juan", "González", "Gerente", 5000.00, "12345678A", new DateTime(2020, 1, 1), "persona1.jpg"),
                new Empleado(2, "María", "López", "Administrativo", 2000.00, "23456789B", new DateTime(2020, 2, 1), "persona2.jpg"),
                new Empleado(3, "Carlos", "García", "Comercial", 3000.00, "34567890C", new DateTime(2020, 3, 1), "persona3.jpg"),
                new Empleado(4, "Sofía", "Pérez", "Programador", 4000.00, "45678901D", new DateTime(2020, 4, 1), "persona4.jpg"),
                new Empleado(5, "Javier", "Martínez", "Recursos Humanos", 2500.00, "56789012E", new DateTime(2020, 5, 1), "persona5.jpg"),
                new Empleado(6, "Laura", "Gómez", "Contable", 2800.00, "67890123F", new DateTime(2020, 6, 1), "persona6.jpg"),
                new Empleado(7, "Pedro", "Rodríguez", "Marketing", 3200.00, "78901234G", new DateTime(2020, 7, 1), "persona7.jpg"),
                new Empleado(8, "Ana", "Sánchez", "Desarrollador", 4500.00, "89012345H", new DateTime(2020, 8, 1), "persona8.jpg"),
                new Empleado(9, "Miguel", "Fernández", "Analista", 3500.00, "90123456I", new DateTime(2020, 9, 1), "persona9.jpg"),
                new Empleado(10, "Luisa", "García", "Diseñadora", 3800.00, "01234567J", new DateTime(2020, 10, 1), "persona10.jpg")
            };
            foreach (Empleado empleado in empleados)
            {
                empleado.Foto = azure.SubirFoto(empleado.Foto);
            }
            this.ListaEmpleados = empleados;

            ObservableCollection<CompaniaEnvio> companias = new ObservableCollection<CompaniaEnvio>()
            {
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 1,
                    Nombre = "DHL",
                    Telefono = "123456789",
                    Foto = "dhl.jpg"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 2,
                    Nombre = "FedEx",
                    Telefono = "987654321",
                    Foto = "fedex.jpg"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 3,
                    Nombre = "UPS",
                    Telefono = "555555555",
                    Foto = "ups.png"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 4,
                    Nombre = "TNT",
                    Telefono = "111111111",
                    Foto = "tnt.png"
                },
                new CompaniaEnvio()
                {
                    IdCompañiaEnvios = 5,
                    Nombre = "Correos",
                    Telefono = "222222222",
                    Foto = "correos.png"
                }
            };
            foreach (CompaniaEnvio compania in companias)
            {
                compania.Foto = azure.SubirFoto(compania.Foto);
            }
            this.ListaCompanias = companias;

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
