using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    internal class CompaniaEnvio : ObservableObject
    {
        private int idCompañiaEnvios;
        private string nombre;
        private string telefono;
        private string foto;

        public int IdCompañiaEnvios
        {
            get { return idCompañiaEnvios; }
            set { SetProperty(ref idCompañiaEnvios, value); }
        }

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        public string Telefono
        {
            get { return telefono; }
            set { SetProperty(ref telefono, value); }
        }

        public string Foto
        {
            get { return foto; }
            set { SetProperty(ref foto, value); }
        }

        public CompaniaEnvio()
        {
        }

        public CompaniaEnvio(int idCompañiaEnvios, string nombre, string telefono, string foto)
        {
            this.idCompañiaEnvios = idCompañiaEnvios;
            this.nombre = nombre;
            this.telefono = telefono;
            this.foto = foto;
        }
    }
}
