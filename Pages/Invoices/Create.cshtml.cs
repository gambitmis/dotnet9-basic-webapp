using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext context;

        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new();

        public CreateModel(AppDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error");
                return Page();
            }
            Console.WriteLine("pass");
            var invoice = new Invoice
            {
                Number = InvoiceDto.Number,
                Status = InvoiceDto.Status,
                IssueDate = InvoiceDto.IssueDate,
                DueDate = InvoiceDto.DueDate,

                Service = InvoiceDto.Service,
                UnitPrice = InvoiceDto.UnitPrice,
                Quantity = InvoiceDto.Quantity,

                ClientName = InvoiceDto.ClientName,
                Email = InvoiceDto.Email,
                Phone = InvoiceDto.Phone,
                Address = InvoiceDto.Address,
            };

            context.Invoices.Add(invoice);
            context.SaveChanges();

            return RedirectToPage("/Invoices/Index");
        }
    }
}
