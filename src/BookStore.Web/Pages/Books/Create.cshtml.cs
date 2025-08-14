using BookStore.DTOs.Book;
using BookStore.Entities;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookStore.Web.Pages.Books;

public class CreateModel : PageModel
{
    private readonly IBookAppService _bookAppService;

    [BindProperty]
    public CreateUpdateBookDto Book { get; set; }

    public CreateModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _bookAppService.CreateAsync(Book);
        return RedirectToPage("./Index");
    }
}