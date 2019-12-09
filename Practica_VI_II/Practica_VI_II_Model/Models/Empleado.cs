using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_VI_II_Model.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Estado_Civil { get; set;}
        public string Pais { get; set; }
    }
}
