using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Models;

namespace Zenworks_Forms_BusinessEntities.Interfaces
{
    public  interface IOrderRepository
    {
        Task<bool> AddOrder(Order Objord);
        Task<bool> UpdateOrder(Order Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<Order>> GetallOrders();
        Task<Order> GetOrderById(int Id);
    }
}
