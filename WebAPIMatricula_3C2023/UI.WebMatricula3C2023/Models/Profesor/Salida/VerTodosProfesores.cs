namespace UI.WebMatricula3C2023.Models.Profesor.Salida
{
    public class VerTodosProfesores : General.RespuestaAPI
    {
        public List<DatosProfesor> ListaProfesores { get; set; }

        public VerTodosProfesores()
        {
            ListaProfesores = new List<DatosProfesor>();
        }
    }

    public class DatosProfesor
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
