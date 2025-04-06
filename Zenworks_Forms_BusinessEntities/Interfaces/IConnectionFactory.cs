using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenworks_Forms_BusinessEntities.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection MidLandSqlConnectionString();
        SqlConnection Northwind_DBSqlConnectionString();
        SqlConnection HotelmanagementsqlConnectionString();

    }
}
