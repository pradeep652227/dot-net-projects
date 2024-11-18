using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositries
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookContext;

        public BookRepository(BookStoreContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _bookContext.Books.Select(book => new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description
            }).ToListAsync();

            return records;
        }

        public async Task<BookModel> GetBookByIdAsync(int Id)
        {
            var record = await _bookContext.Books.Where(book=>book.Id== Id).Select(book=>new BookModel()
            {
                Id=book.Id,
                Title=book.Title,
                Description=book.Description
            }
            ).FirstOrDefaultAsync();

            return record;
        }

        public async Task<int> AddBookAsync(BookModel _bookModel)
        {   //create a new instance of Books class or Books table
            var book = new Books()
            {
                Title = _bookModel.Title,
                Description = _bookModel.Description,
            };
            //Id will be automatically generated from the db
            _bookContext.Books.Add(book);
           await _bookContext.SaveChangesAsync();

            return book.Id;
        }
    
        public async Task<bool> UpdateBookAsync(int bookId,BookModel _bookModel)
        {
            //  var book = await _bookContext.Books.FindAsync(bookId);

            //  if (book == null)
            //      return false;
            // book.Title = _bookModel.Title;  
            //book.Description = _bookModel.Description;
            try
            {
                    var book = new Books()
                    {
                        Id = bookId,
                        Title = _bookModel.Title,
                        Description = _bookModel.Description,
                    };
            
                    _bookContext.Books.Update(book);
          
                        
                    await _bookContext.SaveChangesAsync();
                    return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> UpdateBookPatchAsync(int bookId,JsonPatchDocument bookModel)
        {
            var book = _bookContext.Books.Find(bookId);
            if (book == null)
                return false;

            bookModel.ApplyTo(book);
            await _bookContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            try
            {
                var book = new Books() { Id = bookId };
                _bookContext.Books.Remove(book);
                await _bookContext.SaveChangesAsync();

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
