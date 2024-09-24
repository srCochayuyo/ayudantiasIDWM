using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.Data;
using ayudantis1.src.Dtos;
using ayudantis1.src.Interface;
using ayudantis1.src.models;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

namespace ayudantis1.src.Repository
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Product?> Delete(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(productModel == null)
            {
                throw new Exception("Product not foun");
            }
            _context.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;

        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Post(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> Put(int id, UpdateProductRequestDto productDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if(productModel == null)
            {
                throw new Exception("Product not foun");
            }


            productModel.Name = productDto.Name;
            productModel.Price = productDto.Price;

            await _context.SaveChangesAsync();
            return productModel;
        }
    }
}