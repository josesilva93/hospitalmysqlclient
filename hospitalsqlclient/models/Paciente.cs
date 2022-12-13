using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testefcore.models
{
    public class Paciente : Persona
    {
        public string? diagnostico { get; set; }
        public int dias_Ingresado { get; set; }
        public string? pronostico { get; set; }
         public List<Medicamento>? medicacion { get; set; }
        public List<Prueba>? pruebas { get; set; }
        public bool dado_Alta { get; set; }

        public Paciente() { }
        public Paciente(string nombre, string direccion, string dni, int dias_Ingresado)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.dni = dni;
            this.dias_Ingresado = dias_Ingresado;

        }

    }
}
