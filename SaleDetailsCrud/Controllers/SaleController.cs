using Microsoft.AspNetCore.Mvc;
using SaleDetailsCrud.Models.ViewModel;
using SaleDetailsCrud.Repository;

namespace SaleDetailsCrud.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepo _saleRepo;

        public SaleController(ISaleRepo saleRepo)
        {
            _saleRepo = saleRepo;
        }

        public IActionResult Index()
        {
            var s = _saleRepo.GetAll();
            return View(s);
        }

        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {

                return RedirectToAction("Index");
            }

            var searchResults = _saleRepo.Search(searchTerm);

            return View("Index", searchResults);
        }

        public IActionResult Create()
        {
            SaleViewModel d = _saleRepo.Add();
            return View(d);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SaleViewModel cus)
        {

            _saleRepo.AddSale(cus);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SaleViewModel d = _saleRepo.Update(id);
            return View("Edit", d);
        }
        [HttpPost]
        public IActionResult Edit(SaleViewModel cus)
        {
            _saleRepo.UpdateSale(cus);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _saleRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            SaleViewModel customer = _saleRepo.Update(id);

            if (customer != null)
            {
                return View(customer);
            }

            return NotFound();
        }

        public IActionResult TotalPrice(int saleId)
        {
            decimal totalPrice = _saleRepo.CalculateTotalPrice(saleId);
            return View(totalPrice);
        }


    }
}
