using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        

        public int Count => Products.Count;

        public List<IProduct> Products {get;set;}

        public void Add(IProduct product)
        {
            Products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return Products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if(index < Count)
            {
                return Products[index];
            }
            throw new InvalidOperationException();
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            if (Products.Where(x => x.Price == price) == null)
            {
                return new List<IProduct>();
            }
            return Products.Where(x => x.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (Products.Where(x => x.Quantity == quantity) == null)
            {
                return new List<IProduct>();
            }
            return Products.Where(x => x.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInPriceRange(double lo, double hi)
        {
            if(Products.Where(x => x.Price >= lo && x.Price <= hi) == null)
            {
                return new List<IProduct>();
            }
            return Products.Where(x => x.Price >= lo && x.Price <= hi);
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = (IProduct)Products.Where(x => x.Label == label);
            if(product != null)
            {
                return (IProduct)Products.Where(x => x.Label == label);
            }
            throw new ArgumentException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            IProduct product = new Product()
            {
                Label = "Test",
                Price = double.MinValue,
                Quantity = 1,
            };
            foreach (var item in Products)
            {
                if(item.Price > product.Price)
                {
                    product = item;
                }
            }
            return product;

        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            return Products.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)Products;
        }
    }
}
