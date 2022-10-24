using AbbyFreeCodeCamp.Data;
using AbbyFreeCodeCamp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyFreeCodeCamp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBcontext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDBcontext db)
        {
            _db = db;
        }

        
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            if (Category.Name== Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index"); //car razor page
            }
            return Page();
        }
    }
}
