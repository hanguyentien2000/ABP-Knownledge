using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Entities.Area
{
    public class Area : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public float Population { get; set; }


        // ✅ Constructor không tham số cho EF Core
        protected Area() { }

        public Area(Guid id, string name, float population)
        {
            Id = id;
            Name = name;
            Population = population;
        }
    }
}
