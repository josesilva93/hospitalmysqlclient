using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace testefcore.models
{
    public class Persona
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }

        public string direccion { get; set; }
    }

}
