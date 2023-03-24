using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Proyecto.Clases
{
    internal class Empleado : ObservableObject
    {
        private int idEmpleado;
        private string nombre;
        private string apellidos;
        private string puesto;
        private double sueldo;
        private string dni;
        private DateTime fechaContratacion;
        private string foto;

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { SetProperty(ref idEmpleado, value); }
        }

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { SetProperty(ref apellidos, value); }
        }
        public string Puesto
        {
            get { return puesto; }
            set { SetProperty(ref puesto, value); }
        }
        public double Sueldo
        {
            get { return sueldo; }
            set { SetProperty(ref sueldo, value); }
        }
        public string Dni
        {
            get { return dni; }
            set { SetProperty(ref dni, value); }
        }
        public DateTime FechaContratacion
        {
            get { return fechaContratacion; }
            set { SetProperty(ref fechaContratacion, value); }
        }
        public string Foto
        {
            get { return foto; }
            set { SetProperty(ref foto, value); }
        }

        public Empleado()
        {
        }

        public Empleado(int idEmpleado, string nombre, string apellidos, string puesto, double sueldo, string dni, DateTime fechaContratacion, string foto)
        {
            this.idEmpleado = idEmpleado;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.puesto = puesto;
            this.sueldo = sueldo;
            this.dni = dni;
            this.fechaContratacion = fechaContratacion;
            this.foto = foto;
        }
    }
}
