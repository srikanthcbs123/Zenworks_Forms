using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenworks_Forms_BusinessEntities.Models
{
    public  class Order
    {
        public int OrderId { get; set; }
        public string OrderName { set; get; }
        public string OrderLocation { set; get; }
    }
}
