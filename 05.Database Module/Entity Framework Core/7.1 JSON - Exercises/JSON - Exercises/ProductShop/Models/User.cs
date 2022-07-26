﻿namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        //Place [InverseProperty("Seller")]
        public ICollection<Product> ProductsSold { get; set; }

        //Place [InverseProperty("Buyer")]
        public ICollection<Product> ProductsBought { get; set; }
    }
}