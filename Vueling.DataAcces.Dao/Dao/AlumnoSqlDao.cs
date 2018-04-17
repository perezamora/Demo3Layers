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
    public class AlumnoSqlDao<T> : ICrudDao<T> where T : VuelingObject
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
                    var sqlCommand = "INSERT INTO ALUMNOS ([Guid],[Nombre],[Apellidos],[Dni],[FechaNacimiento],[Edad],[FechaCreacion]) " +
                        "VALUES ('" + alumno.Guid + "','" + alumno.Name + "','" + alumno.Apellidos + "','" + alumno.Dni + "','" + fechaNac + "'," + alumno.Edad + ",'" + alumno.FechaCr + "')";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sqlCommand = "SELECT * FROM ALUMNOS WHERE Guid = '" + alumno.Guid + "'";
                    using (IDbCommand command = database.CreateCommand(sqlCommand, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var alumnoRet = new Alumno();
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
                            //database.CloseConnection(connection);
                            log.Debug("Alumno select: " + alumno.ToString());
                            return alumnoRet as T;
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

        public T Select(T guid)
        {
            throw new NotImplementedException();
        }

        public T SelectById(T id)
        {
            throw new NotImplementedException();
        }

        public T Update(T id)
        {
            throw new NotImplementedException();
        }

        public T Delete(T id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
