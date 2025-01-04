using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext context;

        public DeleteModel(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice != null)
            {
                
                context.Invoices.Remove(invoice);
                context.SaveChanges();
            }

            return RedirectToPage("/Invoices/Index");
        }
    }
}