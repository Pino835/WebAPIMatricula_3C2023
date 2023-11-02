using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Finanza.Interfaces
{
    public interface IAdFinanza
    {
        API.Dto.Finanza.Salida.AgregarFinanza AgregarFinanza(API.Dto.Finanza.Entrada.AgregarFinanza pInformacion);
        API.Dto.Finanza.Salida.EditarFinanza EditarFinanza(API.Dto.Finanza.Entrada.EditarFinanza pInformacion);
        API.Dto.Finanza.Salida.EliminarFinanza EliminarFinanza(API.Dto.Finanza.Entrada.EliminarFinanza pInformacion);
        API.Dto.Finanza.Salida.VerTodosFinanzas VerTodosFinanzas();
        API.Dto.Finanza.Salida.VerDetalleFinanza VerDetalleFinanza(API.Dto.Finanza.Entrada.VerDetalleFinanza pInformacion);
    }
}
