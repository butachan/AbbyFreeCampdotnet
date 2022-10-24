using AbbyFreeCodeCamp.Data;
using AbbyFreeCodeCamp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyFreeCodeCamp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBcontext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDBcontext db)
        {
            _db = db;
        }

        
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost(Category category)
        {
                var categoryFromDb = _db.Category.Find(category.Id);
                if (categoryFromDb != null)
                {
                    _db.Category.Remove(categoryFromDb); 
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Category Deleted successfully";
                    return RedirectToPage("Index"); //car razor page
                }
            return Page();
        }
    }
}
