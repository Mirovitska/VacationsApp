using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Authorization;

namespace IdentityApp.Pages.Invoices
{
    public class DetailsModel : DI_BasePageModel
    {
      

        public DetailsModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
            
        }

      public Vacations Vacations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vacations = await Context.Vacations.FirstOrDefaultAsync(m => m.VacationsId == id);
            if (Vacations == null)
            {
                return NotFound();
            }

            var isCreator = await AuthorizationService.AuthorizeAsync(
                User, Vacations, InvoiceOperations.Read);

            var isManager = User.IsInRole(Constants.InvoiceManagersRole);

            var isAdmin = User.IsInRole(Constants.InvoiceAdminRole);

            if (isCreator.Succeeded == false && isManager == false)
                return Forbid();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id, VacationsStatus status)
        {

            Vacations = await Context.Vacations.FindAsync(id);

            if (Vacations == null)
                return NotFound();


            var invoiceOperation = status == VacationsStatus.Approved
                ? InvoiceOperations.Approve
                : InvoiceOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Vacations, invoiceOperation);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            Vacations.Status = status;
            Context.Vacations.Update(Vacations);

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
