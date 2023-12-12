using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Departamento.Salida
{
    public class VerTodosDepartamento : General.RespuestaAPI
    {
        public List<DatosDepartamento> ListaDepartamentos { get; set; }

        public VerTodosDepartamento()
        {
            ListaDepartamentos = new List<DatosDepartamento>();
        }
    }

    public class DatosDepartamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreDirector { get; set; }
        public string HorarioAtencion { get; set; }
        public int AulaAtencion { get; set; }
        public int CodigoProfesor { get; set; }
    }
}
