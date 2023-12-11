namespace UI.WebMatricula3C2023.Models.Finanza.Entrada
{
    public class AgregarFinanza : General.EntradaAPI
    {
        public int TotalMaterias { get; set; }
        public float CobroMatricula { get; set; }
        public float CobroPoliza { get; set; }
        public float CobroTechFee { get; set; }
        public int CodigoMatricula { get; set; }
    }
}
