using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBot.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlName { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
    }
}
