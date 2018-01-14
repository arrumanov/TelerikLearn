using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class AppCustomers
    {
        public AppCustomers()
        {
            AppOrders = new HashSet<AppOrders>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<AppOrders> AppOrders { get; set; }
    }
}
