using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Programa.Salida
{
    public class VerTodosPrograma : General.RespuestaAPI
    {
        public List<DatosPrograma> ListaProgramas { get; set; }

        public VerTodosPrograma()
        {
            ListaProgramas = new List<DatosPrograma>();
        }
    }

    public class DatosPrograma
    {
        public int Codigo { get; set; }
        public string NombreCarrera { get; set; }
        public string Modalidad { get; set; }
        public string Idioma { get; set; }
        public int CantidadCuatrimestres { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
