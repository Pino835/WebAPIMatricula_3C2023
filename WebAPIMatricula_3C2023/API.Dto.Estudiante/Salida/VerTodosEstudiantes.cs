﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Dto.Estudiante.Salida
{
    public class VerTodosEstudiantes : General.RespuestaAPI
    {
        public List<DatosEstudiante> ListaEstudiantes { get; set; }



        public VerTodosEstudiantes()
        {
            ListaEstudiantes = new List<DatosEstudiante>();
        }
    }



    public class DatosEstudiante
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
    }
}
