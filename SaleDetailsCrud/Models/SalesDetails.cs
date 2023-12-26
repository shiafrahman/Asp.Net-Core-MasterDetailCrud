using System.ComponentModel.DataAnnotations;

namespace SaleDetailsCrud.Models
{
    public class SalesDetails
    {
        public int SalesDetailsId { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SalesMasterId { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
    }
}