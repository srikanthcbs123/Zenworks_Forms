using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Interfaces;
using Zenworks_Forms_BusinessEntities.Models;
using Zenworks_Forms_BusinessEntities.Utility;

namespace Zenworks_Forms_Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AddOrder(Order Objord)
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderName, Objord.OrderName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderLocation, Objord.OrderLocation);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                Da.Fill(dataSet, "Order");

            }
            return true;
        }

        public async Task<bool> DeleteOrder(int OrderId)
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteOrder, con);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderId, OrderId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);

            }
            return true;
        }

        public async Task<List<Order>> GetallOrders()
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                List<Order> orderslist = new List<Order>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Orders");
                foreach (DataRow row in ds.Tables["Orders"].Rows)
                {
                    Order ord = new Order();
                    ord.OrderId = Convert.ToInt16(row["OrderId"]);
                    ord.OrderName = Convert.ToString(row["OrderName"]);
                    ord.OrderLocation = Convert.ToString(row["OrderLocation"]);
                    orderslist.Add(ord);

                }
                return orderslist;



            }
        }

        public async Task<Order> GetOrderById(int Id)
        {
            Order or = new Order();
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetOrderByOrderId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderId, Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Order");
                Order ord = new Order();
                foreach (DataRow row in ds.Tables["Order"].Rows)
                {
                    
                    ord.OrderId = Convert.ToInt16(row["OrderId"]);
                    ord.OrderName = Convert.ToString(row["OrderName"]);
                    ord.OrderLocation = Convert.ToString(row["OrderLocation"]);


                }
                return ord;


            }
        }

        public async Task<bool> UpdateOrder(Order Objord)
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderId, Objord.OrderId);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderName, Objord.OrderName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderLocation, Objord.OrderLocation);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                Da.Fill(dataSet, "Order");

            }
            return true;
        }
    }
}
