using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Evento.Interfaces
{
    public interface IAdEvento
    {
        API.Dto.Evento.Salida.AgregarEvento AgregarEvento(API.Dto.Evento.Entrada.AgregarEvento pInformacion);
        API.Dto.Evento.Salida.EditarEvento EditarEvento(API.Dto.Evento.Entrada.EditarEvento pInformacion);
        API.Dto.Evento.Salida.EliminarEvento EliminarEvento(API.Dto.Evento.Entrada.EliminarEvento pInformacion);
        API.Dto.Evento.Salida.VerTodosEventos VerTodosEventos();
        API.Dto.Evento.Salida.VerDetalleEvento VerDetalleEvento(API.Dto.Evento.Entrada.VerDetalleEvento pInformacion);
    }
}
