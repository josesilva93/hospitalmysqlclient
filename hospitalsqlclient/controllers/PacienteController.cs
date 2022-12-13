using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using testefcore.models;
using testefcore.service;

namespace testefcore.controllers
{
    class PacienteController
    {
        Service service = new Service();
        public void MostrarPacientes()
        {
            List<Paciente> pacienteList = new List<Paciente>();
            pacienteList = service.GetAllPacientes();
            foreach (Paciente p in pacienteList)
            {
                Console.WriteLine($"Paciente: " + p.nombre);
                if (p.pruebas != null)
                {
                    foreach (Prueba prueba in p.pruebas)
                    {
                        Console.WriteLine(prueba.nombre);
                    }
                }

            }

        }
        public void AñadirPaciente(Paciente paciente)
        {
            service.Save(paciente);
            Console.WriteLine($"Paciente: " + paciente.nombre + " añadido.");
        }

        /**  public void AñadirPacientesBD()
           {
               List<Paciente> list = new List<Paciente>();
               Paciente paciente1 = new Paciente("Pepe", "dasfdsfsdf", "1", 30);
               Paciente paciente2 = new Paciente("Manolo", "dasfdsfsdf", "2", 30);
               Paciente paciente3 = new Paciente("Alejandro", "dasfdsfsdf", "3", 30);
               Paciente paciente4 = new Paciente("Manuel", "dasfdsfsdf", "4", 30);
               list.Add(paciente1);
               list.Add(paciente2);
               list.Add(paciente3);
               list.Add(paciente4);
               foreach (Persona p in list)
               {
                //   service.Save(p);
                   Console.WriteLine($"Paciente: " + p.nombre + " añadido.");
               }
           }*/


         public void DarAltaPacienteByDNI(string dni)
         {
             service.AltaPacienteByDNI(dni);         
         }
         public void BorrarPacienteByDNI(string dni)
         {
             service.BorrarPaciente(dni);
         }
         public void CrearPruebaPacienteByDNI(string nombrePrueba, string dniPaciente)
         {
            int idPaciente = service.GetIdByDNI(dniPaciente);
            service.AsignarMedicamentoPrueba(nombrePrueba, idPaciente);
        }
        public void AsignarMedicamentoPacienteByDNI(string nombreMedicamento, string dniPaciente)
         {
            int idPaciente = service.GetIdByDNI(dniPaciente);
             service.AsignarMedicamentoPaciente(nombreMedicamento, idPaciente);
         }
    }
}

