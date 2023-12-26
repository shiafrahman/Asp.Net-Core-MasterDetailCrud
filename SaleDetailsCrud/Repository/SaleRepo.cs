using Microsoft.EntityFrameworkCore;
using SaleDetailsCrud.Models.ViewModel;
using SaleDetailsCrud.Models;

namespace SaleDetailsCrud.Repository
{
    public class SaleRepo : ISaleRepo
    {
        private readonly AppDbContext _db;

        public SaleRepo(AppDbContext db)
        {
            _db = db;
        }

        public SaleViewModel Add()
        {
            SaleViewModel viewModel = new SaleViewModel();
            viewModel.SalesDetails.Add(new SalesDetails { SalesDetailsId = 1, });
            return viewModel;
        }

        public void AddSale(SaleViewModel sale)
        {
            SalesMaster c = new SalesMaster();
            c.InvoiceNumber = sale.InvoiceNumber;
            c.CustomerName = sale.CustomerName;
            c.MobileNo = sale.MobileNo;
            c.Address = sale.Address;
            _db.SalesMasters.Add(c);
            _db.SaveChanges();
            var user = _db.SalesMasters.FirstOrDefault(i => i.MobileNo == sale.MobileNo);
            if (user != null)
            {
                if (sale.SalesDetails.Count > 0)
                {
                    foreach (var item in sale.SalesDetails)
                    {
                        SalesDetails e = new SalesDetails();
                        e.SalesMasterId = user.SalesMasterId;
                        e.ProductName = item.ProductName;
                        e.ProductCode = item.ProductCode;
                        e.Price = item.Price;
                        e.Quantity = item.Quantity;
                        _db.Add(e);


                    }


                }
            }
            _db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var sale = _db.SalesMasters.Find(id);
            var pod = _db.SalesDetails.Where(e => e.SalesMasterId == id);
            foreach (var item in pod)
            {
                _db.SalesDetails.Remove(item);
            }

            _db.Entry(sale).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public IEnumerable<SalesMaster> GetAll()
        {
            var sale = _db.SalesMasters.Include(i => i.SalesDetails).ToList();
            return sale;
        }

        public IEnumerable<SalesMaster> Search(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();


            var sale = _db.SalesMasters
                .Where(c => c.SalesMasterId.ToString().Contains(searchTerm)
                    || c.InvoiceNumber.ToLower().Contains(searchTerm)
                    || c.CustomerName.Contains(searchTerm) || c.MobileNo.Contains(searchTerm))
                .Include(c => c.SalesDetails)
                .ToList();

            return sale;
        }

        public decimal CalculateTotalPrice(int saleId)
        {

            decimal totalPrice = _db.SalesDetails
            .Where(p => p.SalesMasterId == saleId)
            .Sum(p => p.Price);

            return totalPrice;
        }


        public SaleViewModel Update(int id)
        {
            SalesMaster cus = _db.SalesMasters.First(x => x.SalesMasterId == id);
            var pod = _db.SalesDetails.Where(x => x.SalesMasterId == id).ToList();


            if (cus != null)
            {
                SaleViewModel cusVM = new SaleViewModel()
                {
                    SalesMasterId = cus.SalesMasterId,
                    InvoiceNumber = cus.InvoiceNumber,
                    CustomerName = cus.CustomerName,
                    MobileNo = cus.MobileNo,
                    Address = cus.Address,

                };
                if (pod.Count() > 0)
                {
                    foreach (var item in pod)
                    {
                        SalesDetails obj = new SalesDetails();
                        obj.SalesMasterId = cus.SalesMasterId;
                        obj.ProductName = item.ProductName;
                        obj.ProductCode = item.ProductCode;
                        obj.Price = item.Price;
                        obj.Quantity = item.Quantity;
                        cusVM.SalesDetails.Add(obj);
                    }
                }
                return cusVM;
            }
            return null;
        }

        public void UpdateSale(SaleViewModel cus)
        {
            var existingCustomer = _db.SalesMasters.FirstOrDefault(a => a.SalesMasterId == cus.SalesMasterId);
            if (existingCustomer != null)
            {
                existingCustomer.InvoiceNumber = cus.InvoiceNumber;
                existingCustomer.CustomerName = cus.CustomerName;
                existingCustomer.MobileNo = cus.MobileNo;
                existingCustomer.Address = cus.Address;

                var existingProduct = _db.SalesDetails.Where(e => e.SalesMasterId == cus.SalesMasterId);
                _db.SalesDetails.RemoveRange(existingProduct);

                if (cus.SalesDetails != null && cus.SalesDetails.Count > 0)
                {
                    foreach (var result in cus.SalesDetails)
                    {
                        existingCustomer.SalesDetails.Add(new SalesDetails
                        {
                            ProductName = result.ProductName,
                            ProductCode = result.ProductCode,
                            Price = result.Price,
                            Quantity = result.Quantity,
                        });
                    }
                }

                _db.SaveChanges();
            }
        }
    }
}
