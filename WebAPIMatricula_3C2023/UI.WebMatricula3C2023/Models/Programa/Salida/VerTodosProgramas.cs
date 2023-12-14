namespace UI.WebMatricula3C2023.Models.Programa.Salida
{
    public class VerTodosProgramas
    {
        public List<DatosPrograma> ListaProgramas { get; set; }

        public VerTodosProgramas()
        {
            ListaProgramas = new List<DatosPrograma>();
        }
    }

    public class DatosPrograma
    {
        public int Codigo { get; set; }
        public string NombreCarrera { get; set; }
        public string Modalidad { get; set; }
        public string Idioma { get; set; }
        public int CantidadCuatrimestres { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
