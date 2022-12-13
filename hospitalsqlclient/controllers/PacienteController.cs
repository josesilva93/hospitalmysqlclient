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


        /** public Paciente DarAltaPacienteByDNI(string dni)
         {
             Paciente paciente = service.FindPacienteByDNI(dni);
             paciente.dado_Alta = true;
             service.UpdatePaciente(paciente);
             return paciente;
         }
         public void BorrarPacienteByDNI(string dni)
         {
             Paciente paciente = service.FindPacienteByDNI(dni);
             service.BorrarPaciente(paciente);
         }
         public void CrearPruebaPacienteByDNI(string dni, string nombre_prueba)
         {
             Paciente paciente = service.FindPacienteByDNI(dni);
             Prueba prueba = new Prueba();
             prueba.nombre = nombre_prueba;  
             prueba.paciente = paciente;
             service.Save(prueba);
             Console.WriteLine(prueba.nombre);
             Console.WriteLine(paciente.nombre);     
         }
        public void AsignarMedicamentoPacienteByDNI(string dni, string nombre_medicamento)
         {
             Paciente paciente = service.FindPacienteByDNI(dni);
             Medicamento medicamento = new Medicamento();
             medicamento.nombre = nombre_medicamento;
             medicamento.paciente = paciente;
             service.Save(medicamento);
             Console.WriteLine(medicamento.nombre);
             Console.WriteLine(paciente.nombre);
         }*/
    }
}

