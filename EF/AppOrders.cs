using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class AppOrders
    {
        public AppOrders()
        {
            AppOrderDetails = new HashSet<AppOrderDetails>();
        }

        public int Id { get; set; }
        public string CashierId { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public decimal Discount { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public AspNetUsers Cashier { get; set; }
        public AppCustomers Customer { get; set; }
        public ICollection<AppOrderDetails> AppOrderDetails { get; set; }
    }
}
