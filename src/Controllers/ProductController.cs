using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.Data;
using ayudantis1.src.Dtos;
using ayudantis1.src.Mappers;
using ayudantis1.src.models;
using Microsoft.AspNetCore.Mvc;

namespace ayudantis1.src.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        //metodos http

        //Gets

        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList().Select(p => p.ToProductDto());
            return Ok(products);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        //Post

        [HttpPost]

        public IActionResult Post ([FromBody] CreateProductRequestDto productDto)
        {
            var productModel = productDto.ToProductFromCreateDto();
            _context.Products.Add(productModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = productModel.Id}, productModel.ToProductDto());
        }


        //Put

        [HttpPut("{id}")]

        public IActionResult Put([FromRoute] int id, [FromBody] UpdateProductRequestDto UpdateDto)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if(existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = UpdateDto.Name;
            existingProduct.Price = UpdateDto.Price;
            _context.SaveChanges();
            return Ok(existingProduct);
            
        }


        //Delet

        [HttpDelete("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

    }
}