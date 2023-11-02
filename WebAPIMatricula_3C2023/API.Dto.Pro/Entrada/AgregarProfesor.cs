using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Profesor.Entrada
{
    public class AgregarProfesor : General.EntradaAPI
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoFacultad { get; set; }
        public string Estado { get; set; }
    }
}