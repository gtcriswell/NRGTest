using System.Configuration;
using System.Data.SqlClient;

namespace NRGBusiness
{
    public class ConnectionInfo
    {
        private static string _ConnectionString { get; set; }

        public ConnectionInfo(string ConnectionString)
        {
            _ConnectionString = ConnectionString;

        }

        public static SqlConnection Connection
        {
            get
            {
                if(_ConnectionString==null)
                {
                    _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                }
                SqlConnection objConn = new SqlConnection(_ConnectionString);
                return objConn;
            }
        }
    }
}
