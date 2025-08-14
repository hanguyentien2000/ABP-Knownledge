using BookStore.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Interface
{
    public interface ITagAppService :
        ICrudAppService< // ABP tự sinh Create/Update/Delete/Get/GetList
            TagDto,       // DTO để trả ra
            Guid,         // Kiểu khóa chính
            TagPagedAndSortedResultRequestDto, // DTO cho paging
            CreateUpdateTagDto>             // DTO khi create/update
    {

    }
}
