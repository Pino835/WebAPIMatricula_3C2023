﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Finanza.Salida
{
    public class VerTodosFinanzas : General.RespuestaAPI
    {
        public List<DatosFinanza> ListaFinanzas { get; set; }

        public VerTodosFinanzas()
        {
            ListaFinanzas = new List<DatosFinanza>();
        }
    }

    public class DatosFinanza
    {
        public int Codigo { get; set; }
        public int TotalMaterias { get; set; }
        public float CobroMatricula { get; set; }
        public float CobroPoliza { get; set; }
        public float CobroTechFee { get; set; }
        public int CodigoMatricula { get; set; }
    }
}

