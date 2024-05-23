using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.DTOs.Orders
{
    public class OrderHistoryDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDTO> Items { get; set; } = [];
        public double TotalPrice { get; set; }

    }
}
