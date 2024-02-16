using System.Data.SqlClient;

namespace ManagementSystem.Business.Extentions
{
    public static class SqlDataReaderExtention
    {
        public static string? GetNullableString(this SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }

        public static int GetNullableInt32(this SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        public static bool GetBoolean(this SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default : Convert.ToBoolean(reader[colName]);
        }

        public static DateTime GetDateTime(this SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default : Convert.ToDateTime(reader[colName]);
        }
    }
}
