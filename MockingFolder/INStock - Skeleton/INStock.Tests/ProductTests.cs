namespace INStock.Tests
{
    using NUnit.Framework;
    using INStock.Contracts;

    public class ProductTests
    {
        [Test]
        public void TestCreatingAProductGivesItAllTheValues()
        {
            IProduct product = new Product()
            {
                Label = "Macbook",
                Quantity = 1,
                Price = 2000
            };
            Assert.AreEqual("Macbook", product.Label);
            Assert.AreEqual(1, product.Quantity);
            Assert.AreEqual(2000, product.Price);
        }
    }
}