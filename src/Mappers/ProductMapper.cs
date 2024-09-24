using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.Dtos;
using ayudantis1.src.models;

namespace ayudantis1.src.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                id = productModel.Id,
                Name = productModel.Name,
                Price = productModel.Price
            };        
        }


        public static Product ToProductFromCreateDto(this CreateProductRequestDto createProductRequestDto)
        {
            return new Product
            {
                Name = createProductRequestDto.Name,
                Price = createProductRequestDto.Price
            };
        }


    }

}