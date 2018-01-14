using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class AppOrderDetails
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Discount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public AppOrders Order { get; set; }
        public AppProducts Product { get; set; }
    }
}
