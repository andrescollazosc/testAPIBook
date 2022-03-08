namespace BooksStore.Domain.Models
{
    public partial class Client
    {
        public Client()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
