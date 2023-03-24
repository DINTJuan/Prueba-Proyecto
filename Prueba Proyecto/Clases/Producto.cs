using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    internal class Producto : ObservableObject
    {
        private int idProducto;
        private string marca;
        private string nombre;
        private decimal precio;
        private string descripcion;
        private string tipoAlcohol;
        private float graduacion;
        private string foto;

        public int IdProducto
        {
            get { return idProducto; }
            set { SetProperty(ref idProducto, value); }
        }
        public string Marca
        {
            get { return marca; }
            set { SetProperty(ref marca, value); }
        }
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }
        public decimal Precio
        {
            get { return precio; }
            set { SetProperty(ref precio, value); }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { SetProperty(ref descripcion, value); }
        }
        public string TipoAlcohol
        {
            get { return tipoAlcohol; }
            set { SetProperty(ref tipoAlcohol, value); }
        }
        public float Graduacion
        {
            get { return graduacion; }
            set { SetProperty (ref graduacion, value); }
        }
        public string Foto
        {
            get { return foto; }
            set { SetProperty(ref foto, value); }
        }

        public Producto()
        {
        }

        public Producto(int idProducto, string marca, string nombre, decimal precio, string descripcion, string tipoAlcohol, float graduacion, string foto)
        {
            this.idProducto = idProducto;
            this.marca = marca;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.tipoAlcohol = tipoAlcohol;
            this.graduacion = graduacion;
            this.foto = foto;
        }
    }
}
