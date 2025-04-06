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

namespace Zenworks_Forms_Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public EmployeeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddEmployes(Employee empdetail)
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeName, empdetail.empname);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeSalary, empdetail.empsalary);
                SqlParameter outputParam = new SqlParameter(StoredprocedureParameters.Insertedvariable, SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
                var employeeCount = (int)cmd.Parameters[StoredprocedureParameters.Insertedvariable].Value;
                return employeeCount;
            }
            // return true;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeID, empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;
        }

        public async Task<Employee> GetEmployeeById(int empid)
        {
            Employee emp = new Employee();
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetEmployeeByEmpid, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeID, empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    emp.empid = Convert.ToInt16(row["empid"]);
                    emp.empname = Convert.ToString(row["empname"]);
                    emp.empsalary = Convert.ToInt32(row["empsalary"]);
                }
            }
            return emp;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                List<Employee> lstemp = new List<Employee>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Employee");
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    Employee Emp = new Employee();
                    Emp.empid = Convert.ToInt16(row["empid"]);
                    Emp.empname = Convert.ToString(row["empname"]);
                    Emp.empsalary = Convert.ToInt32(row["empsalary"]);
                    lstemp.Add(Emp);
                }
                return lstemp;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeID, empdetail.empid);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeName, empdetail.empname);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeSalary, empdetail.empsalary);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");

                return true;
            }
        }
    }
}
