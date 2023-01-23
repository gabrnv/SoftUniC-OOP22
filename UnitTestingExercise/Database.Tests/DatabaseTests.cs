namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Does_Creating_A_Database_Work()
        {
            Database dBase = new Database(new int[] {1,2,3,4,5,6});
            Assert.AreEqual(6, dBase.Count);
        }

        [Test]
        public void Does_Removing_Elements_From_Empty_Array_Not_Work()
        {
            Database dBase = new Database(new int[] {0});
            Assert.DoesNotThrow(() =>
            {
                dBase.Remove();
            });
        }
    }
}
