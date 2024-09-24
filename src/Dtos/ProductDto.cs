using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ayudantis1.src.Dtos
{
    public class ProductDto
    {
       public int id {get; set;}
       public string Name { get; set; } = string.Empty;

        public int Price { get; set; }   
    }
}