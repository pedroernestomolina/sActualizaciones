using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gNube.DataProvider
{
    
    public class Data: IData
    {
        static MySqlConnectionStringBuilder _cn;


        public Data() 
        {
            _cn= new MySqlConnectionStringBuilder();
            _cn.Database = "pitaTest";
            _cn.UserID = "leonuxBD";
            _cn.Password = "ghx_k!kibx+D";
            _cn.Server = "107.180.50.172";
        }


        public Result.ResultadoEntidad<string>
            MonitorSistemaPosOnLine_Info()
        {
            var result = new Result.ResultadoEntidad<string>();

            try
            {
                using (var cn = new MySqlConnection(_cn.ConnectionString))
                {
                    cn.Open();

                    try
                    {
                        var sql1 = @"select pos_online from monitor_act_sistema where id=1";
                        var comando1 = new MySqlCommand(sql1, cn);
                        var idObj = comando1.ExecuteScalar();
                        if (idObj != null)
                        {
                            result.Entidad = idObj.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Mensaje = ex.Message;
                        result.Result = Result.Enumerados.EnumResult.isError;
                    }
                };
            }
            catch (Exception ex)
            {
                result.Mensaje = ex.Message;
                result.Result = Result.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public Result.Resultado 
            MonitorSistemaPosOnLine_ActualizarVer(string new_pos)
        {
            var result = new Result.Resultado();

            try
            {
                using (var cn = new MySqlConnection(_cn.ConnectionString))
                {
                    cn.Open();
                    MySqlTransaction tr = null;
                    try
                    {
                        tr = cn.BeginTransaction();
                        var sql1 = @"update monitor_act_sistema set 
                                        pos_online=@new_pos
                                        where id=1";
                        var comando1 = new MySqlCommand(sql1, cn, tr);
                        comando1.Parameters.AddWithValue("@new_pos", new_pos);
                        comando1.ExecuteNonQuery();
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        result.Mensaje = ex.Message;
                        result.Result = Result.Enumerados.EnumResult.isError;
                    }
                };
            }
            catch (Exception ex)
            {
                result.Mensaje = ex.Message;
                result.Result = Result.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}