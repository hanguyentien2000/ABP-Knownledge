using BookStore.Entities.Area;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace BookStore.Controllers
{
    [Route("api/area")]
    public class AreaController : AbpController
    {
        private readonly IRepository<Area, Guid> _areaRepository;

        public AreaController(IRepository<Area, Guid> areaRepository)
        {
            _areaRepository = areaRepository;
        }

        [HttpGet]
        public async Task<List<Area>> GetListAsync()
        {
            return await _areaRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Area> GetAsync(Guid id)
        {
            return await _areaRepository.GetAsync(id);
        }

        [HttpPost]
        [UnitOfWork] // Bắt buộc nếu viết CRUD trực tiếp trong controller
        public async Task<Area> CreateAsync(Area book)
        {
            return await _areaRepository.InsertAsync(book);
        }

        [HttpPut("{id}")]
        [UnitOfWork] // Update cũng cần UoW
        public async Task<Area> UpdateAsync(Guid id, Area book)
        {
            var existing = await _areaRepository.GetAsync(id);
            existing.Name = book.Name;
            existing.Population = book.Population;
            return await _areaRepository.UpdateAsync(existing);
        }

        [HttpDelete("{id}")]
        [UnitOfWork] // Delete cũng cần UoW
        public async Task DeleteAsync(Guid id)
        {
            await _areaRepository.DeleteAsync(id);
        }
    }
}
