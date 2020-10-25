using System;

namespace BookLibrary
{
    /// <summary>
    /// Class Library
    /// </summary>
    public class Book
    {
        /// <summary>
        /// properties
        /// </summary>
        private string _title;
        private string _author;
        private double _pageNumber;
        private string _isbn13;
        /// <summary>
        /// Conctructor of the Book class
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="PageNumber"></param>
        /// <param name="Isbn13"></param>
        public Book(string Title, string Author, double PageNumber, string Isbn13)
        {
            _title = Title;
            _author = Author;
            _pageNumber = PageNumber;
            _isbn13 = Isbn13;
        }

        public Book()
        {
        }

        /// <summary>
        /// Getter and setter of Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { Title = value; }

        }
        /// <summary>
        /// Method of checking if the TitleLength is correct
        /// </summary>
        /// <returns></returns>
        public string TitleLength(string Title)
        {
            if (Title.Length >= 2)
            {
                Console.WriteLine(Title);
            }
            else
            {
                throw new ArgumentException("The Title has to be minimum 2 characters long");
            }
            return Title;
        }
        /// <summary>
        /// Getter and setter of Author
        /// </summary>

        public string Author
        {
            get { return _author; }
            set { Author = value; }
        }
        /// <summary>
        /// Getter and setter of PageNumber
        /// </summary>
        public double PageNumber
        {
            get { return _pageNumber; }
            set { PageNumber = value; }
        }
        /// <summary>
        /// Checking if PageNumberLength matches the requirements
        /// </summary>
        /// <returns></returns>
        public double PageNumberLength(double PageNumber)
        {
            if (PageNumber > 10 || PageNumber <= 1000)
            {
                this.PageNumber = PageNumber;
            }
            else
            {
                throw new ArgumentException("Page number has to be in between 10 and 1000 pages");
            }
            return PageNumber;
        }
        /// <summary>
        /// Getter and setter of Isbn13
        /// </summary>

        public string Isbn13
        {
            get { return _isbn13; }
            set { Isbn13 = value; }
        }
        /// <summary>
        /// Method to check if Isbn13 is exactly 13 characters long
        /// </summary>
        /// <returns></returns>
        public string Isbn13CheckLength(string Isbn13)
        {

            if (Isbn13.Length != 13)
            {
                throw new NotImplementedException("The number has to be 13 characters Long");
            }
            else
            {
                return Isbn13;
            }

        }
    }
}
