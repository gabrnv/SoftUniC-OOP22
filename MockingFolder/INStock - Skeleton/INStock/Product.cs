using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo([AllowNull] IProduct other)
        {
            return this.CompareTo((Product)other);
        }
    }
}
