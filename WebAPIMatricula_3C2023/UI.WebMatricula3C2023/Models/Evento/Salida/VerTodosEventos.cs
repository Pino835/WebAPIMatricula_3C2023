namespace UI.WebMatricula3C2023.Models.Evento.Salida
{
    public class VerTodosEventos
    {
        public List<DatosEvento> ListaEventos { get; set; }

        public VerTodosEventos()
        {
            ListaEventos = new List<DatosEvento>();
        }
    }

    public class DatosEvento
    {
        public int Codigo { get; set; }
        public string NombreEvento { get; set; }
        public string NombreInvitado { get; set; }
        public string Horario { get; set; }
        public string Lugar { get; set; }
        public string TipoSello { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
