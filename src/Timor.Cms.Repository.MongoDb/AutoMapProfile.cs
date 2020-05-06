using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Infrastructure.Extensions;
using Domain = Timor.Cms.Domains;
using Po = Timor.Cms.PersistModels.MongoDb;

namespace Timor.Cms.Repository.MongoDb
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<ObjectId, string>()
                .ConstructUsing(source => source.ToString());

            CreateMap<string, ObjectId>()
                .ConvertUsing((source, id) =>
                {
                    if (ObjectId.TryParse(source,out id))
                    {
                        return id;
                    }
                    return ObjectId.Empty;
                });

            CreateMap<Domain.Articles.Article, Po.Articles.Article>().ReverseMap();
            CreateMap<Domain.Articles.Attachment, Po.Articles.Attachment>().ReverseMap();
            CreateMap<Domain.Articles.Seo, Po.Articles.Seo>().ReverseMap();
            CreateMap<Domain.Articles.Category, Po.Articles.Category>()
                .ForMember(x => x.ParentCategoryId,
                    o => o.MapFrom(s => s.ParentCategory == null ? null : s.ParentCategory.Id.ToString()))
                .ReverseMap();
        }
    }
}