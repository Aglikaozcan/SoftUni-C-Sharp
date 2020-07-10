using System;

namespace P04.ShoppingSpree
{    
    public class Product
    {
        private string productName;
        private decimal cost;

        public Product(string productName, decimal cost)
        {
            this.productName = productName;
            this.cost = cost;
        }

        public string ProductName
        {
            get => this.productName;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.productName = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }
    }
}
