using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Texteos
{
    internal class Pruebas
    {
        /*ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();
        empleados.Add(new Empleado(1, "Juan", "Pérez", "Gerente", 3000, "12345678A", new DateTime(2020, 1, 1), "foto1.png"));
            empleados.Add(new Empleado(2, "María", "González", "Administrativo", 2000, "87654321B", new DateTime(2020, 2, 1), "foto2.png"));
            empleados.Add(new Empleado(3, "Pedro", "Sánchez", "Comercial", 2500, "11111111C", new DateTime(2020, 3, 1), "foto3.png"));
            empleados.Add(new Empleado(4, "Ana", "Martínez", "Técnico", 2200, "22222222D", new DateTime(2020, 4, 1), "foto4.png"));
            empleados.Add(new Empleado(5, "Carlos", "Gómez", "Programador", 2800, "33333333E", new DateTime(2020, 5, 1), "foto5.png"));

            PdfServicio pdf = new PdfServicio();
        pdf.GenerarPDFEmpleados(empleados);*/

        /*ObservableCollection<DetallesPedido> detallesPedido = new ObservableCollection<DetallesPedido>
            {
                new DetallesPedido(1, 1, 10.0m, 2, 5.0m),
                new DetallesPedido(1, 2, 15.0m, 1, 0.0m),
                new DetallesPedido(2, 3, 20.0m, 3, 10.0m),
                new DetallesPedido(2, 1, 10.0m, 2, 0.0m),
                new DetallesPedido(3, 2, 15.0m, 1, 0.0m)
            };
            PdfServicio pdf = new PdfServicio();
            pdf.GenerarPDFDetallesPedido(detallesPedido);*/

        /*ObservableCollection<Producto> productos = new ObservableCollection<Producto>
            {
                new Producto(1, "Jack Daniel's", "Whiskey", 35.99m, "Whiskey de Tennesse", "Whiskey", 40f, "foto1.png"),
                new Producto(2, "Johnnie Walker", "Scotch", 49.99m, "Scotch blended", "Whiskey", 40f, "foto2.png"),
                new Producto(3, "Baileys", "Licor", 24.99m, "Licor de crema irlandesa", "Licor", 17f, "foto3.png"),
                new Producto(4, "Grey Goose", "Vodka", 29.99m, "Vodka francés", "Vodka", 40f, "foto4.png"),
                new Producto(5, "Patron", "Tequila", 54.99m, "Tequila premium", "Tequila", 40f, "foto5.png"),
                new Producto(6, "Jägermeister", "Licor", 19.99m, "Licor alemán de hierbas", "Licor", 35f, "foto6.png"),
                new Producto(7, "Hendrick's", "Gin", 39.99m, "Gin escocés", "Gin", 41.4f, "foto7.png"),
                new Producto(8, "Bacardi", "Ron Superior", 20.99m, "Ron superior de alta calidad", "Ron", 40.0f, "foto8.png"),
                new Producto(9, "Smirnoff", "Vodka", 17.99m, "Vodka premium", "Vodka", 37.5f, "foto9.png"),
                new Producto(10, "Tequila Don Julio", "Tequila Blanco", 39.99m, "Tequila de agave azul 100% puro", "Tequila", 40.0f, "foto10.png")
            };

            PdfServicio pdf = new PdfServicio();
            pdf.GenerarPDFProductos(productos);*/

        /*ObservableCollection<Pedido> pedidos = new ObservableCollection<Pedido>()
            {
                new Pedido(1, 1, 1, 1, new DateTime(2022, 1, 1), new DateTime(2022, 1, 8), new DateTime(2022, 1, 2), "Express", "Juan Perez", "Calle 123"),
                new Pedido(2, 2, 2, 2, new DateTime(2022, 1, 2), new DateTime(2022, 1, 9), new DateTime(2022, 1, 3), "Normal", "Maria Gomez", "Avenida 456"),
                new Pedido(3, 3, 3, 3, new DateTime(2022, 1, 3), new DateTime(2022, 1, 10), new DateTime(2022, 1, 4), "Express", "Luis Rodriguez", "Plaza 789"),
                new Pedido(4, 4, 4, 4, new DateTime(2022, 1, 4), new DateTime(2022, 1, 11), new DateTime(2022, 1, 5), "Normal", "Ana Lopez", "Calle 321"),
                new Pedido(5, 5, 5, 5, new DateTime(2022, 1, 5), new DateTime(2022, 1, 12), new DateTime(2022, 1, 6), "Express", "Jose Martinez", "Avenida 654"),
                new Pedido(6, 6, 6, 6, new DateTime(2022, 1, 6), new DateTime(2022, 1, 13), new DateTime(2022, 1, 7), "Normal", "Laura Perez", "Plaza 987"),
                new Pedido(7, 7, 7, 7, new DateTime(2022, 1, 7), new DateTime(2022, 1, 14), new DateTime(2022, 1, 8), "Express", "Carlos Garcia", "Calle 555"),
            };

            PdfServicio pdf = new PdfServicio();
            pdf.GenerarPDFPedidos(pedidos);*/

        /*ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>()
            {
                new Cliente() { IdCliente = 1, Nombre = "Juan", Apellidos = "García", Direcion = "Calle 1", Ciudad = "Madrid", CodigoPostal = "28001" },
                new Cliente() { IdCliente = 2, Nombre = "María", Apellidos = "Rodríguez", Direcion = "Calle 2", Ciudad = "Barcelona", CodigoPostal = "08001" },
                new Cliente() { IdCliente = 3, Nombre = "Pedro", Apellidos = "López", Direcion = "Calle 3", Ciudad = "Valencia", CodigoPostal = "46001" },
                new Cliente() { IdCliente = 4, Nombre = "Ana", Apellidos = "Martínez", Direcion = "Calle 4", Ciudad = "Sevilla", CodigoPostal = "41001" },
                new Cliente() { IdCliente = 5, Nombre = "Carlos", Apellidos = "González", Direcion = "Calle 5", Ciudad = "Bilbao", CodigoPostal = "48001" }
            };

            PdfServicio pdf = new PdfServicio();
            pdf.GenerarPDFClientes(clientes);*/

        /*ObservableCollection<CompaniaEnvio> companias = new ObservableCollection<CompaniaEnvio>()
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
            pdf.GenerarPDFCompañias(companias);*/
    }
}
