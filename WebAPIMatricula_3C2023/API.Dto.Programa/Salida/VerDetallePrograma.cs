using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Programa.Salida
{
    public class VerDetallePrograma : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string NombreCarrera { get; set; }
        public string Modalidad { get; set; }
        public string Idioma { get; set; }
        public int CantidadCuatrimestres { get; set; }
    }
}
