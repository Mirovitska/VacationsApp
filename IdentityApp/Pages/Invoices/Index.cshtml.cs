#nullable disable
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
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
     

        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
           
        }

        public IList<Vacations> Vacation { get;set; }

        public async Task OnGetAsync()
        {
           

                var vacations = from i in Context.Vacations
                               select i;

                var isManager = User.IsInRole(Constants.InvoiceManagersRole);
                var isAdmin = User.IsInRole(Constants.InvoiceAdminRole);

                var currentUserId = UserManager.GetUserId(User);

                if (isManager == false && isAdmin == false)
                {
                    vacations = vacations.Where(i => i.CreatorId == currentUserId);
                }



                Vacation = await vacations.ToListAsync();
            
        }
    }
}
