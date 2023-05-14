using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prueba_Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Servicios
{
    internal class BaseDatosServicio
    {
        
        public ObservableCollection<Producto> SacarProductos()
        {
            string apiUrlproductos = "http://localhost:8080/LicoreriaAPiJPA/tienda/productos";

            ObservableCollection<Producto> productos = new ObservableCollection<Producto>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(apiUrlproductos).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(jsonResponse);

                        // Agregar los productos a la ObservableCollection
                        foreach (Producto producto in listaProductos)
                        {
                            productos.Add(producto);
                        }
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return productos;
        
        }

        public ObservableCollection<CompaniaEnvio> SacarCompaniasEnvio()
        {
            string apiUrlCompaniasEnvio = "http://localhost:8080/LicoreriaAPiJPA/tienda/companiasenvios";

            ObservableCollection<CompaniaEnvio> companiasEnvio = new ObservableCollection<CompaniaEnvio>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(apiUrlCompaniasEnvio).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<CompaniaEnvio> listaCompaniasEnvio = JsonConvert.DeserializeObject<List<CompaniaEnvio>>(jsonResponse);

                        // Agregar las compañías de envío a la ObservableCollection
                        foreach (CompaniaEnvio companiaEnvio in listaCompaniasEnvio)
                        {
                            companiasEnvio.Add(companiaEnvio);
                        }
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return companiasEnvio;
        }

        public ObservableCollection<Cliente> SacarClientes()
        {
            string apiUrlClientes = "http://localhost:8080/LicoreriaAPiJPA/tienda/clientes";

            ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(apiUrlClientes).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<Cliente> listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonResponse);

                        // Agregar los clientes a la ObservableCollection
                        foreach (Cliente cliente in listaClientes)
                        {
                            clientes.Add(cliente);
                        }
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return clientes;
        }

        public ObservableCollection<DetallesPedido> SacarDetallesPedidos()
        {
            string apiUrlDetallesPedidos = "http://localhost:8080/LicoreriaAPiJPA/tienda/detallespedidos";

            ObservableCollection<DetallesPedido> destallespedidos = new ObservableCollection<DetallesPedido>();

            try
            {
                using (HttpClient httpDetallesPedidos = new HttpClient())
                {
                    HttpResponseMessage response = httpDetallesPedidos.GetAsync(apiUrlDetallesPedidos).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<DetallesPedido> listaDetallesPedidos = JsonConvert.DeserializeObject<List<DetallesPedido>>(jsonResponse);

                        // Agregar los clientes a la ObservableCollection
                        foreach (DetallesPedido detallepedido in listaDetallesPedidos)
                        {
                            destallespedidos.Add(detallepedido);
                        }
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            return destallespedidos;
        }

        public ObservableCollection<Empleado> SacarEmpleados()
        {
            string apiUrlEmpleados = "http://localhost:8080/LicoreriaAPiJPA/tienda/empleados";

            ObservableCollection<Empleado> empleados = new ObservableCollection<Empleado>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(apiUrlEmpleados).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<object> listaEmpleados = JsonConvert.DeserializeObject<List<object>>(jsonResponse);

                        // Convertir los objetos genéricos a objetos de tipo Empleado
                        foreach (object empleadoObj in listaEmpleados)
                        {
                            // Convertir el objeto genérico al formato de Empleado
                            Empleado empleado = ConvertirAEmpleado(empleadoObj);

                            // Agregar el empleado a la ObservableCollection
                            empleados.Add(empleado);
                        }
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return empleados;
        }

        public ObservableCollection<Pedido> SacarPedidos()
        {
            string apiUrlPedidos = "http://localhost:8080/LicoreriaAPiJPA/tienda/pedidos";

            ObservableCollection<Pedido> pedidos = new ObservableCollection<Pedido>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(apiUrlPedidos).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<object> listaPedidos = JsonConvert.DeserializeObject<List<object>>(jsonResponse);

                        // Convertir los objetos genéricos a objetos de tipo Empleado
                        foreach (object pedidoObj in listaPedidos)
                        {
                            // Convertir el objeto genérico al formato de Empleado
                            Pedido pedido = ConvertirAPedido(pedidoObj);

                            // Agregar el empleado a la ObservableCollection
                            pedidos.Add(pedido);
                        }
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return pedidos;
        }

        // Metodo para convertir la fecha al formato correcto pedido
        private Pedido ConvertirAPedido(object pedidoObj)
        {
            Pedido pedido = new Pedido();

            // Convertir el objeto genérico al formato de Pedido
            try
            {
                JObject pedidoJson = JObject.Parse(pedidoObj.ToString());

                pedido.IdPedido = int.Parse(pedidoJson["idPedido"].ToString());
                pedido.FechaPedido = DateTime.ParseExact(pedidoJson["fechaPedido"].ToString(), "yyyy-MM-ddTHH:mm:ssZ'['UTC']'", CultureInfo.InvariantCulture);
                pedido.FechaEntrega = DateTime.ParseExact(pedidoJson["fechaEntrega"].ToString(), "yyyy-MM-ddTHH:mm:ssZ'['UTC']'", CultureInfo.InvariantCulture);
                pedido.FechaEnvio = DateTime.ParseExact(pedidoJson["fechaEnvio"].ToString(), "yyyy-MM-ddTHH:mm:ssZ'['UTC']'", CultureInfo.InvariantCulture);
                pedido.FormaEnvio = pedidoJson["formaEnvio"].ToString();
                pedido.Destinatario = pedidoJson["destinatario"].ToString();
                pedido.DirrecionEnvio = pedidoJson["direccionEnvio"].ToString();

                // Convertir el objeto Cliente
                JObject clienteJson = pedidoJson["idCliente"] as JObject;
                Cliente cliente = new Cliente();
                cliente.IdCliente = int.Parse(clienteJson["idCliente"].ToString());
                cliente.Nombre = clienteJson["nombre"].ToString();
                cliente.Apellidos = clienteJson["apellidos"].ToString();
                cliente.Ciudad = clienteJson["ciudad"].ToString();
                cliente.CodigoPostal = clienteJson["codigoPostal"].ToString();
                pedido.IdCliente = cliente;

                // Convertir el objeto Empleado
                JObject empleadoJson = pedidoJson["idEmpleado"] as JObject;
                Empleado empleado = new Empleado();
                empleado.IdEmpleado = int.Parse(empleadoJson["idEmpleado"].ToString());
                empleado.Nombre = empleadoJson["nombre"].ToString();
                empleado.Apellidos = empleadoJson["apellidos"].ToString();
                empleado.Puesto = empleadoJson["puesto"].ToString();
                empleado.Sueldo = double.Parse(empleadoJson["sueldo"].ToString());
                empleado.Dni = empleadoJson["dni"].ToString();
                empleado.FechaContratacion = DateTime.ParseExact(empleadoJson["fechaContratacion"].ToString(), "yyyy-MM-ddTHH:mm:ssZ'['UTC']'", CultureInfo.InvariantCulture);
                empleado.Foto = empleadoJson["foto"].ToString();
                pedido.IdEmpleado = empleado;

                // Convertir el objeto CompaniaEnvio
                JObject companiaEnvioJson = pedidoJson["idCompaniasEnvios"] as JObject;
                CompaniaEnvio companiaEnvio = new CompaniaEnvio();
                companiaEnvio.IdCompaniasEnvios = int.Parse(companiaEnvioJson["idCompaniasEnvios"].ToString());
                companiaEnvio.Nombre = companiaEnvioJson["nombre"].ToString();
                companiaEnvio.Telefono = companiaEnvioJson["telefono"].ToString();
                companiaEnvio.Foto = companiaEnvioJson["foto"].ToString();
                pedido.IdCompañiaEnvio = companiaEnvio;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al convertir el objeto genérico a Pedido: " + ex.Message);
            }

            return pedido;
        }

        // Metodo para convertir la fecha al formato correcto empleado
        private Empleado ConvertirAEmpleado(object empleadoObj)
        {
            Empleado empleado = new Empleado();

            // Convertir el objeto genérico al formato de Empleado
            try
            {
                JObject empleadoJson = JObject.Parse(empleadoObj.ToString());

                empleado.IdEmpleado = int.Parse(empleadoJson["idEmpleado"].ToString());
                empleado.Nombre = empleadoJson["nombre"].ToString();
                empleado.Apellidos = empleadoJson["apellidos"].ToString();
                empleado.Puesto = empleadoJson["puesto"].ToString();
                empleado.Sueldo = double.Parse(empleadoJson["sueldo"].ToString());
                empleado.Dni = empleadoJson["dni"].ToString();
                empleado.FechaContratacion = DateTime.ParseExact(empleadoJson["fechaContratacion"].ToString(), "yyyy-MM-ddTHH:mm:ssZ'['UTC']'", CultureInfo.InvariantCulture);
                empleado.Foto = empleadoJson["foto"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al convertir el objeto genérico a Empleado: " + ex.Message);
            }

            return empleado;
        }

        public void SubirProductos(ObservableCollection<Producto> productossub)
        {
            string baseUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/productos/";

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Producto producto in productossub)
                {
                    try
                    {
                        string apiUrl = baseUrl + producto.IdProducto; // Construir la URL completa con el ID del producto

                        // Crear una copia del producto sin incluir el campo idProducto
                        var productoSinId = new
                        {
                            marca = producto.Marca,
                            nombre = producto.Nombre,
                            precio = producto.Precio,
                            descripcion = producto.Descripcion,
                            tipoAlcohol = producto.TipoAlcohol,
                            graduacion = producto.Graduacion,
                            foto = producto.Foto
                        };

                        string json = JsonConvert.SerializeObject(productoSinId); // Convertir el producto sin el campo idProducto a JSON
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = httpClient.PutAsync(apiUrl, content).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Producto actualizado: " + producto.IdProducto);
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar el producto: " + producto.IdProducto);
                            Console.WriteLine("Código de estado: " + response.StatusCode);
                            Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrió un error al actualizar el producto: " + producto.IdProducto);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        public void SubirCompaniasEnvio(ObservableCollection<CompaniaEnvio> companiasEnvioSub)
        {
            string baseUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/companiasenvios/";

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (CompaniaEnvio companiaEnvio in companiasEnvioSub)
                {
                    try
                    {
                        string apiUrl = baseUrl + companiaEnvio.IdCompaniasEnvios; // Construir la URL completa con el ID de la compañía de envío

                        // Crear una copia de la compañía de envío sin incluir el campo IdCompañiaEnvios
                        var companiaEnvioSinId = new
                        {
                            nombre = companiaEnvio.Nombre,
                            telefono = companiaEnvio.Telefono,
                            foto = companiaEnvio.Foto
                        };

                        string json = JsonConvert.SerializeObject(companiaEnvioSinId); // Convertir la compañía de envío sin el campo IdCompañiaEnvios a JSON
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = httpClient.PutAsync(apiUrl, content).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Compañía de envío actualizada: " + companiaEnvio.IdCompaniasEnvios);
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar la compañía de envío: " + companiaEnvio.IdCompaniasEnvios);
                            Console.WriteLine("Código de estado: " + response.StatusCode);
                            Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrió un error al actualizar la compañía de envío: " + companiaEnvio.IdCompaniasEnvios);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        public void SubirClientes(ObservableCollection<Cliente> clientesSub)
        {
            string baseUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/clientes/";

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Cliente cliente in clientesSub)
                {
                    try
                    {
                        string apiUrl = baseUrl + cliente.IdCliente; // Construir la URL completa con el ID del cliente

                        // Crear una copia del cliente sin incluir el campo IdCliente
                        var clienteSinId = new
                        {
                            nombre = cliente.Nombre,
                            apellidos = cliente.Apellidos,
                            ciudad = cliente.Ciudad,
                            codigoPostal = cliente.CodigoPostal
                        };

                        string json = JsonConvert.SerializeObject(clienteSinId); // Convertir el cliente sin el campo IdCliente a JSON
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = httpClient.PutAsync(apiUrl, content).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Cliente actualizado: " + cliente.IdCliente);
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar el cliente: " + cliente.IdCliente);
                            Console.WriteLine("Código de estado: " + response.StatusCode);
                            Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrió un error al actualizar el cliente: " + cliente.IdCliente);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        public void SubirDetallesPedidos(ObservableCollection<DetallesPedido> detallesPedidosSub)
        {
            string baseUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/detallespedidos";

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (DetallesPedido detallesPedido in detallesPedidosSub)
                {
                    try
                    {
                        var detallesPedidosMin = new
                        {
                            precioUnidad = detallesPedido.PrecioUnidad,
                            cantidad = detallesPedido.Cantidad,
                            descuento = detallesPedido.Descuento,
                            detallespedidosPK = new
                            {
                                idPedido = detallesPedido.DetallespedidosPK.IdPedido,
                                idProducto = detallesPedido.DetallespedidosPK.IdProducto
                            }
                        };

                        string json = JsonConvert.SerializeObject(detallesPedidosMin); // Convertir el empleado sin el campo IdEmpleado a JSON
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = httpClient.PutAsync(baseUrl, content).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("DetallesPedido actualizado: " + detallesPedido.DetallespedidosPK.IdPedido);
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar el empleado: " + detallesPedido.DetallespedidosPK.IdPedido);
                            Console.WriteLine("Código de estado: " + response.StatusCode);
                            Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrió un error al actualizar el empleado: " + detallesPedido.DetallespedidosPK.IdPedido);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                
            }

        }

        public void SubirEmpleados(ObservableCollection<Empleado> empleadosSub)
        {
            string baseUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/empleados/";

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Empleado empleado in empleadosSub)
                {
                    try
                    {
                        string apiUrl = baseUrl + empleado.IdEmpleado; // Construir la URL completa con el ID del empleado

                        // Crear una copia del empleado sin incluir el campo IdEmpleado
                        var empleadoSinId = new
                        {
                            nombre = empleado.Nombre,
                            apellidos = empleado.Apellidos,
                            puesto = empleado.Puesto,
                            sueldo = empleado.Sueldo,
                            dni = empleado.Dni,
                            fechaContratacion = empleado.FechaContratacion,
                            foto = empleado.Foto
                        };

                        string json = JsonConvert.SerializeObject(empleadoSinId); // Convertir el empleado sin el campo IdEmpleado a JSON
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = httpClient.PutAsync(apiUrl, content).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Empleado actualizado: " + empleado.IdEmpleado);
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar el empleado: " + empleado.IdEmpleado);
                            Console.WriteLine("Código de estado: " + response.StatusCode);
                            Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrió un error al actualizar el empleado: " + empleado.IdEmpleado);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        public void SubirPedidos(ObservableCollection<Pedido> pedidosSub)
        {
            string baseUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/pedidos/";

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Pedido pedido in pedidosSub)
                {
                    try
                    {
                        string apiUrl = baseUrl + pedido.IdPedido; // Construir la URL completa con el ID del empleado

                        // Crear una copia del empleado sin incluir el campo IdEmpleado
                        var pedidoSinId = new
                        {
                            destinatario = pedido.Destinatario,
                            direccionEnvio = pedido.DirrecionEnvio,
                            fechaEntrega = pedido.FechaEntrega,
                            fechaEnvio = pedido.FechaEnvio,
                            fechaPedido = pedido.FechaPedido,
                            formaEnvio = pedido.FormaEnvio,
                        };

                        string json = JsonConvert.SerializeObject(pedidoSinId); // Convertir el pedido sin el campo IdPedido a JSON
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = httpClient.PutAsync(apiUrl, content).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Pedido actualizado: " + pedido.IdPedido);
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar el pedido: " + pedido.IdPedido);
                            Console.WriteLine("Código de estado: " + response.StatusCode);
                            Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrió un error al actualizar el pedido: " + pedido.IdPedido);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
        public void EliminarProducto(int id)
        {
            string apiUrlEliminarProducto = "http://localhost:8080/LicoreriaAPiJPA/tienda/productos/" + id;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUrlEliminarProducto).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Producto eliminado correctamente");
                        // También puedes realizar alguna acción adicional después de eliminar el producto
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void EliminarEmpleado(int id)
        {
            string apiUrlEliminarEmpleado = "http://localhost:8080/LicoreriaAPiJPA/tienda/empleados/" + id;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUrlEliminarEmpleado).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Empleado eliminado correctamente");
                        // También puedes realizar alguna acción adicional después de eliminar el empleado
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void EliminarCliente(int id)
        {
            string apiUrlEliminarCliente = "http://localhost:8080/LicoreriaAPiJPA/tienda/clientes/" + id;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUrlEliminarCliente).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Cliente eliminado correctamente");
                        // También puedes realizar alguna acción adicional después de eliminar el cliente
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void EliminarCompaniaEnvio(int id)
        {
            string apiUrlEliminarCompaniaEnvio = "http://localhost:8080/LicoreriaAPiJPA/tienda/companiasenvios/" + id;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUrlEliminarCompaniaEnvio).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Compañía de envío eliminada correctamente");
                        // También puedes realizar alguna acción adicional después de eliminar la compañía de envío
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void EliminarPedido(int id)
        {
            string apiUrlEliminarPedido = "http://localhost:8080/LicoreriaAPiJPA/tienda/pedidos/" + id;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUrlEliminarPedido).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Pedido eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void EliminarDetallePedido(int idp, int idpe)
        {
            string apiUrlEliminarDetallePedido = "http://localhost:8080/LicoreriaAPiJPA/tienda/detallespedidos/" + idp +"/"+ idpe;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUrlEliminarDetallePedido).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Detalle de pedido eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void CrearProducto(Producto producto)
        {
            string apiUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/productos";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var productoSinId = new
                    {
                        marca = producto.Marca,
                        nombre = producto.Nombre,
                        precio = producto.Precio,
                        descripcion = producto.Descripcion,
                        tipoAlcohol = producto.TipoAlcohol,
                        graduacion = producto.Graduacion,
                        foto = producto.Foto
                    };
                    string json = JsonConvert.SerializeObject(productoSinId);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PostAsync(apiUrl, content).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Producto creado exitosamente");
                    }
                    else
                    {
                        Console.WriteLine("Error al crear el producto");
                        Console.WriteLine("Código de estado: " + response.StatusCode);
                        Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al crear el producto");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void CrearEmpleado(Empleado empleado)
        {
            string apiUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/empleados";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var empleadoSinId = new
                    {
                        nombre = empleado.Nombre,
                        apellidos = empleado.Apellidos,
                        puesto = empleado.Puesto,
                        sueldo = empleado.Sueldo,
                        dni = empleado.Dni,
                        fechaContratacion = empleado.FechaContratacion,
                        foto = empleado.Foto
                    };
                    string json = JsonConvert.SerializeObject(empleadoSinId);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PostAsync(apiUrl, content).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Empleado creado exitosamente");
                    }
                    else
                    {
                        Console.WriteLine("Error al crear el empleado");
                        Console.WriteLine("Código de estado: " + response.StatusCode);
                        Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al crear el empleado");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void CrearCompaniaEnvio(CompaniaEnvio companiaEnvio)
        {
            string apiUrl = "http://localhost:8080/LicoreriaAPiJPA/tienda/companiasenvios";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var companiaEnvioSinId = new
                    {
                        nombre = companiaEnvio.Nombre,
                        telefono = companiaEnvio.Telefono,
                        foto = companiaEnvio.Foto
                    };
                    string json = JsonConvert.SerializeObject(companiaEnvioSinId);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PostAsync(apiUrl, content).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Compañía de envío creada exitosamente");
                    }
                    else
                    {
                        Console.WriteLine("Error al crear la compañía de envío");
                        Console.WriteLine("Código de estado: " + response.StatusCode);
                        Console.WriteLine("Mensaje de error: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al crear la compañía de envío");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
