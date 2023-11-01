using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Bll.Programa.Interfaces
{
    public interface IAdPrograma
    {
        API.Dto.Programa.Salida.AgregarPrograma AgregarPrograma(API.Dto.Programa.Entrada.AgregarPrograma pInformacion);
        API.Dto.Programa.Salida.EditarPrograma EditarPrograma(API.Dto.Programa.Entrada.EditarPrograma pInformacion);
        API.Dto.Programa.Salida.EliminarPrograma EliminarPrograma(API.Dto.Programa.Entrada.EliminarPrograma pInformacion);
        API.Dto.Programa.Salida.VerTodosPrograma VerTodosPrograma();
        API.Dto.Programa.Salida.VerDetallePrograma VerDetallePrograma(API.Dto.Programa.Entrada.VerDetallePrograma pInformacion);
    }
}