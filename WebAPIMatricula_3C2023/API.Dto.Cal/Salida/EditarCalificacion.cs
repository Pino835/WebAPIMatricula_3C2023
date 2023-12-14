using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Calificacion.Salida
{
    public class EditarCalificacion : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public float NotaProyecto { get; set; }
        public float NotaTareas { get; set; }
        public float NotaTrabajoCotidiano { get; set; }
        public int CodigoEstudiante { get; set; }
        public int CodigoProfesor { get; set; }
        public int CodigoCurso { get; set; }
    }
}
