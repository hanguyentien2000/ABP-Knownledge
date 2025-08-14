using BookStore.DTOs.Tag;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BookStore.Web.Pages.Tags
{
    public class EditModel : PageModel
    {
        private readonly ITagAppService _tagAppService;

        [BindProperty]
        public CreateUpdateTagDto Tag { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public EditModel(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public async Task OnGetAsync()
        {
            var dto = await _tagAppService.GetAsync(Id);
            Tag = new CreateUpdateTagDto
            {
                Name = dto.Name,
                TagType = dto.TagType
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _tagAppService.UpdateAsync(Id, Tag);
            return RedirectToPage("Index");
        }
    }
}
