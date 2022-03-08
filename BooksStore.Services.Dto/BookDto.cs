namespace BooksStore.Services.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }
    }
}
