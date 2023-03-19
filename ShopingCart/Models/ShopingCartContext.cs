using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopingCart.Models
{
    public class ShopingCartContext : DbContext
    {
        
    
        public ShopingCartContext() : base("name=ShopingCartContext")
        {
        }

        public System.Data.Entity.DbSet<Model.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Model.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Model.Slider> Sliders { get; set; }
    }
}
