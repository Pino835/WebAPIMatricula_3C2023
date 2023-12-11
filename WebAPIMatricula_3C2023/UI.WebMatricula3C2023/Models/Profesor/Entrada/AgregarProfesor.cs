namespace UI.WebMatricula3C2023.Models.Profesor.Entrada
{
    public class AgregarProfesor : General.EntradaAPI
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoFacultad { get; set; }
        public string Estado { get; set; }
    }
}


