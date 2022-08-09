using ControlVuelos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ControlVuelos.Repositories
{
    public class FlightRepository: RepositoryBase
    {
        //retorna los vuelos desde la base de datos
        public VueloCollection listarVuelos()
        {
            VueloCollection lista = new VueloCollection();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Flights] order by Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var flightModel = new flightModel();
                        flightModel.Id = reader[0].ToString();
                        flightModel.Origen = reader[1].ToString();
                        flightModel.Destino = reader[2].ToString();
                        flightModel.Fecha = reader[3].ToString();
                        flightModel.Salida = reader[4].ToString();
                        flightModel.LLegada = reader[5].ToString();
                        flightModel.NumVuelo = reader[6].ToString();
                        flightModel.Aerolinea = reader[7].ToString();
                        flightModel.Estado = reader[8].ToString();
                        lista.Add(flightModel);
                    }
                }
            }
            return lista;
        }

        public bool eliminarVuelo(flightModel f)
        {
            string id = f.Id;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Flights where Id=@id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool Add(flightModel f)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Flights values (NEWID(),@Origen, @Destino, @Fecha, @Salida, @Llegada, @NumVuelo, @Aerolinea, @Estado)";
                command.Parameters.Add("@Origen", SqlDbType.NVarChar).Value = f.Origen;
                command.Parameters.Add("@Destino", SqlDbType.NVarChar).Value = f.Destino;
                command.Parameters.Add("@Fecha", SqlDbType.NVarChar).Value = f.Fecha;
                command.Parameters.Add("@Salida", SqlDbType.NVarChar).Value = f.Salida;
                command.Parameters.Add("@Llegada", SqlDbType.NVarChar).Value = f.LLegada;
                command.Parameters.Add("@NumVuelo", SqlDbType.NVarChar).Value = f.NumVuelo;
                command.Parameters.Add("@Aerolinea", SqlDbType.NVarChar).Value = f.Aerolinea;
                command.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = f.Estado;
                command.ExecuteNonQuery();
            }
            return true;
        }
        
    }
}
