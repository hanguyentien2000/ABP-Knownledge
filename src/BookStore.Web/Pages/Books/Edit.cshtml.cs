using BookStore.DTOs.Book;
using BookStore.Entities;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BookStore.Web.Pages.Books;

public class EditModel : PageModel
{
    /// <summary>
    /// Tất cả gọi API từ BookAppService qua dependency injection, không viết controller thủ công.
    /// </summary>
    private readonly IBookAppService _bookAppService;

    [BindProperty]
    public CreateUpdateBookDto Book { get; set; }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public EditModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public async Task OnGetAsync()
    {
        var bookDto = await _bookAppService.GetAsync(Id);
        Book = new CreateUpdateBookDto
        {
            Name = bookDto.Name,
            Price = bookDto.Price
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) 
            return Page();

        await _bookAppService.UpdateAsync(Id, Book);
        return RedirectToPage("./Index");
    }
}