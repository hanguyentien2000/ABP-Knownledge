using BookStore.Entities.Area;
using BookStore.Entities.Book;
using BookStore.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookStore.Service
{
    public class AreaAppService : ApplicationService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaAppService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<List<Area>> GetListAsync()
        {
            return await _areaRepository.GetListAsync();
        }

        public async Task<Area> GetAsync(Guid id)
        {
            return await _areaRepository.GetAsync(id);
        }

        public async Task<Area> CreateAsync(Area area)
        {
            return await _areaRepository.InsertAsync(area);
        }

        public async Task<Area> UpdateAsync(Guid id, Area area)
        {
            var existing = await _areaRepository.GetAsync(id);
            existing.Name = area.Name;
            existing.Population = area.Population;
            return await _areaRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _areaRepository.DeleteAsync(id);
        }
    }
}
