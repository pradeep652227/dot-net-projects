using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositries
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int Id);
        Task<int> AddBookAsync(BookModel _bookModel);

        Task<bool> UpdateBookAsync(int bookId, BookModel _bookModel);
        Task<bool> UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);

        Task<bool> DeleteBookAsync(int bookId);
    }
}