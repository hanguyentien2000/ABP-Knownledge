using BookStore.DTOs.Book;
using BookStore.Entities.Book;
using BookStore.Interface;
using BookStore.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookStore;

/* Inherit your application services from this class.
 */
//public abstract class BookStoreAppService : ApplicationService
//{
//    protected BookStoreAppService()
//    {
//        LocalizationResource = typeof(BookStoreResource);
//    }
//}
// BookAppService Service kế thừa CrudAppService => có sẵn API CRUD
public class BookAppService : CrudAppService<
    Book,                      // Entity
    BookDto,                   // DTO trả ra
    Guid,                      // Kiểu Id
    PagedAndSortedResultRequestDto, // Dùng cho paging
    CreateUpdateBookDto>,      // DTO khi create/update
    IBookAppService            // Interface service
{
    public BookAppService(IRepository<Book, Guid> repository) : base(repository)
    {
        // Có thể cấu hình thêm ở đây nếu muốn
    }
}
