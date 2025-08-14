using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Entities.Book
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public float Price { get; set; }

        // ✅ Constructor không tham số cho EF Core
        protected Book() { }

        public Book(Guid id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
