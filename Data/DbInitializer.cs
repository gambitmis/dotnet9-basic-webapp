using InvoiceApp.Models;
using InvoiceApp.Services;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        // Create database if it doesn't exist
        context.Database.EnsureCreated();

        // Check if there's already data
        if (context.Invoices.Any())
        {
            return; // Database has been seeded
        }

        // Add sample data
        var invoices = new Invoice[]
        {
            new Invoice
            {
                Number = "INV-2025-001",
                Status = "Paid",
                IssueDate = DateOnly.FromDateTime(DateTime.Now),
                DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)),
                Service = "Web Development",
                UnitPrice = 150.00M,
                Quantity = 40,
                ClientName = "John Smith",
                Email = "john.smith@email.com",
                Phone = "555-0101",
                Address = "123 Main St, Boston, MA 02108"
            },
            new Invoice
            {
                Number = "INV-2025-002",
                Status = "Pending",
                IssueDate = DateOnly.FromDateTime(DateTime.Now),
                DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)),
                Service = "Cloud Hosting",
                UnitPrice = 299.99M,
                Quantity = 1,
                ClientName = "Sarah Johnson",
                Email = "sarah.j@email.com",
                Phone = "555-0102",
                Address = "456 Oak Ave, Seattle, WA 98101"
            }
            // Add more sample invoices as needed
        };

        context.Invoices.AddRange(invoices);
        context.SaveChanges();
    }
}