using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Calificacion.Salida
{
    public class VerDetalleCalificacion : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public int NotaProyecto { get; set; }
        public int NotaTareas { get; set; }
        public int NotaTrabajoCotidiano { get; set; }
        public int CodigoEstudiante { get; set; }
        public int CodigoProfesor { get; set; }
        public int CodigoCurso { get; set; }
    }
}
