using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;

namespace BooksUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TitleLength()
        {
            string Title = "TheAutumn";
            string Author = "James Wiliam";
            double PageNumber = 52;
            string Isbn13 = "1234567891234";

            try
            {
                var Book = new Book(Title, Author, PageNumber, Isbn13);

            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

        }

        [TestMethod]

        public void PageLength()
        {
            string Title = "TheAutumn";
            string Author = "James Wiliam";
            double PageNumber = 52;
            string Isbn13 = "1234567891234";

            try
            {
                var Book = new Book(Title, Author, PageNumber, Isbn13);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ISBN()
        {
            string Title = "TheAutumn";
            string Author = "James Wiliam";
            double PageNumber = 52;
            string Isbn13 = "1234567891234";

            try
            {
                var Book = new Book(Title, Author, PageNumber, Isbn13);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }
    }
}
