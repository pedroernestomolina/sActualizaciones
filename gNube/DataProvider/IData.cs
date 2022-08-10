using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gNube.DataProvider
{
    
    public interface IData
    {

        Result.ResultadoEntidad<string>
            MonitorSistemaPosOnLine_Info();
        Result.Resultado
            MonitorSistemaPosOnLine_ActualizarVer(string new_pos);

        Result.ResultadoEntidad<string>
            MonitorSistemaGestionFtp_Info();
        Result.Resultado
            MonitorSistemaGestionFtp_ActualizarVer(string new_pos);

    }

}