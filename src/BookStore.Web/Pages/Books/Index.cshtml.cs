using BookStore.DTOs.Book;
using BookStore.Entities;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.Web.Pages.Books;

public class IndexModel : PageModel
{
    private readonly IBookAppService _bookAppService;

    public List<BookDto> Books { get; set; }

    public IndexModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public async Task OnGetAsync()
    {
        var result = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        Books = result.Items as List<BookDto>;
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _bookAppService.DeleteAsync(id);
        return RedirectToPage("./Index");
    }
}