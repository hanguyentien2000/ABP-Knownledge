using BookStore.DTOs.Book;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Interface
{
    public interface IBookAppService :
        ICrudAppService< // Tự động tạo API CRUD
            BookDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto>
    {
    }
}
