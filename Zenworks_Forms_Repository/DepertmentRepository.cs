using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Interfaces;
using Zenworks_Forms_BusinessEntities.Models;
using Zenworks_Forms_BusinessEntities.Utility;
using Zenworks_Forms_DBConnectivity;

namespace Zenworks_Forms_Repository
{
    public  class DepertmentRepository: IDepertmentRepository
    {
        //DON'T HARD CODE THE CONNECTION STRING LIKE THIS WAY.
        //string connectionString = "data source=RAYUDU\\SQLEXPRESS;integrated security=yes;Encrypt=True;TrustServerCertificate=True;initial catalog=Northwind_DB";


        private readonly IConnectionFactory _connectionFactory;
        public DepertmentRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> AddDepartment(Department Dept)
        {
            //READ THE CONNECTION STRING FROM CONNECTION FACTORY...
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, Dept.DepartmentName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, Dept.DepartmentLocation);
              // cmd.Parameters.AddWithValue("@insertedvalue", DbType.Int32, direction: ParameterDirection.Output);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
            }
            return true;
        }

        public async Task<bool> DeleteDepartment(int deptId)
        {

            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, deptId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;

        }

        public async Task<List<Department>> GetAllDepartments()
        {
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                List<Department> lstdep = new List<Department>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    Department dep = new Department();
                    dep.DepartmentId = Convert.ToInt16(row["deptid"]);
                    dep.DepartmentName = Convert.ToString(row["deptname"]);
                    dep.DepartmentLocation = Convert.ToString(row["deptlocation"]);
                    lstdep.Add(dep);
                }
                return lstdep;
            }
        }

        public async Task<Department> GetDepartmentById(int DepartmentId)
        {
            Department dep = new Department();
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartmentByDeptId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, DepartmentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    dep.DepartmentId = Convert.ToInt16(row["deptid"]);
                    dep.DepartmentName = Convert.ToString(row["deptname"]);
                    dep.DepartmentLocation = Convert.ToString(row["deptlocation"]);
                }
            }
            return dep;
        }



        public async Task<bool> UpdateDepartment(Department Dept)
        {

            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, Dept.DepartmentId);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, Dept.DepartmentName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, Dept.DepartmentLocation);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
            }
            return true;
        }
    }
}
