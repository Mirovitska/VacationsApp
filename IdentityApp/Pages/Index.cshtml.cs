using IdentityApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, int> vacationsSubmitted;
        public Dictionary<string, int> vacationsApproved;
        public Dictionary<string, int> vacationsRejected;

        private readonly ILogger<IndexModel> _logger;

        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            InitDict(ref vacationsSubmitted);
            InitDict(ref vacationsApproved);
            InitDict(ref vacationsRejected);

            var vacations = _context.Vacations.ToList();

            foreach (var vacation in vacations)
            {

                switch (vacation.Status)
                {
                    case VacationsStatus.Submitted:
                        vacationsSubmitted[vacation.VacationsMonth] = (int)vacation.CountOfVacationsDay;
                        break;
                    case VacationsStatus.Approved:
                        vacationsApproved[vacation.VacationsMonth] = (int)vacation.CountOfVacationsDay;
                        break;
                    case VacationsStatus.Rejected:
                        vacationsRejected[vacation.VacationsMonth] = (int)vacation.CountOfVacationsDay;
                        break;
                    default:
                        break;
                }
            }

        }

        private void InitDict(ref Dictionary<string, int> dict)
        {
            dict = new Dictionary<string, int>()
           
            {
                { "January",0 },
                { "February",0 },
                { "March",0 },
                { "April",0 },
                { "May",0 },
                { "June",0 },
                { "July",0 },
                { "August",0 },
                { "September",0 },

                { "October",0 },
                { "November",0 },
                { "December",0 }
            };
        }
    }
}