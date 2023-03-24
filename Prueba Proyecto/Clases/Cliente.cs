using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    internal class Cliente : ObservableObject
    {
        private int idCliente;
        private string nombre;
        private string apellidos;
        private string direcion;
        private string ciudad;
        private string codigoPostal;

        public int IdCliente
        {
            get { return idCliente; }
            set { SetProperty(ref idCliente, value); }
        }

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        public string Apellidos
        {
            get { return apellidos;  }
            set { SetProperty(ref apellidos, value); }
        }

        public string Direcion
        {
            get { return direcion; }
            set { SetProperty(ref direcion, value); }
        }


        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { SetProperty(ref codigoPostal, value); }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { SetProperty(ref ciudad, value); }
        }

        public Cliente()
        {
        }

        public Cliente(int idCliente, string nombre, string apellidos, string direcion, string ciudad, string codigoPostal)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direcion = direcion;
            this.ciudad = ciudad;
            this.codigoPostal = codigoPostal;
        }
    }
}
