namespace INStock.Contracts
{
    using System.Collections.Generic;

    public interface IProductStock : IEnumerable<IProduct>
    {
        int Count { get; }

        public List<IProduct> Products { get; set; }
        bool Contains(IProduct product);

        void Add(IProduct product);

        bool Remove(IProduct product);

        IProduct Find(int index);

        IProduct FindByLabel(string label);

        IProduct FindMostExpensiveProduct();

        IEnumerable<IProduct> FindAllInPriceRange(double lo, double hi);

        IEnumerable<IProduct> FindAllByPrice(double price);

        IEnumerable<IProduct> FindAllByQuantity(int quantity);
    }
}
