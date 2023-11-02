using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Calificacion.Interfaces
{
    public interface IAdCalificacion
    {

        API.Dto.Calificacion.Salida.AgregarCalificacion AgregarCalificacion(API.Dto.Calificacion.Entrada.AgregarCalificacion pInformacion);
        API.Dto.Calificacion.Salida.EditarCalificacion EditarCalificacion(API.Dto.Calificacion.Entrada.EditarCalificacion pInformacion);
        API.Dto.Calificacion.Salida.EliminarCalificacion EliminarCalificacion(API.Dto.Calificacion.Entrada.EliminarCalificacion pInformacion);
        API.Dto.Calificacion.Salida.VerTodosCalificaciones VerTodosCalificaciones();
        API.Dto.Calificacion.Salida.VerDetalleCalificacion VerDetalleCalificacion(API.Dto.Calificacion.Entrada.VerDetalleCalificacion pInformacion);

    }
}
