using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    internal class Pedido : ObservableObject
    {
        private int idPedido;
        private int idCliente;
        private int idEmpleado;
        private int idCompañiaEnvio;
        private DateTime fechaPedido;
        private DateTime fechaEntrega;
        private DateTime fechaEnvio;
        private string formaEnvio;
        private string destinatario;
        private string dirreccionEnvio;
        private Cliente cliente;
        private Empleado empleado;
        private CompaniaEnvio compañia;

        public int IdPedido
        {
            get { return idPedido; }
            set { SetProperty(ref idPedido, value); }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { SetProperty(ref idCliente, value); }
        }
        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { SetProperty(ref idEmpleado, value); }
        }
        public int IdCompañiaEnvio
        {
            get { return idCompañiaEnvio; }
            set { SetProperty(ref idCompañiaEnvio, value); }
        }
        public DateTime FechaPedido
        {
            get { return fechaPedido; }
            set { SetProperty(ref fechaPedido, value); }
        }
        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { SetProperty(ref fechaEntrega, value); }
        }
        public DateTime FechaEnvio
        {
            get { return fechaEnvio; }
            set { SetProperty(ref fechaEnvio, value); }
        }
        public string FormaEnvio
        {
            get { return formaEnvio; }
            set { SetProperty(ref formaEnvio, value); }
        }
        public string Destinatario
        {
            get { return destinatario; }
            set { SetProperty(ref destinatario, value); }
        }
        public string DirrecionEnvio
        {
            get { return dirreccionEnvio; }
            set { SetProperty (ref dirreccionEnvio, value); }
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set { SetProperty (ref cliente, value); }
        }
        public Empleado Empleado
        {
            get { return empleado; }
            set { SetProperty (ref empleado, value); }
        }
        public CompaniaEnvio CompaniaEnvio
        {
            get { return compañia; }
            set { SetProperty(ref compañia, value); }
        }

        public Pedido()
        {
        }

        public Pedido(int idPedido, int idCliente, int idEmpleado, int idCompañiaEnvio, DateTime fechaPedido, DateTime fechaEntrega, DateTime fechaEnvio, string formaEnvio, string destinatario, string dirreccionEnvio)
        {
            this.idPedido = idPedido;
            this.idCliente = idCliente;
            this.idEmpleado = idEmpleado;
            this.idCompañiaEnvio = idCompañiaEnvio;
            this.fechaPedido = fechaPedido;
            this.fechaEntrega = fechaEntrega;
            this.fechaEnvio = fechaEnvio;
            this.formaEnvio = formaEnvio;
            this.destinatario = destinatario;
            this.dirreccionEnvio = dirreccionEnvio;
        }

        public Pedido(int idPedido, int idCliente, int idEmpleado, int idCompañiaEnvio, DateTime fechaPedido, DateTime fechaEntrega, DateTime fechaEnvio, string formaEnvio, string destinatario, string dirreccionEnvio, Cliente cliente, Empleado empleado, CompaniaEnvio compañia)
        {
            this.idPedido = idPedido;
            this.idCliente = idCliente;
            this.idEmpleado = idEmpleado;
            this.idCompañiaEnvio = idCompañiaEnvio;
            this.fechaPedido = fechaPedido;
            this.fechaEntrega = fechaEntrega;
            this.fechaEnvio = fechaEnvio;
            this.formaEnvio = formaEnvio;
            this.destinatario = destinatario;
            this.dirreccionEnvio = dirreccionEnvio;
            this.cliente = cliente;
            this.empleado = empleado;
            this.compañia = compañia;
        }
    }
}
