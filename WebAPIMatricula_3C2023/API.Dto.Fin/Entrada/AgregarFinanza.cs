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
        public float CobroMatricula { get; set; }
        public float CobroPoliza { get; set; }
        public float CobroTechFee { get; set; }
        public int CodigoMatricula { get; set; }
    }
}