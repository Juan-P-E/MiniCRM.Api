using Microsoft.Data.Sqlite;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Data
{
    public class ClienteData
    {
        private readonly ConexionSQLite _conexion;

        public ClienteData()
        {
            _conexion = new ConexionSQLite();
        }

        public List<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>();

            using (var connection = _conexion.ObtenerConexion())
            {
                connection.Open();

                var query = "SELECT Id, Nombre, Email, Telefono FROM Clientes";

                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email = reader.GetString(2),
                            Telefono = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };

                        lista.Add(cliente);
                    }
                }
            }

            return lista;
        }

        public Cliente InsertarCliente(Cliente cliente)
        {
            using (var connection = _conexion.ObtenerConexion())
            {
                connection.Open();

                var query = @"
                    INSERT INTO Clientes (Nombre, Email, Telefono)
                    VALUES (@Nombre, @Email, @Telefono);

                    SELECT last_insert_rowid();";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefono", (object?)cliente.Telefono ?? DBNull.Value);

                    var idGenerado = Convert.ToInt64(command.ExecuteScalar());
                    cliente.Id = (int)idGenerado;
                }
            }

            return cliente;
        }




        public Cliente? ObtenerClientePorId(int id)
        {
            using (var connection = _conexion.ObtenerConexion())
            {
                connection.Open();

                var query = "SELECT Id, Nombre, Email, Telefono FROM Clientes WHERE Id = @Id";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Email = reader.GetString(2),
                                Telefono = reader.IsDBNull(3) ? null : reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void EliminarCliente(int id)
        {
            using (var connection = _conexion.ObtenerConexion())
            {
                connection.Open();

                var query = "DELETE FROM Clientes WHERE Id = @Id";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarCliente(Cliente cliente)
        {
            using (var connection = _conexion.ObtenerConexion())
            {
                connection.Open();

                var query = @"
            UPDATE Clientes 
            SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono
            WHERE Id = @Id";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", cliente.Id);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefono", (object?)cliente.Telefono ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
