using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class BookStoreContext:DbContext//inherit DbContext class
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)//provide options
        {

        }

        public DbSet<Books> Books { get; set; }//create class for entity framework to create corresponding table
    }
}
