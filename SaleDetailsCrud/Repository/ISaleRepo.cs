using SaleDetailsCrud.Models.ViewModel;
using SaleDetailsCrud.Models;

namespace SaleDetailsCrud.Repository
{
    public interface ISaleRepo
    {
        IEnumerable<SalesMaster> GetAll();
        IEnumerable<SalesMaster> Search(string searchTerm);
        public decimal CalculateTotalPrice(int saleId);
        SaleViewModel Add();
        void AddSale(SaleViewModel sale);
        SaleViewModel Update(int id);
        void UpdateSale(SaleViewModel cus);
        void Delete(int? id);
    }
}
