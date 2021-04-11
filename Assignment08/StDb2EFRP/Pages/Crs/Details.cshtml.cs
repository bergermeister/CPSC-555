using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Crs
{
    public class DetailsModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public DetailsModel(StDb2EFRP.Models.StDb2SqlContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseNum == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
