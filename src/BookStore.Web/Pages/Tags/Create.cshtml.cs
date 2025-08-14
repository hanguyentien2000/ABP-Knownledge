using BookStore.DTOs.Tag;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookStore.Web.Pages.Tags
{
    public class CreateModel : PageModel
    {
        private readonly ITagAppService _tagAppService;

        [BindProperty]
        public CreateUpdateTagDto Tag { get; set; } = new();

        public CreateModel(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _tagAppService.CreateAsync(Tag);
            return RedirectToPage("Index");
        }
    }
}
