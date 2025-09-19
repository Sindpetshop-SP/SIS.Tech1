using System.Data;
using System.Data.SqlClient;

namespace SIS.Tech.Util
{
    public class TrataCampos
    {
        #region ** Object **

        /// <summary>
        /// Trata um campo para se vier DbNull ele retornar 0
        /// </summary>
        /// <param name="campo">Campo a ser tratado</param>
        /// <returns>Se o campo for DbNull retorna 0(zero), se não retorna ele mesmo.</returns>
        public static object ConvertDbNullToZero(object campo)
        {
            if (!object.ReferenceEquals(campo, DBNull.Value))
                return campo;
            else
                return 0;
        }

        #endregion ** Object **

        #region ** SqlDataReader **

        /// <summary>
        /// Recuperar valores decimais a partir da base de dados para verificar se há valores nulos.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static decimal? GetNullableDecimal(SqlDataReader reader, string fieldName)
        {
            if (reader[fieldName] != DBNull.Value)
            {
                //return (decimal)reader[fieldName];
                return reader.GetDecimal(reader.GetOrdinal(fieldName));
            }

            return null;

            //if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
            //{
            //    return (decimal)reader[fieldName];
            //}
            //return null;
        }

        /// <summary>
        /// Recuperar valores decimais a partir da base de dados para verificar se há valores nulos.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static int? GetNullableInt(SqlDataReader reader, string fieldName)
        {
            if (!reader.IsDBNull((int)reader.GetSqlInt32(reader.GetOrdinal(fieldName))))
            {
                return (int)reader[fieldName];
            }

            return null;
        }

        #endregion ** SqlDataReader **

        #region ** IDataReader **

        /// <summary>
        /// Devolve se é null ou devolve o objeto
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public object TrataObject(IDataReader dataReader, string columnName)
        {
            object obj = null;
            if (!object.ReferenceEquals(dataReader[columnName], DBNull.Value))
            {
                obj = dataReader[columnName];
            }

            return obj;

        }

        /// <summary>
        /// Verifica se é DBNULL
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool IsDbNull(IDataReader dataReader, string columnName)
        {
            return dataReader[columnName] == DBNull.Value;
        }

        /// <summary>
        /// Recuperar valores decimais a partir da base de dados para verificar se há valores nulos.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int? GetNullableInt(IDataReader dr, string columnName)
        {
            var value = dr[columnName];
            return value is DBNull ? (int?)null : Convert.ToInt32(value);
        }

        public static decimal? GetNullableDecimal(IDataReader dr, string columnName)
        {
            var value = dr[columnName];
            return value is DBNull ? (decimal?)null : Convert.ToDecimal(value);
        }

        public static DateTime? GetNullableDateTime(IDataReader dr, string columnName)
        {
            var value = dr[columnName];
            return value is DBNull ? (DateTime?)null : Convert.ToDateTime(value);
        }

        /// <summary>
        /// Recuperar valores decimais a partir da base de dados para verificar se há valores nulos.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static int? GetNullableInt(IDataReader reader, int columnIndex)
        {
            return reader.IsDBNull(columnIndex) ? (int?)null : Convert.ToInt32(reader[columnIndex]);
        }

        /// <summary>
        /// Recuperar valores decimais a partir da base de dados para verificar se há valores nulos.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetNullableString(IDataReader reader, string columnName)
        {
            var value = reader[columnName];
            return value is DBNull ? null : Convert.ToString(reader[columnName]);
        }

        public static string GetStringSafe(IDataReader reader, int colIndex)
        {
            return GetStringSafe(reader, colIndex, string.Empty);
        }

        public static string GetStringSafe(IDataReader reader, int colIndex, string defaultValue)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return defaultValue;
        }

        public static string GetStringSafe(IDataReader reader, string columnName)
        {
            return GetStringSafe(reader, reader.GetOrdinal(columnName));
        }

        public static string GetStringSafe(IDataReader reader, string columnName, string defaultValue)
        {
            return GetStringSafe(reader, reader.GetOrdinal(columnName), defaultValue);
        }

        #endregion  ** IDataReader **

    }
}
