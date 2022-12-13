using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using testefcore.controllers;
using testefcore.models;

namespace hospital
{
    class Menu
    {
        PacienteController pacienteController = new PacienteController();

        public Menu()
        {
            while (true)
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Selecciona un nivel de dificultar");
                Console.WriteLine("Introduzca \n 1) Registrar paciente \n 2) Dar de alta" +
                " \n 3) Notificar deceso \n 4) Realizar prueba \n 5) Asignar medicamento");
                Console.WriteLine("_____________________________________________");
                int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
                switch (opcionSeleccionada)
                {
                    case 1:
                        RegistrarPaciente();
                        break;
                    case 2:
                        DarAltaPaciente();
                        break;
                    case 3:
                        DecesoPaciente();
                        break;
                    case 4:
                        AsignarPrueba();
                        break;
                    case 5:
                        AsignarMedicamento();
                        break;
                }

            }
        }
        public void RegistrarPaciente()
        {
            try
            {
                Console.WriteLine("Introduzca el nombre del paciente:");
                Paciente paciente = new Paciente();
                paciente.nombre = Console.ReadLine();
                Console.WriteLine("Introduzca el direccion del paciente:");
                paciente.direccion = Console.ReadLine();
                Console.WriteLine("Introduzca el dni del paciente:");
                paciente.dni = Console.ReadLine();
                Console.WriteLine("Introduzca los dias que estará ingresado el paciente:");
                paciente.dias_Ingresado = Convert.ToInt32(Console.ReadLine());
                pacienteController.AñadirPaciente(paciente);
                Console.WriteLine("Paciente registrado: ");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DarAltaPaciente()
        {
            try
            {
                Console.WriteLine("Introduzca el dni del paciente:");
                pacienteController.DarAltaPacienteByDNI(Console.ReadLine());
                Console.WriteLine("Introduzca la nota especifica de alta: ");
                string nota_alta = Console.ReadLine();
               // Console.WriteLine("Paciente dado de alta: " + paciente.nombre);
               // Console.WriteLine("Nota especifica de alta: " + nota_alta);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DecesoPaciente()
        {
            try
            {
                Console.WriteLine("Introduzca el dni del paciente:");
                string dni = Console.ReadLine();
                pacienteController.BorrarPacienteByDNI(dni);
                Console.WriteLine("Paciente con dni" + dni + "eliminado.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AsignarPrueba()
        {
            try
            {
                Paciente paciente = new Paciente();
                Console.WriteLine("Introduzca el dni del paciente:");
                string dni = Console.ReadLine();
                string pruebaSeleccionada = MenuPruebas();
                pacienteController.CrearPruebaPacienteByDNI(pruebaSeleccionada, dni);
                Console.WriteLine("Se asigno una prueba de: " + pruebaSeleccionada);
                pacienteController.MostrarPacientes();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AsignarMedicamento()
        {
            try
            {
                Paciente paciente = new Paciente();
                Console.WriteLine("Introduzca el dni del paciente:");
                string dni = Console.ReadLine();
                string medicamenteRecetado = MenuMedicamentos();
                pacienteController.AsignarMedicamentoPacienteByDNI(medicamenteRecetado,dni);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string MenuPruebas()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("Selecciona un nivel de dificultar");
            Console.WriteLine("Introduzca \n 1) Rayos X \n 2) TAC" +
            " \n 3) Medida azucar \n 4) Prueba de esfuerzo \n 5) Escanner \n Pulse otro numero para salir");
            Console.WriteLine("_____________________________________________");
            int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
            switch (opcionSeleccionada)
            {
                case 1:
                    return "Rayos X";
                case 2:
                    return "TAC";
                case 3:
                    return "Medida azucar";
                case 4:
                    return "Prueba de esfuerzo";
                case 5:
                    return "Escanner";
                default:
                    return "";
            }
        }
        public string MenuMedicamentos()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("Selecciona un nivel de dificultar");
            Console.WriteLine("Introduzca \n 1) Aspirina \n 2) Rizinotizol" +
            " \n 3) Cascahueton \n 4) Filecodeina \n 5) Surnoteina \n Pulse otro numero para salir");
            Console.WriteLine("_____________________________________________");
            int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
            switch (opcionSeleccionada)
            {
                case 1:
                    return "Aspirina";
                case 2:
                    return "Rizinotizol";
                case 3:
                    return "Cascahueton";
                case 4:
                    return "Filecodeina";
                case 5:
                    return "Surnoteina";
                default:
                    return "";
            }
        }

    }
}