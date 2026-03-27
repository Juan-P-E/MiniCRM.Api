using Microsoft.Data.Sqlite;

namespace MiniCRM.Api.Data
{
    public class ConexionSQLite
    {
        private readonly string _connectionString;

        public ConexionSQLite()
        {
            _connectionString = "Data Source=clientes.db";
        }

        public SqliteConnection ObtenerConexion()
        {
            return new SqliteConnection(_connectionString);
        }

        public void CrearTablaClientes()
        {
            using (var connection = ObtenerConexion())
            {
                connection.Open();

                var query = @"
        CREATE TABLE IF NOT EXISTS Clientes (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Nombre TEXT NOT NULL,
            Email TEXT NOT NULL,
            Telefono TEXT
        );";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}