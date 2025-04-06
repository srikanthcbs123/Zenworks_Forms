using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Zenworks_Forms_BusinessEntities.Utility;
namespace Zenworks_Forms_DBConnectivity
{
    public class ConnectionFactory: IConnectionFactory
    {
        private readonly IConfiguration _config;
        public ConnectionFactory(IConfiguration config)
        {
            _config = config;
        }
        //Don't hard code connecting sting like below.
        //always read the connection string from appsettings.json file
        // string connectionString = "data source=DESKTOP-AAO14OC;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement;integrated security=yes";
        public SqlConnection MidLandSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(Connectionstringname.Midland_DBConnectionstringname).Value);
            //Creates an SqlConnection Object to store the sqlconnection.
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }

        public SqlConnection Northwind_DBSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(Connectionstringname.Northwind_DBConnectionstringname).Value);
            // Creates an SqlConnection Object to store the sqlconnection.
            SqlConnection _connection = new SqlConnection(connStr);
            return _connection;
        }



        public SqlConnection HotelmanagementsqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(Connectionstringname.Hotelmanagement_DBConnectionstringname).Value);
            // Creates an SqlConnection Object to store the sqlconnection.
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }
    }
}
