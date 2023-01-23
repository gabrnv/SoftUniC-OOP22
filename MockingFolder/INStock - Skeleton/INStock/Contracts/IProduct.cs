namespace INStock.Contracts
{
    using System;

    public interface IProduct : IComparable<IProduct>
    {
        string Label { get; }

        double Price { get; } 

        int Quantity { get;}
    }
}