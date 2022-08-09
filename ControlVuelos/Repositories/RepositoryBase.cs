using System.Data.SqlClient;

namespace ControlVuelos.Repositories
{
    public abstract class RepositoryBase
    {
        //conexion con la base de datos
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=DESKTOP-MICH;Initial Catalog=AeropuertoDB;Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
