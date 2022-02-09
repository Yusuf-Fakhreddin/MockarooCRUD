﻿using MockarooCRUD.Models;

namespace MockarooCRUD.Services
{
    interface IProductDataService
    {
        List<ProductModel> GetAllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProduductById(int id);
        int Insert(ProductModel product);
        int Delete(ProductModel product);
        int Update(ProductModel product);
    }
}
