using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class ClienteMapper : Mapper<Cliente>
    {
        public override int Insertar(Cliente cliente)
        {
            return acceso.Escribir("sp_Cliente_Insertar", new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = cliente.UsuarioId },
                new SqlParameter("@DniCuit", SqlDbType.NVarChar, 13) { Value = cliente.DniCuit },
                new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = cliente.Nombre },
                new SqlParameter("@Telefono", SqlDbType.NVarChar, 30) { Value = cliente.Telefono },
                new SqlParameter("@Email", SqlDbType.NVarChar, 150) { Value = cliente.Email },
                new SqlParameter("@AntecedenteNegativo", SqlDbType.Bit) { Value = cliente.AntecedenteNegativo }
            });
        }

        public Cliente Buscar(int clienteId)
        {
            DataTable tabla = acceso.Leer("sp_Cliente_Buscar", new List<SqlParameter>
            {
                new SqlParameter("@ClienteId", SqlDbType.Int) { Value = clienteId }
            });
            return tabla.Rows.Count == 0 ? null : Mapear(tabla.Rows[0]);
        }

        public List<Cliente> Listar(int? usuarioId)
        {
            DataTable tabla = acceso.Leer("sp_Cliente_Listar", new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId.HasValue ? (object)usuarioId.Value : DBNull.Value }
            });
            List<Cliente> clientes = new List<Cliente>();
            foreach (DataRow fila in tabla.Rows) clientes.Add(Mapear(fila));
            return clientes;
        }

        public int GuardarSeguro(Seguro seguro)
        {
            return acceso.Escribir("sp_Seguro_Guardar", new List<SqlParameter>
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = seguro.Id },
                new SqlParameter("@ClienteId", SqlDbType.Int) { Value = seguro.ClienteId },
                new SqlParameter("@Poliza", SqlDbType.NVarChar, 50) { Value = seguro.Poliza },
                new SqlParameter("@Aseguradora", SqlDbType.NVarChar, 100) { Value = seguro.Aseguradora },
                new SqlParameter("@Desde", SqlDbType.DateTime2) { Value = seguro.Desde },
                new SqlParameter("@Hasta", SqlDbType.DateTime2) { Value = seguro.Hasta },
                new SqlParameter("@Cobertura", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = seguro.Cobertura }
            });
        }

        public List<Seguro> ListarSeguros(int clienteId)
        {
            DataTable tabla = acceso.Leer("sp_Seguro_ListarPorCliente", new List<SqlParameter>
            {
                new SqlParameter("@ClienteId", SqlDbType.Int) { Value = clienteId }
            });
            List<Seguro> seguros = new List<Seguro>();
            foreach (DataRow fila in tabla.Rows)
                seguros.Add(new Seguro
                {
                    Id = Convert.ToInt32(fila["Id"]), ClienteId = Convert.ToInt32(fila["ClienteId"]),
                    Cliente = MapearClienteSeguro(fila), Poliza = Convert.ToString(fila["Poliza"]),
                    Aseguradora = Convert.ToString(fila["Aseguradora"]), Desde = Convert.ToDateTime(fila["Desde"]),
                    Hasta = Convert.ToDateTime(fila["Hasta"]), Cobertura = Convert.ToDecimal(fila["Cobertura"])
                });
            return seguros;
        }

        private Cliente Mapear(DataRow fila)
        {
            return new Cliente
            {
                Id = Convert.ToInt32(fila["Id"]), UsuarioId = Convert.ToInt32(fila["UsuarioId"]),
                DniCuit = Convert.ToString(fila["DniCuit"]), Nombre = Convert.ToString(fila["Nombre"]),
                Telefono = Convert.ToString(fila["Telefono"]), Email = Convert.ToString(fila["Email"]),
                AntecedenteNegativo = Convert.ToBoolean(fila["AntecedenteNegativo"]),
                Usuario = MapearUsuario(fila)
            };
        }
        private Usuario MapearUsuario(DataRow fila)
        {
            return new Usuario { Id = Convert.ToInt32(fila["UsuarioId"]), NombreUsuario = Convert.ToString(fila["NombreUsuario"]), Rol = Convert.ToString(fila["Rol"]), Activo = Convert.ToBoolean(fila["Activo"]) };
        }
        private Cliente MapearClienteSeguro(DataRow fila)
        {
            return new Cliente { Id = Convert.ToInt32(fila["ClienteId"]), UsuarioId = Convert.ToInt32(fila["UsuarioId"]), Usuario = MapearUsuario(fila), Nombre = Convert.ToString(fila["Nombre"]), DniCuit = Convert.ToString(fila["DniCuit"]), Telefono = Convert.ToString(fila["Telefono"]), Email = Convert.ToString(fila["Email"]), AntecedenteNegativo = Convert.ToBoolean(fila["AntecedenteNegativo"]) };
        }
    }
}
