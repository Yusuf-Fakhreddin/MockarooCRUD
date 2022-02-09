using MockarooCRUD.Models;
using System.Data.SqlClient;

namespace MockarooCRUD.Services
{
    public class ProductsDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT* FROM dbo.Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        foundProducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)
                           reader[2],
                            Description = (string)reader[3]
                        });

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProducts;
        }

        public ProductModel GetProduductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement= "SELECT * FROM dbo.Products WHERE Name LIKE @Name";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        foundProducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)
                           reader[2],
                            Description = (string)reader[3]
                        });

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
