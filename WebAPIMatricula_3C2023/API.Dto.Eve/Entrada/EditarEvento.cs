using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Evento.Entrada
{
    public class EditarEvento : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string NombreEvento { get; set; }
        public string NombreInvitado { get; set; }
        public DateTime Horario { get; set; }
        public string Lugar { get; set; }
        public string TipoSello { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
