using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Departamento.Entrada
{
    public class AgregarDepartamento : General.EntradaAPI
    {
        public string Nombre { get; set; }
        public string NombreDirector { get; set; }
        public string HorarioAtencion { get; set; }
        public int AulaAtencion { get; set; }
        public int CodigoProfesor { get; set; }
    }
}
