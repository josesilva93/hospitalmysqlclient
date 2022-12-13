using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testefcore.models
{
    public class Prueba
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Paciente paciente { get; set; }
    }
}
