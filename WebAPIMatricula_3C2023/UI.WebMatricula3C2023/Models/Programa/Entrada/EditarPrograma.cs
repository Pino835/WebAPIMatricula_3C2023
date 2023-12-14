namespace UI.WebMatricula3C2023.Models.Programa.Entrada
{
    public class EditarPrograma : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string NombreCarrera { get; set; }
        public string Modalidad { get; set; }
        public string Idioma { get; set; }
        public int CantidadCuatrimestres { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
