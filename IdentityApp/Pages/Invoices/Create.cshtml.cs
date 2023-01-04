using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Authorization;

namespace IdentityApp.Pages.Invoices
{
    public class CreateModel : DI_BasePageModel
    {

        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            :base(context,authorizationService, userManager)
        {
       
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vacations Vacation { get; set; }
        


        public async Task<IActionResult> OnPostAsync()
        {


            Vacation.CreatorId = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Vacation, InvoiceOperations.Create);

            if (isAuthorized.Succeeded == false)
                return Forbid();

            Context.Vacations.Add(Vacation);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
