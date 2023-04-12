using iTextSharp.text;
using iTextSharp.text.pdf;
using Prueba_Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Servicios
{
    internal class PdfServicio
    {
        public void GenerarPDFEmpleados(ObservableCollection<Empleado> empleados)
        {
            // Crear un nuevo documento PDF
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfEmpleados";
            string nombreArchivo = "empleados_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear un objeto PdfWriter para escribir en el archivo PDF
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento
            documento.Open();

            // Agregar un título al documento
            Paragraph titulo = new Paragraph("Registro de empleados\n\n", new Font(Font.FontFamily.HELVETICA, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Crear una tabla para mostrar los datos de los empleados
            PdfPTable tabla = new PdfPTable(7);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 0.5f, 2f, 2f, 2.5f, 2f, 2.5f, 2f});

            // Agregar las celdas del encabezado de la tabla
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Apellidos", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Puesto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Sueldo", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("DNI", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha de contratación", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Agregar las celdas de los datos de los empleados
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Apellidos", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Puesto", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Sueldo", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("DNI", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Fecha de contratación", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));

            // Agregar las celdas de los datos de los empleados
            foreach (Empleado empleado in empleados)
            {
                tabla.AddCell(new PdfPCell(new Phrase(empleado.IdEmpleado.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(empleado.Nombre)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(empleado.Apellidos)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(empleado.Puesto)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(empleado.Sueldo.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(empleado.Dni)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(empleado.FechaContratacion.ToShortDateString())) { NoWrap = true, Padding = 5f });
            }

            // Ajustar el tamaño de la tabla automáticamente
            tabla.CompleteRow();
            tabla.HeaderRows = 1;
            tabla.FooterRows = 1;
            tabla.SkipLastFooter = true;

            // Agregar la tabla al documento
            documento.Add(tabla);

            // Cerrar el documento
            documento.Close();
        }

        public void GenerarPDFDetallesPedido(ObservableCollection<DetallesPedido> detallesPedidos)
        {
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfDetallesPedidos";
            string nombreArchivo = "detalles_pedidos_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear un objeto PdfWriter para escribir en el archivo PDF
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento
            documento.Open();

            // Agregar un título al documento
            Paragraph titulo = new Paragraph("Detalles de pedidos\n\n", new Font(Font.FontFamily.HELVETICA, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Crear una tabla para mostrar los datos de los detalles de pedidos
            PdfPTable tabla = new PdfPTable(5);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 1f, 2f, 2f, 2f, 2f });

            // Agregar las celdas del encabezado de la tabla
            tabla.AddCell(new PdfPCell(new Phrase("ID Pedido", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("ID Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Precio unidad", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Cantidad", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Descuento", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Agregar las celdas de los datos de los detalles de pedidos
            tabla.AddCell(new PdfPCell(new Phrase("ID Pedido", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("ID Producto", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Precio unidad", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Cantidad", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Descuento", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD))));

            // Agregar las celdas de los datos de los detalles de pedidos
            foreach (DetallesPedido detallePedido in detallesPedidos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(detallePedido.IdPedido.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(detallePedido.IdProducto.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(detallePedido.PrecioUnidad.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(detallePedido.Cantidad.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(detallePedido.Descuento.ToString())) { NoWrap = true, Padding = 5f });
            }

            // Ajustar el tamaño de la tabla automáticamente
            tabla.CompleteRow();
            tabla.HeaderRows = 1;
            tabla.FooterRows = 1;
            tabla.SkipLastFooter = true;

            // Agregar la tabla al documento
            documento.Add(tabla);

            // Cerrar el documento
            documento.Close();
        }

        public void GenerarPDFProductos(ObservableCollection<Producto> productos)
        {
            // Crear un nuevo documento PDF
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfProductos";
            string nombreArchivo = "productos_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear un objeto PdfWriter para escribir en el archivo PDF
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento
            documento.Open();

            // Agregar un título al documento
            Paragraph titulo = new Paragraph("Listado de productos\n\n", new Font(Font.FontFamily.HELVETICA, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Crear una tabla para mostrar los datos de los productos
            PdfPTable tabla = new PdfPTable(7);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 0.5f, 1.5f, 2f, 1.5f, 2f, 2f, 1.5f });

            // Agregar las celdas del encabezado de la tabla
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Marca", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Precio", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Descripción", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Tipo de alcohol", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Graduación", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Agregar las celdas de los datos de los productos
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Marca", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Precio", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Descripción", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Tipo de alcohol", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Graduación", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));

            // Agregar las celdas de los datos de los productos
            foreach (Producto producto in productos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(producto.IdProducto.ToString())));
                tabla.AddCell(new PdfPCell(new Phrase(producto.Marca)));
                tabla.AddCell(new PdfPCell(new Phrase(producto.Nombre)));
                tabla.AddCell(new PdfPCell(new Phrase(producto.Precio.ToString())));
                tabla.AddCell(new PdfPCell(new Phrase(producto.Descripcion)));
                tabla.AddCell(new PdfPCell(new Phrase(producto.TipoAlcohol)));
                tabla.AddCell(new PdfPCell(new Phrase(producto.Graduacion.ToString())));
            }

            // Ajustar el tamaño de la tabla automáticamente
            tabla.CompleteRow();
            tabla.HeaderRows = 1;
            tabla.FooterRows = 1;
            tabla.SkipLastFooter = true;

            // Agregar la tabla al documento
            documento.Add(tabla);

            // Cerrar el documento
            documento.Close();
        }

        public void GenerarPDFPedidos(ObservableCollection<Pedido> pedidos)
        {
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfPedidos";
            string nombreArchivo = "pedidos_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear un objeto PdfWriter para escribir en el archivo PDF
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento
            documento.Open();

            // Agregar un título al documento
            Paragraph titulo = new Paragraph("Pedidos\n\n", new Font(Font.FontFamily.HELVETICA, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Crear una tabla para mostrar los datos de los pedidos
            PdfPTable tabla = new PdfPTable(7);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 1f, 2f, 2f, 2f, 2f, 2f, 2f });

            // Agregar las celdas del encabezado de la tabla
            tabla.AddCell(new PdfPCell(new Phrase("ID Pedido", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("ID Cliente", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("ID Empleado", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("ID Compañia Envío", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Pedido", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Entrega", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Envío", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Agregar las celdas de los datos de los pedidos
            tabla.AddCell(new PdfPCell(new Phrase("ID Pedido", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("ID Cliente", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("ID Empleado", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("ID Compañia Envío", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Pedido", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Entrega", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Envío", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));

            // Agregar las celdas de los datos de los pedidos
            foreach (Pedido pedido in pedidos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(pedido.IdPedido.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(pedido.IdCliente.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(pedido.IdEmpleado.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(pedido.IdCompañiaEnvio.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(pedido.FechaPedido.ToShortDateString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(pedido.FechaEntrega.ToShortDateString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(pedido.FechaEnvio.ToShortDateString())) { NoWrap = true, Padding = 5f });
            }

            // Ajustar el tamaño de la tabla automáticamente
            tabla.CompleteRow();
            tabla.HeaderRows = 1;
            tabla.FooterRows = 1;
            tabla.SkipLastFooter = true;

            // Agregar la tabla al documento
            documento.Add(tabla);

            // Cerrar el documento
            documento.Close();
        }

        public void GenerarPDFClientes(ObservableCollection<Cliente> clientes)
        {
            // Crear un nuevo documento PDF
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfClientes";
            string nombreArchivo = "clientes_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear un objeto PdfWriter para escribir en el archivo PDF
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento
            documento.Open();

            // Agregar un título al documento
            Paragraph titulo = new Paragraph("Registro de clientes\n\n", new Font(Font.FontFamily.HELVETICA, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Crear una tabla para mostrar los datos de los clientes
            PdfPTable tabla = new PdfPTable(6);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 0.5f, 2f, 2f, 2.5f, 2f, 2.5f });

            // Agregar las celdas del encabezado de la tabla
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Apellidos", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Dirección", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Ciudad", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Código Postal", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Agregar las celdas de los datos de los clientes
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Apellidos", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Dirección", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Ciudad", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Código Postal", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));

            // Agregar las celdas de los datos de los clientes
            foreach (Cliente cliente in clientes)
            {
                tabla.AddCell(new PdfPCell(new Phrase(cliente.IdCliente.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(cliente.Nombre)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(cliente.Apellidos)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(cliente.Direcion)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(cliente.Ciudad)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(cliente.CodigoPostal)) { NoWrap = true, Padding = 5f });
            }

            // Ajustar el tamaño de la tabla automáticamente
            tabla.CompleteRow();
            tabla.HeaderRows = 1;
            tabla.FooterRows = 1;
            tabla.SkipLastFooter = true;

            // Agregar la tabla al documento
            documento.Add(tabla);

            // Cerrar el documento
            documento.Close();
        }

        public void GenerarPDFCompañias(ObservableCollection<CompaniaEnvio> companiaEnvios)
        {
            // Crear un nuevo documento PDF
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfCompanias";
            string nombreArchivo = "companias_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear un objeto PdfWriter para escribir en el archivo PDF
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento
            documento.Open();

            // Agregar un título al documento
            Paragraph titulo = new Paragraph("Registro de compañías de envío\n\n", new Font(Font.FontFamily.HELVETICA, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Crear una tabla para mostrar los datos de las compañías de envío
            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 0.5f, 2f, 2f });

            // Agregar las celdas del encabezado de la tabla
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Teléfono", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Agregar las celdas de los datos de las compañías de envío
            tabla.AddCell(new PdfPCell(new Phrase("ID", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));
            tabla.AddCell(new PdfPCell(new Phrase("Teléfono", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))));

            // Agregar las celdas de los datos de las compañías de envío
            foreach (CompaniaEnvio compania in companiaEnvios)
            {
                tabla.AddCell(new PdfPCell(new Phrase(compania.IdCompañiaEnvios.ToString())) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(compania.Nombre)) { NoWrap = true, Padding = 5f });
                tabla.AddCell(new PdfPCell(new Phrase(compania.Telefono)) { NoWrap = true, Padding = 5f });
            }

            // Ajustar el tamaño de la tabla automáticamente
            tabla.CompleteRow();
            tabla.HeaderRows = 1;
            tabla.FooterRows = 1;
            tabla.SkipLastFooter = true;

            // Agregar la tabla al documento
            documento.Add(tabla);

            // Cerrar el documento
            documento.Close();
        }

        public void GenerarPDFProducto(Producto producto)
        {
            // Crear un nuevo documento PDF
            Document documento = new Document();
            // Definir la ruta y el nombre del archivo PDF a crear
            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/PdfProductos";
            string nombreArchivo = producto.Nombre + "_" + producto.Marca + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string rutaArchivo = rutaCarpeta + "/" + nombreArchivo;

            // Si la carpeta no existe, crearla
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            // Crea un documento PDF con tamaño A4 y margen de 36 unidades
            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            // Crea un objeto PdfWriter para escribir en el documento
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivo, FileMode.Create));

            // Abre el documento para escribir en él
            document.Open();

            // Crea una tabla para la imagen y los datos del producto
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;

            // Añade la imagen del producto a la tabla
            Image imagen = Image.GetInstance(producto.Foto);
            imagen.ScaleAbsolute(150f, 150f);
            PdfPCell imagenCell = new PdfPCell(imagen, true);
            imagenCell.Border = Rectangle.NO_BORDER;
            imagenCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(imagenCell);

            // Añade los datos del producto a la tabla
            PdfPCell datosCell = new PdfPCell();
            datosCell.Border = Rectangle.NO_BORDER;
            datosCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datosCell.PaddingLeft = 10f;
            datosCell.PaddingRight = 10f;

            datosCell.AddElement(new Paragraph(producto.Nombre, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
            datosCell.AddElement(new Paragraph(producto.Marca, FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            datosCell.AddElement(new Paragraph(producto.Descripcion, FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            datosCell.AddElement(new Paragraph($"Precio: {producto.Precio:C}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            datosCell.AddElement(new Paragraph($"Tipo de alcohol: {producto.TipoAlcohol}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            datosCell.AddElement(new Paragraph($"Graduación: {producto.Graduacion}%", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

            table.AddCell(datosCell);

            // Añade la tabla al documento
            document.Add(table);

            // Cierra el documento y libera los recursos utilizados
            document.Close();
            writer.Close();
        }
    }
}
