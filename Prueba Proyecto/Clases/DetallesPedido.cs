using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    internal class DetallesPedido : ObservableObject
    {
        private int idPedido;
        private int idProducto;
        private decimal precioUnidad;
        private int cantidad;
        private decimal descuento;
        private Pedido pedido;
        private Producto producto;

        public int IdPedido
        {
            get { return idPedido; }
            set { SetProperty(ref idPedido, value); }
        }
        public int IdProducto
        {
            get { return idProducto; }
            set { SetProperty(ref idProducto, value); }
        }
        public decimal PrecioUnidad
        {
            get { return precioUnidad; }
            set { SetProperty(ref precioUnidad, value); }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { SetProperty (ref cantidad, value); }
        }
        public decimal Descuento
        {
            get { return descuento; }
            set { SetProperty (ref descuento, value); }
        }
        public Pedido Pedido
        {
            get { return pedido; }
            set { SetProperty (ref pedido, value); }
        }
        public Producto Producto
        {
            get { return producto; }
            set { SetProperty<Producto> (ref producto, value); }
        }

        public DetallesPedido()
        {
        }

        public DetallesPedido(int idPedido, int idProducto, decimal precioUnidad, int cantidad, decimal descuento)
        {
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.precioUnidad = precioUnidad;
            this.cantidad = cantidad;
            this.descuento = descuento;
        }

        public DetallesPedido(int idPedido, int idProducto, decimal precioUnidad, int cantidad, decimal descuento, Pedido pedido, Producto producto) : this(idPedido, idProducto, precioUnidad, cantidad, descuento)
        {
            this.pedido = pedido;
            this.producto = producto;
        }

        private decimal TotalSinDescuento()
        {
            return PrecioUnidad * Cantidad;
        }
        private decimal TotalConDescuento()
        {
            return (PrecioUnidad * Cantidad) * (Descuento / 100);
        }

    }
}
