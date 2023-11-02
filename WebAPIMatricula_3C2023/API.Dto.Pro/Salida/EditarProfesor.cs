using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Profesor.Salida
{
    public class EditarProfesor : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoFacultad { get; set; }
        public string Estado { get; set; }
    }
}

