namespace UI.WebMatricula3C2023.Models.Profesor.Entrada
{
    public class EditarProfesor : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoFacultad { get; set; }
        public string Estado { get; set; }
    }
}

