using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Finanza.Entrada
{
    public class AgregarFinanza : General.EntradaAPI
    {
        public int TotalMaterias { get; set; }
        public int CobroMatricula { get; set; }
        public int CobroPoliza { get; set; }
        public int CobroTechFee { get; set; }
        public int CodigoMatricula { get; set; }
    }
}