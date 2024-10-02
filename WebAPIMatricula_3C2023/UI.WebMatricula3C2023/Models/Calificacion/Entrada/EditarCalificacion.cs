namespace UI.WebMatricula3C2023.Models.Calificacion.Entrada
{
    public class EditarCalificacion
    {
        public int Codigo { get; set; }
        public float NotaProyecto { get; set; }
        public float NotaTareas { get; set; }
        public float NotaTrabajoCotidiano { get; set; }
        public int CodigoEstudiante { get; set; }
        public int CodigoProfesor { get; set; }
        public int CodigoCurso { get; set; }
    }
}
