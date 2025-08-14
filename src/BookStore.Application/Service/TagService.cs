using BookStore.DTOs.Tag;
using BookStore.Entities.Tag;
using BookStore.Interface;
using BookStore.Permissions.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Service
{
    [Authorize(TagPermissions.Tags.Default)]
    public class TagAppService : CrudAppService<Tag, TagDto, Guid, TagPagedAndSortedResultRequestDto, CreateUpdateTagDto>, ITagAppService
    {
        private readonly IRepository<Tag, Guid> _tagRepository;
        private readonly ILogger<TagAppService> _logger;
        public TagAppService(IRepository<Tag, Guid> tagRepository, ILogger<TagAppService> logger) : base(tagRepository)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        [Authorize(TagPermissions.Tags.View)]
        public override async Task<PagedResultDto<TagDto>> GetListAsync(TagPagedAndSortedResultRequestDto input)
        {
            var queryable = await _tagRepository.GetQueryableAsync();

            // AsNoTracking + filter
            var query = queryable
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.FilterText),
                    x => x.Name.Contains(input.FilterText))
                .WhereIf(!string.IsNullOrEmpty(input.TagType),
                    x => x.TagType == input.TagType);

            var sortedQuery = query.OrderBy(x => x.CreationTime);

            var totalCount = await AsyncExecuter.CountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                sortedQuery.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<TagDto>(
                totalCount,
                items.Select(MapToGetListOutputDto).ToList()
            );
        }

        [Authorize(TagPermissions.Tags.Create)]
        public override async Task<TagDto> CreateAsync(CreateUpdateTagDto input)
        {
            try
            {
                // Example: Validate unique name
                if (await _tagRepository.AnyAsync(x => x.Name == input.Name))
                {
                    throw new BusinessException("TagAlreadyExists")
                        .WithData("Name", input.Name);
                }

                var tag = ObjectMapper.Map<CreateUpdateTagDto, Tag>(input);
                tag = await _tagRepository.InsertAsync(tag, autoSave: true);
                return ObjectMapper.Map<Tag, TagDto>(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating Tag with Name: {Name}", input.Name);
                throw;
            }
  
        }

        public override async Task<TagDto> UpdateAsync(Guid id, CreateUpdateTagDto input)
        {
            try
            {
                var tag = await _tagRepository.GetAsync(id);

                // Example: Validate unique name except current
                if (await _tagRepository.AnyAsync(x => x.Name == input.Name && x.Id != id))
                {
                    throw new BusinessException("TagAlreadyExists")
                        .WithData("Name", input.Name);
                }

                ObjectMapper.Map(input, tag);
                tag = await _tagRepository.UpdateAsync(tag, autoSave: true);
                return ObjectMapper.Map<Tag, TagDto>(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating Tag with Name: {Name}", input.Name);
                throw;
            }

        }

        public override async Task DeleteAsync(Guid id)
        {
            try
            {
                var tag = await _tagRepository.FindAsync(id);
                if (tag == null)
                {
                    throw new EntityNotFoundException(typeof(Tag), id);
                }

                await _tagRepository.DeleteAsync(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred!", id);
                throw;
            }

        }
    }
}
