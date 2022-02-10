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

        public IActionResult ShowDetails(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Create()
        {
            return View("CreateForm");
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }




        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("EditForm", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products =new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int Id)
        { 
            ProductsDAO products=new ProductsDAO();
            ProductModel product =products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
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
