using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public List<Invoice> InvoiceList = new();

        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            InvoiceList = context.Invoices.OrderByDescending(i => i.Id).ToList();
        }
    }
}
