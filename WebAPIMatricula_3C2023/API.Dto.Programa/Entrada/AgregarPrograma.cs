using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Programa.Entrada
{
    public class AgregarPrograma : General.EntradaAPI
    {
        public string NombreCarrera { get; set; }
        public string Modalidad { get; set; }
        public string Idioma { get; set; }
        public int CantidadCuatrimestres { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
