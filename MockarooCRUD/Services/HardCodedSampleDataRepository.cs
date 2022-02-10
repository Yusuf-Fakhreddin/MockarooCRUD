﻿using Bogus;
using MockarooCRUD.Models;

namespace MockarooCRUD.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        // static list that is the same every time this is run
        static List<ProductModel> productsList = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if(productsList.Count == 0)
            {
                productsList.Add(new ProductModel { Id = 1, Name = "House Pad", Price = 5.99m, Description = "A square piece of plastic to make mousing easier" });
                productsList.Add(new ProductModel { Id = 2, Name = "Web Can", Price = 45.5m, Description = "Enables you to attend more Zoom meetings." });
                productsList.Add(new ProductModel { Id = 3, Name = "4 TB USB hard drive", Price = 130.00m, Description = "Backup all of your work. You won't regret it." });
                productsList.Add(new ProductModel { Id = 4, Name = "Mireless Mouse", Price = 15.99m, Description = "Notebook mice don't work very well, do they?" });

                for (int i = 0; i < 100; i++)
                {
                    productsList.Add(new Faker<ProductModel>()
                     .RuleFor(p => p.Id, i + 5)
                     .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                     .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                     .RuleFor(p => p.Description, f => f.Rant.Review()));
                }
            }
 
            return productsList;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
