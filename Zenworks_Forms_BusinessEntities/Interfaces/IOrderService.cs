using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Dtos;

namespace Zenworks_Forms_BusinessEntities.Interfaces
{
    public interface IOrderService
    {
        Task<bool> AddOrder(OrderDto Objord);
        Task<bool> UpdateOrder(OrderDto Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<OrderDto>> GetallOrders();
        Task<OrderDto> GetOrderById(int Id);
    }
}
