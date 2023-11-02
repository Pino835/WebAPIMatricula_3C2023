using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Calificacion.Salida
{
    public class VerTodosCalificaciones : General.RespuestaAPI
    {
        public List<DatosCalificacion> ListaCalificaciones { get; set; }

        public VerTodosCalificaciones()
        {
            ListaCalificaciones = new List<DatosCalificacion>();
        }
    }

    public class DatosCalificacion
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