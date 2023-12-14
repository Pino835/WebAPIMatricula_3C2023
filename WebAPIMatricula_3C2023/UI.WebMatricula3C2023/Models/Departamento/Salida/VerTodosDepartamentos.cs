namespace UI.WebMatricula3C2023.Models.Departamento.Salida
{
    public class VerTodosDepartamentos
    {
        public List<DatosDepartamento> ListaDepartamentos { get; set; }

        public VerTodosDepartamentos()
        {
            ListaDepartamentos = new List<DatosDepartamento>();
        }
    }

    public class DatosDepartamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreDirector { get; set; }
        public string HorarioAtencion { get; set; }
        public int AulaAtencion { get; set; }
        public int CodigoProfesor { get; set; }
    }
}
