using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testefcore.controllers;
using testefcore.models;

namespace hospital
{
    class Manager
    {
        PacienteController pacienteController = new PacienteController();
        
        public Manager()
        {
           // pacienteController.AñadirPacientesBD();
            pacienteController.MostrarPacientes();
            Menu menu = new Menu();
        }
      
    }
}
