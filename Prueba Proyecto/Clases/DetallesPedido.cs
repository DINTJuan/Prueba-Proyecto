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
        private decimal precioUnidad;
        private int cantidad;
        private decimal descuento;
        private DetallespedidosPK detallespedidosPK;

        public DetallespedidosPK DetallespedidosPK
        {
            get { return detallespedidosPK; }
            set { SetProperty(ref detallespedidosPK, value); }
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

        public DetallesPedido()
        {
        }

        public DetallesPedido(decimal precioUnidad, int cantidad, decimal descuento, DetallespedidosPK detallespedidosPK)
        {
            this.precioUnidad = precioUnidad;
            this.cantidad = cantidad;
            this.descuento = descuento;
            this.detallespedidosPK = detallespedidosPK;
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
