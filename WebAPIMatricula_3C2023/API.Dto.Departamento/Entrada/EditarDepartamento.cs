﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Departamento.Entrada
{
    public class EditarDepartamento : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreDirector { get; set; }
        public string HorarioAtencion { get; set; }
        public int AulaAtencion { get; set; }
        public int CodigoCarrera { get; set; }
        public int CodigoProfesor { get; set; }
    }
}
