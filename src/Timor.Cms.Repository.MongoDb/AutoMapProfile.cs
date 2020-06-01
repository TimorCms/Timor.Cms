using AutoMapper;
using MongoDB.Bson;
using System.Linq;
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
                    if (ObjectId.TryParse(source, out id))
                    {
                        return id;
                    }

                    return ObjectId.Empty;
                });

            CreateMap<Domain.Articles.Article, Po.Articles.Article>()
                .ForMember(x => x.CategoryIds,
                    o => o.MapFrom(s =>
                        s.Categories == null ? null : s.Categories.Select(x => ObjectId.Parse(x.Id)).ToList()))
                .ForMember(x => x.Attachments, o => o.MapFrom(s => s.Attachments.Select(at => at.Id)))
                .ForMember(x => x.CoverImage, o => o.MapFrom(s => s.CoverImage != null ? s.CoverImage.Id : null))
                .ForMember(d => d.Ads, o => o.MapFrom(s => s.Ads != null ? s.Ads.Select(a => a.Id) : null))
                .ReverseMap()
                .ForMember(x => x.Attachments, o => o.Ignore())
                .ForMember(x => x.CoverImage, o => o.Ignore())
                .ForMember(x => x.Ads, o => o.Ignore());

            CreateMap<Domain.Articles.Attachment, Po.Articles.Attachment>().ReverseMap();
            CreateMap<Domain.Articles.Seo, Po.Articles.Seo>().ReverseMap();
            CreateMap<Domain.Articles.Category, Po.Articles.Category>()
                .ForMember(x => x.ParentCategoryId,
                    o => o.MapFrom(s => s.ParentCategory == null ? null : s.ParentCategory.Id.ToString()))
                .ReverseMap();

            CreateMap<Domain.Users.User, Po.Users.User>().ReverseMap();
        }
    }
}