using BookStore.Entities.Area;
using BookStore.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Interface
{
    public interface IAreaRepository : IRepository<Area, Guid>
    {

    }
}
