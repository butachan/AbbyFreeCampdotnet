using AbbyFreeCodeCamp.Data;
using AbbyFreeCodeCamp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyFreeCodeCamp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBcontext _db;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDBcontext db)
        {
            _db = db;
        }

        
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.First(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u=>u.Id==id);
            //Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            if (Category.Name== Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                 _db.Category.Update(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index"); //car razor page
            }
            return Page();
        }
    }
}
