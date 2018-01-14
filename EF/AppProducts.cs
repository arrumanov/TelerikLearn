using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class AppProducts
    {
        public AppProducts()
        {
            AppOrderDetails = new HashSet<AppOrderDetails>();
            InverseParent = new HashSet<AppProducts>();
        }

        public int Id { get; set; }
        public decimal BuyingPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public bool IsDiscontinued { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal SellingPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public AppProducts Parent { get; set; }
        public AppProductCategories ProductCategory { get; set; }
        public ICollection<AppOrderDetails> AppOrderDetails { get; set; }
        public ICollection<AppProducts> InverseParent { get; set; }
    }
}
