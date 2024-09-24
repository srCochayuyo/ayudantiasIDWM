using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ayudantis1.src.models
{
    public class Product
    {
          public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        //Entity Framework relationships

         public List<User> Users { get;} = [];
    }
}