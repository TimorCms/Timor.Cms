using AutoMapper;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Articles.CreateArticle;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Dto.Categories;

namespace Timor.Cms.Service
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Article, ArticleOutput>();

            CreateMap<CreateArticleInput, Article>()
                .ForMember(d => d.Attachments, o => o.Ignore())
                .ForMember(d => d.CoverImage, o => o.Ignore())
                .ForMember(d => d.Categories, o => o.Ignore())
                .ReverseMap();

            CreateMap<CreateCategoryInput, Category>();
        }
    }
}
