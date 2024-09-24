using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ayudantis1.src.models
{
    public class User
    {
        public int Id { get; set; }

        public string Rut { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        //Entity Framework Relationships
        public List<Product> Products {get;} = [];

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;  
    }
}