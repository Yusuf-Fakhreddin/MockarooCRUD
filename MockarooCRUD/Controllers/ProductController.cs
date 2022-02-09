using Microsoft.AspNetCore.Mvc;
using MockarooCRUD.Models;
using MockarooCRUD.Services;

namespace MockarooCRUD.Controllers
{
    public class ProductController : Controller
    {
        // /product
        public IActionResult Index()
        {
            //HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();
            // return View(hardCodedSampleDataRepository.GetAllProducts());

            ProductsDAO products =new ProductsDAO();
            return View(products.GetAllProducts());

        }

        // /product/searchResults?searchTerm= 
        public IActionResult SearchResults(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View("Index", productList); 
        }

        // /product/searchform
        public IActionResult SearchForm()
        {
            return View();
        }


        public IActionResult Message()
        {
            return View("message"); 
        }

        public IActionResult Welcome(string name, int secretNumber = 13)
        {
            ViewBag.Name = name;
            ViewBag.Secret = secretNumber;
            return View();
        }

    } }
