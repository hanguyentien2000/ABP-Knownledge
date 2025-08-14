using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.DTOs.Tag
{
    public class TagDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string TagType { get; set; } // Thêm thuộc tính TagType
    }

    public class CreateUpdateTagDto
    {
        public string Name { get; set; }
        public string TagType { get; set; } // Thêm thuộc tính TagType
    }

    public class TagPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string TagType { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
