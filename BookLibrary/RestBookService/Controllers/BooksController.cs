using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> cBook = new List<Book>()
        {
            new Book("Winter", "John Smith", 150, "1234567899874"),
            new Book("Autumn", "Lucas J", 200, "7894561239874"),
            new Book("Spring", "Maria Alala", 100, "6547891236547")
        };

        // GET: api/<BooksController>
        [HttpGet]
        public List<Book> Get()
        {
            return cBook;
        }

        // GET api/<BooksController>/5
        [HttpGet("{Isbn13}")]
        public IActionResult Get(string Isbn13)
        {
            Book book = GetBook(Isbn13);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound("ISBN number is not found");
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            cBook.Add(newBook);
            return CreatedAtAction("Get", new { isbn13 = newBook.Isbn13 }, newBook);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string Isbn13, [FromBody] Book newBook)
        {
            if (Isbn13 != newBook.Isbn13)
            {
                return BadRequest();
            }
            Book currentBook = GetBook(Isbn13);

            if (currentBook != null)
            {
                currentBook.Title = newBook.Title;
                currentBook.Author = newBook.Author;
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string Isbn13)
        {
            Book book = GetBook(Isbn13);
            if (book != null)
            {
                cBook.Remove(book);
            }
            else
            {
                return NotFound();
            }
            return Ok(book);
        }

        public Book GetBook(string Isbn13)
        {
            Book book = cBook.FirstOrDefault(e => e.Isbn13 == Isbn13);
            return book;

        }
    }
}
