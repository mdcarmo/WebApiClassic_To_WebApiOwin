using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiToken.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int QuantityInStock { get; set; }
    }
}