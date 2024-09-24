using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.Dtos;
using ayudantis1.src.models;

namespace ayudantis1.src.Interface
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAll();

        Task<Product?> GetById(int id);

        Task<Product> Post(Product product);

        Task<Product?> Put(int id, UpdateProductRequestDto productDto);

        Task<Product?> Delete(int id);
    }
}