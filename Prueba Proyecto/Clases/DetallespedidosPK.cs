using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    class DetallespedidosPK : ObservableObject
    {
        private int idPedido;
        private int idProducto;

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

        public DetallespedidosPK()
        {
        }
        public DetallespedidosPK(int idPedido, int idProducto)
        {
            this.idPedido = idPedido;
            this.idProducto = idProducto;
        }
    }
}
