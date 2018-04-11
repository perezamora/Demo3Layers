using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAcces.Dao.Dao
{
    public class AlumnoSqlDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IDatabase database;

        public T Add(T item)
        {
            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();
            Alumno alumno = item as Alumno;

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var fechaNac = (SqlDateTime)alumno.FechaNac;
                    var sqlCommand = "INSERT INTO ALUMNOS ([Guid],[Nombre],[Apellidos],[Dni],[FechaNacimiento],[Edad],[FechaCreacion]) " +
                        "VALUES ('" + alumno.Guid + "','" + alumno.Name + "','" + alumno.Apellidos + "','" + alumno.Dni + "','" + fechaNac + "'," + alumno.Edad + ",'" + alumno.FechaCr + "')";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        command.ExecuteNonQuery();
                        database.CloseConnection(connection);
                    }

                    return this.Select(alumno.Guid);
                }
            }
            catch (SqlException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public List<T> GetAlumnos()
        {
            throw new NotImplementedException();
        }

        public T Select(string guid)
        {
            log.Debug("Select: " + guid);
            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "SELECT * FROM ALUMNOS WHERE Guid = '" + guid + "'";
                    log.Debug("sqlCommand: " + sqlCommand);
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var alumno = new Alumno();
                            while (reader.Read())
                            {
                                alumno.Id = reader.GetInt32(0);
                                alumno.Guid = reader.GetGuid(1).ToString();
                                alumno.Name = reader.GetString(2);
                                alumno.Apellidos = reader.GetString(3);
                                alumno.Dni = reader.GetString(4);
                                alumno.FechaNac = reader.GetDateTime(5);
                                alumno.Edad = reader.GetInt32(6);
                                alumno.FechaCr = reader.GetString(7);
                            }
                            database.CloseConnection(connection);
                            log.Debug("Alumno select: " + alumno.ToString());
                            return alumno as T;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}
