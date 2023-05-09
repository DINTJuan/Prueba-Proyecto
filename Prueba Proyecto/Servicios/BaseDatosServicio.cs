using Newtonsoft.Json;
using Prueba_Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
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
    }
}
