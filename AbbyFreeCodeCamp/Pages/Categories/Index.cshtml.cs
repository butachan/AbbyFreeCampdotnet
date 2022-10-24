using AbbyFreeCodeCamp.Data;
using AbbyFreeCodeCamp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyFreeCodeCamp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBcontext _db;
        public IEnumerable<Category> Categories { get; set; }
         public IndexModel(ApplicationDBcontext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
