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
            foreach(Producto producto in productos)
            {
                producto.Foto = azure.SubirFoto(producto.Foto);
            }
            this.ListaProductos = productos;
        }

        public void QuitarProducto()
        {
            ProductoSelecionado = null;
        }

        public void ImprimirProducto()
        {
            pdfServicio.GenerarPDFProducto(productoSelecionado);
        }

        public void ImprimirProductos()
        {
            pdfServicio.GenerarPDFProductos(ListaProductos);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
