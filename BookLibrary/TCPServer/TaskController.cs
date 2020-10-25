using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using Newtonsoft.Json;

namespace TCPServer
{
    class TaskController
    {
        private const string BooksUri = "https://localhost:44354/api/Books";

        public TaskController() { }

        public static async Task<IList<Book>> GetBookAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(BooksUri);
                IList<Book> cList = JsonConvert.DeserializeObject<IList<Book>>(content);
                return cList;
            }
        }

        public static async Task<Book> GetOneBookAsync(string Isbn13)
        {
            string requestUri = BooksUri + "/" + Isbn13;
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(requestUri);
                Book c = JsonConvert.DeserializeObject<Book>(content);
                return c;
            }
        }

        public static async Task<Book> GetOneBookAsync1(string Isbn13)
        {
            string requestUri = BooksUri + "/" + Isbn13;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Book not found");

                }
                response.EnsureSuccessStatusCode();
                string str = await response.Content.ReadAsStringAsync();
                Book c = JsonConvert.DeserializeObject<Book>(str);
                return c;
            }
        }

        public static async Task<Book> AddBookAsync(Book newBook)
        {
            using (HttpClient client = new HttpClient())
            {

                var jsonString = JsonConvert.SerializeObject(newBook);
                Console.WriteLine("JSON: " + jsonString);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(BooksUri, content);
                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    throw new Exception("Book already exists");
                }
                response.EnsureSuccessStatusCode();
                string str = await response.Content.ReadAsStringAsync();
                Book copyOfNewBook = JsonConvert.DeserializeObject<Book>(str);
                return copyOfNewBook;
            }

        }
    }
}
