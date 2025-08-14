using BookStore.DTOs;
using BookStore.DTOs.Tag;
using BookStore.Interface;
using BookStore.Localization.Tag;
using BookStore.Permissions.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BookStore.Web.Pages.Tags
{
    [Authorize(TagPermissions.Tags.View)]
    public class IndexModel : AbpPageModel
    {
        public PagedResultDto<TagDto> TagList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterText { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TagTypeFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        private readonly ITagAppService _tagAppService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<TagResource> L;

        public IndexModel(ITagAppService tagAppService, IAuthorizationService authorizationService, IStringLocalizer<TagResource> localizer)
        {
            _tagAppService = tagAppService;
            _authorizationService = authorizationService;
            L = localizer;
        }


        public List<SelectListItem> TagTypeOptions { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("All", ""),
                new SelectListItem("Type1", "Type1"),
                new SelectListItem("Type2", "Type2")
            };

        public class ModelLocalization
        {
            public string TagList { get; set; } = "TagList";
        }
        public async Task OnGetAsync()
        {
            // Testing localization
            ModelLocalization modelLocalization = new ModelLocalization
            {
                TagList = L["TagList"]
            };

            var input = new TagPagedAndSortedResultRequestDto
            {
                SkipCount = (CurrentPage - 1) * PageSize,
                MaxResultCount = PageSize,
                FilterText = FilterText,
                TagType = TagTypeFilter
            };

            var result = await _tagAppService.GetListAsync(input);

            TagList = result ?? new PagedResultDto<TagDto>(0, Array.Empty<TagDto>());
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _tagAppService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
