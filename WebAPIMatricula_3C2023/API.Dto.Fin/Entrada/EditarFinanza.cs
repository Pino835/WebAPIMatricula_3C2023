using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Finanza.Entrada
{
    public class EditarFinanza : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public int TotalMaterias { get; set; }
        public int CobroMatricula { get; set; }
        public int CobroPoliza { get; set; }
        public int CobroTechFee { get; set; }
        public int CodigoMatricula { get; set; }
    }
}
