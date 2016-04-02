using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dominio
{
    class AccesoDatos
    {
        public static string stringConexion
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            }
        }

        public static int EjecutarSentencia(string consulta, List<SqlParameter> lst, CommandType tipo)
        {
            int filasAfectadas = -1;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.CommandType = tipo;
            if (lst != null) cmd.Parameters.AddRange(lst.ToArray());
            try
            {
                con.Open();
                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return filasAfectadas;
        }
        public static Object EjecutarEscalar(string consulta, List<SqlParameter> lst, CommandType tipo)
        {
            Object retorno = null;
            SqlConnection con = new SqlConnection(stringConexion);
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.CommandType = tipo;
            if (lst != null) cmd.Parameters.AddRange(lst.ToArray());
            try
            {
                con.Open();
                retorno = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return retorno;
        }
        public static SqlDataReader EjecutarLector(string consulta, List<SqlParameter> lst, CommandType tipo)
        {
            SqlDataReader data = null;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.CommandType = tipo;
            if (lst != null) cmd.Parameters.AddRange(lst.ToArray());
            try
            {
                con.Open();
                data = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(SqlException ex)
            {
            }
            return data;
        }


    }
}
