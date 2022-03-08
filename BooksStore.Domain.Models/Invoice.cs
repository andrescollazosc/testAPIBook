namespace BooksStore.Domain.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string? Invoice1 { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
    }
}
