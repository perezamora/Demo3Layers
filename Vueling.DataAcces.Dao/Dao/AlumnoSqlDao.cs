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
    public class AlumnoSqlDao<T> : ICrudDao<T>
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IDatabase database;

        #region Metodos
        public T Insert(T item)
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
                    var sqlCommand = "INSERT INTO ALUMNOS ([Guid],[Nombre],[Apellidos],[Dni],[FechaNacimiento],[Edad],[FechaCreacion]) VALUES (@Guid, @Nombre, @Apellidos, @Dni, @FechaNac, @Edad , @FechaCr)";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        database.AddParameter(command, "@Guid", alumno.Guid);
                        database.AddParameter(command, "@Nombre", alumno.Name);
                        database.AddParameter(command, "@Apellidos", alumno.Apellidos);
                        database.AddParameter(command, "@Dni", alumno.Dni);
                        database.AddParameter(command, "@FechaNac", alumno.FechaNac);
                        database.AddParameter(command, "@Edad", alumno.Edad);
                        database.AddParameter(command, "@FechaCr", alumno.FechaCr);
                        command.ExecuteNonQuery();
                    }

                    sqlCommand = "SELECT * FROM ALUMNOS WHERE Guid = @Guid";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        database.AddParameter(command, "@Guid", alumno.Guid);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var alumnoRet = new Alumno();
                            while (reader.Read())
                            {
                                alumnoRet.Id = Convert.ToInt32(reader["Id"].ToString());
                                alumnoRet.Guid = reader["Guid"].ToString();
                                alumnoRet.Name = reader["Nombre"].ToString();
                                alumnoRet.Apellidos = reader["Apellidos"].ToString();
                                alumnoRet.Dni = reader["Dni"].ToString();
                                alumnoRet.FechaNac = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                alumnoRet.Edad = Convert.ToInt32(reader["Edad"].ToString());
                                alumnoRet.FechaCr = reader["FechaCreacion"].ToString();
                            }

                            //return alumnoRet as T;
                            return (T)Convert.ChangeType(alumnoRet, typeof(T));
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

        public T Select(T item)
        {
            throw new NotImplementedException();
        }

        public T SelectById(T item)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name + Resources.logmessage.valueMethod);

            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();
            Alumno alumno = item as Alumno;

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "SELECT * FROM ALUMNOS WHERE Id = @IDAlumno";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        database.AddParameter(command, "@IDAlumno", alumno.Id);

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var alumnoSel = new Alumno();
                            while (reader.Read())
                            {
                                alumnoSel.Id = Convert.ToInt32(reader["Id"].ToString());
                                alumnoSel.Guid = reader["Guid"].ToString();
                                alumnoSel.Name = reader["Nombre"].ToString();
                                alumnoSel.Apellidos = reader["Apellidos"].ToString();
                                alumnoSel.Dni = reader["Dni"].ToString();
                                alumnoSel.FechaNac = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                alumnoSel.Edad = Convert.ToInt32(reader["Edad"].ToString());
                                alumnoSel.FechaCr = reader["FechaCreacion"].ToString();
                            }

                            return (T)Convert.ChangeType(alumnoSel, typeof(T));
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

        public T Update(T item)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name + Resources.logmessage.valueMethod);

            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();
            Alumno alumno = item as Alumno;

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "UPDATE ALUMNOS SET Nombre = @Nombre, Apellidos = @Apellidos , Dni = @Dni, FechaNacimiento = @FechaNac, Edad = @Edad WHERE id = @IDAlumno";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        database.AddParameter(command, "@IDAlumno", alumno.Id);
                        database.AddParameter(command, "@Nombre", alumno.Name);
                        database.AddParameter(command, "@Apellidos", alumno.Apellidos);
                        database.AddParameter(command, "@Dni", alumno.Dni);
                        database.AddParameter(command, "@FechaNac", alumno.FechaNac);
                        database.AddParameter(command, "@Edad", alumno.Edad);
                        command.ExecuteNonQuery();
                    }

                    sqlCommand = "SELECT * FROM ALUMNOS WHERE Id = @IDAlumno";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        database.AddParameter(command, "@IDAlumno", alumno.Id);

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var alumnoSel = new Alumno();
                            while (reader.Read())
                            {
                                alumnoSel.Id = Convert.ToInt32(reader["Id"].ToString());
                                alumnoSel.Guid = reader["Guid"].ToString();
                                alumnoSel.Name = reader["Nombre"].ToString();
                                alumnoSel.Apellidos = reader["Apellidos"].ToString();
                                alumnoSel.Dni = reader["Dni"].ToString();
                                alumnoSel.FechaNac = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                alumnoSel.Edad = Convert.ToInt32(reader["Edad"].ToString());
                                alumnoSel.FechaCr = reader["FechaCreacion"].ToString();
                            }

                            return (T)Convert.ChangeType(alumnoSel, typeof(T));
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

        public int Delete(T item)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name + Resources.logmessage.valueMethod);

            DBFactory factory = new DBFactory();
            database = factory.DBSqlServer();
            Alumno alumno = item as Alumno;

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var sqlCommand = "DELETE FROM ALUMNOS WHERE Id = @IDAlumno";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        database.AddParameter(command, "@IDAlumno", alumno.Id);
                        return (Int32)command.ExecuteNonQuery();
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
        #endregion
    }
}
