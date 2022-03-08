namespace BooksStore.Domain.Models
{
    public partial class Book
    {
        public Book()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
