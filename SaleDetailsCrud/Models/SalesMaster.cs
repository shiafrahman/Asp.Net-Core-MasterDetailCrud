using System.ComponentModel.DataAnnotations;

namespace SaleDetailsCrud.Models
{
    public class SalesMaster
    {
        [Key]
        public int SalesMasterId { get; set; }
        [Required]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public int SalesDetailsId { get; set; }
        public virtual IList<SalesDetails> SalesDetails { get; set; } = new List<SalesDetails>();
    }
}
