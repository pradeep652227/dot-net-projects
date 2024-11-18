namespace BookStoreAPI.Data
{
    public class Books
    {//columns of table
        //by default Id will be Primary key of the table
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
