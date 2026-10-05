using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection conexion;

        public void Abrir()
        {
            ConnectionStringSettings configuracion = ConfigurationManager.ConnectionStrings["Alquiler"];
            string cadena = configuracion == null
                ? "Data Source=.;Initial Catalog=TC-AlquilerAudiovisual;Integrated Security=True;Connect Timeout=5"
                : configuracion.ConnectionString;
            conexion = new SqlConnection(cadena);
            conexion.Open();
        }

        public void Cerrar()
        {
            if (conexion == null) return;
            conexion.Dispose();
            conexion = null;
        }

        public DataTable Leer(string sp, List<SqlParameter> parametros)
        {
            try
            {
                Abrir();
                using (SqlCommand comando = CrearComando(sp, parametros))
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
            catch (SqlException ex) { throw TraducirError(ex); }
            finally { Cerrar(); }
        }

        public int Escribir(string sp, List<SqlParameter> parametros)
        {
            try
            {
                Abrir();
                using (SqlCommand comando = CrearComando(sp, parametros))
                {
                    SqlParameter resultado = comando.Parameters.Add("@Resultado", SqlDbType.Int);
                    resultado.Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();
                    if (resultado.Value == DBNull.Value) throw new InvalidOperationException("La operación no devolvió un resultado.");
                    return Convert.ToInt32(resultado.Value);
                }
            }
            catch (SqlException ex) { throw TraducirError(ex); }
            finally { Cerrar(); }
        }

        private SqlCommand CrearComando(string sp, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand(sp, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 20;
            if (parametros != null) comando.Parameters.AddRange(parametros.ToArray());
            return comando;
        }

        private Exception TraducirError(SqlException ex)
        {
            string mensaje;
            if (ex.Number >= 50000) mensaje = ex.Message;
            else if (ex.Number == 2601 || ex.Number == 2627) mensaje = "Ya existe un registro con esos datos únicos.";
            else if (ex.Number == 547) mensaje = "Revisá los datos y las relaciones del registro.";
            else if (ex.Number == 1205) mensaje = "Otra operación coincidió con esta. Volvé a intentarlo.";
            else mensaje = "No se pudo completar la operación con los datos. Verificá que la base esté disponible.";
            return new InvalidOperationException(mensaje, ex);
        }
    }
}
