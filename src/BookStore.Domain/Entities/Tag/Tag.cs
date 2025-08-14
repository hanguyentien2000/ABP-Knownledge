using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Entities.Tag
{
    public class Tag : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string TagType { get; set; } // Thêm thuộc tính TagType

        // ✅ Constructor không tham số cho EF Core
        protected Tag() { } // Cho EF Core

        public Tag(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
