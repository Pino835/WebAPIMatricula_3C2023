namespace UI.WebMatricula3C2023.Models.Departamento.Entrada
{
    public class EditarDepartamento : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreDirector { get; set; }
        public string HorarioAtencion { get; set; }
        public int AulaAtencion { get; set; }
        public int CodigoProfesor { get; set; }
    }
}
