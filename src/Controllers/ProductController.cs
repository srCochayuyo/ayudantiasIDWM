using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.Data;
using ayudantis1.src.Dtos;
using ayudantis1.src.Interface;
using ayudantis1.src.Mappers;
using ayudantis1.src.models;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ayudantis1.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductsRepository _productRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            _productRepository = productsRepository;
        }

        //metodos http

        //Gets

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await  _productRepository.GetAll();
            var productDto = products.Select(p => p.ToProductDto());
            return Ok(productDto);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepository.GetById(id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        //Post

        [HttpPost]

        public async Task <IActionResult> Post ([FromBody] CreateProductRequestDto productDto)
        {
            var productModel = productDto.ToProductFromCreateDto();
            await _productRepository.Post(productModel);
            return CreatedAtAction(nameof(GetById), new {id = productModel.Id}, productModel.ToProductDto());
        }


        //Put

        [HttpPut("{id}")]

        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProductRequestDto UpdateDto)
        {
            var ProductModel = await _productRepository.Put(id, UpdateDto);
            if(ProductModel == null)
            {
                return NotFound();
            }
        
            return Ok(ProductModel.ToProductDto());
            
        }


        //Delet

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _productRepository.Delete(id);
            if(product == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}