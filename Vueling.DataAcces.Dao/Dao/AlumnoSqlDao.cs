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
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IDatabase database;

        #region Metodos
        public T Add(T item)
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public int Delete(int id)
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "DELETE FROM ALUMNOS WHERE id = " + id;
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        command.ExecuteNonQuery();
                        database.CloseConnection(connection);
                    }

                    return 0;
                }
            }
            catch (SqlException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public List<T> GetAll()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "SELECT * FROM ALUMNOS";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            List<Alumno> alumnos = new List<Alumno>();
                            while (reader.Read())
                            {
                                var alumno = new Alumno();
                                alumno.Id = reader.GetInt32(0);
                                alumno.Guid = reader.GetGuid(1).ToString();
                                alumno.Name = reader.GetString(2);
                                alumno.Apellidos = reader.GetString(3);
                                alumno.Dni = reader.GetString(4);
                                alumno.FechaNac = reader.GetDateTime(5);
                                alumno.Edad = reader.GetInt32(6);
                                alumno.FechaCr = reader.GetString(7);
                                alumnos.Add(alumno);
                            }
                            database.CloseConnection(connection);
                            return alumnos as List<T>;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public T Select(string guid)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name
                + Resources.logmessage.valueMethod + guid);

            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "SELECT * FROM ALUMNOS WHERE Guid = '" + guid + "'";
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
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public T SelectId(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
