using AutoMapper;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Articles.GetArticleById;

namespace Timor.Cms.Service
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Article, ArticleOutput>();
        }
    }
}
